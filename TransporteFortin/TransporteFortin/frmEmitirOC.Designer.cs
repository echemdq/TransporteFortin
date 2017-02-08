namespace TransporteFortin
{
    partial class frmEmitirOC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmitirOC));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSucursal = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblDireccionCte = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSucursal);
            this.groupBox1.Controls.Add(this.maskedTextBox1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.txtSucursal);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.groupBox1.Location = new System.Drawing.Point(1, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(642, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sucursal";
            // 
            // txtSucursal
            // 
            this.txtSucursal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSucursal.Enabled = false;
            this.txtSucursal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSucursal.Location = new System.Drawing.Point(11, 17);
            this.txtSucursal.Name = "txtSucursal";
            this.txtSucursal.ReadOnly = true;
            this.txtSucursal.Size = new System.Drawing.Size(268, 21);
            this.txtSucursal.TabIndex = 80;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(285, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(33, 35);
            this.button2.TabIndex = 79;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.maskedTextBox1.Location = new System.Drawing.Point(553, 16);
            this.maskedTextBox1.Mask = "00/00/0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(83, 21);
            this.maskedTextBox1.TabIndex = 81;
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblDireccionCte);
            this.groupBox2.Controls.Add(this.lblCliente);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.txtCliente);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.groupBox2.Location = new System.Drawing.Point(1, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(642, 87);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del Cliente";
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Location = new System.Drawing.Point(355, 17);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(69, 13);
            this.lblSucursal.TabIndex = 82;
            this.lblSucursal.Text = "lblSucursal";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(285, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 35);
            this.button1.TabIndex = 81;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // txtCliente
            // 
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCliente.Enabled = false;
            this.txtCliente.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(11, 23);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(268, 21);
            this.txtCliente.TabIndex = 82;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(347, 19);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(60, 13);
            this.lblCliente.TabIndex = 83;
            this.lblCliente.Text = "lblCliente";
            // 
            // lblDireccionCte
            // 
            this.lblDireccionCte.AutoSize = true;
            this.lblDireccionCte.Location = new System.Drawing.Point(11, 57);
            this.lblDireccionCte.Name = "lblDireccionCte";
            this.lblDireccionCte.Size = new System.Drawing.Size(69, 13);
            this.lblDireccionCte.TabIndex = 84;
            this.lblDireccionCte.Text = "Dirección: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(480, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 85;
            this.label1.Text = "Saldo:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 11F);
            this.textBox1.Location = new System.Drawing.Point(522, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(115, 18);
            this.textBox1.TabIndex = 86;
            this.textBox1.Text = "$0,00";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmEmitirOC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 406);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmEmitirOC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emitir Orden de Carga";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtSucursal;
        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDireccionCte;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCliente;
    }
}