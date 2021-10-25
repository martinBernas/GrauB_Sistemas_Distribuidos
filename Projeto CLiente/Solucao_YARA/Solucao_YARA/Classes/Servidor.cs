using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Net;
using System.IO;

namespace Solucao_YARA.Classes
{
    class Servidor
    {
        #region Construtores
        public Servidor()
        {
            temporizador = new Timer(5000);
            temporizador.Elapsed += new ElapsedEventHandler(EstouroTemporizador);

        }
        public Servidor (IPAddress ip, int porta, string endSaida)
        {
            temporizador = new Timer(500);
            temporizador.Elapsed += new ElapsedEventHandler(EstouroTemporizador);
            IP = ip;
            Porta = porta;

            Saida = endSaida;
            
            ler = false;
            status = false;
            recebido = string.Empty;
        }
        #endregion

        #region Funçoes
        public void Ouvir()
        {
            
                Task.Run(() => OuvirConexao());
                
               
        }
        private void OuvirConexao()
        {
            try
            {
            //  IPAddress ipAd = IPAddress.Parse(txbIP.Text);
            //  TCPServer = new TcpListener(ipAd, Convert.ToInt32(txbPorta.Text));
                TCPServer = new TcpListener(IP, Porta);
                TCPServer.Start();
                socket = TCPServer.AcceptSocket();
                int buffer = 500000;
                while (socket.Connected)
                {
                    byte[] b = new byte[buffer];
                    int i = socket.Receive(b);
                    if (i > buffer)
                    {
                        throw new Exception();
                    }
                    
                    if (b[0] == '\0')
                    {
                        // ler = false;
                        socket.Close();
                        socket = TCPServer.AcceptSocket();
                        temporizador.Enabled = true;
                        temporizador.Start();
                    }
                    else
                    {
                    recebido += Encoding.UTF7.GetString(b);
                    ler = true;
                        temporizador.Start();
                    }

                    
                }
                socket.Close();
                TCPServer.Stop();

            }
            catch (SocketException ex)
            {
               //CATCH MUDO PARA QUANDO É INTERROMPIDA A CONEXÃO E ESTA SE AGUARDANDO CONEXÃO;     

           }


        }
        private void EstouroTemporizador(object sender, ElapsedEventArgs s)
        {
            temporizador.Stop();
            if (ler)
            {
                
                List<string> listarecebida = new List<string>();
                string[] recebidos = recebido.Split('\n');
                recebido = string.Empty;
                bool truncada = false;
                bool truncadaEspecial = false;
                foreach (string atual in recebidos)
                {

                    string aux = atual.Trim();
                    if (aux.Contains("<") || aux.Contains(">") )
                    {


                        if (truncada)
                        {
                            listarecebida[listarecebida.Count - 1] = listarecebida[listarecebida.Count - 1].Insert(listarecebida[listarecebida.Count - 1].Length, " " + aux);
                            truncada = false;
                        }
                        if (truncadaEspecial)
                        {
                            listarecebida[listarecebida.Count - 1] = listarecebida[listarecebida.Count - 1].Insert(listarecebida[listarecebida.Count - 1].Length, aux);
                            truncadaEspecial = false;
                        }
                        if (aux.StartsWith("<"))
                        {

                            listarecebida.Add(aux);
                            if (!aux.EndsWith(">"))
                            {
                                truncada = true;
                                if (aux.Contains("</") || aux.EndsWith("<"))
                                {
                                    truncadaEspecial = true;
                                    truncada = false;
                                }
                            }
                        }
                    }


                }

                StreamWriter escrita = new StreamWriter(saida);
                foreach (string atual in listarecebida)
                {
                    escrita.WriteLine(atual);
                }
                escrita.Close();

                ler = false;
            }
            temporizador.Start();
        }
        public void Stop()
        {
            if (socket != null)
            {
                //socket.Disconnect(false);
                socket.Close();
                
            }
            TCPServer.Stop();
            TCPServer = null;
            temporizador.Stop();
            recebido = string.Empty;
            status = false;
            ler = false;
            
            

        }
        #endregion
        #region Propiedades
        private TcpListener TCPServer;
        private Socket socket;
        private string recebido;
        private bool status;
        private bool ler;
        private Timer temporizador;
        private string saida;
        private IPAddress IP;
        private int Porta;
        #endregion
        #region Gets/Sets
        public TcpListener TCPServer1 { get => TCPServer; set => TCPServer = value; }
        public Socket Socket { get => socket; set => socket = value; }
        public string Recebido { get => recebido; set => recebido = value; }
        public bool Status { get => status; set => status = value; }
        public bool Ler { get => ler; set => ler = value; }
        public Timer Temporizador { get => temporizador; set => temporizador = value; }
        public string Saida { get => saida; set => saida = value; }
        #endregion
    }
}
