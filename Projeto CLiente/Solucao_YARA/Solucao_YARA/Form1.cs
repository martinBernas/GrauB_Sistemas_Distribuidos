using Solucao_YARA.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Net.Sockets;
using System.Net;


namespace Solucao_YARA
{
    public partial class Form1 : Form
    {
        #region Variaveis globais
        SerialPort spoEtiquetadora;
        List<Etiqueta> etiquetasLista=new List<Etiqueta>();
        List<Etiqueta> etiquetasListaRenvio = new List<Etiqueta>();
        Etiqueta etiquetaLida=null;
        TcpClient tcpCEtiquetadora;
      
        Servidor Server;
   
        string recebido = string.Empty;
   
        string licenca;
        string cryptoKey;
        List<string> logerros=new List<string>();
        bool falha = false;
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        #region Eventos
        private void btnLer_XML_Click(object sender, EventArgs e)
        {
            Ler_XML();
            EnviaEtiqueta(etiquetaLida);
            etiquetaLida = null;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Inicializa();
            //if (!VerificaLicenca(DateTime.Now, licenca))
            //{
            //    MessageBox.Show("Licença expirou, favor contate a Soma Sul");
            //    logerros.Add("Erro ao verificar liscença:\t" + DateTime.Now.ToString("dd_MM_yy_hh:mm"));
            //    GeraLogErro();
            //    Application.Exit();
                
            //}
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            GeraLogErro();
        }
        private void btnSalvaConfig_Click(object sender, EventArgs e)
        {
            SalvaConfiguracao();
        }
        private void rbtTipoConexao_CheckedChanged(object sender, EventArgs e)
        {
            SelecionaConexao();
        }
        //private void btnOuvirPorta_Click(object sender, EventArgs e)
        //{
        //    OuvirPorta();
        //}
        private void timClock_Tick(object sender, EventArgs e)
        {
            timClock.Stop();
            Verificaleitura();
            timClock.Start();

        }
        void limiteConexao_Tick(object sender, EventArgs e)
        {
            falha = true;
        }
        private void btnAtualizaDisponiveis_Click(object sender, EventArgs e)
        {
            lstDisponiveis.Items.Clear();
            VerificarPasta();
        }
        private void lstDisponiveis_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEnviar.Enabled = true;
        }
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            EnvioUnitario("Principal");
        }
        private void timAutoRefresh_Tick(object sender, EventArgs e)
        {
            AutoRefreshTick();

        }
        private void btnRefreshAuto_Click(object sender, EventArgs e)
        {
            RefreshAuto();
        }
        private void lstReenvio_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelecionaListaRenvio();
            
        }
        private void btnReenviar_Click(object sender, EventArgs e)
        {
            EnvioUnitario("Reenvio");
        }
        private void btnLimpaHistorico_Click(object sender, EventArgs e)
        {
            LimpaHistorico();
        }
        private void btnAtualizaReenvio_Click(object sender, EventArgs e)
        {
            lstReenvio.Items.Clear();
            VerificarPasta();
        }


        #endregion

        #region Funçoes
        string TransformaEmIPString(int IP4,int IP3,int IP2,int IP1)
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
        void SeparaIPCarregaCampos(string ip)
        {
            try
            {
                char[] separador = { '.' };

                string[] separados = ip.Split(separador, 4);
                txbIP4.Text = separados[0];
                txbIP3.Text = separados[1];
                txbIP2.Text = separados[2];
                txbIP1.Text = separados[3];
            }
            catch (Exception)
            {

                throw;
            }
        }
        void Ler_XML()
        {
            try
            {
                DirectoryInfo diretorioXML = new DirectoryInfo(txbArquivoXML.Text);
                FileInfo[] arquivo = diretorioXML.GetFiles("*.xml");
                if (arquivo.Length != 0)
                {
                    string arquivoLeitura = arquivo[0].FullName;
                
                    XmlTextReader XmlLeitura = new XmlTextReader(arquivoLeitura);
                    etiquetaLida = new Etiqueta(XmlLeitura,arquivoLeitura);
                    XmlLeitura.Close();
                    File.Copy(arquivoLeitura, txbSaida.Text + "\\" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".xml");
                    File.Delete(arquivoLeitura);
                    StreamReader modelo = new StreamReader(txbModelos.Text + "\\" + etiquetaLida.Modelo + ".txt");
                    etiquetaLida.Estruturar(modelo);
                    modelo.Close();
                    StreamWriter escrita = new StreamWriter(txbSaida.Text + "\\Saida.txt");
                    List<string> saida = etiquetaLida.EnviaEtiqueta();
                    foreach (string atual in saida)
                    {
                        escrita.WriteLine(atual);
                    }
                    escrita.Close();
                }
                else
                {
                    MessageBox.Show("Não tem arquivos pra ler");
                }
                
            }catch(Exception ex)
            {
                etiquetaLida = null;
                MessageBox.Show("Erro na execução:\n" + ex.Message);

            }
            
            
        }
        void EnviaEtiqueta(Etiqueta enviar)
        {

            try
            {
                if (enviar != null)
                {
                    enviar.VerificaEstrutura();
                    List<string> saida = enviar.EnviaEtiqueta();

                    ConectaEtiquetadora();
                    if (rbtSerial.Checked)
                    {
                        
                        foreach (string atual in saida)
                        {
                            spoEtiquetadora.WriteLine(atual);
                        }
                        
                    }
                    else
                    {
                        NetworkStream stm = tcpCEtiquetadora.GetStream();
                        
                        foreach (string atual in saida)
                        {
                            
                            byte[] ba = Encoding.Default.GetBytes(atual + "\n");
                            //byte[] aux = new byte[atual.Length + 1];
                            //int j = 0;
                            //for (int i = 0; i < ba.Length; i++)
                            //{

                            //    if (ba[i] != 0)
                            //    {
                            //        aux[j] = ba[i];
                            //        j++;
                            //    }

                            //}
                            //stm.Write(aux, 0, aux.Length);
                             stm.Write(ba, 0, ba.Length);

                        }
                       
                    }
                    DesconectaEtiquetadora();

                }
                else
                {
                    MessageBox.Show("Etiqueta Vacia");
                    logerros.Add("Etiqueta vacia " + DateTime.Now.ToString("dd_MM_yy_hh:mm"));
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro no envio da etiqueta:\n" + ex.Message);
                logerros.Add("Erro no envio da etiqueta:\t" + ex.Message + DateTime.Now.ToString("dd_MM_yy_hh:mm"));
            }
            
            
        }
        void DesconectaEtiquetadora()
        {
            if (rbtSerial.Checked)
            {
                spoEtiquetadora.Close();
                spoEtiquetadora = null;
            }
            else
            {
                tcpCEtiquetadora.Close();
                tcpCEtiquetadora = null;
            }
        }
        void ConectaEtiquetadora()
        {
            try
            {
                if (rbtSerial.Checked)
                {
                    spoEtiquetadora = new SerialPort(cmbPortaEtiquetadora.Text, Convert.ToInt32(cmbBaundEtiquetadora.Text));
                    spoEtiquetadora.Open();
                }
                else
                {
                    string ip = TransformaEmIPString(Convert.ToInt32(txbIP4.Text), Convert.ToInt32(txbIP3.Text), Convert.ToInt32(txbIP2.Text), Convert.ToInt32(txbIP1.Text));
                    tcpCEtiquetadora = new TcpClient();
                    //Timer limiteConexao = new Timer();
                    //limiteConexao.Interval = 5000;
                    //limiteConexao.Tick += new System.EventHandler(limiteConexao_Tick);
                    //limiteConexao.Start();
                    tcpCEtiquetadora.Connect(IPAddress.Parse(ip), Convert.ToInt32(txbPortaIP.Text));
                    
                    while (!tcpCEtiquetadora.Connected)
                    {
                        if (falha)
                            throw new Exception("Excedeu o limite de conexão");
                    }
                    falha = false;
                    //limiteConexao.Stop();
                    
                    
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao conectar com a etiquetadora:\n" + ex.Message);
                logerros.Add("Erro ao conectar com a etiquetadora:\t" + ex.Message + DateTime.Now.ToString("dd_MM_yy_hh:mm"));
            }
        }
        void Inicializa()
        {
            try
            {
                
                StreamReader config = new StreamReader(@".\Config.txt", true);
                txbArquivoXML.Text=config.ReadLine();
                txbModelos.Text = config.ReadLine();
                txbSaida.Text = config.ReadLine();
                cmbPortaEtiquetadora.Text = config.ReadLine();
                cmbBaundEtiquetadora.Text = config.ReadLine();
                SeparaIPCarregaCampos(config.ReadLine());
                mtbIPLocal.Text = config.ReadLine();
                txbPortaIP.Text = config.ReadLine();
                txbPortaIPLocal.Text = config.ReadLine();
                txbLogs.Text=config.ReadLine();
                string opcao = config.ReadLine();
                if (opcao.Equals("Serial"))
                {
                    rbtSerial.Checked = true;
                    rbtEthernet.Checked = false;
                }
                else
                {
                    rbtEthernet.Checked = true;
                    rbtSerial.Checked = false;
                }

                licenca = config.ReadLine();


                config.Close();
                cryptoKey = "MartinbmSomaSul";

                //DirectoryInfo diretorioXML = new DirectoryInfo(txbArquivoXML.Text);
                //FileInfo[] arquivo = diretorioXML.GetFiles("*.xml");
                //foreach(FileInfo atual in arquivo)
                //{
                //    File.Delete(atual.FullName);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO AO INICIALIZAR!\n"+ex.Message);
                logerros.Add("Erro inicializar:\t" + ex.Message + DateTime.Now.ToString("dd_MM_yy_hh:mm"));
            }
        }
        void SalvaConfiguracao()
        {
            try
            {
                File.Delete(@".\Config.txt");
                StreamWriter config = new StreamWriter(@".\Config.txt", true);
                config.WriteLine(txbArquivoXML.Text);
                config.WriteLine(txbModelos.Text);
                config.WriteLine(txbSaida.Text);
                config.WriteLine(cmbPortaEtiquetadora.Text);
                config.WriteLine(cmbBaundEtiquetadora.Text);
                config.WriteLine(TransformaEmIPString(Convert.ToInt32(txbIP4.Text), Convert.ToInt32(txbIP3.Text), Convert.ToInt32(txbIP2.Text), Convert.ToInt32(txbIP1.Text)));
                config.WriteLine(mtbIPLocal.Text);
                config.WriteLine(txbPortaIP.Text);
                config.WriteLine(txbPortaIPLocal.Text);
                config.WriteLine(txbLogs.Text);
                if (rbtSerial.Checked)
                    config.WriteLine("Serial");
                else
                    config.WriteLine("IP");

                config.WriteLine(licenca);
                config.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO AO SALVAR AS CONFIGURAÇÕES!\n"+ex.Message);
                logerros.Add("Erro ao salvar configuraçoes:\t" + ex.Message + DateTime.Now.ToString("dd_MM_yy_hh:mm"));
            }
            
        }
        bool VerificaLicenca(DateTime data, string cod)
        {
            Criptografia crip = new Criptografia(CryptProvider.DES);
            crip.Key = cryptoKey;
            string decoded=crip.Decrypt(cod);
            if (Convert.ToInt64(decoded) > data.Ticks)
            {
               
                return true;
            }
            logerros.Add("Erro ao verificar liscença:\t" + DateTime.Now.ToString("dd_MM_yy_hh:mm"));
            return false;
        }
        void GeraLogErro()
        {
            try
            {
                StreamWriter log = new StreamWriter(txbLogs.Text+"\\"+DateTime.Now.ToString("dd_MM_yy_hh_mm")+".txt");
                if (logerros.Count != 0)
                {
                    foreach(string atual in logerros)
                    {
                        log.WriteLine(atual);
                    }
                }
                log.Close();
            }catch(Exception ex)
            {
                MessageBox.Show("Erro ao gerar LOG:"+ex.Message);
            }
        }
        void SelecionaConexao()
        {
            if (rbtSerial.Checked)
            {
                txbIP4.Enabled = false;
                txbIP3.Enabled = false;
                txbIP2.Enabled = false;
                txbIP1.Enabled = false;
                txbPortaIP.Enabled = false;
                cmbPortaEtiquetadora.Enabled = true;
                cmbBaundEtiquetadora.Enabled = true;
            }
            if (rbtEthernet.Checked)
            {
                txbIP4.Enabled = true;
                txbIP3.Enabled = true;
                txbIP2.Enabled = true;
                txbIP1.Enabled = true;
                txbPortaIP.Enabled = true;
                cmbPortaEtiquetadora.Enabled = false;
                cmbBaundEtiquetadora.Enabled = false;
            }
        }
        //void OuvirPorta()
        //{
        //    try
        //    {
        //        if(btnOuvirPorta.Text=="Ouvir porta")
        //        {
        //            btnOuvirPorta.Text = "Parar";
        //            string ip = mtbIPLocal.Text.Replace(',', '.');
                    
           
        //            Server = new Servidor(IPAddress.Parse(ip), Convert.ToInt32(txbPortaIPLocal.Text),txbArquivoXML.Text + "\\arquivo.xml");
        //            Server.Ouvir();
        //            //TCPServer.Start();
        //            //s = TCPServer.AcceptSocket();
        //            //s.
        //            timClock.Start();

        //        }
        //        else
        //        {
        //            Server.Stop();
        //            btnOuvirPorta.Text = "Ouvir porta";
        //            timClock.Stop();
        //        }

        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show("Erro: " + ex.Message);
        //    }
            

        //}
        void Verificaleitura()
        {
            try
            {

                DirectoryInfo diretorioXML = new DirectoryInfo(txbArquivoXML.Text);
                FileInfo[] arquivo = diretorioXML.GetFiles("*.xml");
                if (arquivo.Length != 0)
                {

                    string arquivoLeitura = arquivo[0].FullName;

                    XmlTextReader XmlLeitura = new XmlTextReader(arquivoLeitura);
                    etiquetaLida = new Etiqueta(XmlLeitura,arquivoLeitura);
                    XmlLeitura.Close();
                    File.Copy(arquivoLeitura, txbSaida.Text + "\\" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".xml");
                    File.Delete(arquivoLeitura);
                    StreamReader modelo = new StreamReader(txbModelos.Text + "\\Modelo" + etiquetaLida.Modelo + ".M");
                    etiquetaLida.Estruturar(modelo);
                    modelo.Close();
                    StreamWriter escrita = new StreamWriter(txbSaida.Text + "\\Saida.txt");
                    List<string> saida = etiquetaLida.EnviaEtiqueta();
                    foreach (string atual in saida)
                    {
                        escrita.WriteLine(atual);
                    }
                    escrita.Close();
                    EnviaEtiqueta(etiquetaLida);
                }
            }
            catch (Exception ex)
            {
                etiquetaLida = null;
                MessageBox.Show("Erro na execução:\n" + ex.Message);
            }
        }
        void VerificarPasta()
        {
            try
            {
                int listSelecionado = -1;
                int listSelecRenvio = -1;
                if (lstDisponiveis.SelectedIndex != -1)
                {
                    listSelecionado = lstDisponiveis.SelectedIndex;
                    btnEnviar.Enabled = false;
                }
                if(lstReenvio.SelectedIndex != -1)
                {
                    listSelecRenvio = lstReenvio.SelectedIndex;
                    btnReenviar.Enabled = false;
                    txbQtdRenvio.Enabled = false;
                }
                DirectoryInfo diretorioXML = new DirectoryInfo(txbArquivoXML.Text);
                FileInfo[] arquivo = diretorioXML.GetFiles("*.xml");
                etiquetasLista.Clear();
                lstDisponiveis.Items.Clear();

                if (tabTelas.SelectedIndex == 0)
                {

                    if (arquivo.Length != 0)
                    {
                        foreach (FileInfo arquivoAtual in arquivo)
                        {
                            string endArquivoAtual = arquivoAtual.FullName;
                            XmlTextReader XmlLeitor = new XmlTextReader(endArquivoAtual);
                            etiquetasLista.Add(new Etiqueta(XmlLeitor, endArquivoAtual));
                            XmlLeitor.Close();
                            StreamReader modelo = new StreamReader(txbModelos.Text + "\\" + etiquetasLista[etiquetasLista.Count - 1].Modelo + ".txt");
                            etiquetasLista[etiquetasLista.Count - 1].Estruturar(modelo);
                            modelo.Close();

                        }
                        foreach (Etiqueta atual in etiquetasLista)
                        {
                            lstDisponiveis.Items.Add(atual.Rotulo);
                        }
                    }
                    else
                    {
                        lstDisponiveis.SelectedIndex = -1;
                        btnEnviar.Enabled = false;
                    }

                }
                if (tabTelas.SelectedIndex == 1)
                {
                    diretorioXML = new DirectoryInfo(txbSaida.Text);
                    arquivo = diretorioXML.GetFiles("*.xml");
                    etiquetasListaRenvio.Clear();
                    lstReenvio.Items.Clear();



                    if (arquivo.Length != 0)
                    {
                        foreach (FileInfo arquivoAtual in arquivo)
                        {
                            string endArquivoAtual = arquivoAtual.FullName;
                            XmlTextReader XmlLeitor = new XmlTextReader(endArquivoAtual);
                            etiquetasListaRenvio.Add(new Etiqueta(XmlLeitor, endArquivoAtual));
                            XmlLeitor.Close();
                            StreamReader modelo = new StreamReader(txbModelos.Text + "\\" + etiquetasListaRenvio[etiquetasListaRenvio.Count - 1].Modelo + ".txt");
                            etiquetasListaRenvio[etiquetasListaRenvio.Count - 1].Estruturar(modelo);
                            modelo.Close();

                        }
                        foreach (Etiqueta atual in etiquetasListaRenvio)
                        {
                            lstReenvio.Items.Add(atual.Rotulo);
                        }
                    }
                    else
                    {
                        lstDisponiveis.SelectedIndex = -1;
                        btnReenviar.Enabled = false;
                        txbQtdRenvio.Enabled = false;
                    }
                }



                if (listSelecionado != -1)
                {
                    lstDisponiveis.SelectedIndex = listSelecionado;
                }
                if (listSelecRenvio != -1)
                {
                    lstReenvio.SelectedIndex = listSelecRenvio;
                }

            }
            catch (Exception ex)
            {
                etiquetaLida = null;
                MessageBox.Show("Erro na execução:\n" + ex.Message);
            }

        }
        void EnvioUnitario(string origem)
        {
            bool refreshAtivado = false;
            if (timAutoRefresh.Enabled)
            {
                refreshAtivado = true;
                timAutoRefresh.Enabled= false;
            }

            if (origem == "Principal")
            {
                try
                {
                    Etiqueta aEnviar = etiquetasLista[lstDisponiveis.SelectedIndex];
                    EnviaEtiqueta(aEnviar);
                    //************************************************************************
                    StreamWriter escrita = new StreamWriter(txbSaida.Text + "\\Saida.txt");
                    List<string> saida = aEnviar.EnviaEtiqueta();
                    foreach (string atual in saida)
                    {
                        escrita.WriteLine(atual);
                    }
                    escrita.Close();
                    etiquetasLista.RemoveAt(lstDisponiveis.SelectedIndex);
                    File.Copy(aEnviar.EndOrigem, txbSaida.Text + "\\" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".xml");
                    File.Delete(aEnviar.EndOrigem);
                    lstDisponiveis.Items.RemoveAt(lstDisponiveis.SelectedIndex);
                    if (lstDisponiveis.Items.Count != 0)
                        lstDisponiveis.SetSelected(0, false);
                    else
                        btnEnviar.Enabled = false;
                    VerificarPasta();
                }
                catch (Exception ex)
                {
                    if (refreshAtivado)
                    {
                        timAutoRefresh.Enabled = true;
                    }
                    MessageBox.Show("Erro no envio da etiqueta:\n" + ex.Message);
                    logerros.Add("Erro no envio da etiqueta:\t" + ex.Message + DateTime.Now.ToString("dd_MM_yy_hh:mm"));
                }
                if (refreshAtivado)
                {
                    timAutoRefresh.Enabled = true;
                }
            }
            if (origem == "Reenvio")
            {

                try
                {
                    Etiqueta aEnviar = etiquetasListaRenvio[lstReenvio.SelectedIndex];
                    aEnviar.Quantidade = Convert.ToInt32(txbQtdRenvio.Text);
                    EnviaEtiqueta(aEnviar);
                    StreamWriter escrita = new StreamWriter(txbSaida.Text + "\\Saida.txt");
                    List<string> saida = aEnviar.EnviaEtiqueta();
                    foreach (string atual in saida)
                    {
                        escrita.WriteLine(atual);
                    }
                    escrita.Close();
                    etiquetasListaRenvio.RemoveAt(lstReenvio.SelectedIndex);
                    File.Copy(aEnviar.EndOrigem, txbSaida.Text + "\\" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".xml");
                    File.Delete(aEnviar.EndOrigem);
                    //  lstReenvio.Items.RemoveAt(lstReenvio.SelectedIndex);
                    if (lstReenvio.Items.Count != 0)
                        ; // lstReenvio.SetSelected(lstReenvio.Items.Count-1, false);
                    else
                    {
                        btnReenviar.Enabled = false;
                        txbQtdRenvio.Enabled = false;
                    }
                    VerificarPasta();
                    
                        


                }
                catch (Exception ex)
                {
                    if (refreshAtivado)
                    {
                        timAutoRefresh.Enabled = true;
                    }
                    MessageBox.Show("Erro no envio da etiqueta:\n" + ex.Message);
                    logerros.Add("Erro no envio da etiqueta:\t" + ex.Message + DateTime.Now.ToString("dd_MM_yy_hh:mm"));
                }
                if (refreshAtivado)
                {
                    timAutoRefresh.Enabled = true;
                }
            }
        }
        void RefreshAuto()
        {
            
            if (pibSinal.Image.Size == Properties.Resources.Vermelho1.Size)
            {
                try
                {
                    VerificarPasta();
                    pibSinal.Image = Properties.Resources.Verde;
                    timAutoRefresh.Enabled = true;
                }catch(Exception ex)
                {
                    MessageBox.Show("Erro ao atualizar Pasta de arquivos o auto refresh se´ra desativado:\n" + ex.Message);
                    pibSinal.Image = Properties.Resources.Vermelho1;
                    timAutoRefresh.Enabled = false;
                }
                
            }
            else
            {
                pibSinal.Image = Properties.Resources.Vermelho1;
                timAutoRefresh.Enabled = false;
            }
        }
        void AutoRefreshTick()
        {
            try
            {
                timAutoRefresh.Enabled = false;
                VerificarPasta();
                timAutoRefresh.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar Pasta de arquivos o auto refresh se´ra desativado:\n" + ex.Message);
                pibSinal.Image = Properties.Resources.Vermelho1;
                timAutoRefresh.Enabled = false;
            }
        }
        void SelecionaListaRenvio()
        {
            btnReenviar.Enabled = true;
            txbQtdRenvio.Enabled = true;
            //txbQtdRenvio.Text = Convert.ToString(etiquetasListaRenvio[lstReenvio.SelectedIndex].Quantidade);
        }
        void LimpaHistorico()
        {
            timAutoRefresh.Enabled = false;
            if(DialogResult.Yes==MessageBox.Show("Tem certeza que deseja excluir o historico?\n", "Confirmação exclução", MessageBoxButtons.YesNo))
            {
                DirectoryInfo diretorioXML = new DirectoryInfo(txbSaida.Text);
                FileInfo[] arquivo = diretorioXML.GetFiles("*.xml");
                if (lstReenvio.SelectedIndex != -1)
                {
                    lstReenvio.SetSelected(0, false);
                }
                foreach (FileInfo arquivoAtual in arquivo)
                {
                    arquivoAtual.Delete();
                }
                VerificarPasta();
            }
            if(pibSinal.Image.Size != Properties.Resources.Vermelho1.Size)
            {
                timAutoRefresh.Enabled = true;
            }
                

        }
        void Abortar()
        {
            try
            {
                ConectaEtiquetadora();
                NetworkStream stm = tcpCEtiquetadora.GetStream();
                byte[] ba = Encoding.Default.GetBytes("#Abortar\r");
                stm.Write(ba, 0, ba.Length);
                DesconectaEtiquetadora();
            }catch(Exception ex)
            {
                MessageBox.Show("Erro ao Abortar a impressão:\n" + ex.Message);
                logerros.Add("Erro ao Abortar a impressão:\t" + ex.Message + DateTime.Now.ToString("dd_MM_yy_hh:mm"));
            }
            
        }
        #endregion


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAbortar_Click(object sender, EventArgs e)
        {
            Abortar();
        }
    }
}
