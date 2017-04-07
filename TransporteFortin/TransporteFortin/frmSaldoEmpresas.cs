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
    public partial class frmSaldoEmpresas : Form
    {
        Empresas u = null;
        public frmSaldoEmpresas()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaEmpresas frm = new frmBuscaEmpresas();
                frm.ShowDialog();
                u = frm.u;
                if (u != null)
                {
                    txtEmpresas.Text = u.Empresa;
                    Acceso_BD oacceso = new Acceso_BD();
                    DataTable dt = oacceso.leerDatos("select (sum(debe)-sum(haber)) as saldo, f.fletero from ctactefleteros c inner join fleteros f on c.idfleteros = f.idfleteros where c.idempresas = '"+u.Idempresas+"' group by fletero");
                    int x = 0;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Rows.Add(dt.Rows.Count);
                    double debe = 0;
                    double haber = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        double saldo = Convert.ToDouble(dr["saldo"]);
                        string fletero = Convert.ToString(dr["fletero"]);
                        dataGridView1.Rows[x].Cells[0].Value = fletero;
                        if (saldo < 0)
                        {
                            dataGridView1.Rows[x].Cells[1].Value = 0;
                            haber = haber + Math.Abs(saldo);
                            dataGridView1.Rows[x].Cells[2].Value = Math.Abs(saldo);
                            
                        }
                        else
                        {
                            dataGridView1.Rows[x].Cells[1].Value = saldo;
                            debe = debe + saldo;
                            dataGridView1.Rows[x].Cells[2].Value = 0;
                            
                        }                        
                        x++;
                    }
                        label2.Text = (debe - haber).ToString();
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Buscar: " + ex.Message);
            }
        }

        private void frmSaldoEmpresas_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Fletero";
            dataGridView1.Columns[1].Name = "Deudor";
            dataGridView1.Columns[2].Name = "Acreedor";
        }
    }
}
