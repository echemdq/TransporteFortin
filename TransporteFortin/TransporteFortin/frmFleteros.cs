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
        ControladoraFleteros controlf = new ControladoraFleteros();

        public frmFleteros()
        {
            InitializeComponent();
        }

        public void deshabilitar()
        {
            txtcomentario.Enabled = false;
            btnGuardar.Enabled = false;
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
            maskedTextBox1.Enabled = false;
            cmbTipoCamion.Enabled = false;
            cmbTipoIva.Enabled = false;
        }

        public void habilitar()
        {
            txtcomentario.Enabled = true;
            cmbTipoCamion.Enabled = true;
            cmbTipoIva.Enabled = true;
            btnGuardar.Enabled = true;
            txtDocumento.Enabled = true;
            txtCelular.Enabled = true;
            txtDomicilio.Enabled = true;
            txtMail.Enabled = true;
            txtCliente.Enabled = true;
            txtTelefono.Enabled = true;
            txtFax.Enabled = true;
            txtLocalidad.Enabled = true;
            txtCP.Enabled = true;
            txtCelular.Enabled = true;
            txtModelo.Enabled = true;
            txtChapaC.Enabled = true;
            txtChapaA.Enabled = true;
            maskedTextBox1.Enabled = true;
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
            maskedTextBox1.Text = "";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            habilitar();
            txtDocumento.Focus();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDocumento.Text != "" && txtCliente.Text != "")
                {
                    if (txtCP.Text == "")
                    {
                        txtCP.Text = "0";
                    }
                    Empresas em = null;
                    if (lblIdEmpresa.Text != "")
                    {
                        em = new Empresas(Convert.ToInt32(lblIdEmpresa.Text), "", "", "", "", "", "", "", "");
                    }
                    else
                    {
                        em = new Empresas(0, "", "", "", "", "", "", "", "");
                    }
                    TiposCamion t = new TiposCamion(Convert.ToInt32(cmbTipoCamion.SelectedValue), "");
                    TiposIVA ti = new TiposIVA(Convert.ToInt32(cmbTipoIva.SelectedValue),"","");
                    Fleteros r = new Fleteros(0, Convert.ToInt32(txtDocumento.Text), txtCliente.Text, txtDomicilio.Text, txtLocalidad.Text, txtCP.Text, txtTelefono.Text, txtCelular.Text, txtFax.Text, txtMail.Text, em, txtModelo.Text, t, txtChapaC.Text, txtChapaA.Text,maskedTextBox1.Text, ti,txtcomentario.Text);
                    if (lblIdFletero.Text == "" && txtCliente.Enabled == true)
                    {
                        controlf.Agregar(r);
                        MessageBox.Show("Fletero guardado correctamente");
                    }
                    else if (lblIdFletero.Text != "" && txtCliente.Enabled == true)
                    {
                        r.Idfleteros = Convert.ToInt32(lblIdFletero.Text);
                        controlf.Modificar(r);
                        MessageBox.Show("Fletero modificado correctamente");
                    }
                    limpiar();
                    deshabilitar();
                }
                else
                {
                    MessageBox.Show("Debe completar el nombre, documento");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message);
            }
        }

        private void frmFleteros_Load(object sender, EventArgs e)
        {
            deshabilitar();
            Acceso_BD oacceso = new Acceso_BD();
            DataTable dt = oacceso.leerDatos("select * from tiposcamion order by detalle asc");
            List<TiposCamion> listat = new List<TiposCamion>();
            foreach (DataRow dr in dt.Rows)
            {
                TiposCamion t = new TiposCamion(Convert.ToInt32(dr["idtiposcamion"]), Convert.ToString(dr["detalle"]));
                listat.Add(t);
            }
            cmbTipoCamion.DataSource = listat;
            cmbTipoCamion.DisplayMember = "detalle";
            cmbTipoCamion.ValueMember = "idtiposcamion";
            cmbTipoCamion.SelectedIndex = 0;
            cmbTipoCamion.Text = "full";
            dt = oacceso.leerDatos("select * from tiposiva order by detalle asc");
            List<TiposIVA> listat1 = new List<TiposIVA>();
            foreach (DataRow dr in dt.Rows)
            {
                TiposIVA t = new TiposIVA(Convert.ToInt32(dr["idtiposiva"]), Convert.ToString(dr["detalle"]), Convert.ToString(dr["tipo"]));
                listat1.Add(t);
            }
            cmbTipoIva.DataSource = listat1;
            cmbTipoIva.DisplayMember = "detalle";
            cmbTipoIva.ValueMember = "idtiposiva";
            cmbTipoIva.SelectedIndex = 0;
            cmbTipoIva.Text = "RESPONSABLE INSCRIPTO";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaEmpresas frm = new frmBuscaEmpresas();
                frm.ShowDialog();
                Empresas u = frm.u;
                if (u != null)
                {
                    lblIdEmpresa.Text = Convert.ToString(u.Idempresas);
                    txtEmpresa.Text = u.Empresa;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Buscar: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblIdFletero.Text != "")
                {
                    Fleteros c = new Fleteros(Convert.ToInt32(lblIdFletero.Text),0, "", "", "", "", "", "", "", "", null, "", null, "", "","",null,"");
                    DialogResult dialogResult = MessageBox.Show("Esta seguro de eliminar el Fletero: " + txtCliente.Text, "Eliminar Fletero", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        controlf.Borrar(c);
                        limpiar();
                        deshabilitar();
                        MessageBox.Show("Fletero eliminado correctamente");
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un Fletero para eliminarlo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Eliminar: " + ex.Message);
            }
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

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                deshabilitar();
                limpiar();
                frmBuscaFleteros frm = new frmBuscaFleteros();
                frm.ShowDialog();
                Fleteros u = frm.u;
                if (u != null)
                {
                    txtcomentario.Text = u.Comentario;
                    lblIdFletero.Text = Convert.ToString(u.Idfleteros);
                    lblIdEmpresa.Text = u.Empresas.Idempresas.ToString();
                    txtEmpresa.Text = u.Empresas.Empresa;
                    txtCliente.Text = u.Fletero;
                    txtDomicilio.Text = u.Direccion;
                    txtLocalidad.Text = u.Localidad;
                    txtTelefono.Text = u.Telefono;
                    txtCelular.Text = u.Celular;
                    txtFax.Text = u.Fax;
                    txtModelo.Text = u.Camion;
                    txtMail.Text = u.Mail;
                    cmbTipoCamion.SelectedValue = u.Tiposcamion.Idtiposcamion;
                    txtCP.Text = u.Cp.ToString();
                    txtChapaA.Text = u.Chapaacoplado;
                    txtChapaC.Text = u.Chapacamion;
                    txtDocumento.Text = u.Documento.ToString();
                    cmbTipoIva.SelectedValue = u.TiposIVA.IdTiposIVA;
                    maskedTextBox1.Text = u.Cuit;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message);
            }
        }
    }
}
