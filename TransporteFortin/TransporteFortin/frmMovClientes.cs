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
    public partial class frmMovClientes : Form
    {
        int ptoventa = 0;
        Clientes u = null;
        string concepto = "";
        public frmMovClientes(string con, Clientes c, int talon)
        {
            concepto = con;
            u = c;
            ptoventa = talon;
            InitializeComponent();
            txtProveedor.Text = c.Cliente;
        }

        private void frmMovClientes_Load(object sender, EventArgs e)
        {
            Acceso_BD oacceso = new Acceso_BD();
            DataTable dt = oacceso.leerDatos("select * from conceptos where doc = '" + concepto + "' order by descripcion asc");
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Acceso_BD oacceso = new Acceso_BD();
            string debe = "0";
            string haber = "0";
            if (Convert.ToDecimal(txtValor.Text) > 0)
            {
                if (concepto == "d")
                {
                    debe = txtValor.Text;
                }
                else
                {
                    haber = txtValor.Text;
                }
                oacceso.ActualizarBD("insert into ctacteclientes (fecha, idclientes, idconceptos, descripcion, debe, haber, ptoventa) values ('"+DateTime.Now.ToString("yyyy-MM-dd")+"', '" + u.Idclientes + "','" + cmbConceptos.SelectedValue + "','" + richTextBox1.Text + "','" + debe + "','" + haber + "','" + ptoventa + "')");
                MessageBox.Show("Movimiento cargado exitosamente");
                this.Close();
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
