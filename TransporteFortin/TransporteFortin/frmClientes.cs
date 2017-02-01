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
    public partial class frmClientes : Form
    {
        ControladoraClientes controlc = new ControladoraClientes();
        public frmClientes()
        {
            InitializeComponent();
        }

        public void deshabilitar()
        {
            txtCelular.Enabled = false;
            txtComentarios.Enabled = false;
            txtDomicilio.Enabled = false;
            txtMail.Enabled = false;
            txtCliente.Enabled = false;
            txtTelefono.Enabled = false;
            txtFax.Enabled = false;
            txtLocalidad.Enabled = false;
            txtCP.Enabled = false;
            maskedTextBox1.Enabled = false;
            txtContacto.Enabled = false;
        }
        public void habilitar()
        {
            txtCelular.Enabled = true;
            txtComentarios.Enabled = true;
            txtDomicilio.Enabled = true;
            txtMail.Enabled = true;
            txtCliente.Enabled = true;
            txtTelefono.Enabled = true;
            txtFax.Enabled = true;
            txtLocalidad.Enabled = true;
            txtCP.Enabled = true;
            maskedTextBox1.Enabled = true;
            txtContacto.Enabled = true;
        }
        public void limpiar()
        {
            lblId.Text = "";
            txtCelular.Text = "";
            txtComentarios.Text = "";
            txtDomicilio.Text = "";
            txtMail.Text = "";
            txtCliente.Text = "";
            txtTelefono.Text = "";
            txtFax.Text = "";
            txtLocalidad.Text = "";
            txtCP.Text = "";
            maskedTextBox1.Text = "";
            txtContacto.Text = "";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            habilitar();
            txtCliente.Focus();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            deshabilitar();
            Acceso_BD oacceso = new Acceso_BD();
            DataTable dt = oacceso.leerDatos("select * from tiposiva order by detalle asc");
            List<TiposIVA> listat = new List<TiposIVA>();
            foreach (DataRow dr in dt.Rows)
            {
                TiposIVA t = new TiposIVA(Convert.ToInt32(dr["idtiposiva"]), Convert.ToString(dr["detalle"]),Convert.ToString(dr["tipo"]));
                listat.Add(t);
            }
            cmbTipoIva.DataSource = listat;
            cmbTipoIva.DisplayMember = "detalle";
            cmbTipoIva.ValueMember = "idtiposiva";
            cmbTipoIva.SelectedIndex = 0;
            cmbTipoIva.Text = "RESPONSABLE INSCRIPTO";
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
                if (txtCliente.Text != "")
                {
                    Clientes r = new Clientes(0, txtCliente.Text, txtDomicilio.Text,txtLocalidad.Text,Convert.ToInt32(txtCP.Text),txtTelefono.Text,txtCelular.Text,txtFax.Text,txtMail.Text,txtContacto.Text,maskedTextBox1.Text,null,txtComentarios.Text);
                    
                    if (lblId.Text == "")
                    {
                        controlc.Agregar(r);
                        MessageBox.Show("Cliente guardado correctamente");
                    }
                    else
                    {
                        r.Idclientes = Convert.ToInt32(lblId.Text);
                        controlc.Modificar(r);
                        MessageBox.Show("Cliente modificado correctamente");
                    }
                    limpiar();
                    deshabilitar();
                }
                else
                {
                    MessageBox.Show("Debe completar el nombre y apellido del Cliente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message);
            }
        }
    }
}
