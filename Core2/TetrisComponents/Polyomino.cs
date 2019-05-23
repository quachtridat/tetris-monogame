using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SimpleTetris.Core2.Graphics;
using SimpleTetris.Core2.Physics;
using SimpleTetris.Core2.TetrisComponents.Mechanics;

namespace SimpleTetris.Core2.TetrisComponents {
    /// <summary>
    /// A Tetris piece consisting of <see cref="Mino"/>es.
    /// </summary>
    public class Polyomino : DrawableGameComponent, IFallable, IShiftable, IRotatable {
        public int Rotation { get; protected set; } = 0;

        public Collection<Mino> Minoes { get; protected set; } = new Collection<Mino>();

        public Mino OriginMino { get; set; } = null;

        public Polyomino(Game game) : base(game) { }

        public override void Draw(GameTime gameTime) {
            base.Draw(gameTime);
            foreach (var mino in Minoes) mino.Draw(gameTime);
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            var lastPressedKey = Keyboard.GetState().GetPressedKeys().LastOrDefault();

            ShiftMechanics?.HandleEvent(this, new ShiftEventArgs() {
                GameTime = gameTime,
                Direction = ShiftingDirection.FromKey(lastPressedKey)
            });

            FallMechanics?.HandleEvent(this, new FallEventArgs() {
                GameTime = gameTime
            });

            RotateMechanics?.HandleEvent(this, new RotateEventArgs() {
                GameTime = gameTime,
                Direction = RotatingDirection.FromKey(lastPressedKey)
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
