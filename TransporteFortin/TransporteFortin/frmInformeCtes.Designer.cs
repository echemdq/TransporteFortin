namespace TransporteFortin
{
    partial class frmInformeCtes
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.FleterosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.EmpresasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ClientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.FleterosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpresasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // FleterosBindingSource
            // 
            this.FleterosBindingSource.DataSource = typeof(TransporteFortin.Fleteros);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ClientesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TransporteFortin.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(920, 474);
            this.reportViewer1.TabIndex = 0;
            // 
            // EmpresasBindingSource
            // 
            this.EmpresasBindingSource.DataSource = typeof(TransporteFortin.Empresas);
            // 
            // ClientesBindingSource
            // 
            this.ClientesBindingSource.DataSource = typeof(TransporteFortin.Clientes);
            this.ClientesBindingSource.CurrentChanged += new System.EventHandler(this.ClientesBindingSource_CurrentChanged);
            // 
            // frmInformeCtes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 498);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmInformeCtes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informes";
            this.Load += new System.EventHandler(this.frmprueba_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FleterosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmpresasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ClientesBindingSource;
        private System.Windows.Forms.BindingSource FleterosBindingSource;
        private System.Windows.Forms.BindingSource EmpresasBindingSource;

    }
}