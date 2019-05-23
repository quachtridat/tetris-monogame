using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTetris.Core.Shape.Block;
using SimpleTetris.Core.Exception;

namespace SimpleTetris.Core.Shape.Piece {
    class PieceBuilder : PieceBuilderBase {
        public override void SetBlock(Block.Block block) {
            if (Width <= block.Transform.Position.X)
                throw new OutOfBoundsException($"{nameof(PieceBuilder)}::{nameof(SetBlock)}: ${nameof(block.Transform.Position.X)} Out-Of-Bounds Exception");
            if (Height <= block.Transform.Position.Y)
                throw new OutOfBoundsException($"{nameof(PieceBuilder)}::{nameof(SetBlock)}: ${nameof(block.Transform.Position.Y)} Out-Of-Bounds Exception");
            
        }

        public override Piece Get() {
            return base.Get();
        }
    }
}
