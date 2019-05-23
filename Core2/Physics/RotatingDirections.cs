using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace SimpleTetris.Core2.Physics {
    public enum RotatingDirections {
        None,
        Clockwise,
        Counterclockwise
    }

    public class RotatingDirection {
        public static RotatingDirections FromKey(Keys key) {
            switch (key) {
                case Keys.Up:
                    return RotatingDirections.Clockwise;
                default:
                    return RotatingDirections.None;
            }
        }
    }
}
