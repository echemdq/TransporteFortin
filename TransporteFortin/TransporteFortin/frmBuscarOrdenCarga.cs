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
    public partial class frmBuscarOrdenCarga : Form
    {
        public frmBuscarOrdenCarga()
        {
            InitializeComponent();
        }

        private void frmBuscarOrdenCarga_Load(object sender, EventArgs e)
        {
            mskHasta.Text = DateTime.Today.ToString("dd/MM/yyyy");
            Acceso_BD oacceso = new Acceso_BD();
            DataTable dt = oacceso.leerDatos("select * from sucursales order by sucursal asc");
            List<Sucursales> listat = new List<Sucursales>();
            foreach (DataRow dr in dt.Rows)
            {
                Sucursales t = new Sucursales(Convert.ToInt32(dr["idsucursales"]), Convert.ToString(dr["sucursal"]));
                listat.Add(t);
            }
            cmbSucursal.DataSource = listat;
            cmbSucursal.DisplayMember = "sucursal";
            cmbSucursal.ValueMember = "idsucursales";
            cmbSucursal.SelectedIndex = -1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaClientes frm = new frmBuscaClientes();
                frm.ShowDialog();
                Clientes u = frm.u;
                if (u != null)
                {
                    lblCliente.Text = Convert.ToString(u.Idclientes);
                    txtCliente.Text = u.Cliente;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaFleteros frm = new frmBuscaFleteros();
                frm.ShowDialog();
                Fleteros u = frm.u;
                if (u != null)
                {
                    lblFletero.Text = Convert.ToString(u.Idfleteros);
                    txtFletero.Text = u.Fletero;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message);
            }
        }
    }
}
