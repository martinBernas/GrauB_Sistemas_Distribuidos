using System.Net.Sockets;
using System.Net;

namespace Supervisor_impressora
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSolicitarStatus = new System.Windows.Forms.Button();
            this.btnTrigger = new System.Windows.Forms.Button();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.txbIP4 = new System.Windows.Forms.TextBox();
            this.txbIP3 = new System.Windows.Forms.TextBox();
            this.txbIP2 = new System.Windows.Forms.TextBox();
            this.txbIP1 = new System.Windows.Forms.TextBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.txbPorta = new System.Windows.Forms.TextBox();
            this.lblPorta = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txbNomeCampo = new System.Windows.Forms.TextBox();
            this.txbConteudoCampo = new System.Windows.Forms.TextBox();
            this.btnEnviarCampo = new System.Windows.Forms.Button();
            this.btnAtualizarCampo = new System.Windows.Forms.Button();
            this.btnAbortarImpressoes = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txbQuantidade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSolicitarStatus
            // 
            this.btnSolicitarStatus.Location = new System.Drawing.Point(158, 722);
            this.btnSolicitarStatus.Name = "btnSolicitarStatus";
            this.btnSolicitarStatus.Size = new System.Drawing.Size(139, 23);
            this.btnSolicitarStatus.TabIndex = 0;
            this.btnSolicitarStatus.Text = "Solicitar Status";
            this.btnSolicitarStatus.UseVisualStyleBackColor = true;
            this.btnSolicitarStatus.Click += new System.EventHandler(this.btnSolicitarStatus_Click);
            // 
            // btnTrigger
            // 
            this.btnTrigger.Location = new System.Drawing.Point(303, 722);
            this.btnTrigger.Name = "btnTrigger";
            this.btnTrigger.Size = new System.Drawing.Size(182, 23);
            this.btnTrigger.TabIndex = 1;
            this.btnTrigger.Text = "Triggar impressão";
            this.btnTrigger.UseVisualStyleBackColor = true;
            this.btnTrigger.Click += new System.EventHandler(this.btnTrigger_Click);
            // 
            // lstLog
            // 
            this.lstLog.FormattingEnabled = true;
            this.lstLog.ItemHeight = 15;
            this.lstLog.Location = new System.Drawing.Point(12, 70);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(766, 544);
            this.lstLog.TabIndex = 2;
            // 
            // txbIP4
            // 
            this.txbIP4.Location = new System.Drawing.Point(13, 36);
            this.txbIP4.Name = "txbIP4";
            this.txbIP4.Size = new System.Drawing.Size(40, 23);
            this.txbIP4.TabIndex = 3;
            // 
            // txbIP3
            // 
            this.txbIP3.Location = new System.Drawing.Point(59, 36);
            this.txbIP3.Name = "txbIP3";
            this.txbIP3.Size = new System.Drawing.Size(40, 23);
            this.txbIP3.TabIndex = 4;
            // 
            // txbIP2
            // 
            this.txbIP2.Location = new System.Drawing.Point(105, 36);
            this.txbIP2.Name = "txbIP2";
            this.txbIP2.Size = new System.Drawing.Size(40, 23);
            this.txbIP2.TabIndex = 5;
            // 
            // txbIP1
            // 
            this.txbIP1.Location = new System.Drawing.Point(151, 36);
            this.txbIP1.Name = "txbIP1";
            this.txbIP1.Size = new System.Drawing.Size(40, 23);
            this.txbIP1.TabIndex = 6;
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(13, 13);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(20, 15);
            this.lblIP.TabIndex = 7;
            this.lblIP.Text = "IP:";
            this.lblIP.Click += new System.EventHandler(this.label1_Click);
            // 
            // txbPorta
            // 
            this.txbPorta.Location = new System.Drawing.Point(245, 36);
            this.txbPorta.Name = "txbPorta";
            this.txbPorta.Size = new System.Drawing.Size(91, 23);
            this.txbPorta.TabIndex = 8;
            // 
            // lblPorta
            // 
            this.lblPorta.AutoSize = true;
            this.lblPorta.Location = new System.Drawing.Point(201, 39);
            this.lblPorta.Name = "lblPorta";
            this.lblPorta.Size = new System.Drawing.Size(38, 15);
            this.lblPorta.TabIndex = 9;
            this.lblPorta.Text = "Porta:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(703, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Limpar log";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txbNomeCampo
            // 
            this.txbNomeCampo.Location = new System.Drawing.Point(13, 646);
            this.txbNomeCampo.Name = "txbNomeCampo";
            this.txbNomeCampo.Size = new System.Drawing.Size(100, 23);
            this.txbNomeCampo.TabIndex = 11;
            this.txbNomeCampo.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txbConteudoCampo
            // 
            this.txbConteudoCampo.Location = new System.Drawing.Point(119, 646);
            this.txbConteudoCampo.Name = "txbConteudoCampo";
            this.txbConteudoCampo.Size = new System.Drawing.Size(217, 23);
            this.txbConteudoCampo.TabIndex = 12;
            // 
            // btnEnviarCampo
            // 
            this.btnEnviarCampo.Location = new System.Drawing.Point(342, 645);
            this.btnEnviarCampo.Name = "btnEnviarCampo";
            this.btnEnviarCampo.Size = new System.Drawing.Size(139, 23);
            this.btnEnviarCampo.TabIndex = 13;
            this.btnEnviarCampo.Text = "Enviar Campo";
            this.btnEnviarCampo.UseVisualStyleBackColor = true;
            this.btnEnviarCampo.Click += new System.EventHandler(this.btnEnviarCampo_Click);
            // 
            // btnAtualizarCampo
            // 
            this.btnAtualizarCampo.Location = new System.Drawing.Point(487, 646);
            this.btnAtualizarCampo.Name = "btnAtualizarCampo";
            this.btnAtualizarCampo.Size = new System.Drawing.Size(139, 23);
            this.btnAtualizarCampo.TabIndex = 14;
            this.btnAtualizarCampo.Text = "Atualizar Campo";
            this.btnAtualizarCampo.UseVisualStyleBackColor = true;
            this.btnAtualizarCampo.Click += new System.EventHandler(this.btnAtualizarCampo_Click);
            // 
            // btnAbortarImpressoes
            // 
            this.btnAbortarImpressoes.Location = new System.Drawing.Point(12, 722);
            this.btnAbortarImpressoes.Name = "btnAbortarImpressoes";
            this.btnAbortarImpressoes.Size = new System.Drawing.Size(139, 23);
            this.btnAbortarImpressoes.TabIndex = 15;
            this.btnAbortarImpressoes.Text = "Abortar Impressoes";
            this.btnAbortarImpressoes.UseVisualStyleBackColor = true;
            this.btnAbortarImpressoes.Click += new System.EventHandler(this.btnAbortarImpressoes_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(119, 693);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Definir Impressoes";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txbQuantidade
            // 
            this.txbQuantidade.Location = new System.Drawing.Point(13, 693);
            this.txbQuantidade.Name = "txbQuantidade";
            this.txbQuantidade.Size = new System.Drawing.Size(100, 23);
            this.txbQuantidade.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 628);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nome Campo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 628);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Conteudo Campo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 675);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "Quantidade Impressoes:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 766);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbQuantidade);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAbortarImpressoes);
            this.Controls.Add(this.btnAtualizarCampo);
            this.Controls.Add(this.btnEnviarCampo);
            this.Controls.Add(this.txbConteudoCampo);
            this.Controls.Add(this.txbNomeCampo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblPorta);
            this.Controls.Add(this.txbPorta);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.txbIP1);
            this.Controls.Add(this.txbIP2);
            this.Controls.Add(this.txbIP3);
            this.Controls.Add(this.txbIP4);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.btnTrigger);
            this.Controls.Add(this.btnSolicitarStatus);
            this.Name = "Form1";
            this.Text = "Supervisor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSolicitarStatus;
        private System.Windows.Forms.Button btnTrigger;
        private System.Windows.Forms.ListBox lstLog;
        private TcpClient tcpEtiquetadora;
        private System.Windows.Forms.TextBox txbIP4;
        private System.Windows.Forms.TextBox txbIP3;
        private System.Windows.Forms.TextBox txbIP2;
        private System.Windows.Forms.TextBox txbIP1;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.TextBox txbPorta;
        private System.Windows.Forms.Label lblPorta;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txbNomeCampo;
        private System.Windows.Forms.TextBox txbConteudoCampo;
        private System.Windows.Forms.Button btnEnviarCampo;
        private System.Windows.Forms.Button btnAtualizarCampo;
        private System.Windows.Forms.Button btnAbortarImpressoes;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txbQuantidade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

