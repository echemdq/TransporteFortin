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
    public partial class frmRecibo : Form
    {
        public frmRecibo()
        {
            InitializeComponent();
        }

        private void frmRecibo_Load(object sender, EventArgs e)
        {
            Acceso_BD oa = new Acceso_BD();

            FormasDePagoBindingSource.DataSource = oa.leerDatos("select fo.detalle as Idformaspago, f.importe as Importe, f.cheque as Nrocheque from formasdepago f inner join formaspago fo on f.idformaspago = fo.idformaspago");


            ReportParameter p1 = new ReportParameter("NroRecibo", "1");
            ReportParameter p2 = new ReportParameter("RecibeDe", "1");
            ReportParameter p3 = new ReportParameter("ConceptoDe", "1");
            ReportParameter p4 = new ReportParameter("CantidadDe", DateTime.Now.Date.ToString("dd/MM/yyyy"));
            this.reportViewer1.LocalReport.SetParameters(p1);
            this.reportViewer1.LocalReport.SetParameters(p2);
            this.reportViewer1.LocalReport.SetParameters(p3);
            this.reportViewer1.LocalReport.SetParameters(p4);

            this.reportViewer1.RefreshReport();
        }
    }
}
