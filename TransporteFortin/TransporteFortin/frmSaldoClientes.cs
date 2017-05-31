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
    public partial class frmSaldoClientes : Form
    {
        public frmSaldoClientes()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Acceso_BD oa = new Acceso_BD();
                if (radioButton1.Checked)
                {
                    DataTable dt = oa.leerDatos("select cliente as Cliente, telefono as Telefono, celular as Celular, ifnull((select (sum(haber)-sum(debe)) from ctacteclientes c where  c.idclientes = f.idclientes),0) as Saldo  from clientes f having Saldo <> 0");
                    dataGridView1.DataSource = dt;
                    dt = oa.leerDatos("select sum(ifnull((select (sum(haber)-sum(debe)) from ctacteclientes c where  c.idclientes = f.idclientes),0)) as Saldo  from clientes f having Saldo <> 0");
                    foreach (DataRow dr in dt.Rows)
                    {
                        label2.Text = Convert.ToString(dr["Saldo"]);
                    }
                }
                else
                {
                    DataTable dt = oa.leerDatos("select cliente as Cliente, telefono as Telefono, celular as Celular, ifnull((select (sum(haber)-sum(debe)) from ctacteclientes c where  c.idclientes = f.idclientes),0) as Saldo  from clientes f");
                    dataGridView1.DataSource = dt;
                    dt = oa.leerDatos("select sum(ifnull((select (sum(haber)-sum(debe)) from ctacteclientes c where  c.idclientes = f.idclientes),0)) as Saldo  from clientes f");
                    foreach (DataRow dr in dt.Rows)
                    {
                        label2.Text = Convert.ToString(dr["Saldo"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
