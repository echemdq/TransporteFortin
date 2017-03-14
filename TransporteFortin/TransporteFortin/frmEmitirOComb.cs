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
    public partial class frmEmitirOComb : Form
    {
        Fleteros u = null;
        Proveedores p = null;
        int ptoventa = 0; 
        public frmEmitirOComb(int talon)
        {
            ptoventa = talon;
            InitializeComponent();
        }

        private void frmEmitirOComb_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaProveedores frm = new frmBuscaProveedores();
                frm.ShowDialog();
                p = frm.u;
                if (p != null)
                {
                    lblProveedor.Text = Convert.ToString(p.Idproveedores);
                    txtProvedor.Text = p.Proveedor;
                    txtPrecioComb.Text = p.Valor.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Buscar: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaFleteros frm = new frmBuscaFleteros();
                frm.ShowDialog();
                u = frm.u;
                if (u != null)
                {
                    lblFletero.Text = Convert.ToString(u.Idfleteros);
                    txtFletero.Text = u.Fletero;
                    txtChapaCamion.Text = u.Chapacamion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message);
            }
        }

        private void txtLitros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtLitros.Text.Length; i++)
            {
                if (txtLitros.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (lblProveedor.Text != "")
            {
                double number;
                double number1;
                if (Double.TryParse(txtPrecioComb.Text, out number) && Double.TryParse(txtLitros.Text.Replace('.',','), out number1))
                {
                    txtImporteFinal.Text = Convert.ToString(number * number1);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (p != null && u != null && Convert.ToDouble(txtImporteFinal.Text) > 0)
                {
                    OrdenesCombustible oc = new OrdenesCombustible(0, "0", Convert.ToDateTime(maskedTextBox1.Text), p, u, Convert.ToDecimal(txtPrecioComb.Text), Convert.ToDecimal(txtLitros.Text.Replace('.', ',')),ptoventa);
                    ControladoraOrdenesCombustible c = new ControladoraOrdenesCombustible();
                    c.Agregar(oc);
                    MessageBox.Show("Orden de combustible generada correctamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
