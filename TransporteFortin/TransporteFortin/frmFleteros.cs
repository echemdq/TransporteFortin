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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDocumento.Text != "" && txtCliente.Text != "" && lblIdEmpresa.Text != "")
                {
                    Empresas em = new Empresas(Convert.ToInt32(lblIdEmpresa.Text), "", "", "", "", "", "", "", "");
                    TiposCamion t = new TiposCamion(Convert.ToInt32(cmbTipoCamion.SelectedValue), "");
                    Fleteros r = new Fleteros(0, Convert.ToInt32(txtDocumento.Text), txtCliente.Text, txtDomicilio.Text, txtLocalidad.Text, txtCP.Text, txtTelefono.Text, txtCelular.Text, txtFax.Text, txtMail.Text, em, txtModelo.Text, t, txtChapaC.Text, txtChapaA.Text);
                    if (lblIdFletero.Text == "")
                    {
                        controlf.Agregar(r);
                        MessageBox.Show("Fletero guardado correctamente");
                    }
                    else
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
                    MessageBox.Show("Debe completar el nombre y documento del Fletero");
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
                    Fleteros c = new Fleteros(0, Convert.ToInt32(lblIdFletero.Text), "", "", "", "", "", "", "", "", null, "", null, "", "");
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
    }
}
