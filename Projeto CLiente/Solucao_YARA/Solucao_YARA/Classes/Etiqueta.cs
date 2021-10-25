using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Solucao_YARA.Classes
{
    class Etiqueta
    {
        #region Construtores
        public Etiqueta(int q, List<Campo> campos)
        {
            Quantidade = q;
            Conteudo = campos;
        }
        public Etiqueta(XmlTextReader XML, string end)
        {
            EndOrigem = end;
            Conteudo = new List<Campo>();
            string nome = "##SemNome##";
            string nrlote = "##########";
            string codmaterial = "XXXXXXXXX";

            while (XML.Read())
            {
               
                switch (XML.NodeType)
                {
                    case (XmlNodeType.Element):
                        nome = XML.Name;
                        break;
                    case (XmlNodeType.Text):
                        if (nome.Contains("QuantidadeEtiquetas"))
                        {
                            Quantidade = Convert.ToInt32(XML.Value);
                            nome = "##SemNome##";
                        }else if (nome == "LoteInterno")
                        {
                          nrlote = XML.Value;
                        }
                        else if (nome == "Codigo_Material")
                        {
                           codmaterial = XML.Value;
                        }
                        else if (nome == "Modelo")
                        {
                          Modelo = XML.Value;
                        }
                        else
                        {
                            Conteudo.Add(new CampoTexto(nome, XML.Value));
                        }
                        break;
                    case (XmlNodeType.EndElement):
                        nome = "##SemNome##";
                        break;
                }
            }
            Rotulo = "Cod.: " + codmaterial + " Lote: " + nrlote + " Quant.: " + Quantidade;
            
            
        }
        #endregion

        #region Propriedades
        private List<Campo> conteudo;
        private string modelo;
        private List<string> cabecalho;
        private List<string> rodape;
        private int quantidade;
        private string rotulo;
        private string endOrigem;
        #endregion

        #region Gets/Sets
        public int Quantidade { get => quantidade;
            set {
                quantidade = value;
                rodape = new List<string>();
                rodape.Add("#Imprimir " + Quantidade + " #\r");
            }
        }
        public List<Campo> Conteudo { get => conteudo; set => conteudo = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public List<string> Cabecalho { get => cabecalho; set => cabecalho = value; }
        public List<string> Rodape { get => rodape; set => rodape = value; }
        public string Rotulo { get => rotulo; set => rotulo = value; }
        public string EndOrigem { get => endOrigem; set => endOrigem = value; }
        #endregion

        #region Metodos
        public List<string> EnviaEtiqueta()
        {
            CampoTexto auxt = new CampoTexto();
            CampoLogo auxl = new CampoLogo();
            List<string> saida = new List<string>();
            foreach(string atual in Cabecalho)
            {
                saida.Add(atual);
            }
            foreach(Campo atual in Conteudo)
            {
                if(atual.GetType()==auxt.GetType())
                    saida.Add(((CampoTexto)atual).EnviaCampo());
                if (atual.GetType() == auxl.GetType())
                    saida.Add(((CampoLogo)atual).EnviaCampo());
            }
            foreach(string atual in rodape)
            {
                saida.Add(atual);
            }


            return saida;
        }
        public List<string> EnviaComoVariaveis()
        {
            List<string> saida = new List<string>();
            saida.Add("!C\r!R\r");
            //"!C\r!R\r";
            foreach (CampoTexto atual in conteudo)
            {
                saida.Add(atual.EnviaVariavel());
            }
            saida.Add("!P" + Quantidade + "\r");


            return saida;
        }
        public void VerificaEstrutura()
        {
            //List<Campo> conteudoAuxiliar=new List<Campo>();
            //foreach (Campo atual in conteudo)
            //{
            //    if (atual.Alinhamento == 'R'&& atual.Tipo!='G')
            //    {
                    
            //        System.Windows.Forms.MessageBox.Show("O campo " + atual.Nome + " não possui configuração no Layout "+ modelo );

            //    }else
            //    {
            //        conteudoAuxiliar.Add(atual);
            //    }
            //    conteudo = conteudoAuxiliar;
            //}
        }
        public void Estruturar(StreamReader modelo)
        {
            cabecalho = new List<string>();
            

            while (!modelo.EndOfStream)
            {
                string atual = modelo.ReadLine();
                if (atual.StartsWith("#Dimensionamento") )
                {
                    cabecalho.Add(atual+"\r");
                }
                  
                if (atual.StartsWith("#Campo_texto"))
                {

                    for(int i=0;i<conteudo.Count;i++)
                    {
                        if (conteudo[i].Nome == FiltraNome(atual))
                        {
                            CampoTexto aux = new CampoTexto();
                            CampoLogo auxl = new CampoLogo();
                            if (conteudo[i].GetType()== aux.GetType())
                            {
                                ((CampoTexto)(conteudo[i])).Parametrizar(atual);
                            }
                            if (conteudo[i].GetType() == auxl.GetType())
                            {
                                ((CampoLogo)(conteudo[i])).Parametrizar(atual);
                            }
                            
                        }
                    }
                    
                }
            }
            rodape = new List<string>();
            rodape.Add("#Imprimir " + Quantidade+" #\r");

        }
        private string FiltraNome(string str)
        {
            string resultado = string.Empty;
            string aux = string.Empty;
            aux = str.Remove(0, 13);
            aux = aux.Remove(0,aux.IndexOf(" ")+1);
            aux = aux.Remove(0,aux.IndexOf(" ")+1);
            resultado = aux.Remove(aux.IndexOf(" "));
            
            return resultado;
        }
        
        #endregion
    }
}
