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
    public partial class frmConceptosCaja : Form
    {
        Acceso_BD oa = new Acceso_BD();
        ConceptosCaja c = null;
        public frmConceptosCaja()
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
                    oa.ActualizarBD("delete from conceptoscaja where idconceptoscaja = '" + idnov + "'");
                    MessageBox.Show("Concepto Eliminado Correctamente");
                    frmConceptosCaja_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmConceptosCaja_Load(object sender, EventArgs e)
        {
            conceptosCajaBindingSource.DataSource = oa.leerDatos("select * from conceptoscaja");
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
                    if (txtDescripcion.Text != "" && txtCodigo.Text != "" && cmbTipo.Text != "")
                    {
                        oa.ActualizarBD("insert into conceptoscaja (idconceptoscaja, descripcion, doc) values('" + txtCodigo.Text + "','" + txtDescripcion.Text + "','" + cmbTipo.Text + "')");
                        MessageBox.Show("Concepto creado correctamente");
                        txtDescripcion.Enabled = false;
                        txtDescripcion.Text = "";
                        txtCodigo.Enabled = false;
                        txtCodigo.Text = "";
                        c = null;
                        frmConceptosCaja_Load(sender, e);
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
                        oa.ActualizarBD("update conceptoscaja set idconceptoscaja = '" + txtCodigo.Text + "', descripcion = '" + txtDescripcion.Text + "', doc = '" + cmbTipo.Text + "' where idconceptoscaja = '" + c.Idconceptoscaja + "'");
                        MessageBox.Show("Concepto actualizado correctamente");
                        txtDescripcion.Enabled = false;
                        txtDescripcion.Text = "";
                        txtCodigo.Enabled = false;
                        txtCodigo.Text = "";
                        c = null;
                        frmConceptosCaja_Load(sender, e);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int filaseleccionada = Convert.ToInt32(this.dataGridView1.CurrentRow.Index);
            int idnov = Convert.ToInt32(dataGridView1[0, filaseleccionada].Value);
            string novedad = dataGridView1[1, filaseleccionada].Value.ToString();
            c = new ConceptosCaja(idnov, novedad, dataGridView1[2, filaseleccionada].Value.ToString());
            txtCodigo.Text = c.Idconceptoscaja.ToString();
            txtDescripcion.Text = c.Descripcion;
            cmbTipo.Text = c.Doc;
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
