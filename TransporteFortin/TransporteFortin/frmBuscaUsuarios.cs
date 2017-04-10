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
    public partial class frmBuscaUsuarios : Form
    {
        ControladoraUsuarios controlu = new ControladoraUsuarios();
        public Usuarios u = null;
        public frmBuscaUsuarios()
        {
            InitializeComponent();
        }

        private void frmBuscaUsuarios_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "idusuarios";
            dataGridView1.Columns[1].Name = "Usuario";
            dataGridView1.Columns[2].Name = "contrasena";
            dataGridView1.Columns[2].Visible = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int filaseleccionada = Convert.ToInt32(this.dataGridView1.CurrentRow.Index);
            int idusuario = Convert.ToInt32(dataGridView1[0, filaseleccionada].Value);
            string usuario = dataGridView1[1, filaseleccionada].Value.ToString();
            string contrasena = dataGridView1[2, filaseleccionada].Value.ToString();
            u = new Usuarios(idusuario, usuario, contrasena);
            this.Close();
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
                            d2 += " and usuario like '%" + d1 + "%' ";
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
                                d2 += " and usuario like '%" + d1 + "%' ";

                            }
                        }
                        else
                        {
                            a = false;
                        }
                    }
                    cant++;
                }
                List<Usuarios> lista = controlu.BuscarEspecial(d2);
                int i = 0;
                foreach (Usuarios aux in lista)
                {
                    i++;
                }
                int x = 0;
                if (i > 0)
                {
                    dataGridView1.Rows.Add(i);
                    foreach (Usuarios aux in lista)
                    {
                        dataGridView1.Rows[x].Cells[0].Value = aux.Idusuarios;
                        dataGridView1.Rows[x].Cells[1].Value = aux.Usuario;
                        dataGridView1.Rows[x].Cells[2].Value = aux.Password;
                        x++;
                    }
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
        }
    }
}
