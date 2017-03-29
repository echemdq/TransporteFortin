using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransporteFortin
{
    public partial class frmInformeFleteros : Form
    {
        public frmInformeFleteros()
        {
            InitializeComponent();
        }

        private void frmInformeFleteros_Load(object sender, EventArgs e)
        {
            Acceso_BD oa = new Acceso_BD();
            FleterosBindingSource.DataSource = oa.leerDatos("select f.fletero as Fletero, f.documento as Documento, f.telefono as Telefono, f.celular as Celular, e.empresa as Empresas, t.detalle as Tiposcamion, f.camion as Camion, f.chapacamion as Chapacamion, f.chapaacoplado as Chapaacoplado from fleteros f inner join empresas e on f.idempresas = e.idempresas inner join tiposcamion t on f.idtiposcamion = t.idtiposcamion");
            this.reportViewer1.RefreshReport();
        }
    }
}
