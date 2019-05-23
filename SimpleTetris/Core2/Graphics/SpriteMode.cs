using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SimpleTetris.Core2.Graphics {
    /// <summary>
    /// Whether a sprite takes an entire area or a portion of a <see cref="Texture2D"/> to be its texture.
    /// </summary>
    public enum SpriteModes {
        Single,
        Multiple
    }
}
