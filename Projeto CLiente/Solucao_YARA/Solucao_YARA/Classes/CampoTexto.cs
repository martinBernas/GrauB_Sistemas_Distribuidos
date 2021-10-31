using Solucao_YARA.Classes.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Solucao_YARA.Classes
{
    class CampoTexto : Campo
    {
        #region Propriedades
        private string fonte;
        private int ajusteLargura;
        private string conteudo;
        #endregion

        #region Construtores
        public CampoTexto()
        {
            Tipo = 'T';
            Direcao = 'N';
            Baseline = "100";
            Position = "100";
            Alinhamento = 'L';
            Altura = "14";
            Fonte = "94021";
            AjusteLargura = 100;
            Conteudo = " ";
        }
        public CampoTexto(string novoNome, string novoConteudo)
        {
            Nome = novoNome;
            Conteudo = novoConteudo;
            Tipo = 'S';
            Direcao = 'S';
            Baseline = "100";
            Position = "100";
            Alinhamento = 'R';
            Altura = "14";
            Fonte = "94021";
            AjusteLargura = 0;


        }
        public CampoTexto(char u, string b, string p, char a, string h, int w, string f, int wa, string text)
        {
            Direcao = u;
            Baseline = b;
            Position = p;
            Alinhamento = a;
            Altura = h;
            Largura = w;
            Fonte = f;
            AjusteLargura = wa;
            Conteudo = text;
        }
        #endregion

        #region Gets/Sets
        public int AjusteLargura
        {
            get => ajusteLargura; set
            {
                ajusteLargura = value;
            }
        }
        public string Fonte { get => fonte; set => fonte = value; }
        public string Conteudo
        {
            get => conteudo; set
            {
                conteudo = value;
                conteudo = conteudo.Insert(0, "\"");
                conteudo = conteudo.Insert(conteudo.Length, "\"");
                string aux_conteudo = conteudo;
                int ind = 0;
                int count = 0;
                foreach (char atual in aux_conteudo)
                {
                    if (atual == '%')
                    {
                        conteudo = conteudo.Insert(ind + count, "%");
                        count++;
                    }
                    ind++;
                }
            }
        }
        #endregion

        #region Metodos
        public override string EnviaCampo()
        {
            return ("#Campo_texto|" + Position + " " + Baseline + " " + Nome + " " + Conteudo + " " + Fonte + " " + Altura + "$");
        }
        public string EnviaVariavel()
        {
            return Conteudo + "\r";
        }
        public void Parametrizar(string parametros)
        {
            parametros = parametros.Remove(0, 13);

            Position = parametros.Remove(parametros.IndexOf(" "));

            parametros = parametros.Remove(0, parametros.IndexOf(" ") + 1);

            Baseline = parametros.Remove(parametros.IndexOf(" "));

            parametros = parametros.Remove(0, parametros.IndexOf(" ") + 1);

            Nome = parametros.Remove(parametros.IndexOf(" "));

            parametros = parametros.Remove(0, parametros.IndexOf(" ") + 1);
            parametros = parametros.Remove(0, parametros.IndexOf(" ") + 1);

            Fonte = parametros.Remove(parametros.IndexOf(" "));

            parametros = parametros.Remove(0, parametros.IndexOf(" ") + 1);

            Altura = parametros.Remove(parametros.IndexOf(" "));

            parametros = parametros.Remove(0, parametros.IndexOf(" ") + 1);
        }
        #endregion
    }
}
