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
    public partial class frmInfCtaCteCtes : Form
    {
        int idcli = 0;
        string de = "";
        string ha = "";
        int ch = 0;
        public frmInfCtaCteCtes(int idcliente, int check, string desde, string hasta)
        {
            InitializeComponent();
            idcli = idcliente;
            ch = check;
            de = desde;
            ha = hasta;
        }

        private void frmInfCtaCteCtes_Load(object sender, EventArgs e)
        {
            Acceso_BD oa = new Acceso_BD();
            if (ch == 0)
            {
                CtaCteClientesBindingSource.DataSource = oa.leerDatos("select cli.cliente as Clientes, date_format(f.fecha,'%d/%m/%Y') as Fecha, c.descripcion as Conceptos, f.descripcion as Descripcion, f.ptoventa, debe as Debe, haber as Haber, case when o.nrocarga is not null then concat(cast(o.nrocarga as char), '- Ordenes de Carga') else concat(cast(r.nro as char), '- Recibo') end  as Clientes from ctacteclientes f inner join conceptos c on f.idconceptos = c.codigo left join ordenescarga o on f.idordenescarga = o.idordenescarga left join recibos r on r.idrecibos = f.idrecibos left join clientes cli on f.idclientes = cli.idclientes where f.idclientes = '" + idcli + "'");
                DataTable dt = oa.leerDatos("SELECT SUM(DEBE-HABER) as saldo FROM CTACTECLIENTES WHERE IDCLIENTES = '" + idcli + "'");
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
                        CtaCteClientesBindingSource.DataSource = oa.leerDatos("select cli.cliente as Clientes, date_format(f.fecha,'%d/%m/%Y') as Fecha, c.descripcion as Conceptos, f.descripcion as Descripcion, f.ptoventa, debe as Debe, haber as Haber, case when o.nrocarga is not null then concat(cast(o.nrocarga as char), '- Ordenes de Carga') else concat(cast(r.nro as char), '- Recibo') end  as Clientes from ctacteclientes f inner join conceptos c on f.idconceptos = c.codigo left join ordenescarga o on f.idordenescarga = o.idordenescarga left join recibos r on r.idrecibos = f.idrecibos left join clientes cli on f.idclientes = cli.idclientes where f.idclientes = '" + idcli + "' and date_format(f.fecha,'%d/%m/%Y') between '" + de + "' and '" + ha + "'");
                        DataTable dt = oa.leerDatos("SELECT SUM(DEBE-HABER) as saldo FROM CTACTECLIENTES WHERE IDCLIENTES = '" + idcli + "'");
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

        private void CtaCteClientesBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
