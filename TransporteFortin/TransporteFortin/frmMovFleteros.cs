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
    public partial class frmMovFleteros : Form
    {
        string concepto = "";
        int idfleteros = 0;
        int idempresas = 0;
        int ptoventa = 0;
        public frmMovFleteros(string conc, Fleteros f, Empresas e, int pto)
        {
            InitializeComponent();
            concepto = conc;
            idfleteros = f.Idfleteros;
            idempresas = e.Idempresas;
            txtCliente.Text = f.Fletero;
            txtEmpresa.Text = e.Empresa;
            ptoventa = pto;
        }

        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Acceso_BD oacceso = new Acceso_BD();
                string debe = "0";
                string haber = "0";
                if(Convert.ToDecimal(txtValor.Text) > 0)
                {
                    if(concepto == "d")
                    {
                        debe = txtValor.Text;
                    }
                    else
                    {
                        haber = txtValor.Text;
                    }
                    oacceso.ActualizarBD("insert into ctactefleteros (idfleteros, idempresas, fecha, fecactual, idconceptos, descripcion, debe, haber, ptoventa) values ('" + idfleteros + "','" + idempresas + "',now(),CURRENT_TIMESTAMP,'" + cmbConceptos.SelectedValue + "','" + richTextBox1.Text + "','" + debe + "','" + haber + "','"+ptoventa+"')");
                    MessageBox.Show("Movimiento cargado exitosamente");
                    this.Close();
                }
            }
            catch (Exception eX)
            {
                MessageBox.Show(eX.Message);
            }
        }

        private void frmMovFleteros_Load(object sender, EventArgs e)
        {
            Acceso_BD oacceso = new Acceso_BD();
            DataTable dt = oacceso.leerDatos("select * from conceptos where doc = '"+concepto+"' order by descripcion asc");
            List<Conceptos> listat = new List<Conceptos>();
            foreach (DataRow dr in dt.Rows)
            {
                Conceptos c = new Conceptos(Convert.ToInt32(dr["codigo"]), Convert.ToString(dr["descripcion"]),"");
                listat.Add(c);
            }
            cmbConceptos.DataSource = listat;
            cmbConceptos.DisplayMember = "descripcion";
            cmbConceptos.ValueMember = "codigo";
        }
    }
}
