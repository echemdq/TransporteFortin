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
    public partial class frmBancos : Form
    {
        Acceso_BD oa = new Acceso_BD();
        Bancos b = null;
        public frmBancos()
        {
            InitializeComponent();
        }

        private void frmBancos_Load(object sender, EventArgs e)
        {
            bancosBindingSource.DataSource = oa.leerDatos("select * from bancos order by banco asc");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int filaseleccionada = Convert.ToInt32(this.dataGridView1.CurrentRow.Index);
            int idnov = Convert.ToInt32(dataGridView1[0, filaseleccionada].Value);
            string novedad = dataGridView1[1, filaseleccionada].Value.ToString();
            b = new Bancos(idnov, novedad);
            txtDescripcion.Text = b.Banco;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int filaseleccionada = Convert.ToInt32(this.dataGridView1.CurrentRow.Index);
                int idnov = Convert.ToInt32(dataGridView1[0, filaseleccionada].Value);
                string novedad = dataGridView1[1, filaseleccionada].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("Esta seguro de eliminar el banco: " + novedad, "Eliminar Banco", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    oa.ActualizarBD("delete from bancos where idbancos = '" + idnov + "'");
                    MessageBox.Show("Banco Eliminado Correctamente");
                    txtDescripcion.Enabled = false;
                    txtDescripcion.Text = "";
                    b = null;
                    frmBancos_Load(sender, e);                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = true;
            txtDescripcion.Text = "";
            b = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
            b = null;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (b != null)
            {
                txtDescripcion.Enabled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (b == null)
                {
                    if (txtDescripcion.Text != "")
                    {
                        oa.ActualizarBD("insert into bancos (banco) values('" + txtDescripcion.Text + "')");
                        MessageBox.Show("Banco creado correctamente");
                        txtDescripcion.Enabled = false;
                        txtDescripcion.Text = "";
                        b = null;
                        frmBancos_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Debe completar todos los campos para crear un nuevo banco");
                    }
                }
                else
                {
                    if (txtDescripcion.Text != "")
                    {
                        oa.ActualizarBD("update bancos set banco = '" + txtDescripcion.Text + "' where idbancos = '" + b.Idbancos + "'");
                        MessageBox.Show("Banco actualizado correctamente");
                        txtDescripcion.Enabled = false;
                        txtDescripcion.Text = "";
                        b = null;
                        frmBancos_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Debe completar todos los campos para crear un nuevo banco");
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
