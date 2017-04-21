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
    public partial class frmConsultaRecibos : Form
    {
        string idrecibo = "";
        string total = "";
        string cantidadde = "";
        string concepto = "";
        string recibimosde = "";
        int tip1o = 0;
        int quien1 = 0;
        public frmConsultaRecibos(int talon, int tipo, int quien)
        {
            InitializeComponent();
            textBox1.Text = talon.ToString();
            tip1o = tipo;
            quien1 = quien;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmConsultaRecibos_Load(object sender, EventArgs e)
        {

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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    
                    Acceso_BD oa = new Acceso_BD();
                    DataTable dt = new DataTable();
                    if (tip1o == 0)
                    {
                        if (quien1 == 0)
                        {
                            dt = oa.leerDatos("select r.idrecibos as idrecibos, r.tipo as tipo, r.fecha as fecha, concat(con.descripcion, ' - ',r.comentarios) as comentarios, con.descripcion as concepto, r.importe as importe, c.cliente as cliente, f.fletero as fletero, p.proveedor as proveedor, r.idclientes as idclientes, r.idproveedores as idproveedores, r.idfleteros as idfleteros from recibos r left join clientes c on r.idclientes = c.idclientes left join fleteros f on r.idfleteros = f.idfleteros left join proveedores p on r.idproveedores = p.idproveedores left join conceptos con on r.concepto = con.codigo where ptoventa = '" + textBox1.Text + "' and nro = '" + textBox2.Text + "' and r.idclientes <> 0 and r.idfleteros = 0 and r.tipo = 0");
                        }
                        else if (quien1 == 1)
                        {
                            dt = oa.leerDatos("select r.idrecibos as idrecibos, r.tipo as tipo, r.fecha as fecha, concat(con.descripcion, ' - ',r.comentarios) as comentarios, con.descripcion as concepto, r.importe as importe, c.cliente as cliente, f.fletero as fletero, p.proveedor as proveedor, r.idclientes as idclientes, r.idproveedores as idproveedores, r.idfleteros as idfleteros from recibos r left join clientes c on r.idclientes = c.idclientes left join fleteros f on r.idfleteros = f.idfleteros left join proveedores p on r.idproveedores = p.idproveedores left join conceptos con on r.concepto = con.codigo where ptoventa = '" + textBox1.Text + "' and nro = '" + textBox2.Text + "' and r.idfleteros <> 0 and r.idclientes = 0 and r.tipo = 0");
                        }
                    }
                    else
                    {
                        if (quien1 == 1)
                        {
                            dt = oa.leerDatos("select r.idrecibos as idrecibos, r.tipo as tipo, r.fecha as fecha, concat(con.descripcion, ' - ',r.comentarios) as comentarios, con.descripcion as concepto, r.importe as importe, c.cliente as cliente, f.fletero as fletero, p.proveedor as proveedor, r.idclientes as idclientes, r.idproveedores as idproveedores, r.idfleteros as idfleteros from recibos r left join clientes c on r.idclientes = c.idclientes left join fleteros f on r.idfleteros = f.idfleteros left join proveedores p on r.idproveedores = p.idproveedores left join conceptos con on r.concepto = con.codigo where ptoventa = '" + textBox1.Text + "' and nro = '" + textBox2.Text + "' and r.idfleteros <> 0 and r.idproveedores = 0 and r.tipo = 1");
                        }
                        else if (quien1 == 2)
                        {
                            dt = oa.leerDatos("select r.idrecibos as idrecibos, r.tipo as tipo, r.fecha as fecha, concat(con.descripcion, ' - ',r.comentarios) as comentarios, con.descripcion as concepto, r.importe as importe, c.cliente as cliente, f.fletero as fletero, p.proveedor as proveedor, r.idclientes as idclientes, r.idproveedores as idproveedores, r.idfleteros as idfleteros from recibos r left join clientes c on r.idclientes = c.idclientes left join fleteros f on r.idfleteros = f.idfleteros left join proveedores p on r.idproveedores = p.idproveedores left join conceptos con on r.concepto = con.codigo where ptoventa = '" + textBox1.Text + "' and nro = '" + textBox2.Text + "' and r.idproveedores <> 0 and r.idfleteros = 0 and r.tipo = 1");
                        }
                    }
                    int tipo = 0;
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            idrecibo = Convert.ToString(dr["idrecibos"]);
                            if (Convert.ToInt32(dr["tipo"]) == 0)
                            {
                                rbRecibo.Checked = true;
                            }
                            else
                            {
                                rbOP.Checked = true;
                            }

                            if (Convert.ToInt32(dr["idclientes"]) != 0)
                            {
                                chkClientes.Checked = true;
                                txtCliente.Text = Convert.ToString(dr["cliente"]);
                                chkFleteros.Checked = false;
                                chkProveedores.Checked = false;
                            }
                            else if (Convert.ToInt32(dr["idfleteros"]) != 0)
                            {
                                chkClientes.Checked = false;
                                chkFleteros.Checked = true;
                                txtCliente.Text = Convert.ToString(dr["fletero"]);
                                chkProveedores.Checked = false;
                            }
                            else if (Convert.ToInt32(dr["idproveedores"]) != 0)
                            {
                                chkClientes.Checked = false;
                                chkFleteros.Checked = false;
                                chkProveedores.Checked = true;
                                txtCliente.Text = Convert.ToString(dr["proveedor"]);
                                
                            }
                            recibimosde = txtCliente.Text;
                            txtImporte.Text = Convert.ToString(dr["importe"]);
                            total = txtImporte.Text;
                            concepto = Convert.ToString("concepto");
                            mskDesde.Text = Convert.ToString(dr["fecha"]);
                            cantidadde = enletras(total);  
                            richTextBox1.Text = Convert.ToString(dr["comentarios"]);
                        }
                        if (tip1o == 0)
                        {
                            dataGridView1.DataSource = oa.leerDatos("select f1.detalle as 'FORMA DE PAGO', f.importe AS IMPORTE, f.cheque AS 'NRO CHEQUE O TRANSFERENCIA' from formasdepago f left join formaspago f1 on f.idformaspago = f1. idformaspago where idrecibos = '" + idrecibo + "'");
                        }
                        else
                        {
                            dataGridView1.DataSource = oa.leerDatos("select f1.detalle as 'FORMA DE PAGO', f.importe AS IMPORTE, f.cheque AS 'NRO CHEQUE O TRANSFERENCIA' from formasdepago f left join formaspago f1 on f.idformaspago = f1. idformaspago where idordenespago = '" + idrecibo + "'");
                        }
                    }
                    else
                    {
                        if (dataGridView1.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = null;
                        }
                        chkClientes.Checked = false;
                        chkFleteros.Checked = false;
                        chkProveedores.Checked = false;
                        rbOP.Checked = false;
                        rbRecibo.Checked = false;
                        txtCliente.Text = "";
                        txtImporte.Text = "";
                        mskDesde.Text = "";
                        richTextBox1.Text = "";
                        idrecibo = "";
                        MessageBox.Show("Recibo inexistente");                        
                    }

                }
                else
                {
                    MessageBox.Show("Debe completar los campos talon y nro de recibo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (idrecibo != "")
            {
                frmRecibo frm = null;
                frmOrdenPago frm1 = null;
                if (tip1o == 0)
                {
                    frm = new frmRecibo(Convert.ToInt32(idrecibo), total, cantidadde, concepto, recibimosde);
                    frm.ShowDialog();
                }
                else
                {
                    frm1 = new frmOrdenPago(Convert.ToInt32(idrecibo), total, cantidadde, concepto, recibimosde);
                    frm1.ShowDialog();
                }
                //desea reimprimir
                for (int x = 0; x < 2; x++)
                {
                    DialogResult dialogResult = MessageBox.Show("Desea reimprimir el recibo?", "Reimprime recibo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (tip1o == 0)
                        {
                            frm.ShowDialog();
                        }
                        else
                        {
                            frm1.ShowDialog();
                        }
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
                MessageBox.Show("Imposible reimprimir recibo");
            }
        }
    }
}
