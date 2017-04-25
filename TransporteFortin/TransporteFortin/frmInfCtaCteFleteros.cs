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
    public partial class frmInfCtaCteFleteros : Form
    {
        int idcli = 0;
        string de = "";
        string ha = "";
        int ch = 0;
        string idempresa = "";
        public frmInfCtaCteFleteros(int idcliente, int check, string desde, string hasta, string idemp)
        {
            InitializeComponent();
            idcli = idcliente;
            ch = check;
            de = desde;
            ha = hasta;
            idempresa = idemp;
        }

        private void frmInfCtaCteFleteros_Load(object sender, EventArgs e)
        {
            Acceso_BD oa = new Acceso_BD();
            if (ch == 0)
            {
                CtaCteClientesBindingSource.DataSource = oa.leerDatos("select e.empresa as Recibos, cli.fletero as Clientes, date_format(f.fecha,'%d/%m/%Y') as Fecha, c.descripcion as Conceptos, concat(f.descripcion, ' Nro ', case when o.nrocarga is not null then concat(cast(o.nrocarga as char), '- Ordenes de Carga') else case when r.nro is not null and r.tipo = 0 then concat(cast(r.nro as char), '- Recibo') else case when r.nro is not null and r.tipo = 1 then  concat(cast(r.nro as char), '- Orden de Pago') else concat(cast(oc.nro as char), '- Orden de Combustible') end end end) as Descripcion, f.ptoventa, debe as Debe, haber as Haber from ctactefleteros f inner join conceptos c on f.idconceptos = c.codigo left join ordenescarga o on f.idordenescarga = o.idordenescarga left join ordenescombustible oc on f.idordenescombustible = oc.idordenescombustible left join recibos r on r.idrecibos = f.idrecibos left join fleteros cli on f.idfleteros = cli.idfleteros left join empresas e on f.idempresas = e.idempresas where f.idfleteros = '" + idcli + "' and f.idempresas = '" + idempresa + "'");
                DataTable dt = oa.leerDatos("SELECT SUM(DEBE-HABER) as saldo FROM CTACTEFLETEROS WHERE IDFLETEROS = '" + idcli + "' and idempresas = '" + idempresa + "'");
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
                        CtaCteClientesBindingSource.DataSource = oa.leerDatos("select e.empresa as Recibos, cli.fletero as Clientes, date_format(f.fecha,'%d/%m/%Y') as Fecha, c.descripcion as Conceptos, concat(f.descripcion, ' Nro ', case when o.nrocarga is not null then concat(cast(o.nrocarga as char), '- Ordenes de Carga') else case when r.nro is not null and r.tipo = 0 then concat(cast(r.nro as char), '- Recibo') else case when r.nro is not null and r.tipo = 1 then concat(cast(r.nro as char), '- Orden de Pago') else concat(cast(oc.nro as char), '- Orden de Combustible') end end end) as Descripcion, f.ptoventa, debe as Debe, haber as Haber from ctactefleteros f inner join conceptos c on f.idconceptos = c.codigo left join ordenescarga o on f.idordenescarga = o.idordenescarga left join ordenescombustible oc on f.idordenescombustible = oc.idordenescombustible left join recibos r on r.idrecibos = f.idrecibos left join fleteros cli on f.idfleteros = cli.idfleteros left join empresas e on f.idempresas = e.idempresas where f.idfleteros = '" + idcli + "' and f.idempresas = '" + idempresa + "' and date_format(f.fecha,'%d/%m/%Y') between '" + de + "' and '" + ha + "'");
                        DataTable dt = oa.leerDatos("SELECT SUM(DEBE-HABER) as saldo FROM CTACTEFLETEROS WHERE IDFLETEROS = '" + idcli + "' and idempresas = '" + idempresa + "'");
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
