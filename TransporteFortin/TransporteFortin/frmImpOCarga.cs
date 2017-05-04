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
    public partial class frmImpOCarga : Form
    {
        OrdenesCarga ocarga;
        public frmImpOCarga(OrdenesCarga oc)
        {
            ocarga = oc;
            InitializeComponent();
        }

        private void frmImpOCarga_Load(object sender, EventArgs e)
        {
            if (ocarga.Pagodestino == 1)
            {
                ReportParameter p1 = new ReportParameter("Nro", ocarga.Nrocarga);
                ReportParameter p2 = new ReportParameter("Cliente", ocarga.Clientes.Cliente);
                ReportParameter p3 = new ReportParameter("Domicilio", ocarga.Clientes.Direccion);
                ReportParameter p4 = new ReportParameter("PorCuenta", ocarga.Porcuentade);
                ReportParameter p5 = new ReportParameter("Productos", ocarga.Productos);
                ReportParameter p6 = new ReportParameter("Cantidad", ocarga.Cantidad.ToString());
                ReportParameter p7 = new ReportParameter("Declarado", ocarga.Valordeclarado.ToString());
                ReportParameter p8 = new ReportParameter("ImporteTotal", ocarga.Totalviaje.ToString());
                ReportParameter p9 = new ReportParameter("Comision", ocarga.Comision.ToString());
                ReportParameter p10 = new ReportParameter("Origen", ocarga.Origen);
                ReportParameter p11 = new ReportParameter("Destino", ocarga.Destino);
                ReportParameter p12 = new ReportParameter("Observaciones", ocarga.Observaciones);
                ReportParameter p13 = new ReportParameter("Fletero", ocarga.Fleteros.Fletero);
                ReportParameter p14 = new ReportParameter("DomFletero", ocarga.Fleteros.Direccion);
                ReportParameter p15 = new ReportParameter("TelFletero", ocarga.Fleteros.Telefono);
                ReportParameter p16 = new ReportParameter("CelFletero", ocarga.Fleteros.Celular);
                ReportParameter p17 = new ReportParameter("Registro", ocarga.Fleteros.Documento.ToString());
                ReportParameter p18 = new ReportParameter("Empresa", ocarga.Empresas.Empresa);
                ReportParameter p19 = new ReportParameter("TelEmpresa", ocarga.Empresas.Telefono);
                ReportParameter p20 = new ReportParameter("Camion", ocarga.Fleteros.Camion);
                ReportParameter p21 = new ReportParameter("ChapaCamion", ocarga.Fleteros.Chapacamion);
                ReportParameter p22 = new ReportParameter("TipoAcoplado", ocarga.Fleteros.Tiposcamion.Detalle);
                ReportParameter p23 = new ReportParameter("ChapaAcoplado", ocarga.Fleteros.Chapaacoplado);
                ReportParameter p24 = new ReportParameter("Fecha", ocarga.Fecha.ToString("dd/MM/yyyy"));
                this.reportViewer1.LocalReport.SetParameters(p1);
                this.reportViewer1.LocalReport.SetParameters(p2);
                this.reportViewer1.LocalReport.SetParameters(p3);
                this.reportViewer1.LocalReport.SetParameters(p4);
                this.reportViewer1.LocalReport.SetParameters(p5);
                this.reportViewer1.LocalReport.SetParameters(p6);
                this.reportViewer1.LocalReport.SetParameters(p7);
                this.reportViewer1.LocalReport.SetParameters(p8);
                this.reportViewer1.LocalReport.SetParameters(p9);
                this.reportViewer1.LocalReport.SetParameters(p10);
                this.reportViewer1.LocalReport.SetParameters(p11);
                this.reportViewer1.LocalReport.SetParameters(p12);
                this.reportViewer1.LocalReport.SetParameters(p13);
                this.reportViewer1.LocalReport.SetParameters(p14);
                this.reportViewer1.LocalReport.SetParameters(p15);
                this.reportViewer1.LocalReport.SetParameters(p16);
                this.reportViewer1.LocalReport.SetParameters(p17);
                this.reportViewer1.LocalReport.SetParameters(p18);
                this.reportViewer1.LocalReport.SetParameters(p19);
                this.reportViewer1.LocalReport.SetParameters(p20);
                this.reportViewer1.LocalReport.SetParameters(p21);
                this.reportViewer1.LocalReport.SetParameters(p22);
                this.reportViewer1.LocalReport.SetParameters(p23);
                this.reportViewer1.LocalReport.SetParameters(p24);
                this.reportViewer1.RefreshReport();
            }
            else
            {
                ReportParameter p1 = new ReportParameter("Nro", ocarga.Nrocarga);
                ReportParameter p2 = new ReportParameter("Cliente", ocarga.Clientes.Cliente);
                ReportParameter p3 = new ReportParameter("Domicilio", ocarga.Clientes.Direccion);
                ReportParameter p4 = new ReportParameter("PorCuenta", ocarga.Porcuentade);
                ReportParameter p5 = new ReportParameter("Productos", ocarga.Productos);
                ReportParameter p6 = new ReportParameter("Cantidad", ocarga.Cantidad.ToString());
                ReportParameter p7 = new ReportParameter("Declarado", ocarga.Valordeclarado.ToString());
                ReportParameter p8 = new ReportParameter("ImporteTotal", "0.00");
                ReportParameter p9 = new ReportParameter("Comision", "0.00");
                ReportParameter p10 = new ReportParameter("Origen", ocarga.Origen);
                ReportParameter p11 = new ReportParameter("Destino", ocarga.Destino);
                ReportParameter p12 = new ReportParameter("Observaciones", ocarga.Observaciones);
                ReportParameter p13 = new ReportParameter("Fletero", ocarga.Fleteros.Fletero);
                ReportParameter p14 = new ReportParameter("DomFletero", ocarga.Fleteros.Direccion);
                ReportParameter p15 = new ReportParameter("TelFletero", ocarga.Fleteros.Telefono);
                ReportParameter p16 = new ReportParameter("CelFletero", ocarga.Fleteros.Celular);
                ReportParameter p17 = new ReportParameter("Registro", ocarga.Fleteros.Documento.ToString());
                ReportParameter p18 = new ReportParameter("Empresa", ocarga.Empresas.Empresa);
                ReportParameter p19 = new ReportParameter("TelEmpresa", ocarga.Empresas.Telefono);
                ReportParameter p20 = new ReportParameter("Camion", ocarga.Fleteros.Camion);
                ReportParameter p21 = new ReportParameter("ChapaCamion", ocarga.Fleteros.Chapacamion);
                ReportParameter p22 = new ReportParameter("TipoAcoplado", ocarga.Fleteros.Tiposcamion.Detalle);
                ReportParameter p23 = new ReportParameter("ChapaAcoplado", ocarga.Fleteros.Chapaacoplado);
                ReportParameter p24 = new ReportParameter("Fecha", ocarga.Fecha.ToString("dd/MM/yyyy"));
                this.reportViewer1.LocalReport.SetParameters(p1);
                this.reportViewer1.LocalReport.SetParameters(p2);
                this.reportViewer1.LocalReport.SetParameters(p3);
                this.reportViewer1.LocalReport.SetParameters(p4);
                this.reportViewer1.LocalReport.SetParameters(p5);
                this.reportViewer1.LocalReport.SetParameters(p6);
                this.reportViewer1.LocalReport.SetParameters(p7);
                this.reportViewer1.LocalReport.SetParameters(p8);
                this.reportViewer1.LocalReport.SetParameters(p9);
                this.reportViewer1.LocalReport.SetParameters(p10);
                this.reportViewer1.LocalReport.SetParameters(p11);
                this.reportViewer1.LocalReport.SetParameters(p12);
                this.reportViewer1.LocalReport.SetParameters(p13);
                this.reportViewer1.LocalReport.SetParameters(p14);
                this.reportViewer1.LocalReport.SetParameters(p15);
                this.reportViewer1.LocalReport.SetParameters(p16);
                this.reportViewer1.LocalReport.SetParameters(p17);
                this.reportViewer1.LocalReport.SetParameters(p18);
                this.reportViewer1.LocalReport.SetParameters(p19);
                this.reportViewer1.LocalReport.SetParameters(p20);
                this.reportViewer1.LocalReport.SetParameters(p21);
                this.reportViewer1.LocalReport.SetParameters(p22);
                this.reportViewer1.LocalReport.SetParameters(p23);
                this.reportViewer1.LocalReport.SetParameters(p24);
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
