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
        public frmExpFleteros(int idf, int ide)
        {
            idfletero = idf;
            idempresa = ide;
            InitializeComponent();
        }

        private void frmExpFleteros_Load(object sender, EventArgs e)
        {
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
    }
}
