namespace TransporteFortin
{
    partial class frmIngresoCheques
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
            this.gbcheqt = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtnrochequet = new System.Windows.Forms.TextBox();
            this.mskfechachequet = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtcomchequet = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtchequet = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbcuentaT = new System.Windows.Forms.ComboBox();
            this.btncf = new System.Windows.Forms.Button();
            this.gbcheqt.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbcheqt
            // 
            this.gbcheqt.Controls.Add(this.btncf);
            this.gbcheqt.Controls.Add(this.label17);
            this.gbcheqt.Controls.Add(this.txtnrochequet);
            this.gbcheqt.Controls.Add(this.mskfechachequet);
            this.gbcheqt.Controls.Add(this.label10);
            this.gbcheqt.Controls.Add(this.label7);
            this.gbcheqt.Controls.Add(this.txtcomchequet);
            this.gbcheqt.Controls.Add(this.label8);
            this.gbcheqt.Controls.Add(this.txtchequet);
            this.gbcheqt.Controls.Add(this.label9);
            this.gbcheqt.Controls.Add(this.cmbcuentaT);
            this.gbcheqt.Location = new System.Drawing.Point(12, 12);
            this.gbcheqt.Name = "gbcheqt";
            this.gbcheqt.Size = new System.Drawing.Size(554, 174);
            this.gbcheqt.TabIndex = 154;
            this.gbcheqt.TabStop = false;
            this.gbcheqt.Text = "CHEQUE TERCERO";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(4, 107);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 13);
            this.label17.TabIndex = 166;
            this.label17.Text = "Nro Cheque";
            // 
            // txtnrochequet
            // 
            this.txtnrochequet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnrochequet.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnrochequet.Location = new System.Drawing.Point(85, 105);
            this.txtnrochequet.MaxLength = 8;
            this.txtnrochequet.Name = "txtnrochequet";
            this.txtnrochequet.Size = new System.Drawing.Size(100, 21);
            this.txtnrochequet.TabIndex = 3;
            // 
            // mskfechachequet
            // 
            this.mskfechachequet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mskfechachequet.Location = new System.Drawing.Point(114, 51);
            this.mskfechachequet.Mask = "00/00/0000";
            this.mskfechachequet.Name = "mskfechachequet";
            this.mskfechachequet.Size = new System.Drawing.Size(69, 20);
            this.mskfechachequet.TabIndex = 1;
            this.mskfechachequet.ValidatingType = typeof(System.DateTime);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 13);
            this.label10.TabIndex = 161;
            this.label10.Text = "Fecha Deposito";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 160;
            this.label7.Text = "Comentario";
            // 
            // txtcomchequet
            // 
            this.txtcomchequet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcomchequet.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcomchequet.Location = new System.Drawing.Point(85, 135);
            this.txtcomchequet.Name = "txtcomchequet";
            this.txtcomchequet.Size = new System.Drawing.Size(463, 21);
            this.txtcomchequet.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 158;
            this.label8.Text = "Importe";
            // 
            // txtchequet
            // 
            this.txtchequet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtchequet.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtchequet.Location = new System.Drawing.Point(85, 77);
            this.txtchequet.Name = "txtchequet";
            this.txtchequet.Size = new System.Drawing.Size(112, 21);
            this.txtchequet.TabIndex = 2;
            this.txtchequet.Text = "0.00";
            this.txtchequet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(37, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 156;
            this.label9.Text = "Banco";
            // 
            // cmbcuentaT
            // 
            this.cmbcuentaT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcuentaT.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.cmbcuentaT.FormattingEnabled = true;
            this.cmbcuentaT.Location = new System.Drawing.Point(85, 21);
            this.cmbcuentaT.Name = "cmbcuentaT";
            this.cmbcuentaT.Size = new System.Drawing.Size(242, 21);
            this.cmbcuentaT.TabIndex = 0;
            // 
            // btncf
            // 
            this.btncf.BackColor = System.Drawing.SystemColors.Control;
            this.btncf.BackgroundImage = global::TransporteFortin.Properties.Resources.Symbol_Check;
            this.btncf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btncf.Location = new System.Drawing.Point(317, 66);
            this.btncf.Name = "btncf";
            this.btncf.Size = new System.Drawing.Size(41, 38);
            this.btncf.TabIndex = 5;
            this.btncf.UseVisualStyleBackColor = false;
            this.btncf.Click += new System.EventHandler(this.btncf_Click);
            // 
            // frmIngresoCheques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 193);
            this.Controls.Add(this.gbcheqt);
            this.Name = "frmIngresoCheques";
            this.Text = "frmIngresoCheques";
            this.Load += new System.EventHandler(this.frmIngresoCheques_Load);
            this.gbcheqt.ResumeLayout(false);
            this.gbcheqt.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbcheqt;
        private System.Windows.Forms.Button btncf;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtnrochequet;
        private System.Windows.Forms.MaskedTextBox mskfechachequet;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtcomchequet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtchequet;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbcuentaT;
    }
}