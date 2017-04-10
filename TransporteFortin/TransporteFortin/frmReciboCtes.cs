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
    public partial class frmReciboCtes : Form
    {
        List<FormasDePago> lista = new List<FormasDePago>();
        BdRecibos bd = new BdRecibos();
        Clientes u = null;
        string concepto = "";
        int idrecibo = 0;
        int idusuario = 0;
        int puesto = 0;
        int sucursal = 0;
        int talon = 0;
        public frmReciboCtes(int idreci, int idusu, int pue, int suc, int tal)
        {
            concepto = "c";
            InitializeComponent();
            idrecibo = idreci;
            idusuario = idusu;
            puesto = pue;
            sucursal = suc;
            talon = tal;
        }

        private void frmReciboCtes_Load(object sender, EventArgs e)
        {
            Acceso_BD oacceso = new Acceso_BD();
            DataTable dt = oacceso.leerDatos("select * from conceptoscc where doc = '" + concepto + "' and grupo = 1 order by descripcion asc");
            List<Conceptos> listat = new List<Conceptos>();
            foreach (DataRow dr in dt.Rows)
            {
                Conceptos c = new Conceptos(Convert.ToInt32(dr["idconceptoscc"]), Convert.ToString(dr["descripcion"]),"");
                listat.Add(c);
            }
            cmbConceptos.DataSource = listat;
            cmbConceptos.DisplayMember = "descripcion";
            cmbConceptos.ValueMember = "codigo";

            dt = oacceso.leerDatos("select * from cajas");
            cmbcaja.DataSource = dt;
            cmbcaja.DisplayMember = "nrocaja";
            cmbcaja.ValueMember = "idcajas";
        }

        public string enletras(string num)
        {
            string res, dec = "";
            Int64 entero;
            int decimales;
            double nro;

            try
            {
                nro = Convert.ToDouble(num);
            }
            catch
            {
                return "";
            }

            entero = Convert.ToInt64(Math.Truncate(nro));
            decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));
            if (decimales > 0)
            {
                dec = " CON " + decimales.ToString() + "/100";
            }

            res = toText(Convert.ToDouble(entero)) + dec;
            return res;
        }

        private string toText(double value)
        {
            string Num2Text = "";
            value = Math.Truncate(value);
            if (value == 0) Num2Text = "CERO";
            else if (value == 1) Num2Text = "UNO";
            else if (value == 2) Num2Text = "DOS";
            else if (value == 3) Num2Text = "TRES";
            else if (value == 4) Num2Text = "CUATRO";
            else if (value == 5) Num2Text = "CINCO";
            else if (value == 6) Num2Text = "SEIS";
            else if (value == 7) Num2Text = "SIETE";
            else if (value == 8) Num2Text = "OCHO";
            else if (value == 9) Num2Text = "NUEVE";
            else if (value == 10) Num2Text = "DIEZ";
            else if (value == 11) Num2Text = "ONCE";
            else if (value == 12) Num2Text = "DOCE";
            else if (value == 13) Num2Text = "TRECE";
            else if (value == 14) Num2Text = "CATORCE";
            else if (value == 15) Num2Text = "QUINCE";
            else if (value < 20) Num2Text = "DIECI" + toText(value - 10);
            else if (value == 20) Num2Text = "VEINTE";
            else if (value < 30) Num2Text = "VEINTI" + toText(value - 20);
            else if (value == 30) Num2Text = "TREINTA";
            else if (value == 40) Num2Text = "CUARENTA";
            else if (value == 50) Num2Text = "CINCUENTA";
            else if (value == 60) Num2Text = "SESENTA";
            else if (value == 70) Num2Text = "SETENTA";
            else if (value == 80) Num2Text = "OCHENTA";
            else if (value == 90) Num2Text = "NOVENTA";
            else if (value < 100) Num2Text = toText(Math.Truncate(value / 10) * 10) + " Y " + toText(value % 10);
            else if (value == 100) Num2Text = "CIEN";
            else if (value < 200) Num2Text = "CIENTO " + toText(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = toText(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) Num2Text = "QUINIENTOS";
            else if (value == 700) Num2Text = "SETECIENTOS";
            else if (value == 900) Num2Text = "NOVECIENTOS";
            else if (value < 1000) Num2Text = toText(Math.Truncate(value / 100) * 100) + " " + toText(value % 100);
            else if (value == 1000) Num2Text = "MIL";
            else if (value < 2000) Num2Text = "MIL " + toText(value % 1000);
            else if (value < 1000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0) Num2Text = Num2Text + " " + toText(value % 1000);
            }

            else if (value == 1000000) Num2Text = "UN MILLON";
            else if (value < 2000000) Num2Text = "UN MILLON " + toText(value % 1000000);
            else if (value < 1000000000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000) * 1000000);
            }

            else if (value == 1000000000000) Num2Text = "UN BILLON";
            else if (value < 2000000000000) Num2Text = "UN BILLON " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            else
            {
                Num2Text = toText(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            }
            return Num2Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (u != null)
                {
                    if (lista.Count > 0)
                    {
                        Conceptos conc = new Conceptos(Convert.ToInt32(cmbConceptos.SelectedValue), "", "");
                        Fleteros flet = new Fleteros(0, 0, "", "", "", "", "", "", "", "", null, "", null, "", "", "", null);
                        Clientes cli = u;
                        Proveedores prov = new Proveedores(0, "", "", "", 0, "", "", "", "", "", "", null, "", 0);
                        Sucursales suc = new Sucursales(sucursal, "");
                        Usuarios usu = new Usuarios(idusuario, "", "");
                        Recibos r = new Recibos(0, dateTimePicker1.Value, conc, 0, Convert.ToDecimal(txtTotal.Text), flet, txtComentarios.Text, talon, cli, prov, puesto, usu, suc, 0);                        
                        bd.Agregar(r, lista,Convert.ToInt32(cmbcaja.SelectedValue));
                        MessageBox.Show("OK");
                    }
                    else
                    {
                        MessageBox.Show("Debe cargar al menos una forma de pago");
                    }
                }
                else
                {
                    MessageBox.Show("Debe elegir un cliente al cual acreditar el pago");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaClientes frm = new frmBuscaClientes();
                frm.ShowDialog();
                u = frm.u;
                if (u != null)
                {
                    txtCliente.Text = u.Cliente;
                    txtRecibimosDe.Text = u.Cliente;
                    txtEnConcepto.Text = cmbConceptos.Text;
                    Acceso_BD oa = new Acceso_BD();
                    DataTable dt = oa.leerDatos("SELECT SUM(DEBE-HABER) as saldo FROM CTACTECLIENTES WHERE IDCLIENTES = '" + u.Idclientes + "'");
                    foreach (DataRow dr in dt.Rows)
                    {
                        txtSaldo.Text = Convert.ToString(dr["saldo"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message);
            }
        }

        private void txtTalon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNroRec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

            for (int i = 0; i < txtEfectivo.Text.Length; i++)
            {
                if (txtEfectivo.Text[i] == '.')
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

        private void button5_Click(object sender, EventArgs e)
        {
            txtTotal.Text = (Convert.ToDecimal(txtEfectivo.Text.Replace('.', ',')) + Convert.ToDecimal(txtCheques.Text.Replace('.', ',')) + Convert.ToDecimal(txtTransf.Text.Replace('.', ','))).ToString();
            txtPesosLetras.Text = enletras(txtTotal.Text);            
        }

        private void txtPesosLetras_MouseHover(object sender, EventArgs e)
        {
            if (txtPesosLetras.Text != "")
            {
                toolTip1.Show(txtPesosLetras.Text, txtPesosLetras);
            }
        }

        private void txtPesosLetras_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(txtPesosLetras);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmFormasPago frm = new frmFormasPago(lista);
            frm.ShowDialog();            
            if (frm.lista.Count > 0)
            {
                decimal efec = 0;
                decimal transf = 0;
                decimal chequep = 0;
                decimal total = 0;
                lista = frm.lista;
                foreach (FormasDePago f in lista)
                {
                    if (f.Idformaspago == 1)
                    {
                        efec = efec + f.Importe;
                    }
                    else if (f.Idformaspago == 2 || f.Idformaspago == 3)
                    {
                        chequep = chequep + f.Importe;
                    }
                    else if (f.Idformaspago == 4)
                    {
                        transf = transf + f.Importe;
                    }
                }
                total = efec + chequep + transf;
                txtEfectivo.Text = efec.ToString();
                txtCheques.Text = chequep.ToString();
                txtTransf.Text = transf.ToString();
                txtTotal.Text = total.ToString();
                txtPesosLetras.Text = enletras(txtTotal.Text);  
            }
        }

        private void cmbConceptos_TextChanged(object sender, EventArgs e)
        {
            txtEnConcepto.Text = cmbConceptos.Text;
        }

        private void cmbConceptos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEnConcepto.Text = cmbConceptos.Text;
        }
    }
}
