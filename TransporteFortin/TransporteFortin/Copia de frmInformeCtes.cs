using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace TransporteFortin
{
    public partial class frmInformeCtes : Form
    {
        string tipo = "";
        public frmInformeCtes(string t)
        {
            InitializeComponent();
            tipo = t;
        }

        private void frmprueba_Load(object sender, EventArgs e)
        {
            Acceso_BD oa = new Acceso_BD();
            if (tipo == "cliente")
            {
                reportViewer1.LocalReport.ReportPath = "Report1.rdlc";
                reportViewer1.LocalReport.Refresh();
                ClientesBindingSource.DataSource = oa.leerDatos("select cliente as Cliente, direccion as Direccion, localidad as Localidad, telefono as Telefono, celular as Celular, cuit as Cuit, t.detalle as TiposIVA from clientes c inner join tiposiva t on c.idtiposiva = t.idtiposiva");
                this.reportViewer1.RefreshReport();
            }
            if (tipo == "fletero")
            {
                FleterosBindingSource.DataSource = oa.leerDatos("select f.fletero as Fletero, f.documento as Documento, f.telefono as Telefono, f.celular as Celular, e.empresa as Empresas, t.detalle as Tiposcamion, f.camion as Camion, f.chapacamion as Chapacamion, f.chapaacoplado as Chapaacoplado from fleteros f inner join empresas e on f.idempresas = e.idempresas inner join tiposcamion t on f.idtiposcamion = t.idtiposcamion");
//                
                reportViewer1.LocalReport.ReportPath = "Report2.rdlc";
                reportViewer1.LocalReport.Refresh();
            }
            if (tipo == "empresa")
            {
                EmpresasBindingSource.DataSource = oa.leerDatos("select empresa as Empresa, direccion as Direccion, localidad as Localidad, telefono as Telefono, telefono2 as Telefono2, celular as Celular from empresas");
                //this.reportViewer1.RefreshReport();
                reportViewer1.LocalReport.ReportPath = "Report3.rdlc";
                reportViewer1.LocalReport.Refresh();
            }
        }

        private void ClientesBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
