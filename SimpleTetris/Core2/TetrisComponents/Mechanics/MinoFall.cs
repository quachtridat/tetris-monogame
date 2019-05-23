using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SimpleTetris.Core2.Physics;

namespace SimpleTetris.Core2.TetrisComponents.Mechanics {
    public class MinoFall : IFallMechanics {

        public TimeSpan Counter { get; set; } = TimeSpan.Zero;

        /// <summary>
        /// The number of unit blocks per FallTimeSpan that the <see cref="Mino"/> falls.
        /// </summary>
        public float FallVelocity { get; set; } = 1.0f;

        /// <summary>
        /// The amount of time per fall.
        /// </summary>
        public TimeSpan FallTimeSpan { get; set; } = TimeSpan.FromSeconds(1);

        public void HandleEvent(object sender, FallEventArgs e) {
            if (sender is IFallable) HandleEvent(sender as IFallable, e);
        }

        public void HandleEvent(IFallable sender, FallEventArgs e) {
            if (sender == null || e == null) return;

            if (sender is Mino) {
                Mino mino = sender as Mino;
                Counter += mino.Game.TargetElapsedTime;
                if (Counter >= FallTimeSpan) {
                    mino.Position += new Vector2(0, FallVelocity);
                    Counter -= FallTimeSpan;
                }
            }

            if (sender is Polyomino) {
                Polyomino polyomino = sender as Polyomino;
                Counter += polyomino.Game.TargetElapsedTime;
                if (Counter >= FallTimeSpan) {
                    foreach (Mino mino in polyomino.Minoes) mino.Position += new Vector2(0, FallVelocity);
                    Counter -= FallTimeSpan;
                }
            }
        }
    }
}
