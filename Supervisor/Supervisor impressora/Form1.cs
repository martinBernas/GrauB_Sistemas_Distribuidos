using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace Supervisor_impressora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSolicitarStatus_Click(object sender, EventArgs e)
        {
            try
            {
                ConectaEtiquetadora();
                NetworkStream stm = tcpEtiquetadora.GetStream();
                byte[] ba = Encoding.Default.GetBytes("#Status|10000$");
                stm.Write(ba, 0, ba.Length);
                tcpEtiquetadora.SendTimeout = 100;
                tcpEtiquetadora.ReceiveTimeout = 10000;
                // Reads NetworkStream into a byte buffer.
                byte[] bytes = new byte[tcpEtiquetadora.ReceiveBufferSize];
                                // Read can return anything from 0 to numBytesToRead.
                // This method blocks until at least one byte is read.

                stm.Read(bytes, 0, (int)tcpEtiquetadora.ReceiveBufferSize);
                // Returns the data received from the host to the console.
                stm.Dispose();
                string returndata = Encoding.UTF8.GetString(bytes);
                string[] recebido = returndata.Split('\n');
                DesconectaEtiquetadora();

                foreach(string linha in recebido)
                {
                    lstLog.Items.Add(linha);
                }
                
            }
            catch (Exception ex)
            {
                DesconectaEtiquetadora();
            }
        }

        void ConectaEtiquetadora()
        {
            try
            {
                string ip = TransformaEmIPString(Convert.ToInt32(txbIP4.Text), Convert.ToInt32(txbIP3.Text), Convert.ToInt32(txbIP2.Text), Convert.ToInt32(txbIP1.Text));
                tcpEtiquetadora = new TcpClient();
                //Timer limiteConexao = new Timer();
                //limiteConexao.Interval = 5000;
                //limiteConexao.Tick += new System.EventHandler(limiteConexao_Tick);
                //limiteConexao.Start();
                tcpEtiquetadora.Connect(IPAddress.Parse(ip), Convert.ToInt32(txbPorta.Text));

                while (!tcpEtiquetadora.Connected) { }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar com a etiquetadora:\n" + ex.Message);
            }
        }
        void DesconectaEtiquetadora()
        {
            tcpEtiquetadora.Dispose();
            tcpEtiquetadora.Close();
            tcpEtiquetadora = null;
            
        }
        string TransformaEmIPString(int IP4, int IP3, int IP2, int IP1)
        {
            try
            {
                string retorno = string.Empty;
                retorno = Convert.ToString(IP4) + "." + Convert.ToString(IP3) + "." + Convert.ToString(IP2) + "." + Convert.ToString(IP1);
                return retorno;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnTrigger_Click(object sender, EventArgs e)
        {
            try
            {
                ConectaEtiquetadora();
                NetworkStream stm = tcpEtiquetadora.GetStream();
                byte[] ba = Encoding.Default.GetBytes("#Trigger|0$");
                stm.Write(ba, 0, ba.Length);
                tcpEtiquetadora.ReceiveTimeout = 10000;
                // Reads NetworkStream into a byte buffer.
                byte[] bytes = new byte[tcpEtiquetadora.ReceiveBufferSize];
    
                // Read can return anything from 0 to numBytesToRead.
                // This method blocks until at least one byte is read.
                
                stm.Read(bytes, 0, (int)tcpEtiquetadora.ReceiveBufferSize);
            
                // Returns the data received from the host to the console.
                string returndata = Encoding.UTF8.GetString(bytes);
                DesconectaEtiquetadora();
                lstLog.Items.Add(returndata);
            }
            catch (Exception ex)
            {
                DesconectaEtiquetadora();
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lstLog.Items.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEnviarCampo_Click(object sender, EventArgs e)
        {
            try
            {
                ConectaEtiquetadora();
                NetworkStream stm = tcpEtiquetadora.GetStream();
                byte[] ba = Encoding.Default.GetBytes("#Campo_texto|"+txbNomeCampo.Text+"|"+txbConteudoCampo.Text+"$");
                stm.Write(ba, 0, ba.Length);
                tcpEtiquetadora.ReceiveTimeout = 10000;
                // Reads NetworkStream into a byte buffer.
                byte[] bytes = new byte[tcpEtiquetadora.ReceiveBufferSize];

                // Read can return anything from 0 to numBytesToRead.
                // This method blocks until at least one byte is read.

                stm.Read(bytes, 0, (int)tcpEtiquetadora.ReceiveBufferSize);

                // Returns the data received from the host to the console.
                string returndata = Encoding.UTF8.GetString(bytes);
                DesconectaEtiquetadora();
                lstLog.Items.Add(returndata);
            }
            catch (Exception ex)
            {
                DesconectaEtiquetadora();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ConectaEtiquetadora();
                NetworkStream stm = tcpEtiquetadora.GetStream();
                byte[] ba = Encoding.Default.GetBytes("#Imprimir|" + txbQuantidade.Text + "$");
                stm.Write(ba, 0, ba.Length);
                tcpEtiquetadora.ReceiveTimeout = 10000;
                // Reads NetworkStream into a byte buffer.
                byte[] bytes = new byte[tcpEtiquetadora.ReceiveBufferSize];

                // Read can return anything from 0 to numBytesToRead.
                // This method blocks until at least one byte is read.

                stm.Read(bytes, 0, (int)tcpEtiquetadora.ReceiveBufferSize);

                // Returns the data received from the host to the console.
                string returndata = Encoding.UTF8.GetString(bytes);
                DesconectaEtiquetadora();
                lstLog.Items.Add(returndata);
            }
            catch (Exception ex)
            {
                DesconectaEtiquetadora();
            }
        }

        private void btnAtualizarCampo_Click(object sender, EventArgs e)
        {
            try
            {
                ConectaEtiquetadora();
                NetworkStream stm = tcpEtiquetadora.GetStream();
                byte[] ba = Encoding.Default.GetBytes("#Update|" + txbNomeCampo.Text + "|" + txbConteudoCampo.Text + "$");
                stm.Write(ba, 0, ba.Length);
                tcpEtiquetadora.ReceiveTimeout = 10000;
                // Reads NetworkStream into a byte buffer.
                byte[] bytes = new byte[tcpEtiquetadora.ReceiveBufferSize];

                // Read can return anything from 0 to numBytesToRead.
                // This method blocks until at least one byte is read.

                stm.Read(bytes, 0, (int)tcpEtiquetadora.ReceiveBufferSize);

                // Returns the data received from the host to the console.
                string returndata = Encoding.UTF8.GetString(bytes);
                DesconectaEtiquetadora();
                lstLog.Items.Add(returndata);
            }
            catch (Exception ex)
            {
                DesconectaEtiquetadora();
            }
        }

        private void btnAbortarImpressoes_Click(object sender, EventArgs e)
        {
            try
            {
                ConectaEtiquetadora();
                NetworkStream stm = tcpEtiquetadora.GetStream();
                byte[] ba = Encoding.Default.GetBytes("#Abortar|0$");
                stm.Write(ba, 0, ba.Length);
                tcpEtiquetadora.ReceiveTimeout = 10000;
                // Reads NetworkStream into a byte buffer.
                byte[] bytes = new byte[tcpEtiquetadora.ReceiveBufferSize];

                // Read can return anything from 0 to numBytesToRead.
                // This method blocks until at least one byte is read.

                stm.Read(bytes, 0, (int)tcpEtiquetadora.ReceiveBufferSize);

                // Returns the data received from the host to the console.
                string returndata = Encoding.UTF8.GetString(bytes);
                DesconectaEtiquetadora();
                lstLog.Items.Add(returndata);
            }
            catch (Exception ex)
            {
                DesconectaEtiquetadora();
            }


        }
    }
}
