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
    public partial class frmBuscaEmpresas : Form
    {
        public Empresas u = null;
        ControladoraEmpresas controle = new ControladoraEmpresas();
        public frmBuscaEmpresas()
        {
            InitializeComponent();
        }

        private void frmBuscaEmpresas_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 9;
            dataGridView1.Columns[0].Name = "idempresas";
            dataGridView1.Columns[1].Name = "Empresa";
            dataGridView1.Columns[2].Name = "Direccion";
            dataGridView1.Columns[3].Name = "Localidad";
            dataGridView1.Columns[4].Name = "Telefono";
            dataGridView1.Columns[5].Name = "Telefono 2";
            dataGridView1.Columns[6].Name = "Celular";
            dataGridView1.Columns[7].Name = "Mail";
            dataGridView1.Columns[8].Name = "Comentario";
            dataGridView1.Columns[0].Visible = false;
        }

        private void btnTraer_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text != "")
            {
                dataGridView1.Rows.Clear();
                string d1 = "";
                string d2 = "";
                string d3 = txtCliente.Text.Trim();
                int cant = 1;

                bool a = true;
                while (a == true)
                {
                    int f = d3.LastIndexOf(" ");
                    if (f == -1 && d3.Length != 0)
                    {
                        d1 = d3.Trim();
                        d3 = "";
                        if (cant == 1)
                        {
                            d2 += " like '%" + d1 + "%' ";
                        }
                        else
                        {
                            d2 += " and empresa like '%" + d1 + "%' ";
                        }
                        a = false;
                    }
                    else
                    {
                        int c = d3.LastIndexOf(" ");

                        if (c != -1)
                        {
                            int d = d3.LastIndexOf(" ");
                            d1 = d3.Substring(d, d3.Length - d);
                            d1 = d1.Trim();
                            d = d3.LastIndexOf(" ");
                            d3 = d3.Substring(0, d);
                            if (cant == 1)
                            {
                                d2 += " like '%" + d1 + "%' ";
                            }
                            else
                            {
                                d2 += " and empresa like '%" + d1 + "%' ";

                            }
                        }
                        else
                        {
                            a = false;
                        }
                    }
                    cant++;
                }
                List<Empresas> lista = controle.BuscarEspecial(d2);
                int i = 0;
                foreach (Empresas aux in lista)
                {
                    i++;
                }
                int x = 0;
                if (i > 0)
                {
                    dataGridView1.Rows.Add(i);
                    foreach (Empresas aux in lista)
                    {
                        dataGridView1.Rows[x].Cells[0].Value = aux.Idempresas;
                        dataGridView1.Rows[x].Cells[1].Value = aux.Empresa;
                        dataGridView1.Rows[x].Cells[2].Value = aux.Direccion;
                        dataGridView1.Rows[x].Cells[3].Value = aux.Localidad;
                        dataGridView1.Rows[x].Cells[4].Value = aux.Telefono;
                        dataGridView1.Rows[x].Cells[5].Value = aux.Telefono2;
                        dataGridView1.Rows[x].Cells[6].Value = aux.Celular;
                        dataGridView1.Rows[x].Cells[7].Value = aux.Mail;
                        dataGridView1.Rows[x].Cells[8].Value = aux.Comentario;
                        x++;
                    }
                }
            }
        }

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnTraer_Click(sender, e);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int filaseleccionada = Convert.ToInt32(this.dataGridView1.CurrentRow.Index);
            int idcliente = Convert.ToInt32(dataGridView1[0, filaseleccionada].Value);
            string empresa = dataGridView1[1, filaseleccionada].Value.ToString();
            string direccion = dataGridView1[2, filaseleccionada].Value.ToString();
            string localidad = dataGridView1[3, filaseleccionada].Value.ToString();
            string telefono = dataGridView1[4, filaseleccionada].Value.ToString();
            string telefono2 = dataGridView1[5, filaseleccionada].Value.ToString();
            string celular = dataGridView1[6, filaseleccionada].Value.ToString();
            string mail = dataGridView1[7, filaseleccionada].Value.ToString();
            string comentario = dataGridView1[8, filaseleccionada].Value.ToString();
            u = new Empresas(idcliente, empresa, direccion, localidad, telefono, telefono2, celular, mail, comentario);
            this.Close();
        }
    }
}
