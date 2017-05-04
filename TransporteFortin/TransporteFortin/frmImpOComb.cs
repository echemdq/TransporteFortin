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
    public partial class frmImpOComb : Form
    {
        OrdenesCombustible oc;
        public frmImpOComb(OrdenesCombustible o)
        {
            oc = o;
            InitializeComponent();
        }

        private void frmImpOComb_Load(object sender, EventArgs e)
        {
            ReportParameter p1 = new ReportParameter("Nro", oc.Nro);
            ReportParameter p2 = new ReportParameter("Fletero", oc.Fleteros.Fletero);
            ReportParameter p3 = new ReportParameter("Cantidad", oc.Litros.ToString());
            ReportParameter p4 = new ReportParameter("Fecha", oc.Fecha.ToString("dd/MM/yyyy"));
            ReportParameter p5 = new ReportParameter("ChapaCamion", oc.Fleteros.Chapacamion);
            this.reportViewer1.LocalReport.SetParameters(p1);
            this.reportViewer1.LocalReport.SetParameters(p2);
            this.reportViewer1.LocalReport.SetParameters(p3);
            this.reportViewer1.LocalReport.SetParameters(p4);
            this.reportViewer1.LocalReport.SetParameters(p5);
            this.reportViewer1.RefreshReport();
        }
    }
}
