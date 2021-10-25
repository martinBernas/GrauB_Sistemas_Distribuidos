using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucao_YARA.Classes.Exceptions
{
    class ExceptionComandoInvalido:Exception
    {
        public ExceptionComandoInvalido()
        {
        }

        public ExceptionComandoInvalido(string message)
            : base(message)
        {
        }

        public ExceptionComandoInvalido(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
