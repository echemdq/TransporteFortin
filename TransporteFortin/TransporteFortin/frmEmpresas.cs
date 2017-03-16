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
    public partial class frmEmpresas : Form
    {
        public frmEmpresas()
        {
            InitializeComponent();
        }

        ControladoraEmpresas controle = new ControladoraEmpresas();

        public void deshabilitar()
        {
            txtCelular.Enabled = false;
            txtComentarios.Enabled = false;
            txtDomicilio.Enabled = false;
            txtMail.Enabled = false;
            txtEmpresas.Enabled = false;
            txtTelefono.Enabled = false;
            txtLocalidad.Enabled = false;
            txtTelefono2.Enabled = false;
        }
        public void habilitar()
        {
            txtCelular.Enabled = true;
            txtComentarios.Enabled = true;
            txtDomicilio.Enabled = true;
            txtMail.Enabled = true;
            txtEmpresas.Enabled = true;
            txtTelefono.Enabled = true;
            txtLocalidad.Enabled = true;
            txtTelefono2.Enabled = true;
        }
        public void limpiar()
        {
            lblId.Text = "";
            txtCelular.Text = "";
            txtComentarios.Text = "";
            txtDomicilio.Text = "";
            txtMail.Text = "";
            txtEmpresas.Text = "";
            txtTelefono.Text = "";
            txtLocalidad.Text = "";
            txtTelefono2.Text = "";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            habilitar();
            txtEmpresas.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
            deshabilitar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (lblId.Text != "")
            {
                habilitar();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmpresas.Text != "")
                {
                    Empresas r = new Empresas(0, txtEmpresas.Text, txtDomicilio.Text, txtLocalidad.Text, txtTelefono.Text, txtTelefono2.Text, txtCelular.Text, txtMail.Text, txtComentarios.Text);
                    if (lblId.Text == "")
                    {
                        controle.Agregar(r);
                        MessageBox.Show("Empresa guardada correctamente");
                    }
                    else
                    {
                        r.Idempresas = Convert.ToInt32(lblId.Text);
                        controle.Modificar(r);
                        MessageBox.Show("Empresa modificada correctamente");
                    }
                    limpiar();
                    deshabilitar();
                }
                else
                {
                    MessageBox.Show("Debe completar el nombre de la Empresa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text != "")
                {
                    Empresas c = new Empresas(Convert.ToInt32(lblId.Text), "", "", "", "", "", "", "", "");
                    DialogResult dialogResult = MessageBox.Show("Esta seguro de eliminar la Empresa: " + txtEmpresas.Text, "Eliminar Empresa", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        controle.Borrar(c);
                        limpiar();
                        deshabilitar();
                        MessageBox.Show("Empresa eliminada correctamente");
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una Empresa para eliminarla");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Eliminar: " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                deshabilitar();
                limpiar();
                frmBuscaEmpresas frm = new frmBuscaEmpresas();
                frm.ShowDialog();
                Empresas u = frm.u;
                if (u != null)
                {
                    lblId.Text = Convert.ToString(u.Idempresas);
                    txtEmpresas.Text = u.Empresa;
                    txtDomicilio.Text = u.Direccion;
                    txtLocalidad.Text = u.Localidad;
                    txtTelefono.Text = u.Telefono;
                    txtTelefono2.Text = u.Telefono2;
                    txtCelular.Text = u.Celular;
                    txtComentarios.Text = u.Comentario;
                    txtMail.Text = u.Mail;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Buscar: " + ex.Message);
            }
        }

        private void txtEmpresas_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
