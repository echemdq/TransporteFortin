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
    public partial class frmCuentasBanco : Form
    {
        Acceso_BD oa = new Acceso_BD();
        CuentasBanco c = null;
        public frmCuentasBanco()
        {
            InitializeComponent();
        }

        private void frmCuentasBanco_Load(object sender, EventArgs e)
        {
            DataTable dt = oa.leerDatos("select * from bancos order by banco asc");
            List<Bancos> listat = new List<Bancos>();
            foreach (DataRow dr in dt.Rows)
            {
                Bancos b = new Bancos(Convert.ToInt32(dr["idbancos"]), Convert.ToString(dr["banco"]));
                listat.Add(b);
            }
            cmbTipo.DataSource = listat;
            cmbTipo.DisplayMember = "banco";
            cmbTipo.ValueMember = "idbancos";
            cmbTipo.SelectedIndex = 0;
            cuentasBancoBindingSource.DataSource = oa.leerDatos("select c.idcuentasbanco, b.banco as bancos, c.nrocuenta, c.descripcion from cuentasbanco c inner join bancos b on c.idbancos = b.idbancos");
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
                        oa.ActualizarBD("insert into cuentasbanco (nrocuenta, descripcion, idbancos) values('" + txtCodigo.Text + "','" + txtDescripcion.Text + "','" + cmbTipo.SelectedValue + "')");
                        MessageBox.Show("Cuenta Propia creada correctamente");
                        txtDescripcion.Enabled = false;
                        txtDescripcion.Text = "";
                        txtCodigo.Enabled = false;
                        txtCodigo.Text = "";
                        c = null;
                        frmCuentasBanco_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Debe completar todos los campos para crear una nueva cuenta");
                    }
                }
                else
                {
                    if (txtDescripcion.Text != "" && txtCodigo.Text != "" && cmbTipo.Text != "")
                    {
                        oa.ActualizarBD("update cuentasbanco set nrocuenta = '" + txtCodigo.Text + "', descripcion = '" + txtDescripcion.Text + "', idbancos = '" + cmbTipo.SelectedValue + "' where idcuentasbanco = '" + c.Idcuentasbanco + "'");
                        MessageBox.Show("Cuenta propia actualizada correctamente");
                        txtDescripcion.Enabled = false;
                        txtDescripcion.Text = "";
                        txtCodigo.Enabled = false;
                        txtCodigo.Text = "";
                        c = null;
                        frmCuentasBanco_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Debe completar todos los campos para crear una nueva cuenta");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int filaseleccionada = Convert.ToInt32(this.dataGridView1.CurrentRow.Index);
            int idnov = Convert.ToInt32(dataGridView1[0, filaseleccionada].Value);
            string novedad = dataGridView1[2, filaseleccionada].Value.ToString();
            string descrip = dataGridView1[3, filaseleccionada].Value.ToString();
            c = new CuentasBanco(idnov, null, novedad, descrip);
            txtCodigo.Text = c.Nrocuenta;
            txtDescripcion.Text = c.Descripcion;
            cmbTipo.Text = dataGridView1[1, filaseleccionada].Value.ToString();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int filaseleccionada = Convert.ToInt32(this.dataGridView1.CurrentRow.Index);
                int idnov = Convert.ToInt32(dataGridView1[0, filaseleccionada].Value);
                string novedad = dataGridView1[2, filaseleccionada].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("Esta seguro de eliminar la cuenta nro: " + novedad, "Eliminar Cuenta", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    oa.ActualizarBD("delete from cuentasbanco where idcuentasbanco = '" + idnov + "'");
                    MessageBox.Show("Cuenta Eliminada Correctamente");
                    frmCuentasBanco_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
