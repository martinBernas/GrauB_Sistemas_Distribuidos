using Solucao_YARA.Classes.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucao_YARA.Classes
{
    class Modelo11:Etiqueta
    {
        public Modelo11(int q, List<Campo> campos) : base(q, campos)
        {
            Quantidade = q;
            if (campos.Count < 69)
                throw new ExceptionEtiquetaIncompleta();
            Conteudo = campos;

        }
    }
}
