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
    public partial class frmMovCajas : Form
    {
        int tipo;
        int caja;
        Acceso_BD oa = new Acceso_BD();
        public frmMovCajas(int tip, int ca)
        {
            tipo = tip;
            caja = ca;
            InitializeComponent();
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && txtValor.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void frmMovCajas_Load(object sender, EventArgs e)
        {
            if (tipo == 0)
            {
                txtProveedor.Text = "INGRESO";
                DataTable dt = oa.leerDatos("select * from conceptoscaja where doc = 'c' order by descripcion asc");
                List<Conceptos> listat = new List<Conceptos>();
                foreach (DataRow dr in dt.Rows)
                {
                    Conceptos c = new Conceptos(Convert.ToInt32(dr["idconceptoscaja"]), Convert.ToString(dr["descripcion"]), "");
                    listat.Add(c);
                }
                cmbConceptos.DataSource = listat;
                cmbConceptos.DisplayMember = "descripcion";
                cmbConceptos.ValueMember = "codigo";
            }
            else
            {
                txtProveedor.Text = "EGRESO";
                DataTable dt = oa.leerDatos("select * from conceptoscaja where doc = 'd' order by descripcion asc");
                List<Conceptos> listat = new List<Conceptos>();
                foreach (DataRow dr in dt.Rows)
                {
                    Conceptos c = new Conceptos(Convert.ToInt32(dr["idconceptoscaja"]), Convert.ToString(dr["descripcion"]), "");
                    listat.Add(c);
                }
                cmbConceptos.DataSource = listat;
                cmbConceptos.DisplayMember = "descripcion";
                cmbConceptos.ValueMember = "codigo";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tipo == 0)
                {
                    oa.ActualizarBD("insert into movcajas (idcajas, idrecibos, idconceptoscaja, descripcion, DoC, fecha, importe) values ('" + caja + "','-1','"+cmbConceptos.SelectedValue+"','"+richTextBox1.Text+ " " +cmbConceptos.Text+"','c','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + txtValor.Text + "')");
                    this.Close();
                }
                else
                {
                    oa.ActualizarBD("insert into movcajas (idcajas, idrecibos, idconceptoscaja, descripcion, DoC, fecha, importe) values ('" + caja + "','-1','" + cmbConceptos.SelectedValue + "','" + richTextBox1.Text + " " + cmbConceptos.Text + "','d','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + txtValor.Text + "')");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
