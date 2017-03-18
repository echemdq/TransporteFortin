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
    public partial class frmConceptos : Form
    {
        Conceptos c = null;
        Acceso_BD oa = new Acceso_BD();
        public frmConceptos()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int filaseleccionada = Convert.ToInt32(this.dataGridView1.CurrentRow.Index);
                int idnov = Convert.ToInt32(dataGridView1[0, filaseleccionada].Value);
                string novedad = dataGridView1[1, filaseleccionada].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("Esta seguro de eliminar el concepto: " + novedad, "Eliminar Concepto", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {                    
                    oa.ActualizarBD("delete from conceptos where codigo = '" + idnov + "'");
                    MessageBox.Show("Concepto Eliminado Correctamente");
                    frmConceptos_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmConceptos_Load(object sender, EventArgs e)
        {            
            conceptosBindingSource.DataSource = oa.leerDatos("select * from conceptos");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int filaseleccionada = Convert.ToInt32(this.dataGridView1.CurrentRow.Index);
            int idnov = Convert.ToInt32(dataGridView1[0, filaseleccionada].Value);
            string novedad = dataGridView1[1, filaseleccionada].Value.ToString();
            c = new Conceptos(idnov, novedad, dataGridView1[2, filaseleccionada].Value.ToString());
            txtCodigo.Text = c.Codigo.ToString();
            txtDescripcion.Text = c.Descripcion;
            cmbTipo.Text = c.Doc;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCodigo.Enabled = true;
            txtDescripcion.Enabled = true;
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            c = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            c = null;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (c != null)
            {
                txtCodigo.Enabled = true;
                txtDescripcion.Enabled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (c == null)
                {
                    if (txtDescripcion.Text != "" && txtCodigo.Text != "" && cmbTipo.Text != "")
                    {
                        oa.ActualizarBD("insert into conceptos (codigo, descripcion, doc) values('" + txtCodigo.Text + "','" + txtDescripcion.Text + "','" + cmbTipo.Text + "')");
                        MessageBox.Show("Concepto creado correctamente");
                        txtDescripcion.Enabled = false;
                        txtDescripcion.Text = "";
                        txtCodigo.Enabled = false;
                        txtCodigo.Text = "";
                        c = null;
                        frmConceptos_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Debe completar todos los campos para crear un nuevo concepto");
                    }
                }
                else
                {
                    if (txtDescripcion.Text != "" && txtCodigo.Text != "" && cmbTipo.Text != "")
                    {
                        oa.ActualizarBD("update conceptos set codigo = '"+txtCodigo.Text+"', descripcion = '"+txtDescripcion.Text+"', doc = '"+cmbTipo.Text+"' where codigo = '"+c.Codigo+"'");
                        MessageBox.Show("Concepto creado correctamente");
                        txtDescripcion.Enabled = false;
                        txtDescripcion.Text = "";
                        txtCodigo.Enabled = false;
                        txtCodigo.Text = "";
                        c = null;
                        frmConceptos_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Debe completar todos los campos para crear un nuevo concepto");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
