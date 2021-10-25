using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucao_YARA.Classes
{
    class CampoLogo:Campo
    {
        #region Construtores
        public CampoLogo()
        {

        }
        public CampoLogo(string novoNome, string novoConteudo)
        {
            Nome = novoNome;
            Conteudo = novoConteudo;

        }
        #endregion

        #region Propriedades
        private string conteudo;
        #endregion

        #region Gets/Sets
        public string Conteudo
        {
            get => conteudo; set
            {
                conteudo = value;
                conteudo = conteudo.Insert(0, "\"");
                if (conteudo.Contains(".bmp"))
                {
                    conteudo = conteudo.Remove(conteudo.IndexOf("."), 4);
                }
                conteudo = conteudo.Insert(conteudo.Length, "_S\"");
            }
        }
        #endregion

        #region Metodos
        public void Parametrizar(string parametros)
        {
            parametros = parametros.Remove(0, 3);

            Tipo = parametros[0];
            parametros = parametros.Remove(0, 2);

            Direcao = parametros[0];
            parametros = parametros.Remove(0, 2);

            string inteiro = parametros.Remove(parametros.IndexOf(" "));
            Baseline = inteiro;
            parametros = parametros.Remove(0, parametros.IndexOf(" ") + 1);

            inteiro = parametros.Remove(parametros.IndexOf(" "));
            Position = inteiro;
            parametros = parametros.Remove(0, parametros.IndexOf(" ") + 1);

            Alinhamento = parametros[0];
            parametros = parametros.Remove(0, 2);

            inteiro = parametros.Remove(parametros.IndexOf(" "));
            Altura = inteiro;
            parametros = parametros.Remove(0, parametros.IndexOf(" ") + 1);

            inteiro = parametros.Remove(parametros.IndexOf(" "));
            Largura = Convert.ToInt32(inteiro);
            parametros = parametros.Remove(0, parametros.IndexOf(" ") + 1);
        }
        public override string EnviaCampo()
        {
            return ("!F " + Tipo + " " + Direcao + " " + Convert.ToString(Baseline) + " " + Convert.ToString(Position) + " " + Alinhamento + " " + Convert.ToString(Altura) + " " +
                Convert.ToString(Largura) + " " + Conteudo + "\r");
        } 
        #endregion
    }
}
