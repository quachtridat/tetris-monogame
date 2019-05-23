using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTetris.Core.Exception {
    class OutOfBoundsException : System.Exception {
        public OutOfBoundsException() : base() { }
        public OutOfBoundsException(string message) : base(message) { }
    }
}
