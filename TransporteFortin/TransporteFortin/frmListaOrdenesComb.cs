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
    public partial class frmListaOrdenesComb : Form
    {
        int idusuario = 0;
        string consulta = "";
        List<OrdenesCombustible> lista = new List<OrdenesCombustible>();
        ControladoraOrdenesCombustible controlo = new ControladoraOrdenesCombustible();
        public frmListaOrdenesComb(string where, int idusu)
        {
            idusuario = idusu;
            InitializeComponent();
            consulta = where;
        }

        private void frmListaOrdenesComb_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 9;
            dataGridView1.Columns[0].Name = "idordenescombustible";
            dataGridView1.Columns[1].Name = "Pto Venta - Nro Orden";
            dataGridView1.Columns[2].Name = "Fecha";
            dataGridView1.Columns[3].Name = "idproveedores";
            dataGridView1.Columns[4].Name = "Proveedor";
            dataGridView1.Columns[5].Name = "idfleteros";
            dataGridView1.Columns[6].Name = "Fletero";
            dataGridView1.Columns[7].Name = "Precio Combustible";
            dataGridView1.Columns[8].Name = "Litros";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            try
            {
                lista = controlo.BuscarEspecial(consulta);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            int i = 0;
            foreach (OrdenesCombustible aux in lista)
            {
                i++;
            }
            int x = 0;
            if (i > 0)
            {
                dataGridView1.Rows.Add(i);
                foreach (OrdenesCombustible aux in lista)
                {
                    dataGridView1.Rows[x].Cells[0].Value = aux.Idordenescombustible;
                    dataGridView1.Rows[x].Cells[1].Value = aux.Ptoventa + " " + aux.Nro;
                    dataGridView1.Rows[x].Cells[2].Value = aux.Fecha.ToString("dd/MM/yyyy");
                    dataGridView1.Rows[x].Cells[3].Value = aux.Proveedores.Idproveedores;
                    dataGridView1.Rows[x].Cells[4].Value = aux.Proveedores.Proveedor;
                    dataGridView1.Rows[x].Cells[5].Value = aux.Fleteros.Idfleteros;
                    dataGridView1.Rows[x].Cells[6].Value = aux.Fleteros.Fletero;
                    dataGridView1.Rows[x].Cells[7].Value = aux.Preciocombustible;
                    dataGridView1.Rows[x].Cells[8].Value = aux.Litros;
                    x++;
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OrdenesCombustible oc = null;
            int filaseleccionada = Convert.ToInt32(this.dataGridView1.CurrentRow.Index);
            foreach (OrdenesCombustible o in lista)
            {
                if (o.Idordenescombustible == Convert.ToInt32(dataGridView1[0, filaseleccionada].Value))
                {
                    oc = o;
                }
            }
            frmImpOComb frm = new frmImpOComb(oc);
            frm.ShowDialog();
        }
    }
}
