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
        int filaseleccionada = 0;
        int idoc = 0;
        List<OrdenesCarga> lista = new List<OrdenesCarga>();
        public frmListaOrdenesCarga(string where)
        {
            InitializeComponent();
            consulta = where;
        }

        private void frmListaOrdenesCarga_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 12;
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
            dataGridView1.Columns[11].Name = "Valorizado";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[6].Visible = false; 
            dataGridView1.Columns[11].Visible = false;
            try
            {
                lista = controlo.BuscarEspecial(consulta);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    dataGridView1.Rows[x].Cells[11].Value = aux.Valorizado;
                    x++;
                }
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            filaseleccionada = Convert.ToInt32(this.dataGridView1.CurrentRow.Index);
            int valorizado = Convert.ToInt32(dataGridView1[11, filaseleccionada].Value);
            int anulado = Convert.ToInt32(dataGridView1[10, filaseleccionada].Value);
            idoc = Convert.ToInt32(dataGridView1[0, filaseleccionada].Value);

            if (idoc != 0)
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }

            if (valorizado == 0)
            {
                //button1.Enabled = true;
            }
            else
            {
                button1.Enabled = true;
            }

            if (anulado == 0)
            {
                button2.Enabled = true;
                button1.Enabled = true;
            }
            else
            {
                //button1.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmEmitirOC frm = new frmEmitirOC(idoc,0,0,0,0);
            frm.ShowDialog();
            dataGridView1.Rows.Clear();
            frmListaOrdenesCarga_Load(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (idoc != 0)
                {
                    
                    DialogResult dialogResult = MessageBox.Show("Esta seguro de anular la Orden de Carga?", "Anular Orden de Carga", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Acceso_BD oacceso = new Acceso_BD();
                        oacceso.ActualizarBD("begin; update ordenescarga set anulado = '1', fecanula = now(), observaciones = concat(observaciones, ' ORDEN DE CARGA ANULADA ') where idordenescarga = '"+idoc+"'; insert into ctactefleteros (idfleteros, idempresas, fecha, fecactual, idconceptos, descripcion, ptoventa, idordenescarga, debe, haber, idrecibos) select idfleteros, idempresas, now(), now(), case when idconceptos = 999 then 947 else case when idconceptos = 17 then 15 else 997 end end, concat(descripcion, ' anulacion'), ptoventa, idordenescarga, case when debe = 0 then haber else 0 end, case when haber = 0 then debe else 0 end, idrecibos from ctactefleteros where idordenescarga = '"+idoc+"'; insert into ctacteclientes (idclientes, idconceptos, descripcion, ptoventa, idordenescarga, debe, haber, fecha) select idclientes, case when idconceptos = 949 then 997 else case when idconceptos = 15 then 17 end end, concat(descripcion, ' anulacion'), ptoventa, idordenescarga, case when debe = 0 then haber else 0 end, case when haber = 0 then debe else 0 end, now() from ctacteclientes where idordenescarga = '"+idoc+"'; commit;");
                        MessageBox.Show("Orden de Carga anulada correctamente");
                        dataGridView1.Rows.Clear();
                        frmListaOrdenesCarga_Load(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una orden para anularla");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Eliminar: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                foreach (OrdenesCarga o in lista)
                {
                    if (o.Idordenescarga == idoc)
                    {
                        frmImpOCarga frm = new frmImpOCarga(o);
                        frm.ShowDialog();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
