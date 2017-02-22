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
    public partial class frmListaOrdenesCarga : Form
    {
        string consulta = "";
        ControladoraOrdenesCarga controlo = new ControladoraOrdenesCarga();
        public frmListaOrdenesCarga(string where)
        {
            InitializeComponent();
            consulta = where;
        }

        private void frmListaOrdenesCarga_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 11;
            dataGridView1.Columns[0].Name = "idordenescarga";
            dataGridView1.Columns[1].Name = "Orden";
            dataGridView1.Columns[2].Name = "Sucursal";
            dataGridView1.Columns[3].Name = "Fecha";
            dataGridView1.Columns[4].Name = "idclientes";
            dataGridView1.Columns[5].Name = "Cliente";
            dataGridView1.Columns[6].Name = "idfleteros";
            dataGridView1.Columns[7].Name = "Fletero";
            dataGridView1.Columns[8].Name = "Viaje";
            dataGridView1.Columns[9].Name = "Comision";
            dataGridView1.Columns[10].Name = "Anulado";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[6].Visible = false;

            List<OrdenesCarga> lista = controlo.BuscarEspecial(consulta);
            int i = 0;
            foreach (OrdenesCarga aux in lista)
            {
                i++;
            }
            int x = 0;
            if (i > 0)
            {
                dataGridView1.Rows.Add(i);
                foreach (OrdenesCarga aux in lista)
                {
                    dataGridView1.Rows[x].Cells[0].Value = aux.Idordenescarga;
                    dataGridView1.Rows[x].Cells[1].Value = aux.Ptoventa + " " + aux.Nrocarga;
                    dataGridView1.Rows[x].Cells[2].Value = aux.Sucursales.Sucursal;
                    dataGridView1.Rows[x].Cells[3].Value = aux.Fecha.ToString("dd/MM/yyyy");
                    dataGridView1.Rows[x].Cells[4].Value = aux.Clientes.Idclientes;
                    dataGridView1.Rows[x].Cells[5].Value = aux.Clientes.Cliente;
                    dataGridView1.Rows[x].Cells[6].Value = aux.Fleteros.Idfleteros;
                    dataGridView1.Rows[x].Cells[7].Value = aux.Fleteros.Fletero;
                    dataGridView1.Rows[x].Cells[8].Value = aux.Totalviaje;
                    dataGridView1.Rows[x].Cells[9].Value = aux.Comision;
                    dataGridView1.Rows[x].Cells[10].Value = aux.Anulado;
                    x++;
                }
            }
        }
    }
}
