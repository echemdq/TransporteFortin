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
    public partial class frmBuscarOrdenComb : Form
    {
        int idusuario = 0;
        int idsucursales = 0;
        public frmBuscarOrdenComb(int idusu, int idsuc)
        {
            idusuario = idusu;
            idsucursales = idsuc;
            InitializeComponent();
        }

        private void frmBuscarOrdenComb_Load(object sender, EventArgs e)
        {
            mskHasta.Text = DateTime.Today.ToString("dd/MM/yyyy");            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaProveedores frm = new frmBuscaProveedores();
                frm.ShowDialog();
                Proveedores u = frm.u;
                if (u != null)
                {
                    lblCliente.Text = Convert.ToString(u.Idproveedores);
                    txtCliente.Text = u.Proveedor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaFleteros frm = new frmBuscaFleteros();
                frm.ShowDialog();
                Fleteros u = frm.u;
                if (u != null)
                {
                    lblFletero.Text = Convert.ToString(u.Idfleteros);
                    txtFletero.Text = u.Fletero;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            txtFletero.Text = "";
            lblFletero.Text = "";
            txtCliente.Text = "";
            lblCliente.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string where = "";

                if (textBox1.Text != "")
                {
                    if (where != "")
                    {
                        where = where + " and";
                    }
                    else
                    {
                        where = "where ";
                    }
                    where = where + " o.ptoventa = '" + textBox1.Text + "'";
                }

                if (textBox2.Text != "")
                {
                    if (where != "")
                    {
                        where = where + " and";
                    }
                    else
                    {
                        where = "where ";
                    }
                    where = where + " o.nro = '" + textBox2.Text + "'";
                }

                if (lblCliente.Text != "")
                {
                    if (where != "")
                    {
                        where = where + " and";
                    }
                    else
                    {
                        where = "where ";
                    }
                    where = where + " o.idproveedores = '" + lblCliente.Text + "'";
                }

                if (lblFletero.Text != "")
                {
                    if (where != "")
                    {
                        where = where + " and";
                    }
                    else
                    {
                        where = "where ";
                    }
                    where = where + " o.idfleteros = '" + lblFletero.Text + "'";
                }

                
                DateTime fecha;
                if (DateTime.TryParse(mskDesde.Text, out fecha) == true && DateTime.TryParse(mskHasta.Text, out fecha) == true)
                {
                    DateTime desde = Convert.ToDateTime(mskDesde.Text);
                    DateTime hasta = Convert.ToDateTime(mskHasta.Text);
                    if (desde < hasta)
                    {
                        if (where != "")
                        {
                            where = where + " and";
                        }
                        else
                        {
                            where = "where ";
                        }
                        where = where + " fecha between '" + desde.ToString("yyyy-MM-dd") + "' and '" + hasta.ToString("yyyy-MM-dd") + "'";
                    }
                    else
                    {
                        MessageBox.Show("La fecha desde debe ser menor a la de hasta");
                    }
                }

                frmListaOrdenesComb frm = new frmListaOrdenesComb(where, idusuario);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
