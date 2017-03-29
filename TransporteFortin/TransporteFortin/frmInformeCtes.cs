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
                ClientesBindingSource.DataSource = oa.leerDatos("select cliente as Cliente, direccion as Direccion, localidad as Localidad, telefono as Telefono, celular as Celular, cuit as Cuit, t.detalle as TiposIVA from clientes c inner join tiposiva t on c.idtiposiva = t.idtiposiva");
                this.reportViewer1.RefreshReport();
            }           
            
        }

        private void ClientesBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
