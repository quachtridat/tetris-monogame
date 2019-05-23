using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTetris.Core.Shape.Polyomino.Tetromino {
    abstract class TetrominoCollectionBase {
        public List<Tetromino> Minoes { get; protected set; }

        public virtual Tetromino Get(Tetrominoes mino) {
            throw new NotImplementedException($"{nameof(TetrominoCollectionBase)}::{nameof(Get)}: Not-Implemented Exception");
        }
    }
}
