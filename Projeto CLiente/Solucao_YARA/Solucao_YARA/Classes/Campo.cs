using Solucao_YARA.Classes.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucao_YARA.Classes
{
    class Campo
    {
        #region Propriedades
        private string nome;
        private char tipo;
        private char direcao;
        private string baseline;
        private string position;
        private char alinhamento;
        private string altura;
        private int largura;
        #endregion

        #region Gets/Sets
        public int Largura
        {
            get { return largura; }
            set { largura = value; }
        }
        public string Altura { get => altura; set => altura = value; }
        public char Alinhamento
        {
            get => alinhamento; set
            {
                if (value != 'L' && value != 'C' && value != 'R')
                {
                    throw new ExceptionComandoInvalido();
                }
                else
                    alinhamento = value;
            }
        }
        public string Position { get => position; set => position = value; }
        public string Baseline { get => baseline; set => baseline = value; }
        public char Direcao
        {
            get => direcao; set
            {
                if (value != 'N' && value != 'E' && value != 'S' && value != 'W')
                {
                    throw new ExceptionComandoInvalido();
                }
                else
                    direcao = value;
            }
        }
        public char Tipo
        {
            get => tipo; set
            {
                if (value != 'T' && value != 'S' && value != 'B' && value != 'C' && value != 'G')
                {
                    throw new ExceptionComandoInvalido();
                }
                else
                    tipo = value;
            }
        }
        public string Nome { get => nome; set => nome = value; }
        #endregion

        #region Metodos
        public virtual string EnviaCampo()
        {
            return ("!F " + Tipo + " " + Direcao + " " + Baseline + " " + Position + " " + Alinhamento + " " + Altura + " " + Largura + " " + "\r");
        }
        #endregion
    }
}
