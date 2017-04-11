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
    public partial class frmProveedores : Form
    {
        ControladoraProveedores controlp = new ControladoraProveedores();
        public frmProveedores()
        {
            InitializeComponent();
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;
            int nroDec = 0;
            
            for (int i = 0; i < txtValor.Text.Length; i++)
            {
                if (txtValor.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        
        }

        private void txtCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtCP.Text.Length; i++)
            {
                if (txtCP.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        public void deshabilitar()
        {
            cmbTipoIva.Enabled = false;
            btnGuardar.Enabled = false;
            txtCelular.Enabled = false;
            txtComentarios.Enabled = false;
            txtDomicilio.Enabled = false;
            txtMail.Enabled = false;
            txtProveedor.Enabled = false;
            txtTelefono.Enabled = false;
            txtFax.Enabled = false;
            txtLocalidad.Enabled = false;
            txtCP.Enabled = false;
            maskedTextBox1.Enabled = false;
            txtContacto.Enabled = false;
            txtValor.Enabled = false;
        }
        public void habilitar()
        {
            cmbTipoIva.Enabled = true;
            btnGuardar.Enabled = true;
            txtCelular.Enabled = true;
            txtComentarios.Enabled = true;
            txtDomicilio.Enabled = true;
            txtMail.Enabled = true;
            txtProveedor.Enabled = true;
            txtTelefono.Enabled = true;
            txtFax.Enabled = true;
            txtLocalidad.Enabled = true;
            txtCP.Enabled = true;
            maskedTextBox1.Enabled = true;
            txtContacto.Enabled = true;
            txtValor.Enabled = true;
        }
        public void limpiar()
        {
            lblId.Text = "";
            txtCelular.Text = "";
            txtComentarios.Text = "";
            txtDomicilio.Text = "";
            txtMail.Text = "";
            txtProveedor.Text = "";
            txtTelefono.Text = "";
            txtFax.Text = "";
            txtLocalidad.Text = "";
            txtCP.Text = "";
            maskedTextBox1.Text = "";
            txtContacto.Text = "";
            txtValor.Text = "";
        }
        private void frmProveedores_Load(object sender, EventArgs e)
        {
            deshabilitar();
            Acceso_BD oacceso = new Acceso_BD();
            DataTable dt = oacceso.leerDatos("select * from tiposiva order by detalle asc");
            List<TiposIVA> listat = new List<TiposIVA>();
            foreach (DataRow dr in dt.Rows)
            {
                TiposIVA t = new TiposIVA(Convert.ToInt32(dr["idtiposiva"]), Convert.ToString(dr["detalle"]), Convert.ToString(dr["tipo"]));
                listat.Add(t);
            }
            cmbTipoIva.DataSource = listat;
            cmbTipoIva.DisplayMember = "detalle";
            cmbTipoIva.ValueMember = "idtiposiva";
            cmbTipoIva.SelectedIndex = 0;
            cmbTipoIva.Text = "RESPONSABLE INSCRIPTO";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            habilitar();
            txtProveedor.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProveedor.Text != "")
                {
                    TiposIVA tipoiva = new TiposIVA(Convert.ToInt32(cmbTipoIva.SelectedValue), "", "");
                    if (txtCP.Text == "")
                    {
                        txtCP.Text = "0";
                    }
                    Proveedores r = new Proveedores(0, txtProveedor.Text, txtDomicilio.Text, txtLocalidad.Text, Convert.ToInt32(txtCP.Text), txtTelefono.Text, txtCelular.Text, txtFax.Text, txtMail.Text, txtContacto.Text, maskedTextBox1.Text, tipoiva, txtComentarios.Text, Convert.ToDecimal(txtValor.Text.Replace('.', ',')));
                    if (lblId.Text == "")
                    {
                        controlp.Agregar(r);
                        MessageBox.Show("Proveedor guardado correctamente");
                    }
                    else
                    {
                        r.Idproveedores = Convert.ToInt32(lblId.Text);
                        controlp.Modificar(r);
                        MessageBox.Show("Proveedor modificado correctamente");
                    }
                    limpiar();
                    deshabilitar();
                }
                else
                {
                    MessageBox.Show("Debe completar el Razon Social del Proveedor");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                deshabilitar();
                limpiar();
                frmBuscaProveedores frm = new frmBuscaProveedores();
                frm.ShowDialog();
                Proveedores u = frm.u;
                if (u != null)
                {
                    lblId.Text = Convert.ToString(u.Idproveedores);
                    txtProveedor.Text = u.Proveedor;
                    txtDomicilio.Text = u.Direccion;
                    txtLocalidad.Text = u.Localidad;
                    txtTelefono.Text = u.Telefono;
                    txtCelular.Text = u.Celular;
                    txtFax.Text = u.Fax;
                    txtComentarios.Text = u.Comentario;
                    txtMail.Text = u.Mail;
                    cmbTipoIva.SelectedValue = u.TiposIVA.IdTiposIVA;
                    maskedTextBox1.Text = u.Cuit;
                    txtCP.Text = u.Cp.ToString();
                    txtContacto.Text = u.Contacto;
                    txtValor.Text = u.Valor.ToString().Replace(',', '.');
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Buscar: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (lblId.Text != "")
            {
                habilitar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text != "")
                {
                    Proveedores c = new Proveedores(Convert.ToInt32(lblId.Text), "", "", "", 0, "", "", "", "", "", "", null, "",0);
                    DialogResult dialogResult = MessageBox.Show("Esta seguro de eliminar el Proveedor: " + txtProveedor.Text, "Eliminar Cliente", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        controlp.Borrar(c);
                        limpiar();
                        deshabilitar();
                        MessageBox.Show("Proveedor eliminado correctamente");
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un Proveedor para eliminarlo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Eliminar: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            limpiar();
            deshabilitar();
        }
    }
}
