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
    public partial class frmPrincipal : Form
    {
        Funciones f = new Funciones();
        int idusuario = 0;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void aBMClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (f.acceder(2, idusuario))
            {
                frmClientes frm = new frmClientes();
                frm.ShowDialog();
            }
            else
            {
                if (idusuario == 0)
                {
                    MessageBox.Show("Debe iniciar sesion para acceder");
                }
                else
                {
                    MessageBox.Show("Imposible acceder: usuario sin acceso");
                }
            }
        }

        private void aBMProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (f.acceder(4, idusuario))
            {
                frmProveedores frm = new frmProveedores();
                frm.ShowDialog();
            }
            else
            {
                if (idusuario == 0)
                {
                    MessageBox.Show("Debe iniciar sesion para acceder");
                }
                else
                {
                    MessageBox.Show("Imposible acceder: usuario sin acceso");
                }
            }
        }

        private void aBMEmpresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (f.acceder(3, idusuario))
            {
                frmEmpresas frm = new frmEmpresas();
                frm.ShowDialog();
            }
            else
            {
                if (idusuario == 0)
                {
                    MessageBox.Show("Debe iniciar sesion para acceder");
                }
                else
                {
                    MessageBox.Show("Imposible acceder: usuario sin acceso");
                }
            }

        }

        private void aBMFleterosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (f.acceder(1, idusuario))
            {
                frmFleteros frm = new frmFleteros();
                frm.ShowDialog();
            }
            else
            {
                if (idusuario == 0)
                {
                    MessageBox.Show("Debe iniciar sesion para acceder");
                }
                else
                {
                    MessageBox.Show("Imposible acceder: usuario sin acceso");
                }
            }
        }

        private void emitirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (f.acceder(5, idusuario))
            {
                frmEmitirOC frm = new frmEmitirOC(0);
                frm.ShowDialog();
            }
            else
            {
                if (idusuario == 0)
                {
                    MessageBox.Show("Debe iniciar sesion para acceder");
                }
                else
                {
                    MessageBox.Show("Imposible acceder: usuario sin acceso");
                }
            }
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (f.acceder(6, idusuario))
            {
                frmBuscarOrdenCarga frm = new frmBuscarOrdenCarga();
                frm.ShowDialog();
            }
            else
            {
                if (idusuario == 0)
                {
                    MessageBox.Show("Debe iniciar sesion para acceder");
                }
                else
                {
                    MessageBox.Show("Imposible acceder: usuario sin acceso");
                }
            }
        }

        private void aBMUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            
            if (f.acceder(7, idusuario))
            {
                frmUsuarios frm = new frmUsuarios();
                frm.ShowDialog();
            }
            else
            {
                if (idusuario == 0)
                {
                    MessageBox.Show("Debe iniciar sesion para acceder");
                }
                else
                {
                    MessageBox.Show("Imposible acceder: usuario sin acceso");
                }
            }
        }

        private void iniciarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIniciarSesion frm = new frmIniciarSesion();
            frm.ShowDialog();
            idusuario = frm.idusu;
            if (idusuario != 0)
            {
                toolStripStatusLabel1.Text = "USUARIO: " + frm.usuario.ToUpper();
            }
            else
            {
                toolStripStatusLabel1.Text = "USUARIO: ";
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            
        }
    }
}
