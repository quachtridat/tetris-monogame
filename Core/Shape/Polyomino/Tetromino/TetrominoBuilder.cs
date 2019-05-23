using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SimpleTetris.Core.Physics.Transform;
using Layers = SimpleTetris.Core.Playfield.Layers;

namespace SimpleTetris.Core.Shape.Polyomino.Tetromino {
    class TetrominoBuilder : TetrominoBuilderBase {
        public override Tetromino Build() {
            Tetromino mino = new Tetromino();
            for (uint y = 0; y < 4; ++y)
                for (uint x = 0; x < 4; ++x)
                    if (Textures[y, x] != null)
                        mino.Blocks.Add(new Block.Block {
                            Transform = new Transform {
                                Position = new Vector3 {
                                    X = x,
                                    Y = y,
                                    Z = Layers.PieceLayer
                                }
                            },
                            Size = new Vector3(1, 1, 1),
                            Texture = Textures[y, x]
                        });
            return mino;
        }
    }
}
