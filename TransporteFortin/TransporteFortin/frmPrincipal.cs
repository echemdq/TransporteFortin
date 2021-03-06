﻿using System;
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
            button1.BackColor = Color.White;
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
                if (f.acceder(43, idusuario))
                {
                    frmEmitirOC frm = new frmEmitirOC(0, idusuario, puesto, sucursal, talon, 1);
                    frm.ShowDialog();
                }
                else
                {
                    frmEmitirOC frm = new frmEmitirOC(0, idusuario, puesto, sucursal, talon, 0);
                    frm.ShowDialog();
                }
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
                frmBuscarOrdenCarga frm = new frmBuscarOrdenCarga(idusuario, sucursal);
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
            try
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
                    toolStripStatusLabel2.Text = "PUESTO: " + puesto1.ToUpper();
                    toolStripStatusLabel3.Text = "SUCURSAL: " + sucursal1.ToUpper();
                    toolStripStatusLabel4.Text = "TALON :" + talon1.ToUpper();
                }
                this.Location = new Point(0, 0);
                this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void consultaCteCteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f.acceder(16, idusuario))
            {
                frmCtaCteFleteros frm = new frmCtaCteFleteros(talon, idusuario);
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

        private void button1_Click(object sender, EventArgs e)
        {
            //frmRecibo frm = new frmRecibo();
            //frm.ShowDialog();           
        }

        private void emitirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (f.acceder(8, idusuario))
            {
                frmEmitirOComb frm = new frmEmitirOComb(talon);
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

        private void consultaCtaCteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f.acceder(19, idusuario))
            {

                frmCtaCteProveedores frm = new frmCtaCteProveedores(talon, Convert.ToInt32(idusuario));
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

        private void consultaCtaCteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (f.acceder(11, idusuario))
            {
                frmCtaCteClientes frm = new frmCtaCteClientes(talon,idusuario);
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

        private void saldoEmpresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f.acceder(14, idusuario))
            {
                frmSaldoEmpresas frm = new frmSaldoEmpresas();
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

        private void reciboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f.acceder(12, idusuario))
            {
                frmReciboCtes frm = new frmReciboCtes(0, idusuario, puesto, sucursal, talon);
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

        private void aBMConceptosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f.acceder(20, idusuario))
            {
                frmConceptos frm = new frmConceptos();
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

        private void aBMConceptosCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f.acceder(21, idusuario))
            {
                frmConceptosCaja frm = new frmConceptosCaja();
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

        private void aBMEstadosChequesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f.acceder(22, idusuario))
            {
                frmEstadosCheques frm = new frmEstadosCheques();
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

        private void informeGralClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f.acceder(13, idusuario))
            {
                frmInformeCtes frm = new frmInformeCtes("cliente");
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

        private void informeGralFleterosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f.acceder(18, idusuario))
            {

                frmInformeFleteros frm = new frmInformeFleteros();
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

        private void informeGralEmpresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f.acceder(15, idusuario))
            {
                frmInformeEmpresas frm = new frmInformeEmpresas();
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

        private void aBMBANCOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f.acceder(9, idusuario))
            {
                frmBancos frm = new frmBancos();
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

        private void cuentasPropiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f.acceder(10, idusuario))
            {
                frmCuentasBanco frm = new frmCuentasBanco();
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

        private void reciboToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (f.acceder(17, idusuario))
            {
                frmReciboFleteros frm = new frmReciboFleteros(0, idusuario, puesto, sucursal, talon);
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

        private void ordenDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (f.acceder(32, idusuario))
            {frmOpProveedores frm = new frmOpProveedores(0, idusuario, puesto, sucursal, talon);
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void consultaRecibosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (f.acceder(28, idusuario))
            {
                frmConsultaRecibos frm = new frmConsultaRecibos(talon, 0, 0);
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

        private void consultaRecibosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (f.acceder(29, idusuario))
            {
                frmConsultaRecibos frm = new frmConsultaRecibos(talon, 0, 1);
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

        private void ordenDePagoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            if (f.acceder(30, idusuario))
            {
                frmOpFleteros frm = new frmOpFleteros(0, idusuario, puesto, sucursal, talon);
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

        private void consultaOrdenDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (f.acceder(31, idusuario))
            {
                frmConsultaRecibos frm = new frmConsultaRecibos(talon, 1, 1);
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

        private void cuentaCorrienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (f.acceder(26, idusuario))
            {
                frmCtaCteBancos frm = new frmCtaCteBancos(talon, idusuario);
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

        private void consultaCHqueusPropiosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (f.acceder(27, idusuario))
            {
                frmCheques frm = new frmCheques(2, idusuario);
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

        private void consultaChequeTercerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f.acceder(24, idusuario))
            {
                frmCheques frm = new frmCheques(3, idusuario);
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

        private void consultaTransferenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (f.acceder(25, idusuario))
            {
                frmCheques frm = new frmCheques(4, idusuario);
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

        private void arqueoCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (f.acceder(23, idusuario))
            {
                frmCajas frm = new frmCajas(sucursal, idusuario);
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

        private void ingresoManualChequesTerceroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f.acceder(37, idusuario))
            {

                frmIngresoCheques frm = new frmIngresoCheques();
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

        private void saldoClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f.acceder(42, idusuario))
            {

                frmSaldoClientes frm = new frmSaldoClientes();
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

        private void consultaOrdenDePagoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (f.acceder(31, idusuario))
            {
                frmConsultaRecibos frm = new frmConsultaRecibos(talon, 1, 2);
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

        private void consultarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (f.acceder(6, idusuario))
            {
                frmBuscarOrdenComb frm = new frmBuscarOrdenComb(idusuario, sucursal);
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

        private void saldoFleterosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (f.acceder(45, idusuario))
            {
                frmSaldoFleteros frm = new frmSaldoFleteros();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (idusuario != 0)
            {
                Acceso_BD oacceso = new Acceso_BD();
                DataTable dt = new DataTable();
                dt = oacceso.leerDatos("select count(*) as contador from cargaspendientes c left join cargaspendientesv cv on c.idcargaspendientes = cv.idcargaspendientes and cv.idusuarios = '"+idusuario+"' where c.estado = 0 and cv.idcargaspendientesv is null");
                int x = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    x = Convert.ToInt32(dr["contador"]);
                }
                if (x > 0)
                {
                    timer2.Enabled = true;
                    button1.Text = "Cargas Pendientes (" + x + ")";
                }
                else
                {
                    timer2.Enabled = false;
                    button1.BackColor = Color.White;
                    button1.Text = "Cargas Pendientes (0)";
                }
            }
        }

        private void frmPrincipal_Activated(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.Red)
            {
                button1.BackColor = Color.White;
            }
            else
            {
                button1.BackColor = Color.Red;
            }

            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmCargasPendientes frm = new frmCargasPendientes(idusuario);
            frm.ShowDialog();
        }

        }
    }

