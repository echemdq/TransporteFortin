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
    public partial class frmFleteros : Form
    {
        public frmFleteros()
        {
            InitializeComponent();
        }

        public void deshabilitar()
        {
            txtDocumento.Enabled = false;
            txtCelular.Enabled = false;
            txtDomicilio.Enabled = false;
            txtMail.Enabled = false;
            txtCliente.Enabled = false;
            txtTelefono.Enabled = false;
            txtFax.Enabled = false;
            txtLocalidad.Enabled = false;
            txtCP.Enabled = false;
            txtCelular.Enabled = false;
            txtModelo.Enabled = false;
            txtChapaC.Enabled = false;
            txtChapaA.Enabled = false;
        }
        public void habilitar()
        {
            txtDocumento.Enabled = false;
            txtCelular.Enabled = false;
            txtDomicilio.Enabled = false;
            txtMail.Enabled = false;
            txtCliente.Enabled = false;
            txtTelefono.Enabled = false;
            txtFax.Enabled = false;
            txtLocalidad.Enabled = false;
            txtCP.Enabled = false;
            txtCelular.Enabled = false;
            txtModelo.Enabled = false;
            txtChapaC.Enabled = false;
            txtChapaA.Enabled = false;
        }
        public void limpiar()
        {
            lblIdFletero.Text = "";
            lblIdEmpresa.Text = "";
            txtDocumento.Text = "";
            txtCelular.Text = "";
            txtDomicilio.Text = "";
            txtMail.Text = "";
            txtCliente.Text = "";
            txtTelefono.Text = "";
            txtFax.Text = "";
            txtLocalidad.Text = "";
            txtCP.Text = "";
            txtCelular.Text = "";
            txtModelo.Text = "";
            txtChapaC.Text = "";
            txtChapaA.Text = "";
            txtEmpresa.Text = "";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            habilitar();
            txtCliente.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
            deshabilitar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (lblIdFletero.Text != "")
            {
                habilitar();
            }
        }
    }
}
