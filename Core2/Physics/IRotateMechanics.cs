using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTetris.Core2.Physics {
    public interface IRotateMechanics {
        void HandleEvent(IRotatable sender, RotateEventArgs e);
    }
}
