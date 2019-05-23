using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTetris.Core.Shape.Piece {
    abstract class PieceBuilderBase {
        public uint Width { get; set; }
        public uint Height { get; set; }

        public virtual void SetBlock(Block.Block block) {
            throw new NotImplementedException($"{nameof(PieceBuilderBase)}::{nameof(SetBlock)}: Not-Implemented Exception");
        }

        public virtual Piece Get() {
            throw new NotImplementedException($"{nameof(PieceBuilderBase)}::{nameof(Get)}: Not-Implemented Exception");
        }
    }
}
