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
                        CtaCteClientesBindingSource.DataSource = oa.leerDatos("select concat(c.nrocuenta, ' ', c.descripcion) as Clientes, date_format(m.fecha,'%d/%m/%Y') as Fecha, cb.concepto as Conceptos, m.descripcion as Descripcion, case when m.DoC = 'c' then m.importe else 0 end as Debe, case when m.DoC = 'd' then m.importe else 0 end as Haber from movbancos m left join cuentasbanco c on m.idcuentasbanco = c.idcuentasbanco left join conceptosbanco cb on m.idconceptosbanco = cb.idconceptosbanco left join formasdepago f on m.idformasdepago = f.idformasdepago left join recibos r on f.idrecibos = r.idrecibos left join recibos r1 on  f.idordenespago = r1.idrecibos where m.idcuentasbanco = '" + idcli + "' and m.fecha between '" + desde.ToString("yyyy-MM-dd") + "' and '" + hasta.ToString("yyyy-MM-dd") + "'");
                        DataTable dt = oa.leerDatos("select sum(case when m.DoC = 'c' then m.importe else m.importe*(-1) end) as saldo from movbancos m where m.idcuentasbanco = '" + idcli + "' and date_format(m.fecha,'%d/%m/%Y') between '" + de + "' and '" + ha + "'");
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
