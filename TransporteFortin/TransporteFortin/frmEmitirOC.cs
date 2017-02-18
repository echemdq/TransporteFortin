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
    public partial class frmEmitirOC : Form
    {
        ControladoraOrdenesCarga controlo = new ControladoraOrdenesCarga();
        public frmEmitirOC()
        {
            InitializeComponent();
        }

        private void frmEmitirOC_Load(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Checked = false;
            }
            maskedTextBox1.Text = DateTime.Today.ToString();
            Acceso_BD oacceso = new Acceso_BD();
            DataTable dt = oacceso.leerDatos("select * from sucursales order by sucursal asc");
            List<Sucursales> listat = new List<Sucursales>();
            foreach (DataRow dr in dt.Rows)
            {
                Sucursales t = new Sucursales(Convert.ToInt32(dr["idsucursales"]), Convert.ToString(dr["sucursal"]));
                listat.Add(t);
            }
            cmbSucursal.DataSource = listat;
            cmbSucursal.DisplayMember = "sucursal";
            cmbSucursal.ValueMember = "idsucursales";
            cmbSucursal.SelectedIndex = 0;

            dt = oacceso.leerDatos("select * from tiposcamion order by detalle asc");
            List<TiposCamion> lista = new List<TiposCamion>();
            foreach (DataRow dr in dt.Rows)
            {
                TiposCamion t = new TiposCamion(Convert.ToInt32(dr["idtiposcamion"]), Convert.ToString(dr["detalle"]));
                lista.Add(t);
            }
            cmbTipoCamion.DataSource = lista;
            cmbTipoCamion.DisplayMember = "detalle";
            cmbTipoCamion.ValueMember = "idtiposcamion";
            cmbTipoCamion.SelectedIndex = 0;

            dt = oacceso.leerDatos("select * from unidades order by detalle asc");
            List<Unidades> lista1 = new List<Unidades>();
            foreach (DataRow dr in dt.Rows)
            {
                Unidades t = new Unidades(Convert.ToInt32(dr["idunidades"]), Convert.ToString(dr["detalle"]));
                lista1.Add(t);
            }
            cmbUnidades.DataSource = lista1;
            cmbUnidades.DisplayMember = "detalle";
            cmbUnidades.ValueMember = "idunidades";
            cmbUnidades.SelectedIndex = 0;
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }



        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                groupBox6.Enabled = true;
            }
            else
            {
                groupBox6.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkValorizado.Checked)
            {
                txtPorcentaje.Enabled = true;
                txtValorFijo.Enabled = false;
            }
            else if (radioButton2.Checked)
            {
                txtPorcentaje.Enabled = false;
                txtValorFijo.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaClientes frm = new frmBuscaClientes();
                frm.ShowDialog();
                Clientes u = frm.u;
                if (u != null)
                {
                    lblCliente.Text = Convert.ToString(u.Idclientes);
                    lblDireccionCte.Text = "Direccion: "+ u.Direccion;
                    txtCliente.Text = u.Cliente;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaFleteros frm = new frmBuscaFleteros();
                frm.ShowDialog();
                Fleteros u = frm.u;
                if (u != null)
                {
                    lblFletero.Text = Convert.ToString(u.Idfleteros);
                    lblEmpresa.Text = u.Empresas.Idempresas.ToString();
                    txtEmpresa.Text = u.Empresas.Empresa;
                    txtFletero.Text = u.Fletero;
                    txtDomicilio.Text = u.Direccion;
                    txtLocalidad.Text = u.Localidad;
                    txtTelefono.Text = u.Telefono;
                    txtCelular.Text = u.Celular;
                    txtModelo.Text = u.Camion;
                    cmbTipoCamion.SelectedValue = u.Tiposcamion.Idtiposcamion;
                    txtCP.Text = u.Cp.ToString();
                    txtChapaA.Text = u.Chapaacoplado;
                    txtChapaC.Text = u.Chapacamion;
                    txtDocumento.Text = u.Documento.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message);
            }
        }

        private void txtValorDec_KeyPress(object sender, KeyPressEventArgs e)
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

            for (int i = 0; i < txtValorDec.Text.Length; i++)
            {
                if (txtValorDec.Text[i] == '.')
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

        private void txtValorUni_KeyPress(object sender, KeyPressEventArgs e)
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

            for (int i = 0; i < txtValorUni.Text.Length; i++)
            {
                if (txtValorUni.Text[i] == '.')
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

        private void txtValorUniCte_KeyPress(object sender, KeyPressEventArgs e)
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

            for (int i = 0; i < txtValorUniCte.Text.Length; i++)
            {
                if (txtValorUniCte.Text[i] == '.')
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

        private void txtValorFijo_KeyPress(object sender, KeyPressEventArgs e)
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

            for (int i = 0; i < txtValorFijo.Text.Length; i++)
            {
                if (txtValorFijo.Text[i] == '.')
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

        private void txtIvaViaje_KeyPress(object sender, KeyPressEventArgs e)
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

            for (int i = 0; i < txtIvaViaje.Text.Length; i++)
            {
                if (txtIvaViaje.Text[i] == '.')
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

        private void txtIVACte_KeyPress(object sender, KeyPressEventArgs e)
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

            for (int i = 0; i < txtIVACte.Text.Length; i++)
            {
                if (txtIVACte.Text[i] == '.')
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

        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
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

            for (int i = 0; i < txtPorcentaje.Text.Length; i++)
            {
                if (txtPorcentaje.Text[i] == '.')
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

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }   
        }

        public void limpiar()
        {
            txtCliente.Text = "";
            lblDireccionCte.Text = "Direccion:";
            lblCliente.Text = "";
            txtSaldoCte.Text = "$0.00";
            txtFletero.Text = "";
            txtSaldoFlet.Text = "$0.00";
            txtDocumento.Text = "";
            txtCP.Text = "";
            txtDomicilio.Text = "";
            txtTelefono.Text = "";
            txtLocalidad.Text = "";
            txtCelular.Text = "";
            lblFletero.Text = "";
            lblEmpresa.Text = "";
            txtModelo.Text = "";
            txtChapaC.Text = "";
            txtChapaA.Text = "";
            txtEmpresa.Text = "";
            txtSaldoEmp.Text = "";
            txtRetiraPor.Text = "";
            txtProductos.Text = "";
            txtOrigen.Text = "";
            txtDestino.Text = "";
            txtValorDec.Text = "0";
            chkValorizado.Checked = false;
            txtCantidad.Text = "";
            txtValorUni.Text = "";
            txtValorUniCte.Text = "";
            txtPorcentaje.Text = "";
            txtValorFijo.Text = "0";
            chkPagoDest.Checked = false;
            txtTotalViaje.Text = "$0.00";
            txtIvaViaje.Text = "0.00";
            txtComision.Text = "$0.00";
            txtImporteCte.Text = "0.00";
            txtIVACte.Text = "0.00";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblCliente.Text != "" && lblFletero.Text != "")
                {
                    Sucursales sucursales = new Sucursales(Convert.ToInt32(cmbSucursal.SelectedValue), "");
                    Clientes cliente = new Clientes(Convert.ToInt32(lblCliente.Text), "", "", "", 0, "", "", "", "", "", "", null, "");
                    Fleteros fletero = new Fleteros(Convert.ToInt32(lblFletero.Text), 0, "", "", "", "", "", "", "", "", null, "", null, "", "", "", null);
                    Empresas empresa = new Empresas(Convert.ToInt32(lblEmpresa.Text), "", "", "", "", "", "", "", "");
                    int valorizado = 0;
                    Unidades unidad = null;
                    
                    
                    decimal valorcomision = 0;
                    
                    string tipocom = "p";
                    int pagodest = 0;
                    if (chkPagoDest.Checked)
                    {
                        pagodest = 1;

                    }
                    else
                    {
                        pagodest = 0;
                    }
                    if (chkValorizado.Checked)
                    {
                        if (txtPorcentaje.Text == "")
                        {
                            valorcomision = 0;
                        }
                        else
                        {
                            valorcomision = Convert.ToDecimal(txtPorcentaje.Text);
                        }
                    }
                    else
                    {
                        tipocom = "v";
                        if (txtValorFijo.Text == "")
                        {
                            valorcomision = 0;
                        }
                        else
                        {
                            valorcomision = Convert.ToDecimal(txtValorFijo.Text);
                        }
                    }
                    if (checkBox1.Checked)
                    {
                        valorizado = 1;
                        unidad = new Unidades(Convert.ToInt32(cmbUnidades.SelectedValue), "");
                        if (txtCantidad.Text == "" || txtValorUni.Text == "" || txtValorUniCte.Text == "" || txtPorcentaje.Text == "" || txtValorFijo.Text == "" || Convert.ToDecimal(txtTotalViaje.Text) <= 0)
                        {
                            MessageBox.Show("Debe completar todos los campos para valorizar y calcular el importe del viaje");
                        }
                        else
                        {
                            OrdenesCarga oc = new OrdenesCarga(0, 0, 0, 0, Convert.ToDateTime(maskedTextBox1.Text), sucursales, cliente, fletero, empresa, txtRetiraPor.Text, txtProductos.Text, txtOrigen.Text, txtDestino.Text, Convert.ToDecimal(txtValorDec.Text.Replace('.', ',')), valorizado, unidad, Convert.ToInt32(txtCantidad.Text), Convert.ToDecimal(txtValorUni.Text.Replace('.', ',')), Convert.ToDecimal(txtValorUniCte.Text.Replace('.', ',')), tipocom, valorcomision, pagodest, Convert.ToDecimal(txtTotalViaje.Text), Convert.ToDecimal(txtIvaViaje.Text), Convert.ToDecimal(txtIVACte.Text), Convert.ToDecimal(txtComision.Text), Convert.ToDecimal(txtImporteCte.Text), richTextBox1.Text, 0);
                            controlo.Agregar(oc);
                            MessageBox.Show("Orden de carga generada correctamente");
                            limpiar();
                        }
                    }
                    else
                    {
                        unidad = new Unidades(Convert.ToInt32(cmbUnidades.SelectedValue), "");
                        OrdenesCarga oc = new OrdenesCarga(0, 0, 0, 0, Convert.ToDateTime(maskedTextBox1.Text), sucursales, cliente, fletero, empresa, txtRetiraPor.Text, txtProductos.Text, txtOrigen.Text, txtDestino.Text, Convert.ToDecimal(txtValorDec.Text.Replace('.',',')), valorizado, unidad, 0, 0, 0, tipocom, valorcomision, 0, 0, 0, 0, 0, 0, richTextBox1.Text,0);
                        controlo.Agregar(oc);
                        MessageBox.Show("Orden de carga generada correctamente");
                        limpiar();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Debe seleccionar Cliente y Fletero para generar la Orden");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "" || txtValorUni.Text != "" || txtValorUniCte.Text != "")
            {
                txtTotalViaje.Text = (Convert.ToDecimal(txtCantidad.Text.Replace('.', ',')) * Convert.ToDecimal(txtValorUni.Text.Replace('.', ','))).ToString();
                txtImporteCte.Text = (Convert.ToDecimal(txtCantidad.Text.Replace('.', ',')) * Convert.ToDecimal(txtValorUniCte.Text.Replace('.', ','))).ToString();
                if (chkValorizado.Checked && txtPorcentaje.Text != "")
                {
                    txtComision.Text = (Convert.ToDecimal(txtTotalViaje.Text.Replace('.', ',')) * Convert.ToDecimal(txtPorcentaje.Text.Replace('.', ',')) / 100).ToString();
                }
                else if (radioButton2.Checked && txtValorFijo.Text != "")
                {
                    txtComision.Text = txtValorFijo.Text;
                }
            }
        }
    }
}
