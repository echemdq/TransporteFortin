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
    public partial class frmDepositoCheque : Form
    {
        string n = "";
        int id = 0;
        string b = "";
        string i = "";
        string f = "";
        public frmDepositoCheque(int idfp, string nro, string banco, string importe, string fecha)
        {
            n = nro;
            id = idfp;
            b = banco;
            i = importe;
            f = fecha;
            InitializeComponent();
        }

        private void frmDepositoCheque_Load(object sender, EventArgs e)
        {
            Acceso_BD oacceso = new Acceso_BD();
            DataTable dt = oacceso.leerDatos("select idcuentasbanco, concat(descripcion, ' ', nrocuenta) as descripcion from cuentasbanco order by descripcion asc");
            List<CuentasBanco> listat2 = new List<CuentasBanco>();
            foreach (DataRow dr in dt.Rows)
            {
                CuentasBanco c = new CuentasBanco(Convert.ToInt32(dr["idcuentasbanco"]), null, "", Convert.ToString(dr["descripcion"]));
                listat2.Add(c);
            }

            cmbcuentap.DataSource = listat2;
            cmbcuentap.DisplayMember = "descripcion";
            cmbcuentap.ValueMember = "idcuentasbanco";

            txtBanco.Text = b;
            txtimporte.Text = i;
            txtfechadep.Text = f;
            txtnro.Text = n;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Esta seguro de depositar el cheque en la cuenta bancaria: " + cmbcuentap.Text, "Depositar Cheque", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Acceso_BD oa = new Acceso_BD();
                    oa.ActualizarBD("begin; update formasdepago set idestadoscheques = '2', idcuentasbanco = '" + cmbcuentap.SelectedValue + "' where idformasdepago = '" + id + "'; insert into movbancos (idcuentasbanco, idformasdepago, idconceptosbanco, descripcion, DoC, importe, fecha) values ('" + cmbcuentap.SelectedValue + "','" + id + "','3', 'GS - Depositado en Cuenta Propia', 'c', '" + txtimporte.Text.Replace(',', '.') + "','" + Convert.ToDateTime(txtfechadep.Text).ToString("yyyy-MM-dd") + "'); commit;");
                    MessageBox.Show("Cheque depositado satisfactoriamente");
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
