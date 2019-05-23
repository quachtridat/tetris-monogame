using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace SimpleTetris.Core2.Physics {
    public enum ShiftingDirections {
        None,
        Up,
        Down,
        Left,
        Right
    }
    public class ShiftingDirection {
        public static ShiftingDirections FromKey(Keys key) {
            switch (key) {
                case Keys.Up:
                    return ShiftingDirections.Up;
                case Keys.Down:
                    return ShiftingDirections.Down;
                case Keys.Left:
                    return ShiftingDirections.Left;
                case Keys.Right:
                    return ShiftingDirections.Right;
                default:
                    return ShiftingDirections.None;
            }
        }
    }
}
