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
    public partial class frmBuscaClientes : Form
    {
        ControladoraClientes controlc = new ControladoraClientes();
        public Clientes u = null;
        public frmBuscaClientes()
        {
            InitializeComponent();
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
                            d2 += " and cliente like '%" + d1 + "%' ";
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
                                d2 += " and cliente like '%" + d1 + "%' ";

                            }
                        }
                        else
                        {
                            a = false;
                        }
                    }
                    cant++;
                }
                List<Clientes> lista = controlc.BuscarEspecial(d2);
                int i = 0;
                foreach (Clientes aux in lista)
                {
                    i++;
                }
                int x = 0;
                if (i > 0)
                {
                    dataGridView1.Rows.Add(i);
                    foreach (Clientes aux in lista)
                    {
                        dataGridView1.Rows[x].Cells[0].Value = aux.Idclientes;
                        dataGridView1.Rows[x].Cells[1].Value = aux.Cliente;
                        dataGridView1.Rows[x].Cells[2].Value = aux.Direccion;
                        dataGridView1.Rows[x].Cells[3].Value = aux.Localidad;
                        dataGridView1.Rows[x].Cells[4].Value = aux.Cp;
                        dataGridView1.Rows[x].Cells[5].Value = aux.Telefono;
                        dataGridView1.Rows[x].Cells[6].Value = aux.Celular;
                        dataGridView1.Rows[x].Cells[7].Value = aux.Fax;
                        dataGridView1.Rows[x].Cells[8].Value = aux.Mail;
                        dataGridView1.Rows[x].Cells[9].Value = aux.Contacto;
                        dataGridView1.Rows[x].Cells[10].Value = aux.Cuit;
                        dataGridView1.Rows[x].Cells[11].Value = aux.TiposIVA.IdTiposIVA;
                        dataGridView1.Rows[x].Cells[12].Value = aux.Comentario;
                        x++;
                    }
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
        }

        private void txtPaciente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnTraer_Click(sender, e);
            }
        }

        private void frmBuscaClientes_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 13;
            dataGridView1.Columns[0].Name = "idclientes";
            dataGridView1.Columns[1].Name = "Cliente";
            dataGridView1.Columns[2].Name = "Direccion";
            dataGridView1.Columns[3].Name = "Localidad";
            dataGridView1.Columns[4].Name = "Cod Postal";
            dataGridView1.Columns[5].Name = "Telefono";
            dataGridView1.Columns[6].Name = "Celular";
            dataGridView1.Columns[7].Name = "Fax";
            dataGridView1.Columns[8].Name = "Mail";
            dataGridView1.Columns[9].Name = "Contacto";
            dataGridView1.Columns[10].Name = "Cuit";
            dataGridView1.Columns[11].Name = "idtiposiva";
            dataGridView1.Columns[12].Name = "Comentario";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int filaseleccionada = Convert.ToInt32(this.dataGridView1.CurrentRow.Index);
            int idcliente = Convert.ToInt32(dataGridView1[0, filaseleccionada].Value);
            string cliente = dataGridView1[1, filaseleccionada].Value.ToString();
            int idtipoiva = Convert.ToInt32(dataGridView1[11, filaseleccionada].Value);
            string direccion = dataGridView1[2, filaseleccionada].Value.ToString();
            TiposIVA tipoiv = new TiposIVA(idtipoiva, "","");
            string localidad = dataGridView1[3, filaseleccionada].Value.ToString();
            string cp = Convert.ToString(dataGridView1[4, filaseleccionada].Value);
            string telefono = dataGridView1[5, filaseleccionada].Value.ToString();
            string celular = dataGridView1[6, filaseleccionada].Value.ToString();
            string fax = dataGridView1[7, filaseleccionada].Value.ToString();
            string mail = dataGridView1[8, filaseleccionada].Value.ToString();
            string contacto = dataGridView1[9, filaseleccionada].Value.ToString();
            string cuit = dataGridView1[10, filaseleccionada].Value.ToString();
            string comentario = dataGridView1[12, filaseleccionada].Value.ToString();
            u = new Clientes(idcliente, cliente, direccion, localidad, cp, telefono, celular, fax, mail, contacto, cuit, tipoiv, comentario);
            this.Close();
        }
    }
}
