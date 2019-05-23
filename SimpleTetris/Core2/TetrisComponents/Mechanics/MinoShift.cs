using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SimpleTetris.Core2.Physics;

namespace SimpleTetris.Core2.TetrisComponents.Mechanics {
    public class MinoShift : IShiftMechanics {

        public TimeSpan Counter { get; set; } = TimeSpan.Zero;

        public TimeSpan HoldThreshold { get; set; } = TimeSpan.FromSeconds(0.5);

        protected ShiftingDirections LastDirection { get; set; } = ShiftingDirections.None;

        public bool DirectionChanged { get; protected set; } = false;

        public void HandleEvent(object sender, ShiftEventArgs e) {
            if (sender is IShiftable) HandleEvent(sender as IShiftable, e);
        }

        public void HandleEvent(IShiftable sender, ShiftEventArgs e) {
            if (sender == null || e == null) return;

            if (e.Direction != LastDirection) {
                Counter = TimeSpan.Zero;
                LastDirection = e.Direction;
                DirectionChanged = true;
            } else DirectionChanged = false;

            if (sender is Mino) {
                Mino mino = sender as Mino;

                Counter += mino.Game.TargetElapsedTime;
                bool isHolding = !(Counter < HoldThreshold);

                if (DirectionChanged || !DirectionChanged && isHolding) mino.Position = Adjust(mino.Position, e.Direction);
            }

            if (sender is Polyomino) {
                Polyomino polyomino = sender as Polyomino;

                Counter += polyomino.Game.TargetElapsedTime;
                bool isHolding = !(Counter < HoldThreshold);

                if (DirectionChanged || !DirectionChanged && isHolding)
                    foreach (Mino mino in polyomino.Minoes)
                        mino.Position = Adjust(mino.Position, e.Direction);
            }
        }

        /// <summary>
        /// Adjust the position <paramref name="pos"/> in accordance with the direction <paramref name="dir"/>.
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static Vector2 Adjust(Vector2 pos, ShiftingDirections dir) {
            switch (dir) {
                case ShiftingDirections.Down:
                    pos += new Vector2(0, +1);
                    return pos;
                case ShiftingDirections.Left:
                    pos += new Vector2(-1, 0);
                    return pos;
                case ShiftingDirections.Right:
                    pos += new Vector2(+1, 0);
                    return pos;
                default:
                    return pos;
            }
        }
    }
}
