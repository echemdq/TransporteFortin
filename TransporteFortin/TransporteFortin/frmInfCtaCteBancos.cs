using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace TransporteFortin
{
    public partial class frmInfCtaCteBancos : Form
    {
        int idcli = 0;
        string de = "";
        string ha = "";
        int ch = 0;
        public frmInfCtaCteBancos(int idcliente, int check, string desde, string hasta)
        {
            InitializeComponent();
            idcli = idcliente;
            ch = check;
            de = desde;
            ha = hasta;
        }

        private void frmInfCtaCteBancos_Load(object sender, EventArgs e)
        {
            Acceso_BD oa = new Acceso_BD();
            if (ch == 0)
            {
                CtaCteClientesBindingSource.DataSource = oa.leerDatos("select concat(c.nrocuenta, ' ', c.descripcion) as Clientes, date_format(m.fecha,'%d/%m/%Y') as Fecha, cb.concepto as Conceptos, m.descripcion as Descripcion, case when m.DoC = 'c' then m.importe else 0 end as Debe, case when m.DoC = 'd' then m.importe else 0 end as Haber from movbancos m left join cuentasbanco c on m.idcuentasbanco = c.idcuentasbanco left join conceptosbanco cb on m.idconceptosbanco = cb.idconceptosbanco left join formasdepago f on m.idformasdepago = f.idformasdepago left join recibos r on f.idrecibos = r.idrecibos left join recibos r1 on  f.idordenespago = r1.idrecibos where m.idcuentasbanco = '"+idcli+"' order by m.fecha asc");
                DataTable dt = oa.leerDatos("select sum(case when m.DoC = 'c' then m.importe else m.importe*(-1) end) as saldo from movbancos m where m.idcuentasbanco = '" + idcli + "'");
                string saldo = "";
                foreach (DataRow dr in dt.Rows)
                {
                    saldo = Convert.ToString(dr["saldo"]);
                }
                ReportParameter p1 = new ReportParameter("Saldo", saldo);
                ReportParameter p2 = new ReportParameter("Desde", "");
                ReportParameter p3 = new ReportParameter("Hasta", "");
                ReportParameter p4 = new ReportParameter("Fecha", DateTime.Now.Date.ToString("dd/MM/yyyy"));
                this.reportViewer1.LocalReport.SetParameters(p1);
                this.reportViewer1.LocalReport.SetParameters(p2);
                this.reportViewer1.LocalReport.SetParameters(p3);
                this.reportViewer1.LocalReport.SetParameters(p4);
                this.reportViewer1.RefreshReport();
            }
            else
            {
                DateTime desde;
                DateTime hasta;
                if (DateTime.TryParse(de, out desde) && DateTime.TryParse(ha, out hasta))
                {
                    if (desde <= hasta)
                    {

                        //CtaCteClientesBindingSource.DataSource = oa.leerDatos("select concat(c.nrocuenta, ' ', c.descripcion) as Clientes, '' as Fecha, 'SALDO ANTERIOR' as Concepto, '' as Descripcion, '' as 'OPago / Recibo', '' as Cheque, case when ((select sum(case when m.DoC = 'c' then m.importe else m.importe*(-1) end) from movbancos m where m.idcuentasbanco = '" + cmbBancos.SelectedValue + "' and m.fecha < '" + desde.ToString("yyyy-MM-dd") + "')) < 0 then 0 else (select sum(case when m.DoC = 'c' then m.importe else m.importe*(-1) end) from movbancos m where m.idcuentasbanco = '" + cmbBancos.SelectedValue + "' and m.fecha < '" + desde.ToString("yyyy-MM-dd") + "') end as Acreditado, case when ((select sum(case when m.DoC = 'd' then m.importe else m.importe*(-1) end) from movbancos m where m.idcuentasbanco = '" + cmbBancos.SelectedValue + "' and m.fecha < '" + desde.ToString("yyyy-MM-dd") + "')) < 0 then 0 else (select sum(case when m.DoC = 'd' then m.importe else m.importe*(-1) end) from movbancos m where m.idcuentasbanco = '" + cmbBancos.SelectedValue + "' and m.fecha < '" + desde.ToString("yyyy-MM-dd") + "') end as Debitado, '' as fecha1 union select m.idmovbancos as id, date_format(m.fecha,'%d/%m/%Y') as Fecha, cb.concepto as Concepto, m.descripcion as Descripcion, case when f.idrecibos <> 0 then concat(cast(r.ptoventa as char), '-', cast(r.nro as char)) else concat(cast(r1.ptoventa as char), '-', cast(r1.nro as char)) end as 'OPago / Recibo', f.cheque as Cheque, case when m.DoC = 'c' then m.importe else 0 end as Acreditado, case when m.DoC = 'd' then m.importe  else 0 end as Debitado, date_format(m.fecha,'%Y/%m/%d') as fecha1 from movbancos m left join conceptosbanco cb on m.idconceptosbanco = cb.idconceptosbanco left join formasdepago f on m.idformasdepago = f.idformasdepago left join recibos r on f.idrecibos = r.idrecibos left join recibos r1 on  f.idordenespago = r1.idrecibos where m.idcuentasbanco = '" + cmbBancos.SelectedValue + "' and m.fecha between '" + desde.ToString("yyyy-MM-dd") + "' and '" + hasta.ToString("yyyy-MM-dd") + "' order by fecha1 asc
                        CtaCteClientesBindingSource.DataSource = oa.leerDatos("select 0 as id, '' as Clientes,'' as Fecha, 'SALDO ANTERIOR' as Conceptos, '' as Descripcion, case when ((select sum(case when m.DoC = 'c' then m.importe else m.importe*(-1) end) from movbancos m where m.idcuentasbanco = '1' and m.fecha < '2017-06-28')) < 0 then 0 else (select sum(case when m.DoC = 'c' then m.importe else m.importe*(-1) end) from movbancos m where m.idcuentasbanco = '1' and m.fecha < '2017-06-28') end as Debe, case when ((select sum(case when m.DoC = 'd' then m.importe else m.importe*(-1) end) from movbancos m where m.idcuentasbanco = '1' and m.fecha < '2017-06-28')) < 0 then 0 else (select sum(case when m.DoC = 'd' then m.importe else m.importe*(-1) end) from movbancos m where m.idcuentasbanco = '1' and m.fecha < '2017-06-28') end as Haber, '' as fecha1 union select m.idmovbancos as id, concat(c.nrocuenta, ' ', c.descripcion) as Clientes,date_format(m.fecha,'%d/%m/%Y') as Fecha, cb.concepto as Conceptos, m.descripcion as Descripcion,  case when m.DoC = 'c' then m.importe else 0 end as Debe, case when m.DoC = 'd' then m.importe  else 0 end as Haber, date_format(m.fecha,'%Y/%m/%d') as fecha1 from movbancos m left join conceptosbanco cb on m.idconceptosbanco = cb.idconceptosbanco left join formasdepago f on m.idformasdepago = f.idformasdepago left join recibos r on f.idrecibos = r.idrecibos left join recibos r1 on  f.idordenespago = r1.idrecibos left join cuentasbanco c on m.idcuentasbanco = c.idcuentasbanco where m.idcuentasbanco = '"+idcli+"' and m.fecha between '"+desde.ToString("yyyy-MM-dd")+"' and '"+hasta.ToString("yyyy-MM-dd")+"' order by fecha1 asc");
                        DataTable dt = oa.leerDatos("select sum(case when m.DoC = 'c' then m.importe else m.importe*(-1) end) as saldo from movbancos m where m.idcuentasbanco = '" + idcli + "' and m.fecha <= '" + hasta.ToString("yyyy-MM-dd") + "'");
                        string saldo = "";
                        foreach (DataRow dr in dt.Rows)
                        {
                            saldo = Convert.ToString(dr["saldo"]);
                        }
                        ReportParameter p1 = new ReportParameter("Saldo", saldo);
                        ReportParameter p2 = new ReportParameter("Desde", de);
                        ReportParameter p3 = new ReportParameter("Hasta", ha);
                        ReportParameter p4 = new ReportParameter("Fecha", DateTime.Now.Date.ToString("dd/MM/yyyy"));
                        this.reportViewer1.LocalReport.SetParameters(p1);
                        this.reportViewer1.LocalReport.SetParameters(p2);
                        this.reportViewer1.LocalReport.SetParameters(p3);
                        this.reportViewer1.LocalReport.SetParameters(p4);
                        this.reportViewer1.RefreshReport();
                    }
                }
            }
        }
    }
}
