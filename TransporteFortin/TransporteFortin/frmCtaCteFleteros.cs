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
    public partial class frmCtaCteFleteros : Form
    {
        Fleteros u = null;
        Empresas em = null;
        int ptoventa = 0;
        public frmCtaCteFleteros(int pto)
        {
            ptoventa = pto;
            InitializeComponent();
        }

        public void buscar1()
        {
            if (u != null)
            {
                Acceso_BD oacceso = new Acceso_BD();
                DataTable dt = oacceso.leerDatos("select idfleteros, c.idempresas, ifnull(e.empresa, 'SIN EMPRESA') as empresa, sum(debe-haber) as saldo, case when c.idempresas = e.idempresas then 1 else 0 end as activo from ctactefleteros c left join empresas e on c.idempresas = e.idempresas where idfleteros = '" + u.Idfleteros + "' group by idfleteros, c.idempresas, empresa order by activo desc");
               
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    i++;
                }
                int x = 0;
                if (i > 0)
                {
                    dataGridView2.Rows.Add(i);
                    foreach (DataRow dr in dt.Rows)
                    {
                        dataGridView2.Rows[x].Cells[0].Value = Convert.ToString(dr["idfleteros"]);
                        dataGridView2.Rows[x].Cells[1].Value = Convert.ToString(dr["idempresas"]);
                        dataGridView2.Rows[x].Cells[2].Value = Convert.ToString(dr["empresa"]);
                        dataGridView2.Rows[x].Cells[3].Value = Convert.ToString(dr["saldo"]);
                        dataGridView2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        if (x == 0)
                        {
                            //label2.Text = Convert.ToString(dr["saldo"]);
                        }
                        x++;
                    }
                }
            }
        }

        public void buscar(int idem)
        {
            if (u != null)
            {
                em = new Empresas(u.Empresas.Idempresas, u.Empresas.Empresa, "", "", "", "", "", "", "");
                double debe = 0;
                double haber = 0;
                txtCliente.Text = u.Fletero;
                txtDomicilio.Text = u.Direccion;
                txtTelefono.Text = u.Telefono;
                txtDocumento.Text = u.Documento.ToString();
                ControladoraCtaCteFleteros controlc = new ControladoraCtaCteFleteros();
                string where = "f.idfleteros = '" + u.Idfleteros + "' and f.idempresas = '" + idem + "'";
                List<CtaCteFleteros> lista = controlc.BuscarEspecial(where);
                int i = 0;
                foreach (CtaCteFleteros aux in lista)
                {
                    i++;
                }
                int x = 0;
                if (i > 0)
                {
                    dataGridView1.Rows.Add(i);
                    foreach (CtaCteFleteros aux in lista)
                    {
                        dataGridView1.Rows[x].Cells[0].Value = aux.Fecha.ToString("dd/MM/yyyy");
                        dataGridView1.Rows[x].Cells[1].Value = aux.Conceptos.Concepto;
                        dataGridView1.Rows[x].Cells[2].Value = aux.Descripcion;
                        string prueba = aux.Ordenescarga.Nrocarga;
                        dataGridView1.Rows[x].Cells[3].Value = aux.Ptoventa + "-" + aux.Ordenescarga.Nrocarga;
                        dataGridView1.Rows[x].Cells[4].Value = aux.Debe;
                        debe = debe+Convert.ToDouble(aux.Debe);
                        dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView1.Rows[x].Cells[5].Value = aux.Haber;
                        haber = haber+Convert.ToDouble(aux.Haber);
                        label2.Text = (debe - haber).ToString();
                        x++;
                    }
                }

            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaFleteros frm = new frmBuscaFleteros();
                frm.ShowDialog();
                u = frm.u;
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();
                buscar1();
                buscar(u.Empresas.Idempresas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message);
            }
        }

        private void frmCtaCteFleteros_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "Fecha";
            dataGridView1.Columns[1].Name = "Concepto";
            dataGridView1.Columns[2].Name = "Descripcion";
            dataGridView1.Columns[3].Name = "Referencia";
            dataGridView1.Columns[4].Name = "Debe";
            dataGridView1.Columns[5].Name = "Haber";

            dataGridView2.ColumnCount = 4;
            dataGridView2.Columns[0].Name = "idfleteros";
            dataGridView2.Columns[1].Name = "idempresas";
            dataGridView2.Columns[2].Name = "Empresa";
            dataGridView2.Columns[3].Name = "Saldo";
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[1].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frmMovFleteros frm = new frmMovFleteros("d", u, em, ptoventa);
                frm.ShowDialog();
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();
                buscar1();
                buscar(em.Idempresas);              
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                frmMovFleteros frm = new frmMovFleteros("c", u, em, ptoventa);
                frm.ShowDialog();
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();
                buscar1();
                buscar(em.Idempresas);  
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows.Clear();
            int filaseleccionada = Convert.ToInt32(this.dataGridView2.CurrentRow.Index);
            int idfletero = Convert.ToInt32(dataGridView2[0, filaseleccionada].Value);
            int idempresa = Convert.ToInt32(dataGridView2[1, filaseleccionada].Value);
            dataGridView1.Rows.Clear();
            label2.Text = Convert.ToString(dataGridView2[3, filaseleccionada].Value);
            buscar(idempresa);
            //u = new Fleteros(idfletero, documento, fletero, direccion, localidad, cp.ToString(), telefono, celular, fax, mail, emp, camion, tipoiv, chapacamion, chapaacoplado, cuit, ti);
        }
    }
}
