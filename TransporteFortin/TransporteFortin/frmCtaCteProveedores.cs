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
    public partial class frmCtaCteProveedores : Form
    {
        Proveedores u = null;
        int idusuario = 0;
        int ptoventa = 0;
        public frmCtaCteProveedores(int pto,int idusu)
        {
            idusuario = idusu;
            InitializeComponent();
            ptoventa = pto;
        }

        public void buscar(int idprov)
        {
            if (u != null)
            {
                ControladoraCtaCteProveedores controlc = new ControladoraCtaCteProveedores();
                List<CtaCteProveedores> lista = controlc.BuscarEspecial(u.Idproveedores.ToString());
                int i = 0;
                double debe = 0;
                double haber = 0;
                foreach (CtaCteProveedores aux in lista)
                {
                    i++;
                }
                int x = 0;
                if (i > 0)
                {
                    dataGridView1.Rows.Add(i);
                    foreach (CtaCteProveedores aux in lista)
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
                                        dataGridView1.Rows[x].Cells[3].Value = aux.Ptoventa + "-" + aux.Ordenescomb.Nro;
                                        dataGridView1.Rows[x].Cells[4].Value = aux.Debe;
                                        dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        dataGridView1.Rows[x].Cells[5].Value = aux.Haber;
                                        dataGridView1.Rows[x].Cells[6].Value = aux.Idctacteproveedores;
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
                            dataGridView1.Rows[x].Cells[3].Value = aux.Ptoventa + "-" + aux.Ordenescomb.Nro;
                            dataGridView1.Rows[x].Cells[4].Value = aux.Debe;
                            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView1.Rows[x].Cells[5].Value = aux.Haber;
                            dataGridView1.Rows[x].Cells[6].Value = aux.Idctacteproveedores;
                            debe = debe + Convert.ToDouble(aux.Debe);
                            haber = haber + Convert.ToDouble(aux.Haber);
                            x++;
                        }
                    }
                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    }
                }
                label8.Text = (debe - haber).ToString();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaProveedores frm = new frmBuscaProveedores();
                frm.ShowDialog();
                u = frm.u;
                if (u != null)
                {
                    lblId.Text = Convert.ToString(u.Idproveedores);
                    txtCliente.Text = u.Proveedor;
                    txtDomicilio.Text = u.Direccion;
                    txtLocalidad.Text = u.Localidad;
                    txtTelefono.Text = u.Telefono;
                    txtCelular.Text = u.Celular;
                    txtContacto.Text = u.Contacto;
                    dataGridView1.Rows.Clear();
                    buscar(u.Idproveedores);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmCtaCteProveedores_Load(object sender, EventArgs e)
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
                frmMovProveedores frm = new frmMovProveedores("d", u, ptoventa);
                frm.ShowDialog();
                dataGridView1.Rows.Clear();
                label8.Text = "0.00";
                buscar(u.Idproveedores);
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
                frmMovProveedores frm = new frmMovProveedores("c", u, ptoventa);
                frm.ShowDialog();
                dataGridView1.Rows.Clear();
                buscar(u.Idproveedores);
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
                    frmInfCtaCteProv frm = new frmInfCtaCteProv(u.Idproveedores, chk, maskedTextBox1.Text, maskedTextBox2.Text);
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
                buscar(u.Idproveedores);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Funciones f = new Funciones();
                if (f.acceder(41, idusuario))
                {
                    int filaseleccionada = Convert.ToInt32(this.dataGridView1.CurrentRow.Index);
                    string la = Convert.ToString(dataGridView1[6, filaseleccionada].Value);
                    string desc = Convert.ToString(dataGridView1[2, filaseleccionada].Value);
                    DialogResult dialogResult = MessageBox.Show("Esta seguro de editar descripcion " + desc, "Editar movimiento", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        frmDescripcion frm = new frmDescripcion(la, desc, 2);
                        frm.ShowDialog();
                    }
                    dataGridView1.Rows.Clear();
                    buscar(u.Idproveedores);
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
