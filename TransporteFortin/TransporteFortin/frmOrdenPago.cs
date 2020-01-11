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
    public partial class frmOrdenPago : Form
    {
        int idrecibo = 0;
        string total = "";
        string cantidadde = "";
        string concepto = "";
        string recibimosde = "";
        public frmOrdenPago(int idrec, string tot, string cantde, string conc, string recde)
        {
            idrecibo = idrec;
            total = tot;
            cantidadde = cantde;
            concepto = conc;
            recibimosde = recde;
            InitializeComponent();
        }

        private void frmOrdenPago_Load(object sender, EventArgs e)
        {
            Acceso_BD oa = new Acceso_BD();
            DataTable dt = oa.leerDatos("select r.nro as nro, fo.detalle as Idformaspago, f.importe as Importe, r.fecha as fecha, f.cheque as Nrocheque from formasdepago f inner join formaspago fo on f.idformaspago = fo.idformaspago inner join recibos r on f.idordenespago = r.idrecibos where f.idordenespago = '" + idrecibo + "'");
            string nrorecibo = "";
            DateTime fecha = DateTime.Now;
            foreach (DataRow dr in dt.Rows)
            {
                nrorecibo = Convert.ToString(dr["nro"]);
                fecha = Convert.ToDateTime(dr["fecha"]);
            }
            FormasDePagoBindingSource.DataSource = dt;
            ReportParameter p1 = new ReportParameter("NroRecibo", nrorecibo);
            ReportParameter p2 = new ReportParameter("RecibeDe", recibimosde);
            ReportParameter p3 = new ReportParameter("ConceptoDe", concepto);
            ReportParameter p4 = new ReportParameter("CantidadDe", cantidadde);
            ReportParameter p5 = new ReportParameter("Fecha", fecha.ToString("dd/MM/yyyy"));
            ReportParameter p6 = new ReportParameter("Total", total);
            this.reportViewer1.LocalReport.SetParameters(p1);
            this.reportViewer1.LocalReport.SetParameters(p2);
            this.reportViewer1.LocalReport.SetParameters(p3);
            this.reportViewer1.LocalReport.SetParameters(p4);
            this.reportViewer1.LocalReport.SetParameters(p5);
            this.reportViewer1.LocalReport.SetParameters(p6);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
