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
    public partial class frmInfCtaCteProv : Form
    {
        int idcli = 0;
        string de = "";
        string ha = "";
        int ch = 0;

        public frmInfCtaCteProv(int idcliente, int check, string desde, string hasta)
        {
            InitializeComponent();
            idcli = idcliente;
            ch = check;
            de = desde;
            ha = hasta;
        }

        private void frmInfCtaCteProv_Load(object sender, EventArgs e)
        {
            Acceso_BD oa = new Acceso_BD();
            if (ch == 0)
            {
                CtaCteClientesBindingSource.DataSource = oa.leerDatos("select cli.proveedor as Clientes, date_format(f.fecha,'%d/%m/%Y') as Fecha, c.descripcion as Conceptos, f.ptoventa, debe as Debe, haber as Haber, concat(ifnull(f.descripcion,''), ' Nro ', case when o.nro is not null then concat(ifnull(cast(o.nro as char),''), '- Ordenes de Combustible') else case when r.nro is not null and r.tipo = 0 then concat(ifnull(cast(r.nro as char),''), '- Recibo') else concat(ifnull(cast(r.nro as char),''), '- Orden de Pago') end end) as Descripcion from ctacteproveedores f inner join conceptos c on f.idconceptos = c.codigo left join ordenescombustible o on f.idordenescombustible = o.idordenescombustible left join recibos r on r.idrecibos = f.idrecibos left join proveedores cli on f.idproveedores = cli.idproveedores where f.idproveedores = '" + idcli + "'");
                DataTable dt = oa.leerDatos("SELECT SUM(DEBE-HABER) as saldo FROM ctacteproveedores WHERE idproveedores = '" + idcli + "'");
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
                        CtaCteClientesBindingSource.DataSource = oa.leerDatos("select cli.proveedor as Clientes, date_format(f.fecha,'%d/%m/%Y') as Fecha, c.descripcion as Conceptos, f.ptoventa, debe as Debe, haber as Haber, concat(ifnull(f.descripcion,''), ' Nro ', case when o.nro is not null then concat(ifnull(cast(o.nro as char),''), '- Ordenes de Combustible') else case when r.nro is not null and r.tipo = 0 then concat(ifnull(cast(r.nro as char),''), '- Recibo') else concat(ifnull(cast(r.nro as char),''), '- Orden de Pago') end end) as Descripcion from ctacteproveedores f inner join conceptos c on f.idconceptos = c.codigo left join ordenescombustible o on f.idordenescombustible = o.idordenescombustible left join recibos r on r.idrecibos = f.idrecibos left join proveedores cli on f.idproveedores = cli.idproveedores where f.idproveedores = '" + idcli + "' and f.fecha between '" + desde.ToString("yyyy-MM-dd") + "' and '" + hasta.ToString("yyyy-MM-dd") + "'");
                        DataTable dt = oa.leerDatos("SELECT SUM(DEBE-HABER) as saldo FROM ctacteproveedores WHERE idproveedores = '" + idcli + "'");
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
