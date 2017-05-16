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
    public partial class frmReciboFleteros : Form
    {
        List<FormasDePago> lista = new List<FormasDePago>();
        Fleteros u = null;
        BdRecibos bd = new BdRecibos();
        Empresas em = null;
        string concepto = "";
        int idrecibo = 0;
        int idusuario = 0;
        int puesto = 0;
        int sucursal = 0;
        int talon = 0;
        public frmReciboFleteros(int idreci, int idusu, int pue, int suc, int tal)
        {
            concepto = "c";
            InitializeComponent();
            idrecibo = idreci;
            idusuario = idusu;
            puesto = pue;
            sucursal = suc;
            talon = tal;
        }

        public void buscar()
        {
            if (u != null)
            {
                Acceso_BD oacceso = new Acceso_BD();
                DataTable dt = oacceso.leerDatos("select c.idempresas as idempresas, ifnull(e.empresa, 'SIN EMPRESA') as empresa, case when c.idempresas = e.idempresas then 1 else 0 end as activo from ctactefleteros c left join empresas e on c.idempresas = e.idempresas where idfleteros = '" + u.Idfleteros + "' group by idempresas, empresa union select f.idempresas as idempresas, ifnull(e.empresa, 'SIN EMPRESA') as empresa, case when f.idempresas = e.idempresas then 1 else 0 end as activo from fleteros f left join empresas e on f.idempresas = e.idempresas where f.idfleteros = '" + u.Idfleteros + "' order by activo desc");
                List<Empresas> listat = new List<Empresas>();
                foreach (DataRow dr in dt.Rows)
                {
                    em = new Empresas(Convert.ToInt32(dr["idempresas"]), Convert.ToString(dr["empresa"]), "", "", "", "", "", "", "");
                    listat.Add(em);
                }
                cmbemp.DataSource = listat;
                cmbemp.DisplayMember = "empresa";
                cmbemp.ValueMember = "idempresas";          
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaFleteros frm = new frmBuscaFleteros();
                frm.ShowDialog();
                u = frm.u;
                if (u != null)
                {
                    txtCliente.Text = u.Fletero;
                    txtRecibimosDe.Text = u.Fletero;
                    txtEnConcepto.Text = cmbConceptos.Text;
                    buscar();
                    Acceso_BD oa = new Acceso_BD();
                    DataTable dt = oa.leerDatos("SELECT SUM(HABER-DEBE) as saldo FROM ctactefleteros WHERE idfleteros = '" + u.Idfleteros + "' and idempresas = '"+u.Empresas.Idempresas+"'");
                    cmbemp.SelectedValue = u.Empresas.Idempresas;
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

        private void frmReciboFleteros_Load(object sender, EventArgs e)
        {
            Acceso_BD oacceso = new Acceso_BD();
            DataTable dt = oacceso.leerDatos("select * from conceptoscc where doc = 'c' and grupo = 1 order by descripcion asc");
            List<Conceptos> listat = new List<Conceptos>();
            foreach (DataRow dr in dt.Rows)
            {
                Conceptos c = new Conceptos(Convert.ToInt32(dr["idconceptoscc"]), Convert.ToString(dr["descripcion"]), "");
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

        private void cmbemp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Acceso_BD oa = new Acceso_BD();
            DataTable dt = oa.leerDatos("SELECT SUM(DEBE-HABER) as saldo FROM ctactefleteros WHERE idfleteros = '" + u.Idfleteros + "' and idempresas = '" + cmbemp.SelectedValue + "'");
            foreach (DataRow dr in dt.Rows)
            {
                txtSaldo.Text = Convert.ToString(dr["saldo"]);
            }
        }

        private void cmbConceptos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEnConcepto.Text = cmbConceptos.Text;
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

        private void button2_Click(object sender, EventArgs e)
        {
            frmFormasPago frm = new frmFormasPago(lista,0);
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (u != null)
                {
                    if (lista.Count > 0)
                    {
                        Conceptos conc = new Conceptos(Convert.ToInt32(cmbConceptos.SelectedValue), "", "");
                        Fleteros flet = u;
                        Clientes cli = new Clientes(0, "", "", "", "", "", "", "", "", "", "", null, "");
                        Proveedores prov = new Proveedores(0, "", "", "", 0, "", "", "", "", "", "", null, "", 0);
                        Sucursales suc = new Sucursales(sucursal, "");
                        Usuarios usu = new Usuarios(idusuario, "", "");
                        Recibos r = new Recibos(0, dateTimePicker1.Value, conc, 0, Convert.ToDecimal(txtTotal.Text), flet, txtComentarios.Text, talon, cli, prov, puesto, usu, suc, 0);
                        int idrecibos = bd.Agregar(r, lista, Convert.ToInt32(cmbcaja.SelectedValue));
                        frmRecibo frm = new frmRecibo(idrecibos, txtTotal.Text, txtPesosLetras.Text, txtEnConcepto.Text, txtRecibimosDe.Text);
                        frm.ShowDialog();

                        //desea reimprimir

                        for (int x = 0; x < 2; x++)
                        {
                            DialogResult dialogResult = MessageBox.Show("Desea reimprimir el recibo?", "Reimprime recibo", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                frm.ShowDialog();
                                x--;
                            }
                            else
                            {
                                x = x + 10;
                            }
                        }
                        this.Close();
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
    }
}
