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
        int sucursal = 0;
        int talon = 0;
        int puesto = 0;
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
                frmEmitirOC frm = new frmEmitirOC(0, idusuario, puesto, sucursal, talon);
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
            puesto = Convert.ToInt32(Environment.GetEnvironmentVariable("fvpuesto"));
            sucursal = Convert.ToInt32(Environment.GetEnvironmentVariable("fvsucursal"));
            Acceso_BD oacc = new Acceso_BD();
            DataTable dt = oacc.leerDatos("select ifnull(p.puesto, 0) as puesto, ifnull(s.sucursal,0) as sucursales, s.ptoventa as ptoventa from puestos p inner join sucursales s on p.idsucursales = s.idsucursales where idpuestos = '" + puesto + "' and p.idsucursales = '" + sucursal + "'");
            string puesto1 = "";
            string sucursal1 = "";
            string talon1 = "";
            foreach (DataRow dr in dt.Rows)
            {
                puesto1 = Convert.ToString(dr["puesto"]);
                sucursal1 = Convert.ToString(dr["sucursales"]);
                talon1 = Convert.ToString(dr["ptoventa"]);
            }
            if (puesto1 == "")
            {
                MessageBox.Show("PUESTO NO VERIFICADO, COMUNIQUESE CON EL PROGRAMADOR");
                this.Close();
            }
            else
            {
                talon = Convert.ToInt32(talon1);
                toolStripStatusLabel2.Text = "PUESTO: "+puesto1.ToUpper();
                toolStripStatusLabel3.Text = "SUCURSAL: " + sucursal1.ToUpper();
                toolStripStatusLabel4.Text = "TALON :" + talon1.ToUpper();
            }
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            
        }

        private void consultaCteCteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCtaCteFleteros frm = new frmCtaCteFleteros(talon);
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmRecibo frm = new frmRecibo();
            frm.ShowDialog();
        }

        private void emitirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEmitirOComb frm = new frmEmitirOComb(talon);
            frm.ShowDialog();
        }

        private void consultaCtaCteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCtaCteProveedores frm = new frmCtaCteProveedores(talon);
            frm.ShowDialog();
        }

        private void consultaCtaCteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCtaCteClientes frm = new frmCtaCteClientes(talon);
            frm.ShowDialog();
        }

        private void saldoEmpresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSaldoEmpresas frm = new frmSaldoEmpresas();
            frm.ShowDialog();
        }

        private void reciboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReciboCtes frm = new frmReciboCtes("c");
            frm.ShowDialog();
        }

        private void aBMConceptosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConceptos frm = new frmConceptos();
            frm.ShowDialog();
        }

        private void aBMConceptosCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConceptosCaja frm = new frmConceptosCaja();
            frm.ShowDialog();
        }

        private void aBMEstadosChequesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstadosCheques frm = new frmEstadosCheques();
            frm.ShowDialog();
        }

        private void informeGralClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInformeCtes frm = new frmInformeCtes("cliente");
            frm.ShowDialog();
        }

        private void informeGralFleterosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInformeFleteros frm = new frmInformeFleteros();
            frm.ShowDialog();
        }

        private void informeGralEmpresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInformeEmpresas frm = new frmInformeEmpresas();
            frm.ShowDialog();
        }

        private void aBMBANCOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBancos frm = new frmBancos();
            frm.ShowDialog();
        }

        private void cuentasPropiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCuentasBanco frm = new frmCuentasBanco();
            frm.ShowDialog();
        }
    }
}
