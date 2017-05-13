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
    public partial class frmIngresoCheques : Form
    {
        public frmIngresoCheques()
        {
            InitializeComponent();
        }

        private void frmIngresoCheques_Load(object sender, EventArgs e)
        {
            Acceso_BD oacceso = new Acceso_BD();
            DataTable dt = oacceso.leerDatos("select * from bancos order by banco asc");
            List<Bancos> listat1 = new List<Bancos>();
            foreach (DataRow dr in dt.Rows)
            {
                Bancos c = new Bancos(Convert.ToInt32(dr["idbancos"]), Convert.ToString(dr["banco"]));
                listat1.Add(c);
            }

            cmbcuentaT.DataSource = listat1;
            cmbcuentaT.DisplayMember = "banco";
            cmbcuentaT.ValueMember = "idbancos";


        }

        private void btncf_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Esta seguro de ingresar el cheque", "Ingreso Cheque", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DateTime r;
                    if (Convert.ToDecimal(txtchequet.Text.Replace('.', ',')) > 0 && txtnrochequet.Text != "" && DateTime.TryParse(mskfechachequet.Text, out r) && txtcomchequet.Text != "")
                    {
                        Acceso_BD oa = new Acceso_BD();
                        oa.ActualizarBD("insert into formasdepago (idbancos, cheque, idcuentasbanco, fechaentrega, fechadeposito, importe, idestadoscheques, comentarios, idrecibos, idordenespago, idformaspago) values ('" + cmbcuentaT.SelectedValue + "','" + txtnrochequet.Text + "','0','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + r.ToString("yyyy-MM-dd") + "','" + txtchequet.Text + "','1', 'Ing Manual - " +txtcomchequet.Text + "','0','0','3')");
                        MessageBox.Show("Cheque ingresado correctamente");
                        txtchequet.Text = "0.00";
                        txtcomchequet.Text = "";
                        mskfechachequet.Text = "";
                        txtnrochequet.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Debe completar el nro de cheque y una fecha valida");
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
