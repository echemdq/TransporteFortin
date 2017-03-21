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
    public partial class frmprueba : Form
    {
        public frmprueba()
        {
            InitializeComponent();
        }

        private void frmprueba_Load(object sender, EventArgs e)
        {
            Acceso_BD oa = new Acceso_BD();            
            ClientesBindingSource.DataSource = oa.leerDatos("select Cliente, Direccion, Localidad, Telefono, Celular, cuit as Cuit, t.detalle as TiposIVA from clientes c inner join tiposiva t on c.idtiposiva = t.idtiposiva");
            this.reportViewer1.RefreshReport();
        }
    }
}
