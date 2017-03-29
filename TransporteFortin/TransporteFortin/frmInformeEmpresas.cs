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
    public partial class frmInformeEmpresas : Form
    {
        public frmInformeEmpresas()
        {
            InitializeComponent();
        }

        private void frmInformeEmpresas_Load(object sender, EventArgs e)
        {
            Acceso_BD oa = new Acceso_BD();
            EmpresasBindingSource.DataSource = oa.leerDatos("select empresa as Empresa, direccion as Direccion, localidad as Localidad, telefono as Telefono, telefono2 as Telefono2, celular as Celular from empresas");
            this.reportViewer1.RefreshReport();
        }
    }
}
