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
        public frmCtaCteFleteros()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaFleteros frm = new frmBuscaFleteros();
                frm.ShowDialog();
                Fleteros u = frm.u;
                if (u != null)
                {
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
                            dataGridView1.Rows[x].Cells[5].Value = aux.Haber;
                            x++;
                        }
                    }
                }
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
            dataGridView1.Columns[3].Name = "Refer.";
            dataGridView1.Columns[4].Name = "Debe";
            dataGridView1.Columns[5].Name = "Haber";
        }
    }
}
