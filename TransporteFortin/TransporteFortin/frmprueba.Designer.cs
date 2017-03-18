namespace TransporteFortin
{
    partial class frmprueba
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.accesosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accesoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idaccesosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accesosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idaccesosDataGridViewTextBoxColumn,
            this.accesoDataGridViewTextBoxColumn});
            this.dataGridView1.Location = new System.Drawing.Point(1, 165);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(931, 173);
            this.dataGridView1.TabIndex = 0;
            // 
            // accesosBindingSource
            // 
            this.accesosBindingSource.DataSource = typeof(TransporteFortin.Accesos);
            // 
            // accesoDataGridViewTextBoxColumn
            // 
            this.accesoDataGridViewTextBoxColumn.DataPropertyName = "Acceso";
            this.accesoDataGridViewTextBoxColumn.HeaderText = "Acceso";
            this.accesoDataGridViewTextBoxColumn.Name = "accesoDataGridViewTextBoxColumn";
            this.accesoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idaccesosDataGridViewTextBoxColumn
            // 
            this.idaccesosDataGridViewTextBoxColumn.DataPropertyName = "Idaccesos";
            this.idaccesosDataGridViewTextBoxColumn.HeaderText = "Idaccesos";
            this.idaccesosDataGridViewTextBoxColumn.Name = "idaccesosDataGridViewTextBoxColumn";
            this.idaccesosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmprueba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 498);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmprueba";
            this.Text = "frmprueba";
            this.Load += new System.EventHandler(this.frmprueba_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accesosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idaccesosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accesoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource accesosBindingSource;
    }
}