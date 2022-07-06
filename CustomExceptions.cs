using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class ExpiredException : Exception
    {
        public string Message { get; private set; }
        public ExpiredException(string message)
        {
            this.Message = message;
        }
    }
}
