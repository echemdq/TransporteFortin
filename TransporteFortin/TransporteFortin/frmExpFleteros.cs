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
    public partial class frmExpFleteros : Form
    {
        int idfletero = 0;
        int idempresa = 0;
        decimal importe = 0;
        string fletero = "";
        public frmExpFleteros(int idf, int ide, string imp,string flet)
        {
            fletero = flet;
            importe = Convert.ToDecimal(imp);
            idfletero = idf;
            idempresa = ide;
            InitializeComponent();
        }

        private void frmExpFleteros_Load(object sender, EventArgs e)
        {
            label2.Text = importe.ToString();
            Acceso_BD oacceso = new Acceso_BD();
            DataTable dt = oacceso.leerDatos("select * from fleteros where idempresas = '"+idempresa+"' and idfleteros <> '"+idfletero+"' order by fletero asc");
            List<Fleteros> listat1 = new List<Fleteros>();
            foreach (DataRow dr in dt.Rows)
            {
                Fleteros c = new Fleteros(Convert.ToInt32(dr["idfleteros"]), 0, Convert.ToString(dr["fletero"]), "", "", "", "", "", "", "", null, "", null, "", "", "", null, "");
                listat1.Add(c);
            }

            cmbFletero.DataSource = listat1;
            cmbFletero.DisplayMember = "fletero";
            cmbFletero.ValueMember = "idfleteros";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Esta seguro de mover saldo", "Mover Saldo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Acceso_BD oa = new Acceso_BD();
                    if (importe < 0)
                    {
                        oa.ActualizarBD("begin; insert into ctactefleteros (idfleteros, idempresas, fecha, fecactual, idconceptos, descripcion, ptoventa, idordenescarga, debe, haber, idrecibos, idordenescombustible) values ('" + idfletero + "', '" + idempresa + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "',now(), '942', 'GS - A fletero: " + cmbFletero.Text + "','0', 0, 0, '" + Math.Abs(importe).ToString().Replace(',', '.') + "',0,0); insert into ctactefleteros (idfleteros, idempresas, fecha, fecactual, idconceptos, descripcion, ptoventa, idordenescarga, debe, haber, idrecibos, idordenescombustible) values ('" + cmbFletero.SelectedValue + "', '" + idempresa + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "',now(), '943', 'GS - De fletero: " + fletero + "','0', 0, '" + Math.Abs(importe).ToString().Replace(',', '.') + "', 0,0,0); commit;");
                    }
                    else
                    {
                        oa.ActualizarBD("begin; insert into ctactefleteros (idfleteros, idempresas, fecha, fecactual, idconceptos, descripcion, ptoventa, idordenescarga, debe, haber, idrecibos, idordenescombustible) values ('" + idfletero + "', '" + idempresa + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "',now(), '943', 'GS - A fletero: " + cmbFletero.Text + "','0', 0, '" + Math.Abs(importe).ToString().Replace(',', '.') + "', 0,0,0); insert into ctactefleteros (idfleteros, idempresas, fecha, fecactual, idconceptos, descripcion, ptoventa, idordenescarga, debe, haber, idrecibos, idordenescombustible) values ('" + cmbFletero.SelectedValue + "', '" + idempresa + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "',now(), '942', 'GS - De fletero: " + fletero + "','0', 0, 0, '" + Math.Abs(importe).ToString().Replace(',', '.') + "',0,0); commit;");
                    }
                    MessageBox.Show("Saldos migrados correctamente");
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
