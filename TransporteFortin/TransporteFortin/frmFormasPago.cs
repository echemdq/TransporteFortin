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
    public partial class frmFormasPago : Form
    {
        public List<FormasDePago> lista = null;
        int id = 0;
        public frmFormasPago(List<FormasDePago> lista1)
        {
            lista = lista1;
            
            InitializeComponent();
        }

        private void frmFormasPago_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Importe";
            dataGridView1.Columns[1].Name = "Forma de pago";
            dataGridView1.Columns[2].Name = "Nro cheque o transf";
            dataGridView1.Columns[3].Name = "id";
            dataGridView1.Columns[3].Visible = false;
            if (lista.Count > 0)
            {
                cargalista();
            }
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
        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        public void cargalista()
        {
            int i = 0;
            foreach (FormasDePago aux in lista)
            {
                i++;
            }
            int x = 0;
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
            }
            if (i > 0)
            {
                dataGridView1.Rows.Add(i);
                foreach (FormasDePago aux in lista)
                {
                    dataGridView1.Rows[x].Cells[0].Value = aux.Importe;
                    if (aux.Idformaspago == 1)
                    {
                        dataGridView1.Rows[x].Cells[1].Value = "EFECTIVO";
                    }
                    else if (aux.Idformaspago == 2)
                    {
                        dataGridView1.Rows[x].Cells[1].Value = "CHEQUE PROPIO";
                    }
                    if (aux.Idformaspago == 3)
                    {
                        dataGridView1.Rows[x].Cells[1].Value = "CHEQUE TERCERO";
                    }
                    if (aux.Idformaspago == 4)
                    {
                        dataGridView1.Rows[x].Cells[1].Value = "TRANSFERENCIA";
                    }
                    dataGridView1.Rows[x].Cells[2].Value = aux.Nrocheque;
                    dataGridView1.Rows[x].Cells[3].Value = aux.Idformasdepago;
                    x++;
                }
            }
        }

        private void btnefect_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtEfectivo.Text.Replace('.', ',')) > 0)
                {
                    id = id + 1;
                    FormasDePago f = new FormasDePago(id, Convert.ToDecimal(txtEfectivo.Text.Replace('.', ',')), 0, 0, DateTime.Now, "", txtcomefe.Text, Convert.ToInt32(cmbFormaPago.SelectedValue), 0, 0);
                    lista.Add(f);
                    dataGridView1.DataSource = null;
                    cargalista();
                    txtEfectivo.Text = "0.00";
                    txtcomefe.Text = "";
                }
                else
                {
                    MessageBox.Show("El importe debe ser mayor a 0");
                }
            }
            catch (Exception ex)
            {
                id = id - 1;
                MessageBox.Show(ex.Message);
            }
        }



        private void btntransf_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime r;
                if (Convert.ToDecimal(txttransf.Text.Replace('.', ',')) > 0 && txtnrotransf.Text != "" && DateTime.TryParse(mskfechatra.Text, out r))
                {
                    id = id + 1;
                    FormasDePago f = new FormasDePago(id, Convert.ToDecimal(txttransf.Text.Replace('.', ',')), 0, Convert.ToInt32(cmbcuentatra.SelectedValue), Convert.ToDateTime(mskfechatra.Text), txtnrotransf.Text, txtcomtran.Text, Convert.ToInt32(cmbFormaPago.SelectedValue), 0, 0);
                    lista.Add(f);
                    dataGridView1.DataSource = null;
                    cargalista();
                    txttransf.Text = "0.00";
                    mskfechatra.Text = "";
                    txtnrotransf.Text = "";
                    txtcomtran.Text = "";
                }
                else
                {
                    MessageBox.Show("Debe completar nro de transferencia y fecha valida");
                }
            }
            catch (Exception ex)
            {
                id = id - 1;
                MessageBox.Show(ex.Message);
            }
        }

        private void btncp_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime r;
                if (Convert.ToDecimal(txtchequep.Text.Replace('.', ',')) > 0 && txtnrochequep.Text != "" && DateTime.TryParse(mskfechacheqep.Text, out r))
                {
                    id = id + 1;
                    FormasDePago f = new FormasDePago(id, Convert.ToDecimal(txtchequep.Text.Replace('.', ',')), 0, Convert.ToInt32(cmbcuentap.SelectedValue), Convert.ToDateTime(mskfechacheqep.Text), txtnrochequep.Text, txtcomcheqp.Text, Convert.ToInt32(cmbFormaPago.SelectedValue), 0, 0);
                    lista.Add(f);
                    dataGridView1.DataSource = null;
                    cargalista();
                    txtchequep.Text = "0.00";
                    txtnrochequep.Text = "";
                    mskfechacheqep.Text = "";
                    txtcomcheqp.Text = "";
                }
                else
                {
                    MessageBox.Show("Debe completar el nro de cheque y una fecha valida");
                }
            }
            catch (Exception ex)
            {
                id = id - 1;
                MessageBox.Show(ex.Message);
            }
        }

        private void btncf_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime r;
                if (Convert.ToDecimal(txtchequet.Text.Replace('.', ',')) > 0 && txtnrochequet.Text != "" && DateTime.TryParse(mskfechachequet.Text, out r))
                {
                id = id + 1;
                FormasDePago f = new FormasDePago(id, Convert.ToDecimal(txtchequet.Text.Replace('.', ',')), Convert.ToInt32(cmbcuentaT.SelectedValue), 0, Convert.ToDateTime(mskfechachequet.Text), txtnrochequet.Text, txtcomchequet.Text, Convert.ToInt32(cmbFormaPago.SelectedValue), 0, 0);
                lista.Add(f);
                dataGridView1.DataSource = null;
                cargalista();
                txtchequet.Text = "0.00";
                txtcomchequet.Text = "";
                mskfechachequet.Text = "";
                txtnrochequet.Text = "";
                }
                else
                {
                    MessageBox.Show("Debe completar el nro de cheque y una fecha valida");
                }
            }
            catch (Exception ex)
            {
                id = id - 1;
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int filaseleccionada = Convert.ToInt32(this.dataGridView1.CurrentRow.Index);
                int idnov = Convert.ToInt32(dataGridView1[3, filaseleccionada].Value);
                DialogResult dialogResult = MessageBox.Show("Esta seguro de eliminar movimiento", "Eliminar movimiento", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (FormasDePago f in lista)
                    {
                        if (f.Idformasdepago == idnov)
                        {
                            lista.Remove(f);
                            break;
                        }
                    }
                    cargalista();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtnrochequep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtnrotransf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtsucursal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsucursal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtnrochequet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
