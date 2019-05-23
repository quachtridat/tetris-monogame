using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTetris.Core.Shape.Polyomino.Tetromino {
    class TetrominoCollection : TetrominoCollectionBase {
        public override Tetromino Get(Tetrominoes mino) {
            return Minoes[(int)mino];
        }
    }
}
