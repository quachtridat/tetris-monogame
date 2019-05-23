using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using BlockMatrix = MathNet.Numerics.LinearAlgebra.Matrix<uint>;

using SimpleTetris.Core.Physics.Transform;

namespace SimpleTetris.Core.Shape.Piece {
    abstract class PieceBase {
        public Transform Transform { get; set; } = new Transform();
        //public BlockMatrix Matrix { get; protected set; }
        public List<Block.Block> Blocks { get; protected set; } = new List<Block.Block>();
    }
}
