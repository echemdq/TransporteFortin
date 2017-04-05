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
    public partial class frmOpProveedores : Form
    {
        Proveedores u = null;
        public frmOpProveedores()
        {
            InitializeComponent();
        }

        private void frmOpProveedores_Load(object sender, EventArgs e)
        {
            Acceso_BD oacceso = new Acceso_BD();
            DataTable dt = oacceso.leerDatos("select * from conceptoscc where doc = 'c' and grupo = 1 order by descripcion asc");
            List<Conceptos> listat = new List<Conceptos>();
            foreach (DataRow dr in dt.Rows)
            {
                Conceptos c = new Conceptos(Convert.ToInt32(dr["idconceptoscc"]), Convert.ToString(dr["descripcion"]), "");
                listat.Add(c);
            }
            cmbConceptos.DataSource = listat;
            cmbConceptos.DisplayMember = "descripcion";
            cmbConceptos.ValueMember = "idconceptoscc";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaProveedores frm = new frmBuscaProveedores();
                frm.ShowDialog();
                u = frm.u;
                if (u != null)
                {
                    txtCliente.Text = u.Proveedor;
                    txtEnConcepto.Text = cmbConceptos.Text;
                    Acceso_BD oa = new Acceso_BD();
                    DataTable dt = oa.leerDatos("SELECT SUM(DEBE-HABER) as saldo FROM ctacteproveedores WHERE idproveedores = '" + u.Idproveedores + "'");
                    foreach (DataRow dr in dt.Rows)
                    {
                        txtSaldo.Text = Convert.ToString(dr["saldo"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message);
            }
        }
    }
}
