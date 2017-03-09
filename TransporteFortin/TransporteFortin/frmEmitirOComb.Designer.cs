namespace TransporteFortin
{
    partial class frmEmitirOComb
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmitirOComb));
            this.label15 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtProvedor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrecioComb = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtChapaCamion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtFletero = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLitros = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.txtImporteFinal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.lblFletero = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(73, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(183, 13);
            this.label15.TabIndex = 107;
            this.label15.Text = "Emisión Orden de Combustible";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBox1.Location = new System.Drawing.Point(262, 12);
            this.maskedTextBox1.Mask = "00/00/0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(83, 21);
            this.maskedTextBox1.TabIndex = 106;
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblProveedor);
            this.groupBox1.Controls.Add(this.txtPrecioComb);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtProvedor);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 100);
            this.groupBox1.TabIndex = 108;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PROVEEDOR";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(348, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 35);
            this.button1.TabIndex = 83;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtProvedor
            // 
            this.txtProvedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProvedor.Enabled = false;
            this.txtProvedor.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProvedor.Location = new System.Drawing.Point(6, 20);
            this.txtProvedor.Name = "txtProvedor";
            this.txtProvedor.ReadOnly = true;
            this.txtProvedor.Size = new System.Drawing.Size(336, 21);
            this.txtProvedor.TabIndex = 84;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 85;
            this.label1.Text = "Precio Combustible:";
            // 
            // txtPrecioComb
            // 
            this.txtPrecioComb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioComb.Location = new System.Drawing.Point(211, 59);
            this.txtPrecioComb.Name = "txtPrecioComb";
            this.txtPrecioComb.ReadOnly = true;
            this.txtPrecioComb.Size = new System.Drawing.Size(100, 21);
            this.txtPrecioComb.TabIndex = 86;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblFletero);
            this.groupBox2.Controls.Add(this.txtChapaCamion);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.txtFletero);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(387, 100);
            this.groupBox2.TabIndex = 109;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FLETERO";
            // 
            // txtChapaCamion
            // 
            this.txtChapaCamion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChapaCamion.Location = new System.Drawing.Point(188, 60);
            this.txtChapaCamion.Name = "txtChapaCamion";
            this.txtChapaCamion.ReadOnly = true;
            this.txtChapaCamion.Size = new System.Drawing.Size(100, 21);
            this.txtChapaCamion.TabIndex = 86;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 85;
            this.label2.Text = "Patente Camión:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(348, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(33, 35);
            this.button2.TabIndex = 83;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtFletero
            // 
            this.txtFletero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFletero.Enabled = false;
            this.txtFletero.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFletero.Location = new System.Drawing.Point(6, 20);
            this.txtFletero.Name = "txtFletero";
            this.txtFletero.ReadOnly = true;
            this.txtFletero.Size = new System.Drawing.Size(336, 21);
            this.txtFletero.TabIndex = 84;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label3.Location = new System.Drawing.Point(14, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 110;
            this.label3.Text = "Litros a Cargar:";
            // 
            // txtLitros
            // 
            this.txtLitros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLitros.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLitros.Location = new System.Drawing.Point(111, 251);
            this.txtLitros.Name = "txtLitros";
            this.txtLitros.Size = new System.Drawing.Size(105, 21);
            this.txtLitros.TabIndex = 111;
            this.txtLitros.Text = "0.00";
            this.txtLitros.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLitros_KeyPress);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(43, 278);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(144, 23);
            this.button5.TabIndex = 112;
            this.button5.Text = "Calcular Valores";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // txtImporteFinal
            // 
            this.txtImporteFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImporteFinal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporteFinal.Location = new System.Drawing.Point(111, 307);
            this.txtImporteFinal.Name = "txtImporteFinal";
            this.txtImporteFinal.ReadOnly = true;
            this.txtImporteFinal.Size = new System.Drawing.Size(105, 21);
            this.txtImporteFinal.TabIndex = 114;
            this.txtImporteFinal.Text = "0.00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label4.Location = new System.Drawing.Point(22, 309);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 113;
            this.label4.Text = "Importe Final:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(292, 264);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 58);
            this.button3.TabIndex = 115;
            this.button3.Text = "GENERAR";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Location = new System.Drawing.Point(19, 66);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(0, 13);
            this.lblProveedor.TabIndex = 87;
            this.lblProveedor.Visible = false;
            // 
            // lblFletero
            // 
            this.lblFletero.AutoSize = true;
            this.lblFletero.Location = new System.Drawing.Point(17, 61);
            this.lblFletero.Name = "lblFletero";
            this.lblFletero.Size = new System.Drawing.Size(0, 13);
            this.lblFletero.TabIndex = 87;
            this.lblFletero.Visible = false;
            // 
            // frmEmitirOComb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 338);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtImporteFinal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.txtLitros);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.maskedTextBox1);
            this.Name = "frmEmitirOComb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emitir Orden Combustible";
            this.Load += new System.EventHandler(this.frmEmitirOComb_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtProvedor;
        private System.Windows.Forms.TextBox txtPrecioComb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtChapaCamion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtFletero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLitros;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txtImporteFinal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label lblFletero;
    }
}