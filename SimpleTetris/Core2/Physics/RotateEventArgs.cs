﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SimpleTetris.Core2.Physics {
    public class RotateEventArgs : EventArgs {
        public GameTime GameTime;
        public RotatingDirections Direction;
    }
}
