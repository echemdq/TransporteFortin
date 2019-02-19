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
    public partial class frmCtaCteClientes : Form
    {
        int ptoventa = 0;
        Clientes u = null;

        int idusuario = 0;
        public frmCtaCteClientes(int talon, int idusu)
        {
            idusuario = idusu;
            ptoventa = talon;
            InitializeComponent();
        }

        public void buscar(int idcli)
        {
            if (u != null)
            {
                
                ControladoraCtaCteClientes controlc = new ControladoraCtaCteClientes();
                List<CtaCteClientes> lista = new List<CtaCteClientes>();
                lista = null;
                lista = controlc.BuscarEspecial(u.Idclientes.ToString());
                int i = 0;
                double debe = 0;
                double haber = 0;
                foreach (CtaCteClientes aux in lista)
                {
                    i++;
                }
                int x = 0;
                if (i > 0)
                {
                    dataGridView1.Rows.Add(i);
                    foreach (CtaCteClientes aux in lista)
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
                                        dataGridView1.Rows[x].Cells[3].Value = aux.Ptoventa + "-" + aux.Ordenescarga.Nrocarga;
                                        dataGridView1.Rows[x].Cells[4].Value = aux.Debe;
                                        dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        dataGridView1.Rows[x].Cells[5].Value = aux.Haber;
                                        dataGridView1.Rows[x].Cells[6].Value = aux.Idctacteclientes;
                                        dataGridView1.Columns[6].Visible = false;
                                        debe = debe + Convert.ToDouble(aux.Debe);
                                        haber = haber + Convert.ToDouble(aux.Haber);
                                        x++;
                                    }
                                    else
                                    {
                                        debe = debe + Convert.ToDouble(aux.Debe);
                                        haber = haber + Convert.ToDouble(aux.Haber);
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
                            dataGridView1.Rows[x].Cells[3].Value = aux.Ptoventa + "-" + aux.Ordenescarga.Nrocarga;
                            dataGridView1.Rows[x].Cells[4].Value = aux.Debe;
                            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView1.Rows[x].Cells[5].Value = aux.Haber;

                            dataGridView1.Rows[x].Cells[6].Value = aux.Idctacteclientes;
                            dataGridView1.Columns[6].Visible = false;
                            debe = debe + Convert.ToDouble(aux.Debe);
                            haber = haber + Convert.ToDouble(aux.Haber);
                            x++;
                        }
                    }
                }
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];
                    //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView1.Columns[3].Width = 175;
                    dataGridView1.Columns[2].Width = 175;
                }
                label8.Text = Convert.ToDouble(haber - debe).ToString();
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
                    Acceso_BD oa = new Acceso_BD();
                    DataTable dt = oa.leerDatos("select ifnull(count(*), 0) as cant from ordenescarga o inner join clientes c on o.idclientes = c.idclientes inner join fleteros f on f.idfleteros = o.idfleteros inner join tiposcamion t on f.idtiposcamion = t.idtiposcamion left join empresas e on f.idempresas = e.idempresas inner join sucursales s on s.idsucursales = o.idsucursales where  o.idclientes = '" + u.Idclientes + "' and o.valorizado = '0' and o.anulado = '0'");
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
                        button5.Text ="";
                        button5.Enabled = false;
                    }
                    lblId.Text = Convert.ToString(u.Idclientes);
                    txtCliente.Text = u.Cliente;
                    txtDomicilio.Text = u.Direccion;
                    txtLocalidad.Text = u.Localidad;
                    txtTelefono.Text = u.Telefono;
                    txtCelular.Text = u.Celular;
                    txtContacto.Text = u.Contacto;
                    dataGridView1.Rows.Clear();
                    buscar(u.Idclientes);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message);
            }
        }

        private void frmCtaCteClientes_Load(object sender, EventArgs e)
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (u != null)
                {
                    frmMovClientes frm = new frmMovClientes("d", u, ptoventa);
                    frm.ShowDialog();
                    dataGridView1.Rows.Clear();
                    buscar(u.Idclientes);
                }
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
                if (u != null)
                {
                    frmMovClientes frm = new frmMovClientes("c", u, ptoventa);
                    frm.ShowDialog();
                    dataGridView1.Rows.Clear();
                    buscar(u.Idclientes);
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
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
                    frmInfCtaCteCtes frm = new frmInfCtaCteCtes(u.Idclientes, chk, maskedTextBox1.Text, maskedTextBox2.Text);
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
            if (u != null)
            {
                dataGridView1.Rows.Clear();
                label8.Text = "0.00";
                buscar(u.Idclientes);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string where = "where  o.idclientes = '" + u.Idclientes + "' and o.valorizado = '0' and o.anulado = '0'";
            frmListaOrdenesCarga frm = new frmListaOrdenesCarga(where, idusuario);
            frm.ShowDialog();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Funciones f = new Funciones();
                if (f.acceder(34, idusuario))
                {
                    int filaseleccionada = Convert.ToInt32(this.dataGridView1.CurrentRow.Index);
                    string la = Convert.ToString(dataGridView1[6, filaseleccionada].Value);
                    string desc = Convert.ToString(dataGridView1[2, filaseleccionada].Value);
                    DialogResult dialogResult = MessageBox.Show("Esta seguro de editar descripcion " + desc, "Eliminar movimiento", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        frmDescripcion frm = new frmDescripcion(la, desc, 0);
                        frm.ShowDialog();
                    }
                    button4_Click(sender, e);
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
    }
}
