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
    public partial class frmAgregaCargap : Form
    {
        int idusuario = 0;
        Empresas u = null;
        public frmAgregaCargap(int idusu)
        {
            InitializeComponent();
            idusuario = idusu;
        }

        private void frmAgregaCargap_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (idusuario != 0)
                {
                    Acceso_BD oacceso = new Acceso_BD();
                    oacceso.ActualizarBD("insert into cargaspendientes (origen, destino, observaciones, idempresas, creador) values ('" + txtCliente.Text + "', '" + txtDomicilio.Text + "', '" + txtcomentario.Text + "', '" + u.Idempresas + "', '" + idusuario + "')");
                    MessageBox.Show("Nueva notificacion creada");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaEmpresas frm = new frmBuscaEmpresas();
                frm.ShowDialog();
                u = frm.u;
                if (u != null)
                {
                    textBox1.Text = u.Empresa;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Buscar: " + ex.Message);
            }
        }
    }
}
