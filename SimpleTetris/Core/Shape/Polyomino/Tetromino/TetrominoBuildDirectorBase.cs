using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTetris.Core.Shape.Polyomino.Tetromino {
    abstract class TetrominoBuildDirectorBase {
        protected TetrominoBuilderBase builder;

        public virtual void Direct(Tetrominoes mino) {
            throw new NotImplementedException($"{nameof(TetrominoBuildDirectorBase)}::{nameof(Direct)}: Not-Implemented Exception");
        }
    }
}
