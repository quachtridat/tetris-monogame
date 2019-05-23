using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SimpleTetris.Core2.Delegates;

namespace SimpleTetris.Core2.Graphics {
    /// <summary>
    /// An entire or a portion of a <see cref="Texture2D"/> that has position.
    /// </summary>
    public class Sprite : DrawableGameComponent {

        public Vector2 Position { get; set; } = Vector2.Zero;
        public float RotationAngle { get; set; } = 0f;
        public float Scale { get; set; } = 1f;

        public SpriteModes SpriteMode { get; set; } = SpriteModes.Single;
        public Texture2D SamplingTexture { get; set; } = null;
        public Rectangle TexturePortion { get; set; } = Rectangle.Empty;

        public Action<object[]> Painter { get; set; } = null;

        public Sprite(Game game) : base(game) {
            SpriteMode = SpriteModes.Single;
        }

        public override void Draw(GameTime gameTime) {
            base.Draw(gameTime);

            Painter?.Invoke(new[] { this });
        }
    }
}
