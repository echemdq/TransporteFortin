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
        int ptoventa = 0;
        public frmCtaCteProveedores(int pto)
        {
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
                        dataGridView1.Rows[x].Cells[0].Value = aux.Fecha.ToString("dd/MM/yyyy");
                        dataGridView1.Rows[x].Cells[1].Value = aux.Conceptos.Descripcion;
                        dataGridView1.Rows[x].Cells[2].Value = aux.Descripcion;
                        dataGridView1.Rows[x].Cells[3].Value = aux.Ptoventa + "-" + aux.Ordenescomb.Nro;
                        dataGridView1.Rows[x].Cells[4].Value = aux.Debe;
                        dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView1.Rows[x].Cells[5].Value = aux.Haber;
                        debe = debe + Convert.ToDouble(aux.Debe);
                        haber = haber + Convert.ToDouble(aux.Haber);
                        x++;
                    }
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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
                frmMovProveedores frm = new frmMovProveedores("d", u, ptoventa);
                frm.ShowDialog();
                dataGridView1.Rows.Clear();
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
    }
}
