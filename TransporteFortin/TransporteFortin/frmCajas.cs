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
    public partial class frmCajas : Form
    {
        public frmCajas()
        {
            InitializeComponent();
        }

        private void frmCajas_Load(object sender, EventArgs e)
        {
            Acceso_BD oacceso = new Acceso_BD();
            DataTable dt = oacceso.leerDatos("select * from cajas");
            cmbcaja.DataSource = dt;
            cmbcaja.DisplayMember = "nrocaja";
            cmbcaja.ValueMember = "idcajas";
            maskedTextBox1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            maskedTextBox2.Text = DateTime.Now.ToString("dd/MM/yyyy");
            checkBox1.Checked = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Acceso_BD oa = new Acceso_BD();
                if (checkBox1.Checked)
                {
                    DateTime desde;
                    DateTime hasta;
                    if (DateTime.TryParse(maskedTextBox1.Text, out desde) && DateTime.TryParse(maskedTextBox2.Text, out hasta))
                    {
                        if (desde <= hasta)
                        {
                            DataTable dt = oa.leerDatos("select m.fecha as Fecha, m.descripcion as Descripcion, case when DoC = 'c' then m.importe else 0 end as Ingreso, case when DoC = 'd' then m.importe else 0 end as Egreso from movcajas m  where m.idcajas = '" + cmbcaja.SelectedValue + "' and m.fecha between '"+desde.ToString("yyyy-MM-dd")+"' and '"+hasta.ToString("yyyy-MM-dd")+"'");
                            dataGridView1.DataSource = dt;
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                            dt = oa.leerDatos("select sum(case when m.DoC = 'c' then m.importe else m.importe * -1 end) as Saldo from movcajas m where m.idcajas = '" + cmbcaja.SelectedValue + "' and m.fecha between '" + desde.ToString("yyyy-MM-dd") + "' and '" + hasta.ToString("yyyy-MM-dd") + "'");
                            foreach (DataRow dr in dt.Rows)
                            {
                                label1.Text = "Total: $" + Convert.ToString(dr["Saldo"]);
                            }
                            dt = oa.leerDatos("select case when fo.detalle is null and fo1.detalle is null then 'EFECTIVO' else case when fo.detalle is null then fo1.detalle else fo.detalle end end as 'Formas de Pago', ifnull(sum(case when m.doc = 'c' then case when fo.detalle is null and fo1.detalle is null then m.importe else case when fo.detalle is null then f1.importe else f.importe end end end), 0)  as Ingreso, ifnull(sum(case when m.doc = 'd' then case when fo.detalle is null and fo1.detalle is null then m.importe else case when fo.detalle is null then f1.importe else f.importe end end end), 0)  as Egreso from movcajas m left join formasdepago f on f.idrecibos = m.idrecibos left join formasdepago f1 on f1.idordenespago = m.idrecibos left join formaspago fo on f.idformaspago = fo.idformaspago left join formaspago fo1 on f1.idformaspago = fo1.idformaspago where m.idcajas = '" + cmbcaja.SelectedValue + "' and m.fecha between '" + desde.ToString("yyyy-MM-dd") + "' and '" + hasta.ToString("yyyy-MM-dd") + "' group by case when fo.detalle is null and fo1.detalle is null then 'EFECTIVO' else case when fo.detalle is null then fo1.detalle else fo.detalle end end");
                            dataGridView2.DataSource = dt;
                            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        }
                    }
                }
                else
                {
                    DataTable dt = oa.leerDatos("select m.fecha as Fecha, m.descripcion as Descripcion, case when DoC = 'c' then m.importe else 0 end as Ingreso, case when DoC = 'd' then m.importe else 0 end as Egreso from movcajas m  where m.idcajas = '" + cmbcaja.SelectedValue + "'");
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dt = oa.leerDatos("select sum(case when m.DoC = 'c' then m.importe else m.importe * -1 end) as Saldo from movcajas m where m.idcajas = '" + cmbcaja.SelectedValue + "'");
                    foreach (DataRow dr in dt.Rows)
                    {
                        label1.Text = "Total: $" + Convert.ToString(dr["Saldo"]);
                    }
                    dt = oa.leerDatos("select case when fo.detalle is null and fo1.detalle is null then 'EFECTIVO' else case when fo.detalle is null then fo1.detalle else fo.detalle end end as 'Formas de Pago', ifnull(sum(case when m.doc = 'c' then case when fo.detalle is null and fo1.detalle is null then m.importe else case when fo.detalle is null then f1.importe else f.importe end end end), 0)  as Ingreso, ifnull(sum(case when m.doc = 'd' then case when fo.detalle is null and fo1.detalle is null then m.importe else case when fo.detalle is null then f1.importe else f.importe end end end), 0)  as Egreso from movcajas m left join formasdepago f on f.idrecibos = m.idrecibos left join formasdepago f1 on f1.idordenespago = m.idrecibos left join formaspago fo on f.idformaspago = fo.idformaspago left join formaspago fo1 on f1.idformaspago = fo1.idformaspago where m.idcajas = '" + cmbcaja.SelectedValue + "' group by case when fo.detalle is null and fo1.detalle is null then 'EFECTIVO' else case when fo.detalle is null then fo1.detalle else fo.detalle end end");
                    dataGridView2.DataSource = dt;
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMovCajas frm = new frmMovCajas(0, Convert.ToInt32(cmbcaja.SelectedValue));
            frm.ShowDialog();
            button4_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMovCajas frm = new frmMovCajas(1, Convert.ToInt32(cmbcaja.SelectedValue));
            frm.ShowDialog();
            button4_Click(sender, e);
        }
    }
}
