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
    public partial class frmDescripcion : Form
    {
        string ide = "";
        string descr = "";
        int tipo = 0;
        public frmDescripcion(string id, string desc, int t)
        {
            tipo = t;
            ide = id;
            descr = desc;
            InitializeComponent();
        }

        private void frmDescripcion_Load(object sender, EventArgs e)
        {
            txtConceptoFact.Text = descr;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Acceso_BD oa = new Acceso_BD();
                if (tipo == 0)
                {
                    oa.ActualizarBD("update ctacteclientes set descripcion = '" + txtConceptoFact.Text + "' where idctacteclientes = '" + ide + "'");
                    MessageBox.Show("Descripcion actualizada correctamente");
                }
                else
                {
                    oa.ActualizarBD("update ctactefleteros set descripcion = '" + txtConceptoFact.Text + "' where idctactefleteros = '" + ide + "'");
                    MessageBox.Show("Descripcion actualizada correctamente");
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
