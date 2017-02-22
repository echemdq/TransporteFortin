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
    public partial class frmBuscarOrdenCarga : Form
    {
        public frmBuscarOrdenCarga()
        {
            InitializeComponent();
        }

        private void frmBuscarOrdenCarga_Load(object sender, EventArgs e)
        {
            mskHasta.Text = DateTime.Today.ToString("dd/MM/yyyy");
            Acceso_BD oacceso = new Acceso_BD();
            DataTable dt = oacceso.leerDatos("select * from sucursales order by sucursal asc");
            List<Sucursales> listat = new List<Sucursales>();
            foreach (DataRow dr in dt.Rows)
            {
                Sucursales t = new Sucursales(Convert.ToInt32(dr["idsucursales"]), Convert.ToString(dr["sucursal"]));
                listat.Add(t);
            }
            cmbSucursal.DataSource = listat;
            cmbSucursal.DisplayMember = "sucursal";
            cmbSucursal.ValueMember = "idsucursales";
            cmbSucursal.SelectedIndex = -1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaClientes frm = new frmBuscaClientes();
                frm.ShowDialog();
                Clientes u = frm.u;
                if (u != null)
                {
                    lblCliente.Text = Convert.ToString(u.Idclientes);
                    txtCliente.Text = u.Cliente;
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            } 
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rbValTodas.Checked = true;
            rbEsNoAnu.Checked = true;
            textBox1.Text = "";
            textBox2.Text = "";
            cmbSucursal.SelectedIndex = -1;
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
                    where = where + " ptoventa = '"+textBox1.Text+"'";
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
                    where = where + " nrocarga = '" + textBox2.Text + "'";
                }

                if (lblCliente.Text != "")
                {
                    if (where != "")
                    {
                        where = where + " and";
                    }
                    where = where + " idclientes = '" + lblCliente.Text + "'";
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
                    where = where + " idfleteros = '" + lblFletero.Text + "'";
                }

                if (cmbSucursal.SelectedIndex != -1)
                {
                    if (where != "")
                    {
                        where = where + " and";
                    }
                    else
                    {
                        where = "where ";
                    }
                    where = where + " idsucursales = '" + Convert.ToInt32(cmbSucursal.SelectedValue) + "'";
                }

                if (rbValVal.Checked)
                {
                    if (where != "")
                    {
                        where = where + " and";
                    }
                    else
                    {
                        where = "where ";
                    }
                    where = where + " valorizado = '1'";
                }
                else if (rbValNo.Checked)
                {
                    if (where != "")
                    {
                        where = where + " and";
                    }
                    else
                    {
                        where = "where ";
                    }
                    where = where + " valorizado = '0'";
                }                

                if (rbEsAnu.Checked)
                {
                    if (where != "")
                    {
                        where = where + " and";
                    }
                    else
                    {
                        where = "where ";
                    }
                    where = where + " anulado = '1'";
                }
                else if (rbEsNoAnu.Checked)
                {
                    if (where != "")
                    {
                        where = where + " and";
                    }
                    else
                    {
                        where = "where ";
                    }
                    where = where + " anulado = '0'";
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
                frmListaOrdenesCarga frm = new frmListaOrdenesCarga(where);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
