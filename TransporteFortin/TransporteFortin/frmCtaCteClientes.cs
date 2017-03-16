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
        public frmCtaCteClientes(int talon)
        {
            ptoventa = talon;
            InitializeComponent();
        }

        public void buscar(int idcli)
        {
            if (u != null)
            {
                ControladoraCtaCteClientes controlc = new ControladoraCtaCteClientes();
                List<CtaCteClientes> lista = controlc.BuscarEspecial(u.Idclientes.ToString());
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
                        dataGridView1.Rows[x].Cells[0].Value = aux.Fecha.ToString("dd/MM/yyyy");
                        dataGridView1.Rows[x].Cells[1].Value = aux.Conceptos.Concepto;
                        dataGridView1.Rows[x].Cells[2].Value = aux.Descripcion;
                        dataGridView1.Rows[x].Cells[3].Value = aux.Ptoventa + "-" + aux.Ordenescarga.Nrocarga;
                        dataGridView1.Rows[x].Cells[4].Value = aux.Debe;
                        dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView1.Rows[x].Cells[5].Value = aux.Haber;
                        debe = debe + Convert.ToDouble(aux.Debe);
                        haber = haber + Convert.ToDouble(aux.Haber);
                        x++;
                    }
                }
                label8.Text = (debe - haber).ToString();
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
                    lblId.Text = Convert.ToString(u.Idclientes);
                    txtCliente.Text = u.Cliente;
                    txtDomicilio.Text = u.Direccion;
                    txtLocalidad.Text = u.Localidad;
                    txtTelefono.Text = u.Telefono;
                    txtCelular.Text = u.Celular;
                    txtContacto.Text = u.Contacto;
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
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "Fecha";
            dataGridView1.Columns[1].Name = "Concepto";
            dataGridView1.Columns[2].Name = "Descripcion";
            dataGridView1.Columns[3].Name = "Referencia";
            dataGridView1.Columns[4].Name = "Debe";
            dataGridView1.Columns[5].Name = "Haber";
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
    }
}
