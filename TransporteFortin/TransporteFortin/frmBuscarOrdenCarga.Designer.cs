namespace TransporteFortin
{
    partial class frmBuscarOrdenCarga
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarOrdenCarga));
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtFletero = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSucursal = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblFletero = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.mskHasta = new System.Windows.Forms.MaskedTextBox();
            this.mskDesde = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbValNo = new System.Windows.Forms.RadioButton();
            this.rbValVal = new System.Windows.Forms.RadioButton();
            this.rbValTodas = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbEsNoAnu = new System.Windows.Forms.RadioButton();
            this.rbEsAnu = new System.Windows.Forms.RadioButton();
            this.rbEsTodas = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox8.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCliente
            // 
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCliente.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(70, 73);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(253, 21);
            this.txtCliente.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 57;
            this.label1.Text = "Cliente:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.Control;
            this.btnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.BackgroundImage")));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.Location = new System.Drawing.Point(338, 63);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(41, 38);
            this.btnBuscar.TabIndex = 56;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(338, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 38);
            this.button1.TabIndex = 59;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFletero
            // 
            this.txtFletero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFletero.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFletero.Location = new System.Drawing.Point(70, 112);
            this.txtFletero.Name = "txtFletero";
            this.txtFletero.ReadOnly = true;
            this.txtFletero.Size = new System.Drawing.Size(253, 21);
            this.txtFletero.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "Fletero:";
            // 
            // cmbSucursal
            // 
            this.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSucursal.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.cmbSucursal.FormattingEnabled = true;
            this.cmbSucursal.Location = new System.Drawing.Point(70, 35);
            this.cmbSucursal.Name = "cmbSucursal";
            this.cmbSucursal.Size = new System.Drawing.Size(309, 21);
            this.cmbSucursal.TabIndex = 61;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 62;
            this.label3.Text = "Sucursal:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 13);
            this.label4.TabIndex = 63;
            this.label4.Text = "Nro Orden de Carga:";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(136, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(51, 21);
            this.textBox1.TabIndex = 64;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(193, 7);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(106, 21);
            this.textBox2.TabIndex = 65;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(333, 13);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(0, 13);
            this.lblCliente.TabIndex = 66;
            this.lblCliente.Visible = false;
            // 
            // lblFletero
            // 
            this.lblFletero.AutoSize = true;
            this.lblFletero.Location = new System.Drawing.Point(308, 12);
            this.lblFletero.Name = "lblFletero";
            this.lblFletero.Size = new System.Drawing.Size(0, 13);
            this.lblFletero.TabIndex = 67;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.mskHasta);
            this.groupBox8.Controls.Add(this.mskDesde);
            this.groupBox8.Controls.Add(this.label6);
            this.groupBox8.Controls.Add(this.label5);
            this.groupBox8.Font = new System.Drawing.Font("Verdana", 8F);
            this.groupBox8.Location = new System.Drawing.Point(14, 146);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(365, 61);
            this.groupBox8.TabIndex = 68;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Fecha de Emision";
            // 
            // mskHasta
            // 
            this.mskHasta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mskHasta.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.mskHasta.Location = new System.Drawing.Point(219, 22);
            this.mskHasta.Mask = "00/00/0000";
            this.mskHasta.Name = "mskHasta";
            this.mskHasta.Size = new System.Drawing.Size(100, 21);
            this.mskHasta.TabIndex = 61;
            this.mskHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskHasta.ValidatingType = typeof(System.DateTime);
            // 
            // mskDesde
            // 
            this.mskDesde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mskDesde.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.mskDesde.Location = new System.Drawing.Point(65, 22);
            this.mskDesde.Mask = "00/00/0000";
            this.mskDesde.Name = "mskDesde";
            this.mskDesde.Size = new System.Drawing.Size(100, 21);
            this.mskDesde.TabIndex = 60;
            this.mskDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskDesde.ValidatingType = typeof(System.DateTime);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(176, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 59;
            this.label6.Text = "Hasta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 58;
            this.label5.Text = "Desde:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbValNo);
            this.groupBox1.Controls.Add(this.rbValVal);
            this.groupBox1.Controls.Add(this.rbValTodas);
            this.groupBox1.Location = new System.Drawing.Point(14, 216);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(147, 94);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Valorizacion Orden Carga";
            // 
            // rbValNo
            // 
            this.rbValNo.AutoSize = true;
            this.rbValNo.Location = new System.Drawing.Point(8, 65);
            this.rbValNo.Name = "rbValNo";
            this.rbValNo.Size = new System.Drawing.Size(96, 17);
            this.rbValNo.TabIndex = 2;
            this.rbValNo.Text = "No Valorizadas";
            this.rbValNo.UseVisualStyleBackColor = true;
            // 
            // rbValVal
            // 
            this.rbValVal.AutoSize = true;
            this.rbValVal.Location = new System.Drawing.Point(8, 41);
            this.rbValVal.Name = "rbValVal";
            this.rbValVal.Size = new System.Drawing.Size(79, 17);
            this.rbValVal.TabIndex = 1;
            this.rbValVal.Text = "Valorizadas";
            this.rbValVal.UseVisualStyleBackColor = true;
            // 
            // rbValTodas
            // 
            this.rbValTodas.AutoSize = true;
            this.rbValTodas.Checked = true;
            this.rbValTodas.Location = new System.Drawing.Point(8, 17);
            this.rbValTodas.Name = "rbValTodas";
            this.rbValTodas.Size = new System.Drawing.Size(55, 17);
            this.rbValTodas.TabIndex = 0;
            this.rbValTodas.TabStop = true;
            this.rbValTodas.Text = "Todas";
            this.rbValTodas.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbEsNoAnu);
            this.groupBox2.Controls.Add(this.rbEsAnu);
            this.groupBox2.Controls.Add(this.rbEsTodas);
            this.groupBox2.Location = new System.Drawing.Point(167, 216);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(147, 94);
            this.groupBox2.TabIndex = 70;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Estado Orden Carga";
            // 
            // rbEsNoAnu
            // 
            this.rbEsNoAnu.AutoSize = true;
            this.rbEsNoAnu.Checked = true;
            this.rbEsNoAnu.Location = new System.Drawing.Point(8, 65);
            this.rbEsNoAnu.Name = "rbEsNoAnu";
            this.rbEsNoAnu.Size = new System.Drawing.Size(86, 17);
            this.rbEsNoAnu.TabIndex = 2;
            this.rbEsNoAnu.TabStop = true;
            this.rbEsNoAnu.Text = "No Anuladas";
            this.rbEsNoAnu.UseVisualStyleBackColor = true;
            // 
            // rbEsAnu
            // 
            this.rbEsAnu.AutoSize = true;
            this.rbEsAnu.Location = new System.Drawing.Point(8, 41);
            this.rbEsAnu.Name = "rbEsAnu";
            this.rbEsAnu.Size = new System.Drawing.Size(69, 17);
            this.rbEsAnu.TabIndex = 1;
            this.rbEsAnu.Text = "Anuladas";
            this.rbEsAnu.UseVisualStyleBackColor = true;
            // 
            // rbEsTodas
            // 
            this.rbEsTodas.AutoSize = true;
            this.rbEsTodas.Location = new System.Drawing.Point(8, 17);
            this.rbEsTodas.Name = "rbEsTodas";
            this.rbEsTodas.Size = new System.Drawing.Size(55, 17);
            this.rbEsTodas.TabIndex = 0;
            this.rbEsTodas.Text = "Todas";
            this.rbEsTodas.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::TransporteFortin.Properties.Resources.Undo;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(338, 222);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(41, 38);
            this.button2.TabIndex = 72;
            this.toolTip1.SetToolTip(this.button2, "Limpiar Campos");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(338, 270);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(41, 38);
            this.button3.TabIndex = 73;
            this.toolTip1.SetToolTip(this.button3, "Buscar Ordenes");
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmBuscarOrdenCarga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 313);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.lblFletero);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbSucursal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtFletero);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(413, 351);
            this.MinimumSize = new System.Drawing.Size(413, 351);
            this.Name = "frmBuscarOrdenCarga";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Orden de Carga";
            this.Load += new System.EventHandler(this.frmBuscarOrdenCarga_Load);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtFletero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSucursal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblFletero;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.MaskedTextBox mskHasta;
        private System.Windows.Forms.MaskedTextBox mskDesde;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbValNo;
        private System.Windows.Forms.RadioButton rbValVal;
        private System.Windows.Forms.RadioButton rbValTodas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbEsNoAnu;
        private System.Windows.Forms.RadioButton rbEsAnu;
        private System.Windows.Forms.RadioButton rbEsTodas;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}