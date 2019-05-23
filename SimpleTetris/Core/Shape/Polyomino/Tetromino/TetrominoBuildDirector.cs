using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTetris.Core.Shape.Polyomino.Tetromino {
    class TetrominoBuildDirector : TetrominoBuildDirectorBase {
        public TetrominoBuildDirector(TetrominoBuilderBase builder) {
            this.builder = builder;
        }
        public override void Direct(Tetrominoes mino) {
            base.Direct(mino);
        }
    }
}
