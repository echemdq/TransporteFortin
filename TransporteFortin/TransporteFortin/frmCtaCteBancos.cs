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
    public partial class frmCtaCteBancos : Form
    {
        int ptoventa = 0;
        int idusuario = 0;
        public frmCtaCteBancos(int talon, int idusu)
        {
            idusuario = idusu;
            ptoventa = talon;
            InitializeComponent();
        }

        private void frmCtaCteBancos_Load(object sender, EventArgs e)
        {
            Acceso_BD oacceso = new Acceso_BD();
            DataTable dt = oacceso.leerDatos("select * from cuentasbanco order by descripcion asc");
            List<CuentasBanco> listat = new List<CuentasBanco>();
            foreach (DataRow dr in dt.Rows)
            {
                CuentasBanco t = new CuentasBanco(Convert.ToInt32(dr["idcuentasbanco"]), null, "", Convert.ToString(dr["nrocuenta"]) + " " + Convert.ToString(dr["descripcion"]));
                listat.Add(t);
            }
            cmbBancos.DataSource = listat;
            cmbBancos.DisplayMember = "descripcion";
            cmbBancos.ValueMember = "idcuentasbanco";

            maskedTextBox1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            maskedTextBox2.Text = DateTime.Now.AddDays(30).ToString("dd/MM/yyyy");
            checkBox1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Acceso_BD oa = new Acceso_BD();
                dataGridView1.DataSource = oa.leerDatos("select m.idmovbancos as id, date_format(m.fecha,'%d/%m/%Y') as Fecha, cb.concepto as Concepto, m.descripcion as Descripcion, case when f.idrecibos <> 0 then concat(cast(r.ptoventa as char), '-', cast(r.nro as char)) else concat(cast(r1.ptoventa as char), '-', cast(r1.nro as char)) end as 'OPago / Recibo', case when m.DoC = 'c' then m.importe else 0 end as Acreditado, case when m.DoC = 'd' then m.importe  else 0 end as Debitado from movbancos m left join conceptosbanco cb on m.idconceptosbanco = cb.idconceptosbanco left join formasdepago f on m.idformasdepago = f.idformasdepago left join recibos r on f.idrecibos = r.idrecibos left join recibos r1 on  f.idordenespago = r1.idrecibos where m.idcuentasbanco = '" + cmbBancos.SelectedValue + "' order by m.fecha asc");
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.Columns[0].Visible = false;
                DataTable dt = oa.leerDatos("select sum(case when m.DoC = 'c' then m.importe else m.importe*(-1) end) as Acreditado from movbancos m where m.idcuentasbanco = '" + cmbBancos.SelectedValue + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    label1.Text = "Saldo: $" + Convert.ToString(dr["Acreditado"]);
                }
            }
            else
            {
                DateTime desde;
                DateTime hasta;
                if (DateTime.TryParse(maskedTextBox1.Text, out desde) && DateTime.TryParse(maskedTextBox2.Text, out hasta))
                {
                    if (desde <= hasta)
                    {
                        Acceso_BD oa = new Acceso_BD();
                        dataGridView1.DataSource = oa.leerDatos("select 0 as id, '' as Fecha, 'SALDO ANTERIOR' as Concepto, '' as Descripcion, '' as 'OPago / Recibo', case when ((select sum(case when m.DoC = 'c' then m.importe else m.importe*(-1) end) from movbancos m where m.idcuentasbanco = '"+cmbBancos.SelectedValue+"' and m.fecha < '" + desde.ToString("yyyy-MM-dd") + "')) < 0 then 0 else (select sum(case when m.DoC = 'c' then m.importe else m.importe*(-1) end) from movbancos m where m.idcuentasbanco = '" + cmbBancos.SelectedValue + "' and m.fecha < '" + desde.ToString("yyyy-MM-dd") + "') end as Acreditado, case when ((select sum(case when m.DoC = 'd' then m.importe else m.importe*(-1) end) from movbancos m where m.idcuentasbanco = '" + cmbBancos.SelectedValue + "' and m.fecha < '" + desde.ToString("yyyy-MM-dd") + "')) < 0 then 0 else (select sum(case when m.DoC = 'd' then m.importe else m.importe*(-1) end) from movbancos m where m.idcuentasbanco = '" + cmbBancos.SelectedValue + "' and m.fecha < '" + desde.ToString("yyyy-MM-dd") + "') end as Debitado union select m.idmovbancos as id, date_format(m.fecha,'%d/%m/%Y') as Fecha, cb.concepto as Concepto, m.descripcion as Descripcion, case when f.idrecibos <> 0 then concat(cast(r.ptoventa as char), '-', cast(r.nro as char)) else concat(cast(r1.ptoventa as char), '-', cast(r1.nro as char)) end as 'OPago / Recibo', case when m.DoC = 'c' then m.importe else 0 end as Acreditado, case when m.DoC = 'd' then m.importe  else 0 end as Debitado from movbancos m left join conceptosbanco cb on m.idconceptosbanco = cb.idconceptosbanco left join formasdepago f on m.idformasdepago = f.idformasdepago left join recibos r on f.idrecibos = r.idrecibos left join recibos r1 on  f.idordenespago = r1.idrecibos where m.idcuentasbanco = '" + cmbBancos.SelectedValue + "' and m.fecha between '" + desde.ToString("yyyy-MM-dd") + "' and '" + hasta.ToString("yyyy-MM-dd") + "' order by fecha asc");
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        dataGridView1.Columns[0].Visible = false;
                        DataTable dt = oa.leerDatos("select sum(case when m.DoC = 'c' then m.importe else m.importe*(-1) end) as Acreditado from movbancos m where m.idcuentasbanco = '" + cmbBancos.SelectedValue + "' and m.fecha <= '" + hasta.ToString("yyyy-MM-dd") + "' ");
                        foreach (DataRow dr in dt.Rows)
                        {
                            label1.Text = "Saldo: $"+Convert.ToString(dr["Acreditado"]);
                        }
                    }
                    else
                    {
                        dataGridView1.DataSource = null;
                        label1.Text = "Saldo: $0.00";
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                CuentasBanco t = new CuentasBanco(Convert.ToInt32(cmbBancos.SelectedValue), null, null, cmbBancos.Text);
                frmMovBancos frm = new frmMovBancos("d", t, ptoventa);
                frm.ShowDialog();
                button1_Click(sender, e);
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                CuentasBanco t = new CuentasBanco(Convert.ToInt32(cmbBancos.SelectedValue), null, null, cmbBancos.Text);
                frmMovBancos frm = new frmMovBancos("c", t, ptoventa);
                frm.ShowDialog();
                button1_Click(sender, e);
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Funciones f = new Funciones();
                if (f.acceder(33, idusuario))
                {
                    int filaseleccionada = Convert.ToInt32(this.dataGridView1.CurrentRow.Index);
                    string la = Convert.ToString(dataGridView1[4, filaseleccionada].Value);
                    if (Convert.ToString(dataGridView1[4, filaseleccionada].Value).Length == 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("Esta seguro de eliminar movimiento", "Eliminar movimiento", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Acceso_BD oa = new Acceso_BD();
                            oa.ActualizarBD("delete from movbancos where idmovbancos = '" + Convert.ToString(dataGridView1[0, filaseleccionada].Value) + "'");
                            MessageBox.Show("Movimiento eliminado correctamente");
                            button1_Click(sender, e);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Imposible eliminar movimiento no manual");
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                CuentasBanco t = new CuentasBanco(Convert.ToInt32(cmbBancos.SelectedValue), null, null, cmbBancos.Text);
                int chk = 0;
                if (checkBox1.Checked)
                {
                    chk = 1;
                }
                frmInfCtaCteBancos frm = new frmInfCtaCteBancos(t.Idcuentasbanco, chk, maskedTextBox1.Text, maskedTextBox2.Text);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
