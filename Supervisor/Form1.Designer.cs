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
            this.SuspendLayout();
            // 
            // btnSolicitarStatus
            // 
            this.btnSolicitarStatus.Location = new System.Drawing.Point(140, 815);
            this.btnSolicitarStatus.Name = "btnSolicitarStatus";
            this.btnSolicitarStatus.Size = new System.Drawing.Size(139, 23);
            this.btnSolicitarStatus.TabIndex = 0;
            this.btnSolicitarStatus.Text = "Solicitar Status";
            this.btnSolicitarStatus.UseVisualStyleBackColor = true;
            this.btnSolicitarStatus.Click += new System.EventHandler(this.btnSolicitarStatus_Click);
            // 
            // btnTrigger
            // 
            this.btnTrigger.Location = new System.Drawing.Point(474, 815);
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
            this.lstLog.Size = new System.Drawing.Size(766, 739);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 850);
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
    }
}

