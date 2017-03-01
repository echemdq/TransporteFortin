using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransporteFortin
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void aBMClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes frm = new frmClientes();
            frm.ShowDialog();
        }

        private void aBMProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedores frm = new frmProveedores();
            frm.ShowDialog();
        }

        private void aBMEmpresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpresas frm = new frmEmpresas();
            frm.ShowDialog();
        }

        private void aBMFleterosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFleteros frm = new frmFleteros();
            frm.ShowDialog();
        }

        private void emitirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmitirOC frm = new frmEmitirOC(0);
            frm.ShowDialog();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBuscarOrdenCarga frm = new frmBuscarOrdenCarga();
            frm.ShowDialog();
        }
    }
}
