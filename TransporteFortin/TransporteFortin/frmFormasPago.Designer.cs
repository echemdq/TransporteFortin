namespace TransporteFortin
{
    partial class frmFormasPago
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
            this.cmbFormaPago = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbefectivo = new System.Windows.Forms.GroupBox();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnefect = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gbtransferencia = new System.Windows.Forms.GroupBox();
            this.cmbcuentatra = new System.Windows.Forms.ComboBox();
            this.btntransf = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txttransf = new System.Windows.Forms.TextBox();
            this.gbcheqt = new System.Windows.Forms.GroupBox();
            this.txtcomtran = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtcomefe = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtcomchequet = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtchequet = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbcuentaT = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.mskfechachequet = new System.Windows.Forms.MaskedTextBox();
            this.mskfechatra = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.gbchequep = new System.Windows.Forms.GroupBox();
            this.mskfechacheqep = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtcomcheqp = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtchequep = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbcuentap = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtnrochequep = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtnrochequet = new System.Windows.Forms.TextBox();
            this.btncp = new System.Windows.Forms.Button();
            this.btncf = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.txtsucursal = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtnrotransf = new System.Windows.Forms.TextBox();
            this.gbefectivo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbtransferencia.SuspendLayout();
            this.gbcheqt.SuspendLayout();
            this.gbchequep.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbFormaPago
            // 
            this.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormaPago.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.cmbFormaPago.FormattingEnabled = true;
            this.cmbFormaPago.Location = new System.Drawing.Point(111, 12);
            this.cmbFormaPago.Name = "cmbFormaPago";
            this.cmbFormaPago.Size = new System.Drawing.Size(281, 21);
            this.cmbFormaPago.TabIndex = 129;
            this.cmbFormaPago.SelectedIndexChanged += new System.EventHandler(this.cmbFormaPago_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 132;
            this.label1.Text = "Forma de Pago";
            // 
            // gbefectivo
            // 
            this.gbefectivo.Controls.Add(this.label6);
            this.gbefectivo.Controls.Add(this.txtcomefe);
            this.gbefectivo.Controls.Add(this.label2);
            this.gbefectivo.Controls.Add(this.btnefect);
            this.gbefectivo.Controls.Add(this.txtEfectivo);
            this.gbefectivo.Location = new System.Drawing.Point(12, 39);
            this.gbefectivo.Name = "gbefectivo";
            this.gbefectivo.Size = new System.Drawing.Size(377, 88);
            this.gbefectivo.TabIndex = 133;
            this.gbefectivo.TabStop = false;
            this.gbefectivo.Text = "EFECTIVO";
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEfectivo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivo.Location = new System.Drawing.Point(84, 28);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(112, 21);
            this.txtEfectivo.TabIndex = 139;
            this.txtEfectivo.Text = "0.00";
            this.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEfectivo_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 140;
            this.label2.Text = "Importe";
            // 
            // btnefect
            // 
            this.btnefect.BackColor = System.Drawing.SystemColors.Control;
            this.btnefect.BackgroundImage = global::TransporteFortin.Properties.Resources.Symbol_Check;
            this.btnefect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnefect.Location = new System.Drawing.Point(330, 15);
            this.btnefect.Name = "btnefect";
            this.btnefect.Size = new System.Drawing.Size(41, 38);
            this.btnefect.TabIndex = 145;
            this.btnefect.UseVisualStyleBackColor = false;
            this.btnefect.Click += new System.EventHandler(this.btnefect_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 248);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(386, 122);
            this.dataGridView1.TabIndex = 146;
            // 
            // gbtransferencia
            // 
            this.gbtransferencia.Controls.Add(this.label19);
            this.gbtransferencia.Controls.Add(this.txtnrotransf);
            this.gbtransferencia.Controls.Add(this.mskfechatra);
            this.gbtransferencia.Controls.Add(this.label11);
            this.gbtransferencia.Controls.Add(this.label5);
            this.gbtransferencia.Controls.Add(this.txtcomtran);
            this.gbtransferencia.Controls.Add(this.label4);
            this.gbtransferencia.Controls.Add(this.txttransf);
            this.gbtransferencia.Controls.Add(this.label3);
            this.gbtransferencia.Controls.Add(this.btntransf);
            this.gbtransferencia.Controls.Add(this.cmbcuentatra);
            this.gbtransferencia.Location = new System.Drawing.Point(483, 12);
            this.gbtransferencia.Name = "gbtransferencia";
            this.gbtransferencia.Size = new System.Drawing.Size(377, 167);
            this.gbtransferencia.TabIndex = 147;
            this.gbtransferencia.TabStop = false;
            this.gbtransferencia.Text = "TRANSFERENCIA";
            // 
            // cmbcuentatra
            // 
            this.cmbcuentatra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcuentatra.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.cmbcuentatra.FormattingEnabled = true;
            this.cmbcuentatra.Location = new System.Drawing.Point(84, 25);
            this.cmbcuentatra.Name = "cmbcuentatra";
            this.cmbcuentatra.Size = new System.Drawing.Size(242, 21);
            this.cmbcuentatra.TabIndex = 148;
            // 
            // btntransf
            // 
            this.btntransf.BackColor = System.Drawing.SystemColors.Control;
            this.btntransf.BackgroundImage = global::TransporteFortin.Properties.Resources.Symbol_Check;
            this.btntransf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btntransf.Location = new System.Drawing.Point(330, 35);
            this.btntransf.Name = "btntransf";
            this.btntransf.Size = new System.Drawing.Size(41, 38);
            this.btntransf.TabIndex = 149;
            this.btntransf.UseVisualStyleBackColor = false;
            this.btntransf.Click += new System.EventHandler(this.btntransf_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 150;
            this.label3.Text = "Banco";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 152;
            this.label4.Text = "Importe";
            // 
            // txttransf
            // 
            this.txttransf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttransf.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttransf.Location = new System.Drawing.Point(84, 52);
            this.txttransf.Name = "txttransf";
            this.txttransf.Size = new System.Drawing.Size(112, 21);
            this.txttransf.TabIndex = 151;
            this.txttransf.Text = "0.00";
            this.txttransf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txttransf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttransf_KeyPress);
            // 
            // gbcheqt
            // 
            this.gbcheqt.Controls.Add(this.label18);
            this.gbcheqt.Controls.Add(this.txtsucursal);
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
            this.gbcheqt.Location = new System.Drawing.Point(484, 185);
            this.gbcheqt.Name = "gbcheqt";
            this.gbcheqt.Size = new System.Drawing.Size(377, 160);
            this.gbcheqt.TabIndex = 153;
            this.gbcheqt.TabStop = false;
            this.gbcheqt.Text = "CHEQUE TERCERO";
            // 
            // txtcomtran
            // 
            this.txtcomtran.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcomtran.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcomtran.Location = new System.Drawing.Point(84, 133);
            this.txtcomtran.Name = "txtcomtran";
            this.txtcomtran.Size = new System.Drawing.Size(287, 21);
            this.txtcomtran.TabIndex = 153;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 154;
            this.label5.Text = "Comentario";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 156;
            this.label6.Text = "Comentario";
            // 
            // txtcomefe
            // 
            this.txtcomefe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcomefe.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcomefe.Location = new System.Drawing.Point(84, 56);
            this.txtcomefe.Name = "txtcomefe";
            this.txtcomefe.Size = new System.Drawing.Size(287, 21);
            this.txtcomefe.TabIndex = 155;
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
            this.txtcomchequet.Size = new System.Drawing.Size(287, 21);
            this.txtcomchequet.TabIndex = 159;
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
            this.txtchequet.TabIndex = 157;
            this.txtchequet.Text = "0.00";
            this.txtchequet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtchequet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
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
            this.cmbcuentaT.TabIndex = 155;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(196, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 161;
            this.label10.Text = "Fecha";
            // 
            // mskfechachequet
            // 
            this.mskfechachequet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mskfechachequet.Location = new System.Drawing.Point(242, 105);
            this.mskfechachequet.Mask = "00/00/0000";
            this.mskfechachequet.Name = "mskfechachequet";
            this.mskfechachequet.Size = new System.Drawing.Size(100, 20);
            this.mskfechachequet.TabIndex = 162;
            this.mskfechachequet.ValidatingType = typeof(System.DateTime);
            // 
            // mskfechatra
            // 
            this.mskfechatra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mskfechatra.Location = new System.Drawing.Point(84, 79);
            this.mskfechatra.Mask = "00/00/0000";
            this.mskfechatra.Name = "mskfechatra";
            this.mskfechatra.Size = new System.Drawing.Size(100, 20);
            this.mskfechatra.TabIndex = 164;
            this.mskfechatra.ValidatingType = typeof(System.DateTime);
            this.mskfechatra.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox2_MaskInputRejected);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(38, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 163;
            this.label11.Text = "Fecha";
            // 
            // gbchequep
            // 
            this.gbchequep.Controls.Add(this.btncp);
            this.gbchequep.Controls.Add(this.label16);
            this.gbchequep.Controls.Add(this.txtnrochequep);
            this.gbchequep.Controls.Add(this.mskfechacheqep);
            this.gbchequep.Controls.Add(this.label12);
            this.gbchequep.Controls.Add(this.label13);
            this.gbchequep.Controls.Add(this.txtcomcheqp);
            this.gbchequep.Controls.Add(this.label14);
            this.gbchequep.Controls.Add(this.txtchequep);
            this.gbchequep.Controls.Add(this.label15);
            this.gbchequep.Controls.Add(this.cmbcuentap);
            this.gbchequep.Location = new System.Drawing.Point(50, 173);
            this.gbchequep.Name = "gbchequep";
            this.gbchequep.Size = new System.Drawing.Size(377, 172);
            this.gbchequep.TabIndex = 154;
            this.gbchequep.TabStop = false;
            this.gbchequep.Text = "CHEQUE PROPIO";
            // 
            // mskfechacheqep
            // 
            this.mskfechacheqep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mskfechacheqep.Location = new System.Drawing.Point(85, 74);
            this.mskfechacheqep.Mask = "00/00/0000";
            this.mskfechacheqep.Name = "mskfechacheqep";
            this.mskfechacheqep.Size = new System.Drawing.Size(100, 20);
            this.mskfechacheqep.TabIndex = 162;
            this.mskfechacheqep.ValidatingType = typeof(System.DateTime);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(39, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 161;
            this.label12.Text = "Fecha";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(5, 130);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 13);
            this.label13.TabIndex = 160;
            this.label13.Text = "Comentario";
            // 
            // txtcomcheqp
            // 
            this.txtcomcheqp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcomcheqp.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcomcheqp.Location = new System.Drawing.Point(85, 128);
            this.txtcomcheqp.Name = "txtcomcheqp";
            this.txtcomcheqp.Size = new System.Drawing.Size(287, 21);
            this.txtcomcheqp.TabIndex = 159;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(27, 50);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 158;
            this.label14.Text = "Importe";
            // 
            // txtchequep
            // 
            this.txtchequep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtchequep.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtchequep.Location = new System.Drawing.Point(85, 48);
            this.txtchequep.Name = "txtchequep";
            this.txtchequep.Size = new System.Drawing.Size(112, 21);
            this.txtchequep.TabIndex = 157;
            this.txtchequep.Text = "0.00";
            this.txtchequep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(37, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 13);
            this.label15.TabIndex = 156;
            this.label15.Text = "Banco";
            // 
            // cmbcuentap
            // 
            this.cmbcuentap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcuentap.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.cmbcuentap.FormattingEnabled = true;
            this.cmbcuentap.Location = new System.Drawing.Point(85, 21);
            this.cmbcuentap.Name = "cmbcuentap";
            this.cmbcuentap.Size = new System.Drawing.Size(242, 21);
            this.cmbcuentap.TabIndex = 155;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(4, 103);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 13);
            this.label16.TabIndex = 164;
            this.label16.Text = "Nro Cheque";
            // 
            // txtnrochequep
            // 
            this.txtnrochequep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnrochequep.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnrochequep.Location = new System.Drawing.Point(85, 101);
            this.txtnrochequep.Name = "txtnrochequep";
            this.txtnrochequep.Size = new System.Drawing.Size(100, 21);
            this.txtnrochequep.TabIndex = 163;
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
            this.txtnrochequet.Name = "txtnrochequet";
            this.txtnrochequet.Size = new System.Drawing.Size(100, 21);
            this.txtnrochequet.TabIndex = 165;
            // 
            // btncp
            // 
            this.btncp.BackColor = System.Drawing.SystemColors.Control;
            this.btncp.BackgroundImage = global::TransporteFortin.Properties.Resources.Symbol_Check;
            this.btncp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btncp.Location = new System.Drawing.Point(331, 52);
            this.btncp.Name = "btncp";
            this.btncp.Size = new System.Drawing.Size(41, 38);
            this.btncp.TabIndex = 165;
            this.btncp.UseVisualStyleBackColor = false;
            this.btncp.Click += new System.EventHandler(this.btncp_Click);
            // 
            // btncf
            // 
            this.btncf.BackColor = System.Drawing.SystemColors.Control;
            this.btncf.BackgroundImage = global::TransporteFortin.Properties.Resources.Symbol_Check;
            this.btncf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btncf.Location = new System.Drawing.Point(314, 54);
            this.btncf.Name = "btncf";
            this.btncf.Size = new System.Drawing.Size(41, 38);
            this.btncf.TabIndex = 167;
            this.btncf.UseVisualStyleBackColor = false;
            this.btncf.Click += new System.EventHandler(this.btncf_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(26, 52);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 13);
            this.label18.TabIndex = 169;
            this.label18.Text = "Sucursal";
            // 
            // txtsucursal
            // 
            this.txtsucursal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsucursal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsucursal.Location = new System.Drawing.Point(85, 48);
            this.txtsucursal.Name = "txtsucursal";
            this.txtsucursal.Size = new System.Drawing.Size(100, 21);
            this.txtsucursal.TabIndex = 168;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(-2, 108);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(85, 13);
            this.label19.TabIndex = 166;
            this.label19.Text = "Transferencia";
            // 
            // txtnrotransf
            // 
            this.txtnrotransf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnrotransf.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnrotransf.Location = new System.Drawing.Point(84, 105);
            this.txtnrotransf.Name = "txtnrotransf";
            this.txtnrotransf.Size = new System.Drawing.Size(100, 21);
            this.txtnrotransf.TabIndex = 165;
            // 
            // frmFormasPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 389);
            this.Controls.Add(this.gbchequep);
            this.Controls.Add(this.gbtransferencia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbFormaPago);
            this.Controls.Add(this.gbefectivo);
            this.Controls.Add(this.gbcheqt);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmFormasPago";
            this.Text = "Formas de Pago";
            this.Load += new System.EventHandler(this.frmFormasPago_Load);
            this.gbefectivo.ResumeLayout(false);
            this.gbefectivo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbtransferencia.ResumeLayout(false);
            this.gbtransferencia.PerformLayout();
            this.gbcheqt.ResumeLayout(false);
            this.gbcheqt.PerformLayout();
            this.gbchequep.ResumeLayout(false);
            this.gbchequep.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbFormaPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbefectivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.Button btnefect;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox gbtransferencia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txttransf;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btntransf;
        private System.Windows.Forms.ComboBox cmbcuentatra;
        private System.Windows.Forms.GroupBox gbcheqt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtcomtran;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtcomefe;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtcomchequet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtchequet;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbcuentaT;
        private System.Windows.Forms.MaskedTextBox mskfechatra;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox mskfechachequet;
        private System.Windows.Forms.GroupBox gbchequep;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtnrochequep;
        private System.Windows.Forms.MaskedTextBox mskfechacheqep;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtcomcheqp;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtchequep;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbcuentap;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtnrochequet;
        private System.Windows.Forms.Button btncf;
        private System.Windows.Forms.Button btncp;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtsucursal;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtnrotransf;
    }
}