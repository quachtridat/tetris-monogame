using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SimpleTetris.Core2.Graphics;
using SimpleTetris.Core2.Physics;
using SimpleTetris.Core2.TetrisComponents.Mechanics;

namespace SimpleTetris.Core2.TetrisComponents {
    /// <summary>
    /// A unit block of a Tetris piece.
    /// </summary>
    public class Mino : Sprite, IFallable, IShiftable, IRotatable {
        public Mino(Game game) : base(game) {
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            ShiftMechanics?.HandleEvent(this, new ShiftEventArgs() {
                GameTime = gameTime,
                Direction = ShiftingDirection.FromKey(Keyboard.GetState().GetPressedKeys().LastOrDefault())
            });

            FallMechanics?.HandleEvent(this, new FallEventArgs() {
                GameTime = gameTime
            });
        }

        #region Physics: Falling

        public IFallMechanics FallMechanics { get; set; }

        #endregion

        #region Physics: Shifting

        public IShiftMechanics ShiftMechanics { get; set; }

        #endregion

        #region Physics: Rotating

        public IRotateMechanics RotateMechanics { get; set; }

        #endregion
    }
}
