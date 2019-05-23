using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SimpleTetris.Core.Physics.Transform {
    abstract class TransformBase {
        public Vector3 Position;
        public Quaternion Rotation;
    }
}
