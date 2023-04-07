using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyCodeFromTheDirectory {
  internal class NotAnEmptyFileException : ArgumentException {
    public NotAnEmptyFileException(string message) : base(message) { }
  }
}
