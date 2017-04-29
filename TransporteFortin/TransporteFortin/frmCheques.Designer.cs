namespace TransporteFortin
{
    partial class frmCheques
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Numero = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtfechaemi = new System.Windows.Forms.TextBox();
            this.txtfechadep = new System.Windows.Forms.TextBox();
            this.txtorigen = new System.Windows.Forms.TextBox();
            this.txtdestino = new System.Windows.Forms.TextBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtnro = new System.Windows.Forms.TextBox();
            this.txtimporte = new System.Windows.Forms.TextBox();
            this.txtforma = new System.Windows.Forms.TextBox();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.txtCuentaBanco = new System.Windows.Forms.TextBox();
            this.txtrecibo = new System.Windows.Forms.TextBox();
            this.txtordenpago = new System.Windows.Forms.TextBox();
            this.txtcomentarios = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 128);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(672, 241);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label1.Location = new System.Drawing.Point(19, 378);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha Emision";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label2.Location = new System.Drawing.Point(13, 404);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha Deposito";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label3.Location = new System.Drawing.Point(62, 430);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Origen";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label4.Location = new System.Drawing.Point(57, 456);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Destino";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label5.Location = new System.Drawing.Point(62, 482);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Estado";
            // 
            // Numero
            // 
            this.Numero.AutoSize = true;
            this.Numero.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.Numero.Location = new System.Drawing.Point(57, 508);
            this.Numero.Name = "Numero";
            this.Numero.Size = new System.Drawing.Size(52, 13);
            this.Numero.TabIndex = 6;
            this.Numero.Text = "Numero";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label7.Location = new System.Drawing.Point(420, 378);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Importe";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label8.Location = new System.Drawing.Point(380, 405);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Forma de Pago";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label9.Location = new System.Drawing.Point(431, 430);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Banco";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label10.Location = new System.Drawing.Point(386, 456);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Cuenta Banco";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label11.Location = new System.Drawing.Point(428, 482);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Recibo";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label12.Location = new System.Drawing.Point(381, 508);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Orden de Pago";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label13.Location = new System.Drawing.Point(29, 538);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Comentarios";
            // 
            // txtfechaemi
            // 
            this.txtfechaemi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfechaemi.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtfechaemi.Location = new System.Drawing.Point(125, 375);
            this.txtfechaemi.Name = "txtfechaemi";
            this.txtfechaemi.ReadOnly = true;
            this.txtfechaemi.Size = new System.Drawing.Size(100, 21);
            this.txtfechaemi.TabIndex = 14;
            // 
            // txtfechadep
            // 
            this.txtfechadep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtfechadep.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtfechadep.Location = new System.Drawing.Point(125, 401);
            this.txtfechadep.Name = "txtfechadep";
            this.txtfechadep.ReadOnly = true;
            this.txtfechadep.Size = new System.Drawing.Size(100, 21);
            this.txtfechadep.TabIndex = 15;
            // 
            // txtorigen
            // 
            this.txtorigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtorigen.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtorigen.Location = new System.Drawing.Point(125, 427);
            this.txtorigen.Name = "txtorigen";
            this.txtorigen.ReadOnly = true;
            this.txtorigen.Size = new System.Drawing.Size(218, 21);
            this.txtorigen.TabIndex = 16;
            // 
            // txtdestino
            // 
            this.txtdestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdestino.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtdestino.Location = new System.Drawing.Point(125, 453);
            this.txtdestino.Name = "txtdestino";
            this.txtdestino.ReadOnly = true;
            this.txtdestino.Size = new System.Drawing.Size(218, 21);
            this.txtdestino.TabIndex = 17;
            // 
            // txtEstado
            // 
            this.txtEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstado.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtEstado.Location = new System.Drawing.Point(125, 479);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(218, 21);
            this.txtEstado.TabIndex = 18;
            // 
            // txtnro
            // 
            this.txtnro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnro.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtnro.Location = new System.Drawing.Point(125, 505);
            this.txtnro.Name = "txtnro";
            this.txtnro.ReadOnly = true;
            this.txtnro.Size = new System.Drawing.Size(100, 21);
            this.txtnro.TabIndex = 19;
            // 
            // txtimporte
            // 
            this.txtimporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtimporte.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtimporte.Location = new System.Drawing.Point(480, 375);
            this.txtimporte.Name = "txtimporte";
            this.txtimporte.ReadOnly = true;
            this.txtimporte.Size = new System.Drawing.Size(100, 21);
            this.txtimporte.TabIndex = 20;
            // 
            // txtforma
            // 
            this.txtforma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtforma.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtforma.Location = new System.Drawing.Point(480, 402);
            this.txtforma.Name = "txtforma";
            this.txtforma.ReadOnly = true;
            this.txtforma.Size = new System.Drawing.Size(204, 21);
            this.txtforma.TabIndex = 21;
            // 
            // txtBanco
            // 
            this.txtBanco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBanco.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtBanco.Location = new System.Drawing.Point(480, 427);
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.ReadOnly = true;
            this.txtBanco.Size = new System.Drawing.Size(204, 21);
            this.txtBanco.TabIndex = 22;
            // 
            // txtCuentaBanco
            // 
            this.txtCuentaBanco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCuentaBanco.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtCuentaBanco.Location = new System.Drawing.Point(480, 453);
            this.txtCuentaBanco.Name = "txtCuentaBanco";
            this.txtCuentaBanco.ReadOnly = true;
            this.txtCuentaBanco.Size = new System.Drawing.Size(204, 21);
            this.txtCuentaBanco.TabIndex = 23;
            // 
            // txtrecibo
            // 
            this.txtrecibo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtrecibo.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtrecibo.Location = new System.Drawing.Point(480, 479);
            this.txtrecibo.Name = "txtrecibo";
            this.txtrecibo.ReadOnly = true;
            this.txtrecibo.Size = new System.Drawing.Size(100, 21);
            this.txtrecibo.TabIndex = 24;
            // 
            // txtordenpago
            // 
            this.txtordenpago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtordenpago.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtordenpago.Location = new System.Drawing.Point(480, 505);
            this.txtordenpago.Name = "txtordenpago";
            this.txtordenpago.ReadOnly = true;
            this.txtordenpago.Size = new System.Drawing.Size(100, 21);
            this.txtordenpago.TabIndex = 25;
            // 
            // txtcomentarios
            // 
            this.txtcomentarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcomentarios.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtcomentarios.Location = new System.Drawing.Point(125, 535);
            this.txtcomentarios.Name = "txtcomentarios";
            this.txtcomentarios.ReadOnly = true;
            this.txtcomentarios.Size = new System.Drawing.Size(559, 21);
            this.txtcomentarios.TabIndex = 26;
            // 
            // frmCheques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 567);
            this.Controls.Add(this.txtcomentarios);
            this.Controls.Add(this.txtordenpago);
            this.Controls.Add(this.txtrecibo);
            this.Controls.Add(this.txtCuentaBanco);
            this.Controls.Add(this.txtBanco);
            this.Controls.Add(this.txtforma);
            this.Controls.Add(this.txtimporte);
            this.Controls.Add(this.txtnro);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtdestino);
            this.Controls.Add(this.txtorigen);
            this.Controls.Add(this.txtfechadep);
            this.Controls.Add(this.txtfechaemi);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Numero);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmCheques";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Cheques";
            this.Load += new System.EventHandler(this.frmCheques_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Numero;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtfechaemi;
        private System.Windows.Forms.TextBox txtfechadep;
        private System.Windows.Forms.TextBox txtorigen;
        private System.Windows.Forms.TextBox txtdestino;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txtnro;
        private System.Windows.Forms.TextBox txtimporte;
        private System.Windows.Forms.TextBox txtforma;
        private System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.TextBox txtCuentaBanco;
        private System.Windows.Forms.TextBox txtrecibo;
        private System.Windows.Forms.TextBox txtordenpago;
        private System.Windows.Forms.TextBox txtcomentarios;
    }
}