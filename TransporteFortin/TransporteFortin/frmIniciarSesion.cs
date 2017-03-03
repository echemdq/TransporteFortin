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
    public partial class frmIniciarSesion : Form
    {
        List<Usuarios> listat = new List<Usuarios>();
        public int idusu = 0;
        public frmIniciarSesion()
        {
            InitializeComponent();
        }

        private void frmIniciarSesion_Load(object sender, EventArgs e)
        {
            Acceso_BD oacceso = new Acceso_BD();
            DataTable dt = oacceso.leerDatos("select * from usuarios order by usuario asc");
            
            foreach (DataRow dr in dt.Rows)
            {
                Usuarios t = new Usuarios(Convert.ToInt32(dr["idusuarios"]), Convert.ToString(dr["usuario"]), Convert.ToString(dr["contrasena"]));
                listat.Add(t);
            }
            cmbUsuarios.DataSource = listat;
            cmbUsuarios.DisplayMember = "usuario";
            cmbUsuarios.ValueMember = "idusuarios";
            cmbUsuarios.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int x = 0;
                foreach (Usuarios u in listat)
                {
                    if (u.Usuario == cmbUsuarios.Text && u.Password == txtPassword.Text)
                    {
                        x = 1;
                        idusu = u.Idusuarios;
                        break;
                    }
                }
                if (x == 0)
                {
                    MessageBox.Show("Usuario y/o contraseña incorrectos");
                }
                else
                {
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
