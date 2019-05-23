using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SimpleTetris.Core.Physics.Transform;

namespace SimpleTetris.Core.Shape.Block {
    abstract class BlockBase {
        public Transform Transform { get; set; }
        public Texture2D Texture { get; set; }
        public Vector3 Size { get; set; }
    }
}
