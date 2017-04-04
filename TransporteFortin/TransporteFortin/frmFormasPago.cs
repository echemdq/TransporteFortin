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
    public partial class frmFormasPago : Form
    {
        List<FormasDePago> lista = new List<FormasDePago>();
        public frmFormasPago()
        {
            InitializeComponent();
        }

        private void frmFormasPago_Load(object sender, EventArgs e)
        {
            Acceso_BD oacceso = new Acceso_BD();
            DataTable dt = oacceso.leerDatos("select * from formaspago order by idformaspago asc");
            List<FormasPago> listat = new List<FormasPago>();
            foreach (DataRow dr in dt.Rows)
            {
                FormasPago c = new FormasPago(Convert.ToInt32(dr["idformaspago"]), Convert.ToString(dr["detalle"]));
                listat.Add(c);
            }
            cmbFormaPago.DataSource = listat;
            cmbFormaPago.DisplayMember = "detalle";
            cmbFormaPago.ValueMember = "idformaspago";

            dt = oacceso.leerDatos("select * from bancos order by banco asc");
            List<Bancos> listat1 = new List<Bancos>();
            foreach (DataRow dr in dt.Rows)
            {
                Bancos c = new Bancos(Convert.ToInt32(dr["idbancos"]), Convert.ToString(dr["banco"]));
                listat1.Add(c);
            }
            
            cmbcuentaT.DataSource = listat1;
            cmbcuentaT.DisplayMember = "banco";
            cmbcuentaT.ValueMember = "idbancos";

            dt = oacceso.leerDatos("select idcuentasbanco, concat(descripcion, ' ', nrocuenta) as descripcion from cuentasbanco order by descripcion asc");
            List<CuentasBanco> listat2 = new List<CuentasBanco>();
            foreach (DataRow dr in dt.Rows)
            {
                CuentasBanco c = new CuentasBanco(Convert.ToInt32(dr["idcuentasbanco"]), null, "", Convert.ToString(dr["descripcion"]));
                listat2.Add(c);
            }
            
            cmbcuentap.DataSource = listat2;
            cmbcuentap.DisplayMember = "descripcion";
            cmbcuentap.ValueMember = "idcuentasbanco";
            
            cmbcuentatra.DataSource = listat2;
            cmbcuentatra.DisplayMember = "descripcion";
            cmbcuentatra.ValueMember = "idcuentasbanco";

            gbcheqt.Visible = false;
            gbchequep.Visible = false;
            gbefectivo.Visible = true;
            gbtransferencia.Visible = false;
            
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
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

            for (int i = 0; i < txtEfectivo.Text.Length; i++)
            {
                if (txtEfectivo.Text[i] == '.')
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

        private void txttransf_KeyPress(object sender, KeyPressEventArgs e)
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

            for (int i = 0; i < txttransf.Text.Length; i++)
            {
                if (txttransf.Text[i] == '.')
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

            for (int i = 0; i < txtchequet.Text.Length; i++)
            {
                if (txtchequet.Text[i] == '.')
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

        private void cmbFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFormaPago.SelectedValue.ToString() == "1")
            {
                gbcheqt.Visible = false;
                gbchequep.Visible = false;
                gbefectivo.Location = new Point(12, 39);
                gbefectivo.Visible = true;
                gbtransferencia.Visible = false;
            }
            else if (cmbFormaPago.SelectedValue.ToString() == "2") 
            {
                gbcheqt.Visible = false;
                gbchequep.Location = new Point(12, 39);
                gbchequep.Visible = true;
                gbefectivo.Visible = false;
                gbtransferencia.Visible = false;
            }
            else if (cmbFormaPago.SelectedValue.ToString() == "3")
            {
                gbcheqt.Location = new Point(12, 39);
                gbcheqt.Visible = true;
                gbchequep.Visible = false;
                gbefectivo.Visible = false;
                gbtransferencia.Visible = false;
            }
            else if (cmbFormaPago.SelectedValue.ToString() == "4")
            {
                gbcheqt.Visible = false;
                gbchequep.Visible = false;
                gbefectivo.Visible = false;
                gbtransferencia.Location = new Point(12, 39);
                gbtransferencia.Visible = true;
            }
        }

        private void btnefect_Click(object sender, EventArgs e)
        {
            FormasDePago f = new FormasDePago(0, Convert.ToDecimal(txtEfectivo.Text),0, 0, DateTime.Now, "", txtcomefe.Text, Convert.ToInt32(cmbFormaPago.SelectedValue), 0, 0);
            lista.Add(f);
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
        
        }

        private void btntransf_Click(object sender, EventArgs e)
        {
            FormasDePago f = new FormasDePago(0, Convert.ToDecimal(txttransf.Text), 0, Convert.ToInt32(cmbcuentatra.SelectedValue), Convert.ToDateTime(mskfechatra.Text), txtnrotransf.Text, txtcomtran.Text, Convert.ToInt32(cmbFormaPago.SelectedValue), 0, 0);
            lista.Add(f);
        }

        private void btncp_Click(object sender, EventArgs e)
        {
            FormasDePago f = new FormasDePago(0, Convert.ToDecimal(txtchequep.Text), 0, Convert.ToInt32(cmbcuentap.SelectedValue), Convert.ToDateTime(mskfechacheqep.Text), txtnrochequep.Text, txtcomcheqp.Text, Convert.ToInt32(cmbFormaPago.SelectedValue), 0, 0);
            lista.Add(f);
        }

        private void btncf_Click(object sender, EventArgs e)
        {
            FormasDePago f = new FormasDePago(0, Convert.ToDecimal(txtchequet.Text), Convert.ToInt32(cmbcuentaT.SelectedValue), 0, Convert.ToDateTime(mskfechachequet.Text), txtnrochequet.Text, txtcomchequet.Text, Convert.ToInt32(cmbFormaPago.SelectedValue), 0, 0);
            lista.Add(f);
        }
    }
}
