using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using MinoBuildDirectorBase = SimpleTetris.Core.Shape.Polyomino.Tetromino.TetrominoBuildDirectorBase;

namespace SimpleTetris.Core.Shape.Polyomino.Tetromino.BuildDirectors {
    class MinoSimpleDirector : MinoBuildDirectorBase {
        public Texture2D Texture { get; set; }

        public MinoSimpleDirector(TetrominoBuilderBase builder) {
            this.builder = builder;
        }

        public override void Direct(Tetrominoes mino) {
            switch (mino) {
                case Tetrominoes.I:
                    builder.Textures[0, 0] = Texture;
                    builder.Textures[0, 1] = Texture;
                    builder.Textures[0, 2] = Texture;
                    builder.Textures[0, 3] = Texture;
                    break;
                case Tetrominoes.O:
                    builder.Textures[0, 0] = Texture;
                    builder.Textures[0, 1] = Texture;
                    builder.Textures[1, 0] = Texture;
                    builder.Textures[1, 1] = Texture;
                    break;
                case Tetrominoes.T:
                    builder.Textures[0, 1] = Texture;
                    builder.Textures[1, 0] = Texture;
                    builder.Textures[1, 1] = Texture;
                    builder.Textures[1, 2] = Texture;
                    break;
                case Tetrominoes.S:
                    builder.Textures[0, 1] = Texture;
                    builder.Textures[0, 2] = Texture;
                    builder.Textures[1, 0] = Texture;
                    builder.Textures[1, 1] = Texture;
                    break;
                case Tetrominoes.Z:
                    builder.Textures[0, 0] = Texture;
                    builder.Textures[0, 1] = Texture;
                    builder.Textures[1, 1] = Texture;
                    builder.Textures[1, 2] = Texture;
                    break;
                case Tetrominoes.J:
                    builder.Textures[0, 0] = Texture;
                    builder.Textures[1, 0] = Texture;
                    builder.Textures[1, 1] = Texture;
                    builder.Textures[1, 2] = Texture;
                    break;
                case Tetrominoes.L:
                    builder.Textures[0, 2] = Texture;
                    builder.Textures[1, 0] = Texture;
                    builder.Textures[1, 1] = Texture;
                    builder.Textures[1, 2] = Texture;
                    break;
            }
        }
    }
}
