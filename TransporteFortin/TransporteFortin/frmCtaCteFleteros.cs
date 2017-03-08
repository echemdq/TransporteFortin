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
        decimal debe = 0;
        decimal haber = 0;
        public frmCtaCteFleteros(int pto)
        {
            ptoventa = pto;
            InitializeComponent();
        }
        public void buscar()
        {
            if (u != null)
            {
                em = new Empresas(u.Empresas.Idempresas, u.Empresas.Empresa, "", "", "", "", "", "", "");
                txtEmpresa.Text = u.Empresas.Empresa;
                txtCliente.Text = u.Fletero;
                txtDomicilio.Text = u.Direccion;
                txtTelefono.Text = u.Telefono;
                txtDocumento.Text = u.Documento.ToString();
                ControladoraCtaCteFleteros controlc = new ControladoraCtaCteFleteros();
                List<CtaCteFleteros> lista = controlc.BuscarEspecial(u.Idfleteros.ToString());
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
                        dataGridView1.Rows[x].Cells[3].Value = aux.Ptoventa + "-" + aux.Ordenescarga.Nrocarga;
                        dataGridView1.Rows[x].Cells[4].Value = aux.Debe;
                        debe = debe + aux.Debe;
                        dataGridView1.Rows[x].Cells[5].Value = aux.Haber;
                        haber = haber + aux.Haber;
                        x++;
                    }
                }
            }
            label2.Text = Convert.ToString(debe - haber);
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaFleteros frm = new frmBuscaFleteros();
                frm.ShowDialog();
                u = frm.u;
                buscar();
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
            dataGridView1.Columns[3].Name = "Referencia (Talon - Orden Carga)";
            dataGridView1.Columns[4].Name = "Debe";
            dataGridView1.Columns[5].Name = "Haber";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frmMovFleteros frm = new frmMovFleteros("d", u, em, ptoventa);
                frm.ShowDialog();
                dataGridView1.Rows.Clear();
                debe = 0;
                haber = 0;
                buscar();                
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
                debe = 0;
                haber = 0;
                buscar();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
    }
}
