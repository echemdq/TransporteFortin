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
    public partial class frmMovBancos : Form
    {
        int ptoventa = 0;
        CuentasBanco u = null;
        string concepto = "";
        public frmMovBancos(string con, CuentasBanco c, int talon)
        {
            concepto = con;
            u = c;
            ptoventa = talon;
            InitializeComponent();
            txtProveedor.Text = c.Descripcion;
        }

        private void frmMovBancos_Load(object sender, EventArgs e)
        {
            Acceso_BD oacceso = new Acceso_BD();
            DataTable dt = oacceso.leerDatos("select * from conceptosbanco where tipo = '" + concepto + "' order by concepto asc");
            List<Conceptos> listat = new List<Conceptos>();
            foreach (DataRow dr in dt.Rows)
            {
                Conceptos c = new Conceptos(Convert.ToInt32(dr["idconceptosbanco"]), Convert.ToString(dr["concepto"]), "");
                listat.Add(c);
            }
            cmbConceptos.DataSource = listat;
            cmbConceptos.DisplayMember = "descripcion";
            cmbConceptos.ValueMember = "codigo";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Acceso_BD oacceso = new Acceso_BD();
                oacceso.ActualizarBD("insert into movbancos (idcuentasbanco, idformasdepago, idconceptosbanco, descripcion, DoC, importe, fecha) values ('"+u.Idcuentasbanco+"', 0, '"+cmbConceptos.SelectedValue+"', '"+richTextBox1.Text+"', '"+concepto+"','"+txtValor.Text+"', now())");
                MessageBox.Show("Movimiento cargado exitosamente");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
