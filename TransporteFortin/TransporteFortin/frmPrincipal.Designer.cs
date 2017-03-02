namespace TransporteFortin
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordenesDeCargaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emitirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bancosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empresasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMEmpresasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fleterosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMFleterosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMProveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.ordenesDeCargaToolStripMenuItem,
            this.bancosToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.empresasToolStripMenuItem,
            this.fleterosToolStripMenuItem,
            this.proveedoresToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(876, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iniciarSesionToolStripMenuItem,
            this.aBMUsuariosToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // iniciarSesionToolStripMenuItem
            // 
            this.iniciarSesionToolStripMenuItem.Name = "iniciarSesionToolStripMenuItem";
            this.iniciarSesionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.iniciarSesionToolStripMenuItem.Text = "Iniciar Sesion";
            // 
            // ordenesDeCargaToolStripMenuItem
            // 
            this.ordenesDeCargaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emitirToolStripMenuItem,
            this.consultarToolStripMenuItem});
            this.ordenesDeCargaToolStripMenuItem.Name = "ordenesDeCargaToolStripMenuItem";
            this.ordenesDeCargaToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.ordenesDeCargaToolStripMenuItem.Text = "Ordenes de Carga";
            // 
            // emitirToolStripMenuItem
            // 
            this.emitirToolStripMenuItem.Name = "emitirToolStripMenuItem";
            this.emitirToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.emitirToolStripMenuItem.Text = "Emitir";
            this.emitirToolStripMenuItem.Click += new System.EventHandler(this.emitirToolStripMenuItem_Click);
            // 
            // consultarToolStripMenuItem
            // 
            this.consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            this.consultarToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.consultarToolStripMenuItem.Text = "Consultar";
            this.consultarToolStripMenuItem.Click += new System.EventHandler(this.consultarToolStripMenuItem_Click);
            // 
            // bancosToolStripMenuItem
            // 
            this.bancosToolStripMenuItem.Name = "bancosToolStripMenuItem";
            this.bancosToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.bancosToolStripMenuItem.Text = "Bancos";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMClientesToolStripMenuItem});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // aBMClientesToolStripMenuItem
            // 
            this.aBMClientesToolStripMenuItem.Name = "aBMClientesToolStripMenuItem";
            this.aBMClientesToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.aBMClientesToolStripMenuItem.Text = "ABM Clientes";
            this.aBMClientesToolStripMenuItem.Click += new System.EventHandler(this.aBMClientesToolStripMenuItem_Click);
            // 
            // empresasToolStripMenuItem
            // 
            this.empresasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMEmpresasToolStripMenuItem});
            this.empresasToolStripMenuItem.Name = "empresasToolStripMenuItem";
            this.empresasToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.empresasToolStripMenuItem.Text = "Empresas";
            // 
            // aBMEmpresasToolStripMenuItem
            // 
            this.aBMEmpresasToolStripMenuItem.Name = "aBMEmpresasToolStripMenuItem";
            this.aBMEmpresasToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.aBMEmpresasToolStripMenuItem.Text = "ABM Empresas";
            this.aBMEmpresasToolStripMenuItem.Click += new System.EventHandler(this.aBMEmpresasToolStripMenuItem_Click);
            // 
            // fleterosToolStripMenuItem
            // 
            this.fleterosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMFleterosToolStripMenuItem});
            this.fleterosToolStripMenuItem.Name = "fleterosToolStripMenuItem";
            this.fleterosToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.fleterosToolStripMenuItem.Text = "Fleteros";
            // 
            // aBMFleterosToolStripMenuItem
            // 
            this.aBMFleterosToolStripMenuItem.Name = "aBMFleterosToolStripMenuItem";
            this.aBMFleterosToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.aBMFleterosToolStripMenuItem.Text = "ABM Fleteros";
            this.aBMFleterosToolStripMenuItem.Click += new System.EventHandler(this.aBMFleterosToolStripMenuItem_Click);
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMProveedoresToolStripMenuItem});
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.proveedoresToolStripMenuItem.Text = "Proveedores";
            // 
            // aBMProveedoresToolStripMenuItem
            // 
            this.aBMProveedoresToolStripMenuItem.Name = "aBMProveedoresToolStripMenuItem";
            this.aBMProveedoresToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.aBMProveedoresToolStripMenuItem.Text = "ABM Proveedores";
            this.aBMProveedoresToolStripMenuItem.Click += new System.EventHandler(this.aBMProveedoresToolStripMenuItem_Click);
            // 
            // aBMUsuariosToolStripMenuItem
            // 
            this.aBMUsuariosToolStripMenuItem.Name = "aBMUsuariosToolStripMenuItem";
            this.aBMUsuariosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aBMUsuariosToolStripMenuItem.Text = "ABM Usuarios";
            this.aBMUsuariosToolStripMenuItem.Click += new System.EventHandler(this.aBMUsuariosToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 395);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transporte El Fortin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iniciarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empresasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMEmpresasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fleterosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bancosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMFleterosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMProveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordenesDeCargaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emitirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMUsuariosToolStripMenuItem;
    }
}

