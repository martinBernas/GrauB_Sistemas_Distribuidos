using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucao_YARA.Classes.Exceptions
{
    class ExceptionEtiquetaIncompleta:Exception
    {
        public ExceptionEtiquetaIncompleta()
        {
        }

        public ExceptionEtiquetaIncompleta(string message)
            : base(message)
        {
        }

        public ExceptionEtiquetaIncompleta(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
