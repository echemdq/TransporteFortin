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
    public partial class frmEstadosCheques : Form
    {
        Acceso_BD oa = new Acceso_BD();
        EstadosCheques c = null;
        public frmEstadosCheques()
        {
            InitializeComponent();
        }

        private void frmEstadosCheques_Load(object sender, EventArgs e)
        {
            DataTable dt = oa.leerDatos("select * from estadoscheques");
            dataGridView1.DataSource = dt;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCodigo.Enabled = true;
            txtDescripcion.Enabled = true;
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            c = null;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (c == null)
                {
                    if (txtDescripcion.Text != "" && txtCodigo.Text != "")
                    {
                        oa.ActualizarBD("insert into estadoscheques (idestadoscheques, estado) values('" + txtCodigo.Text + "','" + txtDescripcion.Text + "')");
                        MessageBox.Show("Estado creado correctamente");
                        txtDescripcion.Enabled = false;
                        txtDescripcion.Text = "";
                        txtCodigo.Enabled = false;
                        txtCodigo.Text = "";
                        c = null;
                        frmEstadosCheques_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Debe completar todos los campos para crear un nuevo estado");
                    }
                }
                else
                {
                    if (txtDescripcion.Text != "" && txtCodigo.Text != "")
                    {
                        oa.ActualizarBD("update estadoscheques set idestadoscheques = '" + txtCodigo.Text + "', estado = '" + txtDescripcion.Text + "' where idestadoscheques = '" + c.Idestadoscheques + "'");
                        MessageBox.Show("Estado actualizado correctamente");
                        txtDescripcion.Enabled = false;
                        txtDescripcion.Text = "";
                        txtCodigo.Enabled = false;
                        txtCodigo.Text = "";
                        c = null;
                        frmEstadosCheques_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Debe completar todos los campos para crear un nuevo estado");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (c != null)
            {
                txtCodigo.Enabled = true;
                txtDescripcion.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            c = null;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int filaseleccionada = Convert.ToInt32(this.dataGridView1.CurrentRow.Index);
            int idnov = Convert.ToInt32(dataGridView1[0, filaseleccionada].Value);
            string novedad = dataGridView1[1, filaseleccionada].Value.ToString();
            c = new EstadosCheques(idnov, novedad);
            txtCodigo.Text = c.Idestadoscheques.ToString();
            txtDescripcion.Text = c.Estado;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int filaseleccionada = Convert.ToInt32(this.dataGridView1.CurrentRow.Index);
                int idnov = Convert.ToInt32(dataGridView1[0, filaseleccionada].Value);
                string novedad = dataGridView1[1, filaseleccionada].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("Esta seguro de eliminar el estado: " + novedad, "Eliminar estado", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //oa.ActualizarBD("delete from estadoscheques where idestadoscheques = '" + idnov + "'");
                    //MessageBox.Show("Estado Eliminado Correctamente");
                    //frmEstadosCheques_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void estadosChequesBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
