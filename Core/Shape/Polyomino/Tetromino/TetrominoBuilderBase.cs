using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace SimpleTetris.Core.Shape.Polyomino.Tetromino {
    abstract class TetrominoBuilderBase {
        public Texture2D[,] Textures { get; protected set; } = new Texture2D[4, 4];

        public virtual Tetromino Build() {
            throw new NotImplementedException($"{nameof(TetrominoBuilderBase)}::{nameof(Build)}: Not-Implemented Exception");
        }
    }
}
