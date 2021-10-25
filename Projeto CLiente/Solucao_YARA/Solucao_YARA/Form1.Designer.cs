namespace Solucao_YARA
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabTelas = new System.Windows.Forms.TabControl();
            this.tabInicio = new System.Windows.Forms.TabPage();
            this.btnAbortar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnAtualizaDisponiveis = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.lstDisponiveis = new System.Windows.Forms.ListBox();
            this.tabReenvio = new System.Windows.Forms.TabPage();
            this.btnAbortar1 = new System.Windows.Forms.Button();
            this.btnLimpaHistorico = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txbQtdRenvio = new System.Windows.Forms.TextBox();
            this.btnReenviar = new System.Windows.Forms.Button();
            this.btnAtualizaReenvio = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.lstReenvio = new System.Windows.Forms.ListBox();
            this.tabConfiguracoes = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.txbLogs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbSaida = new System.Windows.Forms.TextBox();
            this.txbModelos = new System.Windows.Forms.TextBox();
            this.btnLer_XML = new System.Windows.Forms.Button();
            this.txbArquivoXML = new System.Windows.Forms.TextBox();
            this.txbIP1 = new System.Windows.Forms.TextBox();
            this.txbIP2 = new System.Windows.Forms.TextBox();
            this.txbIP3 = new System.Windows.Forms.TextBox();
            this.txbIP4 = new System.Windows.Forms.TextBox();
            this.txbPortaIPLocal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.mtbIPLocal = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txbPortaIP = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rbtEthernet = new System.Windows.Forms.RadioButton();
            this.rbtSerial = new System.Windows.Forms.RadioButton();
            this.btnSalvaConfig = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbBaundEtiquetadora = new System.Windows.Forms.ComboBox();
            this.cmbPortaEtiquetadora = new System.Windows.Forms.ComboBox();
            this.timClock = new System.Windows.Forms.Timer(this.components);
            this.btnRefreshAuto = new System.Windows.Forms.Button();
            this.timAutoRefresh = new System.Windows.Forms.Timer(this.components);
            this.pibSinal = new System.Windows.Forms.PictureBox();
            this.tabTelas.SuspendLayout();
            this.tabInicio.SuspendLayout();
            this.tabReenvio.SuspendLayout();
            this.tabConfiguracoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pibSinal)).BeginInit();
            this.SuspendLayout();
            // 
            // tabTelas
            // 
            this.tabTelas.Controls.Add(this.tabInicio);
            this.tabTelas.Controls.Add(this.tabReenvio);
            this.tabTelas.Controls.Add(this.tabConfiguracoes);
            this.tabTelas.Location = new System.Drawing.Point(12, 52);
            this.tabTelas.Name = "tabTelas";
            this.tabTelas.SelectedIndex = 0;
            this.tabTelas.Size = new System.Drawing.Size(717, 377);
            this.tabTelas.TabIndex = 0;
            // 
            // tabInicio
            // 
            this.tabInicio.Controls.Add(this.btnAbortar);
            this.tabInicio.Controls.Add(this.btnEnviar);
            this.tabInicio.Controls.Add(this.btnAtualizaDisponiveis);
            this.tabInicio.Controls.Add(this.label13);
            this.tabInicio.Controls.Add(this.lstDisponiveis);
            this.tabInicio.Location = new System.Drawing.Point(4, 22);
            this.tabInicio.Name = "tabInicio";
            this.tabInicio.Padding = new System.Windows.Forms.Padding(3);
            this.tabInicio.Size = new System.Drawing.Size(709, 351);
            this.tabInicio.TabIndex = 2;
            this.tabInicio.Text = "Inicio";
            this.tabInicio.UseVisualStyleBackColor = true;
            // 
            // btnAbortar
            // 
            this.btnAbortar.Location = new System.Drawing.Point(532, 298);
            this.btnAbortar.Name = "btnAbortar";
            this.btnAbortar.Size = new System.Drawing.Size(128, 23);
            this.btnAbortar.TabIndex = 4;
            this.btnAbortar.Text = "Abortar impressoes";
            this.btnAbortar.UseVisualStyleBackColor = true;
            this.btnAbortar.Click += new System.EventHandler(this.btnAbortar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Enabled = false;
            this.btnEnviar.Location = new System.Drawing.Point(9, 298);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 3;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnAtualizaDisponiveis
            // 
            this.btnAtualizaDisponiveis.Location = new System.Drawing.Point(120, 6);
            this.btnAtualizaDisponiveis.Name = "btnAtualizaDisponiveis";
            this.btnAtualizaDisponiveis.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizaDisponiveis.TabIndex = 2;
            this.btnAtualizaDisponiveis.Text = "Atualizar";
            this.btnAtualizaDisponiveis.UseVisualStyleBackColor = true;
            this.btnAtualizaDisponiveis.Click += new System.EventHandler(this.btnAtualizaDisponiveis_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Arquivos Disponiveis:";
            // 
            // lstDisponiveis
            // 
            this.lstDisponiveis.FormattingEnabled = true;
            this.lstDisponiveis.Location = new System.Drawing.Point(6, 41);
            this.lstDisponiveis.Name = "lstDisponiveis";
            this.lstDisponiveis.Size = new System.Drawing.Size(697, 251);
            this.lstDisponiveis.TabIndex = 0;
            this.lstDisponiveis.SelectedIndexChanged += new System.EventHandler(this.lstDisponiveis_SelectedIndexChanged);
            // 
            // tabReenvio
            // 
            this.tabReenvio.Controls.Add(this.btnAbortar1);
            this.tabReenvio.Controls.Add(this.btnLimpaHistorico);
            this.tabReenvio.Controls.Add(this.label15);
            this.tabReenvio.Controls.Add(this.txbQtdRenvio);
            this.tabReenvio.Controls.Add(this.btnReenviar);
            this.tabReenvio.Controls.Add(this.btnAtualizaReenvio);
            this.tabReenvio.Controls.Add(this.label14);
            this.tabReenvio.Controls.Add(this.lstReenvio);
            this.tabReenvio.Location = new System.Drawing.Point(4, 22);
            this.tabReenvio.Name = "tabReenvio";
            this.tabReenvio.Size = new System.Drawing.Size(709, 351);
            this.tabReenvio.TabIndex = 3;
            this.tabReenvio.Text = "Reenvio";
            this.tabReenvio.UseVisualStyleBackColor = true;
            // 
            // btnAbortar1
            // 
            this.btnAbortar1.Location = new System.Drawing.Point(570, 313);
            this.btnAbortar1.Name = "btnAbortar1";
            this.btnAbortar1.Size = new System.Drawing.Size(128, 23);
            this.btnAbortar1.TabIndex = 10;
            this.btnAbortar1.Text = "Abortar impressoes";
            this.btnAbortar1.UseVisualStyleBackColor = true;
            this.btnAbortar1.Click += new System.EventHandler(this.btnAbortar_Click);
            // 
            // btnLimpaHistorico
            // 
            this.btnLimpaHistorico.Location = new System.Drawing.Point(364, 10);
            this.btnLimpaHistorico.Name = "btnLimpaHistorico";
            this.btnLimpaHistorico.Size = new System.Drawing.Size(97, 23);
            this.btnLimpaHistorico.TabIndex = 9;
            this.btnLimpaHistorico.Text = "Limpa Hitorico";
            this.btnLimpaHistorico.UseVisualStyleBackColor = true;
            this.btnLimpaHistorico.Click += new System.EventHandler(this.btnLimpaHistorico_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(98, 318);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 13);
            this.label15.TabIndex = 8;
            this.label15.Text = "Quantidade:";
            // 
            // txbQtdRenvio
            // 
            this.txbQtdRenvio.Enabled = false;
            this.txbQtdRenvio.Location = new System.Drawing.Point(169, 315);
            this.txbQtdRenvio.Name = "txbQtdRenvio";
            this.txbQtdRenvio.Size = new System.Drawing.Size(100, 20);
            this.txbQtdRenvio.TabIndex = 7;
            // 
            // btnReenviar
            // 
            this.btnReenviar.Enabled = false;
            this.btnReenviar.Location = new System.Drawing.Point(6, 313);
            this.btnReenviar.Name = "btnReenviar";
            this.btnReenviar.Size = new System.Drawing.Size(75, 23);
            this.btnReenviar.TabIndex = 6;
            this.btnReenviar.Text = "Renviar";
            this.btnReenviar.UseVisualStyleBackColor = true;
            this.btnReenviar.Click += new System.EventHandler(this.btnReenviar_Click);
            // 
            // btnAtualizaReenvio
            // 
            this.btnAtualizaReenvio.Location = new System.Drawing.Point(179, 10);
            this.btnAtualizaReenvio.Name = "btnAtualizaReenvio";
            this.btnAtualizaReenvio.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizaReenvio.TabIndex = 5;
            this.btnAtualizaReenvio.Text = "Atualizar";
            this.btnAtualizaReenvio.UseVisualStyleBackColor = true;
            this.btnAtualizaReenvio.Click += new System.EventHandler(this.btnAtualizaReenvio_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(170, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Arquivos Disponiveis para reenvio:";
            // 
            // lstReenvio
            // 
            this.lstReenvio.FormattingEnabled = true;
            this.lstReenvio.Location = new System.Drawing.Point(3, 44);
            this.lstReenvio.Name = "lstReenvio";
            this.lstReenvio.Size = new System.Drawing.Size(697, 251);
            this.lstReenvio.TabIndex = 3;
            this.lstReenvio.SelectedIndexChanged += new System.EventHandler(this.lstReenvio_SelectedIndexChanged);
            // 
            // tabConfiguracoes
            // 
            this.tabConfiguracoes.Controls.Add(this.label12);
            this.tabConfiguracoes.Controls.Add(this.txbLogs);
            this.tabConfiguracoes.Controls.Add(this.label3);
            this.tabConfiguracoes.Controls.Add(this.label2);
            this.tabConfiguracoes.Controls.Add(this.label1);
            this.tabConfiguracoes.Controls.Add(this.txbSaida);
            this.tabConfiguracoes.Controls.Add(this.txbModelos);
            this.tabConfiguracoes.Controls.Add(this.btnLer_XML);
            this.tabConfiguracoes.Controls.Add(this.txbArquivoXML);
            this.tabConfiguracoes.Controls.Add(this.txbIP1);
            this.tabConfiguracoes.Controls.Add(this.txbIP2);
            this.tabConfiguracoes.Controls.Add(this.txbIP3);
            this.tabConfiguracoes.Controls.Add(this.txbIP4);
            this.tabConfiguracoes.Controls.Add(this.txbPortaIPLocal);
            this.tabConfiguracoes.Controls.Add(this.label10);
            this.tabConfiguracoes.Controls.Add(this.mtbIPLocal);
            this.tabConfiguracoes.Controls.Add(this.label11);
            this.tabConfiguracoes.Controls.Add(this.label9);
            this.tabConfiguracoes.Controls.Add(this.txbPortaIP);
            this.tabConfiguracoes.Controls.Add(this.label8);
            this.tabConfiguracoes.Controls.Add(this.label6);
            this.tabConfiguracoes.Controls.Add(this.rbtEthernet);
            this.tabConfiguracoes.Controls.Add(this.rbtSerial);
            this.tabConfiguracoes.Controls.Add(this.btnSalvaConfig);
            this.tabConfiguracoes.Controls.Add(this.label7);
            this.tabConfiguracoes.Controls.Add(this.label5);
            this.tabConfiguracoes.Controls.Add(this.label4);
            this.tabConfiguracoes.Controls.Add(this.cmbBaundEtiquetadora);
            this.tabConfiguracoes.Controls.Add(this.cmbPortaEtiquetadora);
            this.tabConfiguracoes.Location = new System.Drawing.Point(4, 22);
            this.tabConfiguracoes.Name = "tabConfiguracoes";
            this.tabConfiguracoes.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfiguracoes.Size = new System.Drawing.Size(709, 351);
            this.tabConfiguracoes.TabIndex = 1;
            this.tabConfiguracoes.Text = "Configurações";
            this.tabConfiguracoes.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 151);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 47;
            this.label12.Text = "Diretorio Logs:";
            // 
            // txbLogs
            // 
            this.txbLogs.Location = new System.Drawing.Point(50, 167);
            this.txbLogs.Name = "txbLogs";
            this.txbLogs.Size = new System.Drawing.Size(218, 20);
            this.txbLogs.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Diretorio Saida:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Diretorio Layouts:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Diretorio Arquivo XML:";
            // 
            // txbSaida
            // 
            this.txbSaida.Location = new System.Drawing.Point(50, 125);
            this.txbSaida.Name = "txbSaida";
            this.txbSaida.Size = new System.Drawing.Size(218, 20);
            this.txbSaida.TabIndex = 42;
            // 
            // txbModelos
            // 
            this.txbModelos.Location = new System.Drawing.Point(50, 87);
            this.txbModelos.Name = "txbModelos";
            this.txbModelos.Size = new System.Drawing.Size(218, 20);
            this.txbModelos.TabIndex = 41;
            // 
            // btnLer_XML
            // 
            this.btnLer_XML.Enabled = false;
            this.btnLer_XML.Location = new System.Drawing.Point(274, 46);
            this.btnLer_XML.Name = "btnLer_XML";
            this.btnLer_XML.Size = new System.Drawing.Size(75, 23);
            this.btnLer_XML.TabIndex = 40;
            this.btnLer_XML.Text = "Ler XML";
            this.btnLer_XML.UseVisualStyleBackColor = true;
            this.btnLer_XML.Visible = false;
            // 
            // txbArquivoXML
            // 
            this.txbArquivoXML.Location = new System.Drawing.Point(50, 48);
            this.txbArquivoXML.Name = "txbArquivoXML";
            this.txbArquivoXML.Size = new System.Drawing.Size(218, 20);
            this.txbArquivoXML.TabIndex = 39;
            // 
            // txbIP1
            // 
            this.txbIP1.Location = new System.Drawing.Point(655, 68);
            this.txbIP1.Name = "txbIP1";
            this.txbIP1.Size = new System.Drawing.Size(37, 20);
            this.txbIP1.TabIndex = 38;
            // 
            // txbIP2
            // 
            this.txbIP2.Location = new System.Drawing.Point(612, 68);
            this.txbIP2.Name = "txbIP2";
            this.txbIP2.Size = new System.Drawing.Size(37, 20);
            this.txbIP2.TabIndex = 37;
            // 
            // txbIP3
            // 
            this.txbIP3.Location = new System.Drawing.Point(569, 68);
            this.txbIP3.Name = "txbIP3";
            this.txbIP3.Size = new System.Drawing.Size(37, 20);
            this.txbIP3.TabIndex = 36;
            // 
            // txbIP4
            // 
            this.txbIP4.Location = new System.Drawing.Point(526, 68);
            this.txbIP4.Name = "txbIP4";
            this.txbIP4.Size = new System.Drawing.Size(37, 20);
            this.txbIP4.TabIndex = 35;
            // 
            // txbPortaIPLocal
            // 
            this.txbPortaIPLocal.Location = new System.Drawing.Point(19, 258);
            this.txbPortaIPLocal.Name = "txbPortaIPLocal";
            this.txbPortaIPLocal.Size = new System.Drawing.Size(100, 20);
            this.txbPortaIPLocal.TabIndex = 32;
            this.txbPortaIPLocal.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 242);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "Porta:";
            this.label10.Visible = false;
            // 
            // mtbIPLocal
            // 
            this.mtbIPLocal.Location = new System.Drawing.Point(19, 210);
            this.mtbIPLocal.Mask = "###.###.###.###";
            this.mtbIPLocal.Name = "mtbIPLocal";
            this.mtbIPLocal.Size = new System.Drawing.Size(100, 20);
            this.mtbIPLocal.TabIndex = 30;
            this.mtbIPLocal.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 194);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "IP Local:";
            this.label11.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Configuraçoes Software:";
            // 
            // txbPortaIP
            // 
            this.txbPortaIP.Location = new System.Drawing.Point(526, 122);
            this.txbPortaIP.Name = "txbPortaIP";
            this.txbPortaIP.Size = new System.Drawing.Size(100, 20);
            this.txbPortaIP.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(523, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Porta:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(523, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "IP:";
            // 
            // rbtEthernet
            // 
            this.rbtEthernet.AutoSize = true;
            this.rbtEthernet.Location = new System.Drawing.Point(526, 29);
            this.rbtEthernet.Name = "rbtEthernet";
            this.rbtEthernet.Size = new System.Drawing.Size(65, 17);
            this.rbtEthernet.TabIndex = 22;
            this.rbtEthernet.TabStop = true;
            this.rbtEthernet.Text = "Ethernet";
            this.rbtEthernet.UseVisualStyleBackColor = true;
            this.rbtEthernet.CheckedChanged += new System.EventHandler(this.rbtTipoConexao_CheckedChanged);
            // 
            // rbtSerial
            // 
            this.rbtSerial.AutoSize = true;
            this.rbtSerial.Location = new System.Drawing.Point(397, 29);
            this.rbtSerial.Name = "rbtSerial";
            this.rbtSerial.Size = new System.Drawing.Size(51, 17);
            this.rbtSerial.TabIndex = 21;
            this.rbtSerial.TabStop = true;
            this.rbtSerial.Text = "Serial";
            this.rbtSerial.UseVisualStyleBackColor = true;
            this.rbtSerial.CheckedChanged += new System.EventHandler(this.rbtTipoConexao_CheckedChanged);
            // 
            // btnSalvaConfig
            // 
            this.btnSalvaConfig.Location = new System.Drawing.Point(575, 322);
            this.btnSalvaConfig.Name = "btnSalvaConfig";
            this.btnSalvaConfig.Size = new System.Drawing.Size(128, 23);
            this.btnSalvaConfig.TabIndex = 20;
            this.btnSalvaConfig.Text = "Salvar Configurações";
            this.btnSalvaConfig.UseVisualStyleBackColor = true;
            this.btnSalvaConfig.Click += new System.EventHandler(this.btnSalvaConfig_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(394, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "BaundRate:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(394, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Porta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(394, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Configuraçoes Etiquetadora:";
            // 
            // cmbBaundEtiquetadora
            // 
            this.cmbBaundEtiquetadora.FormattingEnabled = true;
            this.cmbBaundEtiquetadora.Items.AddRange(new object[] {
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200"});
            this.cmbBaundEtiquetadora.Location = new System.Drawing.Point(397, 121);
            this.cmbBaundEtiquetadora.Name = "cmbBaundEtiquetadora";
            this.cmbBaundEtiquetadora.Size = new System.Drawing.Size(121, 21);
            this.cmbBaundEtiquetadora.TabIndex = 15;
            // 
            // cmbPortaEtiquetadora
            // 
            this.cmbPortaEtiquetadora.FormattingEnabled = true;
            this.cmbPortaEtiquetadora.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9"});
            this.cmbPortaEtiquetadora.Location = new System.Drawing.Point(397, 68);
            this.cmbPortaEtiquetadora.Name = "cmbPortaEtiquetadora";
            this.cmbPortaEtiquetadora.Size = new System.Drawing.Size(121, 21);
            this.cmbPortaEtiquetadora.TabIndex = 14;
            // 
            // timClock
            // 
            this.timClock.Interval = 5000;
            this.timClock.Tick += new System.EventHandler(this.timClock_Tick);
            // 
            // btnRefreshAuto
            // 
            this.btnRefreshAuto.Location = new System.Drawing.Point(586, 23);
            this.btnRefreshAuto.Name = "btnRefreshAuto";
            this.btnRefreshAuto.Size = new System.Drawing.Size(101, 23);
            this.btnRefreshAuto.TabIndex = 4;
            this.btnRefreshAuto.Text = "Auto Refresh";
            this.btnRefreshAuto.UseVisualStyleBackColor = true;
            this.btnRefreshAuto.Click += new System.EventHandler(this.btnRefreshAuto_Click);
            // 
            // timAutoRefresh
            // 
            this.timAutoRefresh.Interval = 5000;
            this.timAutoRefresh.Tick += new System.EventHandler(this.timAutoRefresh_Tick);
            // 
            // pibSinal
            // 
            this.pibSinal.ErrorImage = global::Solucao_YARA.Properties.Resources.Vermelho1;
            this.pibSinal.Image = global::Solucao_YARA.Properties.Resources.Vermelho1;
            this.pibSinal.InitialImage = global::Solucao_YARA.Properties.Resources.Vermelho1;
            this.pibSinal.Location = new System.Drawing.Point(693, 13);
            this.pibSinal.Name = "pibSinal";
            this.pibSinal.Size = new System.Drawing.Size(32, 33);
            this.pibSinal.TabIndex = 5;
            this.pibSinal.TabStop = false;
            this.pibSinal.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 441);
            this.Controls.Add(this.btnRefreshAuto);
            this.Controls.Add(this.pibSinal);
            this.Controls.Add(this.tabTelas);
            this.Name = "Form1";
            this.Text = "Projeto GB";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabTelas.ResumeLayout(false);
            this.tabInicio.ResumeLayout(false);
            this.tabInicio.PerformLayout();
            this.tabReenvio.ResumeLayout(false);
            this.tabReenvio.PerformLayout();
            this.tabConfiguracoes.ResumeLayout(false);
            this.tabConfiguracoes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pibSinal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabTelas;
        private System.Windows.Forms.TabPage tabConfiguracoes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbBaundEtiquetadora;
        private System.Windows.Forms.ComboBox cmbPortaEtiquetadora;
        private System.Windows.Forms.Button btnSalvaConfig;
        private System.Windows.Forms.RadioButton rbtEthernet;
        private System.Windows.Forms.RadioButton rbtSerial;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbPortaIP;
        private System.Windows.Forms.Timer timClock;
        private System.Windows.Forms.TextBox txbIP1;
        private System.Windows.Forms.TextBox txbIP2;
        private System.Windows.Forms.TextBox txbIP3;
        private System.Windows.Forms.TextBox txbIP4;
        private System.Windows.Forms.TabPage tabInicio;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnAtualizaDisponiveis;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListBox lstDisponiveis;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txbLogs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbSaida;
        private System.Windows.Forms.TextBox txbModelos;
        private System.Windows.Forms.Button btnLer_XML;
        private System.Windows.Forms.TextBox txbArquivoXML;
        private System.Windows.Forms.TextBox txbPortaIPLocal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox mtbIPLocal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pibSinal;
        private System.Windows.Forms.Button btnRefreshAuto;
        private System.Windows.Forms.Timer timAutoRefresh;
        private System.Windows.Forms.TabPage tabReenvio;
        private System.Windows.Forms.Button btnReenviar;
        private System.Windows.Forms.Button btnAtualizaReenvio;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListBox lstReenvio;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txbQtdRenvio;
        private System.Windows.Forms.Button btnLimpaHistorico;
        private System.Windows.Forms.Button btnAbortar;
        private System.Windows.Forms.Button btnAbortar1;
    }
}

