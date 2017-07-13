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
    public partial class frmBuscaFleteros : Form
    {
        public Fleteros u = null;
        ControladoraFleteros controlf = new ControladoraFleteros();
        public frmBuscaFleteros()
        {
            InitializeComponent();
        }

        private void btnTraer_Click(object sender, EventArgs e)
        {
            //if (txtCliente.Text != "")
            //{
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
                            d2 += " and c.localidad like '%" + d1 + "%' ";
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
                                d2 += " and c.localidad like '%" + d1 + "%' ";

                            }
                        }
                        else
                        {
                            a = false;
                        }
                    }
                    cant++;
                }
                int j = 0;
                if (checkBox1.Checked)
                {
                    j = Convert.ToInt32(cmbTipoCamion.SelectedValue);
                }
                List<Fleteros> lista = controlf.BuscarEspecial(d2, j);
                int i = 0;
                foreach (Fleteros aux in lista)
                {
                    i++;
                }
                int x = 0;
                if (i > 0)
                {
                    dataGridView1.Rows.Add(i);
                    foreach (Fleteros aux in lista)
                    {
                        dataGridView1.Rows[x].Cells[0].Value = aux.Idfleteros;
                        dataGridView1.Rows[x].Cells[1].Value = aux.Fletero;
                        dataGridView1.Rows[x].Cells[2].Value = aux.Direccion;
                        dataGridView1.Rows[x].Cells[3].Value = aux.Localidad;
                        dataGridView1.Rows[x].Cells[4].Value = aux.Cp;
                        dataGridView1.Rows[x].Cells[5].Value = aux.Telefono;
                        dataGridView1.Rows[x].Cells[6].Value = aux.Celular;
                        dataGridView1.Rows[x].Cells[7].Value = aux.Fax;
                        dataGridView1.Rows[x].Cells[8].Value = aux.Mail;
                        dataGridView1.Rows[x].Cells[9].Value = aux.Documento;
                        dataGridView1.Rows[x].Cells[10].Value = aux.Empresas.Idempresas;
                        dataGridView1.Rows[x].Cells[11].Value = aux.Camion;
                        dataGridView1.Rows[x].Cells[12].Value = aux.Tiposcamion.Idtiposcamion;
                        dataGridView1.Rows[x].Cells[13].Value = aux.Chapacamion;
                        dataGridView1.Rows[x].Cells[14].Value = aux.Chapaacoplado;
                        dataGridView1.Rows[x].Cells[15].Value = aux.Empresas.Empresa;
                        dataGridView1.Rows[x].Cells[16].Value = aux.Cuit;
                        dataGridView1.Rows[x].Cells[17].Value = aux.TiposIVA.IdTiposIVA;
                        dataGridView1.Rows[x].Cells[18].Value = aux.Comentario;
                        x++;
                    }
                    
                }
                
            //}




                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void frmBuscaFleteros_Load(object sender, EventArgs e)
        {
            Acceso_BD oacceso = new Acceso_BD();
            DataTable dt = oacceso.leerDatos("select * from tiposcamion order by detalle asc");
            List<TiposCamion> listat = new List<TiposCamion>();
            foreach (DataRow dr in dt.Rows)
            {
                TiposCamion t = new TiposCamion(Convert.ToInt32(dr["idtiposcamion"]), Convert.ToString(dr["detalle"]));
                listat.Add(t);
            }
            cmbTipoCamion.DataSource = listat;
            cmbTipoCamion.DisplayMember = "detalle";
            cmbTipoCamion.ValueMember = "idtiposcamion";
            cmbTipoCamion.SelectedIndex = 0;
            dataGridView1.ColumnCount = 19;
            dataGridView1.Columns[0].Name = "idfleteros";
            dataGridView1.Columns[1].Name = "Fletero";
            dataGridView1.Columns[2].Name = "Direccion";
            dataGridView1.Columns[3].Name = "Localidad";
            dataGridView1.Columns[4].Name = "Cod Postal";
            dataGridView1.Columns[5].Name = "Telefono";
            dataGridView1.Columns[6].Name = "Celular";
            dataGridView1.Columns[7].Name = "Fax";
            dataGridView1.Columns[8].Name = "Mail";
            dataGridView1.Columns[9].Name = "Documento";
            dataGridView1.Columns[10].Name = "idempresas";
            dataGridView1.Columns[11].Name = "Camion";
            dataGridView1.Columns[12].Name = "idtiposcamion";
            dataGridView1.Columns[13].Name = "Chapa Camion";
            dataGridView1.Columns[14].Name = "Chapa Acoplado";
            dataGridView1.Columns[15].Name = "Empresa";
            dataGridView1.Columns[16].Name = "Cuit";
            dataGridView1.Columns[17].Name = "TipoIva";
            dataGridView1.Columns[18].Name = "Comentario";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[17].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[18].Visible = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int filaseleccionada = Convert.ToInt32(this.dataGridView1.CurrentRow.Index);
            int idfletero = Convert.ToInt32(dataGridView1[0, filaseleccionada].Value);
            string fletero = dataGridView1[1, filaseleccionada].Value.ToString();
            int idtipocamion = Convert.ToInt32(dataGridView1[12, filaseleccionada].Value);
            int idtipoiva = Convert.ToInt32(dataGridView1[17, filaseleccionada].Value);
            TiposIVA ti = new TiposIVA(idtipoiva, "", "");
            string direccion = dataGridView1[2, filaseleccionada].Value.ToString();
            TiposCamion tipoiv = new TiposCamion(idtipocamion, "");
            int idempresa = Convert.ToInt32(dataGridView1[10, filaseleccionada].Value);
            Empresas emp = new Empresas(idempresa, dataGridView1[15, filaseleccionada].Value.ToString(),"","","","","","","");
            string localidad = dataGridView1[3, filaseleccionada].Value.ToString();
            string cp = Convert.ToString(dataGridView1[4, filaseleccionada].Value);
            string telefono = dataGridView1[5, filaseleccionada].Value.ToString();
            string celular = dataGridView1[6, filaseleccionada].Value.ToString();
            string fax = dataGridView1[7, filaseleccionada].Value.ToString();
            string mail = dataGridView1[8, filaseleccionada].Value.ToString();
            int documento = Convert.ToInt32(dataGridView1[9, filaseleccionada].Value);
            string camion = dataGridView1[11, filaseleccionada].Value.ToString();
            string chapacamion = dataGridView1[13, filaseleccionada].Value.ToString();
            string chapaacoplado = dataGridView1[14, filaseleccionada].Value.ToString();
            string cuit = dataGridView1[16, filaseleccionada].Value.ToString();
            string comentario = dataGridView1[18, filaseleccionada].Value.ToString();
            u = new Fleteros(idfletero, documento, fletero, direccion, localidad, cp.ToString(), telefono, celular, fax, mail, emp, camion, tipoiv, chapacamion, chapaacoplado,cuit,ti,comentario);
            this.Close();
        }

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnTraer_Click(sender, e);
            }
        }
    }
}
