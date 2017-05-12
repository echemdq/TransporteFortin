namespace TransporteFortin
{
    partial class frmDepositoCheque
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label15 = new System.Windows.Forms.Label();
            this.cmbcuentap = new System.Windows.Forms.ComboBox();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.txtimporte = new System.Windows.Forms.TextBox();
            this.txtnro = new System.Windows.Forms.TextBox();
            this.txtfechadep = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Numero = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(12, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(116, 13);
            this.label15.TabIndex = 158;
            this.label15.Text = "Cuenta a depositar";
            // 
            // cmbcuentap
            // 
            this.cmbcuentap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcuentap.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.cmbcuentap.FormattingEnabled = true;
            this.cmbcuentap.Location = new System.Drawing.Point(134, 12);
            this.cmbcuentap.Name = "cmbcuentap";
            this.cmbcuentap.Size = new System.Drawing.Size(242, 21);
            this.cmbcuentap.TabIndex = 157;
            // 
            // txtBanco
            // 
            this.txtBanco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBanco.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtBanco.Location = new System.Drawing.Point(134, 93);
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.ReadOnly = true;
            this.txtBanco.Size = new System.Drawing.Size(204, 21);
            this.txtBanco.TabIndex = 166;
            // 
            // txtimporte
            // 
            this.txtimporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtimporte.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtimporte.Location = new System.Drawing.Point(134, 66);
            this.txtimporte.Name = "txtimporte";
            this.txtimporte.ReadOnly = true;
            this.txtimporte.Size = new System.Drawing.Size(100, 21);
            this.txtimporte.TabIndex = 165;
            // 
            // txtnro
            // 
            this.txtnro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnro.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtnro.Location = new System.Drawing.Point(134, 39);
            this.txtnro.Name = "txtnro";
            this.txtnro.ReadOnly = true;
            this.txtnro.Size = new System.Drawing.Size(100, 21);
            this.txtnro.TabIndex = 164;
            // 
            // txtfechadep
            // 
            this.txtfechadep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfechadep.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtfechadep.Location = new System.Drawing.Point(134, 120);
            this.txtfechadep.Name = "txtfechadep";
            this.txtfechadep.ReadOnly = true;
            this.txtfechadep.Size = new System.Drawing.Size(100, 21);
            this.txtfechadep.TabIndex = 163;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label9.Location = new System.Drawing.Point(86, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 162;
            this.label9.Text = "Banco";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label7.Location = new System.Drawing.Point(75, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 161;
            this.label7.Text = "Importe";
            // 
            // Numero
            // 
            this.Numero.AutoSize = true;
            this.Numero.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.Numero.Location = new System.Drawing.Point(76, 41);
            this.Numero.Name = "Numero";
            this.Numero.Size = new System.Drawing.Size(52, 13);
            this.Numero.TabIndex = 160;
            this.Numero.Text = "Numero";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label2.Location = new System.Drawing.Point(34, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 159;
            this.label2.Text = "Fecha Deposito";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Control;
            this.button4.BackgroundImage = global::TransporteFortin.Properties.Resources.Symbol_Check;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(418, 52);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(45, 45);
            this.button4.TabIndex = 167;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // frmDepositoCheque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 153);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtBanco);
            this.Controls.Add(this.txtimporte);
            this.Controls.Add(this.txtnro);
            this.Controls.Add(this.txtfechadep);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Numero);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cmbcuentap);
            this.Name = "frmDepositoCheque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Depositar Cheque en Banco";
            this.Load += new System.EventHandler(this.frmDepositoCheque_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbcuentap;
        private System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.TextBox txtimporte;
        private System.Windows.Forms.TextBox txtnro;
        private System.Windows.Forms.TextBox txtfechadep;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label Numero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
    }
}