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
        int idusuario = 0;
        int idemp = 0;
        public frmCtaCteFleteros(int pto, int idusu)
        {
            idusuario = idusu;
            ptoventa = pto;
            InitializeComponent();
        }

        public void buscar1()
        {
            if (u != null)
            {
                Acceso_BD oacceso = new Acceso_BD();
                DataTable dt = oacceso.leerDatos("select idfleteros, c.idempresas, ifnull(e.empresa, 'SIN EMPRESA') as empresa, sum(haber-debe) as saldo, case when c.idempresas = e.idempresas then 1 else 0 end as activo from ctactefleteros c left join empresas e on c.idempresas = e.idempresas where idfleteros = '" + u.Idfleteros + "' group by idfleteros, c.idempresas, empresa order by activo desc");
               
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
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
        }

        public void buscar(int idem)
        {
            if (u != null)
            {
                idemp = idem;
                em = new Empresas(u.Empresas.Idempresas, u.Empresas.Empresa, "", "", "", "", "", "", "");
                decimal debe = 0;
                decimal haber = 0;
                textBox1.Text = u.Empresas.Empresa;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (Convert.ToString(row.Cells["Empresa"].Value) == textBox1.Text)
                    {
                        dataGridView2.CurrentCell = row.Cells["Empresa"];
                        break;
                    }
                }
                Acceso_BD oa = new Acceso_BD();
                DataTable dt = oa.leerDatos("select (sum(haber)-sum(debe)) as saldo from ctactefleteros c where c.idempresas = '"+idemp+"' and c.idfleteros = '"+u.Idfleteros+"'");
                foreach (DataRow dr in dt.Rows)
                {
                    textBox2.Text = Convert.ToString(dr["saldo"]);
                }
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
                        if (checkBox1.Checked)
                        {
                            DateTime desde;
                            DateTime hasta;
                            if (DateTime.TryParse(maskedTextBox1.Text, out desde) && DateTime.TryParse(maskedTextBox2.Text, out hasta))
                            {
                                if (desde <= hasta)
                                {
                                    if (aux.Fecha.Date >= desde.Date && aux.Fecha.Date <= hasta.Date)
                                    {
                                        dataGridView1.Rows[x].Cells[0].Value = aux.Fecha.ToString("dd/MM/yyyy");
                                        dataGridView1.Rows[x].Cells[1].Value = aux.Conceptos.Descripcion;
                                        dataGridView1.Rows[x].Cells[2].Value = aux.Descripcion;
                                        string prueba = aux.Ordenescarga.Nrocarga;
                                        dataGridView1.Rows[x].Cells[3].Value = aux.Ptoventa + "-" + aux.Ordenescarga.Nrocarga;
                                        dataGridView1.Rows[x].Cells[4].Value = aux.Debe;                                        
                                        dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        dataGridView1.Rows[x].Cells[5].Value = aux.Haber;
                                        dataGridView1.Rows[x].Cells[6].Value = aux.Idctactefleteros;
                                        dataGridView1.Columns[6].Visible = false;
                                        debe = debe + Convert.ToDecimal(aux.Debe);
                                        haber = haber + Convert.ToDecimal(aux.Haber);
                                        x++;
                                    }
                                    else
                                    {
                                        debe = debe + Convert.ToDecimal(aux.Debe);
                                        haber = haber + Convert.ToDecimal(aux.Haber);
                                        dataGridView1.Rows.RemoveAt(x);
                                    }
                                }
                                else
                                {
                                    dataGridView1.Rows.Clear();
                                    MessageBox.Show("Desde debe ser menor o igual a hasta");
                                    break;
                                }
                            }
                        }
                        else
                        {
                            dataGridView1.Rows[x].Cells[0].Value = aux.Fecha.ToString("dd/MM/yyyy");
                            dataGridView1.Rows[x].Cells[1].Value = aux.Conceptos.Descripcion;
                            dataGridView1.Rows[x].Cells[2].Value = aux.Descripcion;
                            string prueba = aux.Ordenescarga.Nrocarga;
                            dataGridView1.Rows[x].Cells[3].Value = aux.Ptoventa + "-" + aux.Ordenescarga.Nrocarga;
                            dataGridView1.Rows[x].Cells[4].Value = aux.Debe;                            
                            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView1.Rows[x].Cells[5].Value = aux.Haber;
                            dataGridView1.Rows[x].Cells[6].Value = aux.Idctactefleteros;
                            dataGridView1.Columns[6].Visible = false;
                            debe = debe + Convert.ToDecimal(aux.Debe);
                            haber = haber + Convert.ToDecimal(aux.Haber);                            
                            x++;
                        }
                    }
                    label2.Text = (haber - debe).ToString();

                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];


                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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
                if (u != null)
                {
                    Acceso_BD oa = new Acceso_BD();
                    DataTable dt = oa.leerDatos("select count(*) as cant from ordenescarga o inner join clientes c on o.idclientes = c.idclientes inner join fleteros f on f.idfleteros = o.idfleteros inner join tiposcamion t on f.idtiposcamion = t.idtiposcamion left join empresas e on f.idempresas = e.idempresas inner join sucursales s on s.idsucursales = o.idsucursales where  o.idfleteros = '" + u.Idfleteros + "' and o.valorizado = '0' and o.anulado = '0'");
                    int cant = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        cant = Convert.ToInt32(dr["cant"]);
                    }
                    if (cant > 0)
                    {
                        button5.Text = "Ord.Carga Pendientes " + cant.ToString();
                        button5.Enabled = true;
                    }
                    else
                    {
                        button5.Text = "";
                        button5.Enabled = false;
                    }

                    dataGridView1.Rows.Clear();
                    dataGridView2.Rows.Clear();
                    buscar1();
                    buscar(u.Empresas.Idempresas);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message);
            }
        }

        private void frmCtaCteFleteros_Load(object sender, EventArgs e)
        {

            maskedTextBox1.Text = DateTime.Now.AddDays(-30).ToString("dd/MM/yyyy");
            maskedTextBox2.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].Name = "Fecha";
            dataGridView1.Columns[1].Name = "Concepto";
            dataGridView1.Columns[2].Name = "Descripcion";
            dataGridView1.Columns[3].Name = "Referencia";
            dataGridView1.Columns[4].Name = "Debe";
            dataGridView1.Columns[5].Name = "Haber";
            dataGridView1.Columns[6].Name = "id";
            dataGridView1.Columns[6].Visible = false;
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
            u.Empresas.Empresa = Convert.ToString(dataGridView2[2, filaseleccionada].Value);
            dataGridView1.Rows.Clear();
            label2.Text = Convert.ToString(dataGridView2[3, filaseleccionada].Value);
            buscar(idempresa);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (u != null)
                {
                    int chk = 0;
                    if (checkBox1.Checked)
                    {
                        chk = 1;
                    }
                    frmInfCtaCteFleteros frm = new frmInfCtaCteFleteros(u.Idfleteros, chk, maskedTextBox1.Text, maskedTextBox2.Text, idemp.ToString());
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (u != null && checkBox1.Checked)
            {
                dataGridView1.Rows.Clear();
                label2.Text = "0.00";
                buscar(u.Empresas.Idempresas);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string where = "where  o.idfleteros = '" + u.Idfleteros + "' and o.valorizado = '0' and o.anulado = '0'";
            frmListaOrdenesCarga frm = new frmListaOrdenesCarga(where);
            frm.ShowDialog();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Funciones f = new Funciones();
                if (f.acceder(35, idusuario))
                {
                    int filaseleccionada = Convert.ToInt32(this.dataGridView1.CurrentRow.Index);
                    string la = Convert.ToString(dataGridView1[6, filaseleccionada].Value);
                    string desc = Convert.ToString(dataGridView1[2, filaseleccionada].Value);
                    DialogResult dialogResult = MessageBox.Show("Esta seguro de editar descripcion " + desc, "Editar movimiento", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        
                        frmDescripcion frm = new frmDescripcion(la, desc, 1);
                        frm.ShowDialog();
                    }
                    dataGridView2_CellClick(sender, e);
                }
                else
                {
                    if (idusuario == 0)
                    {
                        MessageBox.Show("Debe iniciar sesion para acceder");
                    }
                    else
                    {
                        MessageBox.Show("Imposible acceder: usuario sin acceso");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Funciones f = new Funciones();
            if (f.acceder(38, idusuario))
            {
                if (u != null && idemp != 0)
                {
                    frmExpFleteros frm = new frmExpFleteros(u.Idfleteros, idemp, label2.Text, txtCliente.Text);
                    frm.ShowDialog();
                    dataGridView1.Rows.Clear();
                    dataGridView2.Rows.Clear();
                    buscar1();
                    buscar(em.Idempresas);
                }
            }
            else
            {
                if (idusuario == 0)
                {
                    MessageBox.Show("Debe iniciar sesion para acceder");
                }
                else
                {
                    MessageBox.Show("Imposible acceder: usuario sin acceso");
                }
            }
        }
    }
}
