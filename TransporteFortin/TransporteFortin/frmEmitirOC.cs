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
    public partial class frmEmitirOC : Form
    {
        ControladoraOrdenesCarga controlo = new ControladoraOrdenesCarga();
        int idordencarga = 0;
        int idsucursal = 0;
        int idusuario = 0;
        int idptoventa = 0;
        int idpuesto = 0;
        int destino = 0;
        Clientes u = null;
        Fleteros f = null;
        public frmEmitirOC(int idorden, int idusu, int idpue, int idsuc, int talon, int dest)
        {
            destino = dest;
            InitializeComponent();
            idordencarga = idorden;
            idusuario = idusu;
            idpuesto = idpue;
            idsucursal = idsuc;
            idptoventa = talon;
            this.Text = "Ordenes de Carga | TALON: " + idptoventa;
        }

        private void frmEmitirOC_Load(object sender, EventArgs e)
        {
            if (destino == 0)
            {
                chkPagoDest.Checked = true;
                chkPagoDest.Enabled = false;
            }
            if (idordencarga == 0)
            {
                button3.Enabled = false;
                if (checkBox1.Checked)
                {
                    checkBox1.Checked = false;
                }
                maskedTextBox1.Text = DateTime.Today.ToString("dd/MM/yyyy");
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
                cmbSucursal.SelectedValue = idsucursal;

                dt = oacceso.leerDatos("select ifnull(ptoventa,0) as ok from contadores where detalle = 'ocarga' and ptoventa = '" + idptoventa + "'");
                int OK = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    OK = Convert.ToInt32(dr["ok"]);
                }
                if (OK == 0)
                {
                    MessageBox.Show("Comprobantes sin configurar");
                    this.Close();
                }

                dt = oacceso.leerDatos("select * from tiposcamion order by detalle asc");
                List<TiposCamion> lista = new List<TiposCamion>();
                foreach (DataRow dr in dt.Rows)
                {
                    TiposCamion t = new TiposCamion(Convert.ToInt32(dr["idtiposcamion"]), Convert.ToString(dr["detalle"]));
                    lista.Add(t);
                }
                cmbTipoCamion.DataSource = lista;
                cmbTipoCamion.DisplayMember = "detalle";
                cmbTipoCamion.ValueMember = "idtiposcamion";
                cmbTipoCamion.SelectedIndex = 0;

                dt = oacceso.leerDatos("select * from unidades order by detalle asc");
                List<Unidades> lista1 = new List<Unidades>();
                foreach (DataRow dr in dt.Rows)
                {
                    Unidades t = new Unidades(Convert.ToInt32(dr["idunidades"]), Convert.ToString(dr["detalle"]));
                    lista1.Add(t);
                }
                cmbUnidades.DataSource = lista1;
                cmbUnidades.DisplayMember = "detalle";
                cmbUnidades.ValueMember = "idunidades";
                cmbUnidades.SelectedIndex = 0;

                dt = oacceso.leerDatos("select * from configuraciones where detalle = 'porcentaje'");
                foreach (DataRow dr in dt.Rows)
                {
                    txtPorcentaje.Text = Convert.ToString(dr["valor"]);
                }
            }
            else
            {
                Acceso_BD oacceso = new Acceso_BD();
                button2.Enabled = false;
                if (checkBox1.Checked)
                {
                    checkBox1.Checked = false;
                }

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
                cmbSucursal.SelectedIndex = 0;

                dt = oacceso.leerDatos("select * from tiposcamion order by detalle asc");
                List<TiposCamion> lista = new List<TiposCamion>();
                foreach (DataRow dr in dt.Rows)
                {
                    TiposCamion t = new TiposCamion(Convert.ToInt32(dr["idtiposcamion"]), Convert.ToString(dr["detalle"]));
                    lista.Add(t);
                }
                cmbTipoCamion.DataSource = lista;
                cmbTipoCamion.DisplayMember = "detalle";
                cmbTipoCamion.ValueMember = "idtiposcamion";
                cmbTipoCamion.SelectedIndex = 0;

                dt = oacceso.leerDatos("select * from unidades order by detalle asc");
                List<Unidades> lista1 = new List<Unidades>();
                foreach (DataRow dr in dt.Rows)
                {
                    Unidades t = new Unidades(Convert.ToInt32(dr["idunidades"]), Convert.ToString(dr["detalle"]));
                    lista1.Add(t);
                }
                cmbUnidades.DataSource = lista1;
                cmbUnidades.DisplayMember = "detalle";
                cmbUnidades.ValueMember = "idunidades";
                cmbUnidades.SelectedIndex = 0;

                dt = oacceso.leerDatos("select o.idclientes, o.idfleteros, o.idempresas, idsucursales, c.cliente, c.direccion, f.fletero, f.documento, f.camion, f.idtiposcamion, f.chapacamion, f.chapaacoplado, e.empresa, porcuentade, productos, origen, destino, valordeclarado, valorizado, idunidades, cantidad, valorunidad, tipocomision, valorcomision, pagodestino, totalviaje, ivaviaje, comision, importecliente, observaciones, valorunidadcte, ivacliente, ptoventa, puesto, anulado, fecanula, fecha from ordenescarga o inner join clientes c on o.idclientes = c.idclientes inner join fleteros f on o.idfleteros = f.idfleteros left join empresas e on o.idempresas = e.idempresas where idordenescarga = '" + idordencarga + "'");

                foreach (DataRow dr in dt.Rows)
                {
                    this.Text = "Ordenes de Carga | TALON: " + Convert.ToString(dr["ptoventa"]);
                    idptoventa = Convert.ToInt32(dr["ptoventa"]);
                    lblCliente.Text = Convert.ToString(dr["idclientes"]);
                    lblFletero.Text = Convert.ToString(dr["idfleteros"]);
                    lblEmpresa.Text = Convert.ToString(dr["idempresas"]);                    
                    cmbSucursal.SelectedValue = Convert.ToInt32(dr["idsucursales"]);
                    cmbTipoCamion.SelectedValue = Convert.ToInt32(dr["idtiposcamion"]);
                    int valorizado = 0;
                    valorizado = Convert.ToInt32(dr["valorizado"]);
                    int anulado = 0;
                    anulado = Convert.ToInt32(dr["anulado"]);
                    txtCliente.Text = Convert.ToString(dr["cliente"]);
                    lblDireccionCte.Text = "Direccion "+Convert.ToString(dr["direccion"]);
                    txtFletero.Text = Convert.ToString(dr["fletero"]);
                    txtDocumento.Text = Convert.ToString(dr["documento"]);
                    txtModelo.Text = Convert.ToString(dr["camion"]);
                    txtChapaA.Text = Convert.ToString(dr["chapaacoplado"]);
                    txtChapaC.Text = Convert.ToString(dr["chapacamion"]);
                    txtEmpresa.Text = Convert.ToString(dr["empresa"]);
                    txtRetiraPor.Text = Convert.ToString(dr["porcuentade"]);
                    txtOrigen.Text = Convert.ToString(dr["origen"]);
                    txtDestino.Text = Convert.ToString(dr["destino"]);
                    txtProductos.Text = Convert.ToString(dr["productos"]);
                    txtValorDec.Text = Convert.ToString(dr["valordeclarado"]);
                    maskedTextBox1.Text = Convert.ToDateTime(dr["fecha"]).ToString("dd/MM/yyyy");
                    dt = oacceso.leerDatos("select * from configuraciones where detalle = 'porcentaje'");
                    foreach (DataRow dr1 in dt.Rows)
                    {
                        txtPorcentaje.Text = Convert.ToString(dr1["valor"]);
                    }
                    if (valorizado != 0)
                    {
                        button3.Enabled = false;
                        checkBox1.Enabled = false;
                        richTextBox1.Text = Convert.ToString(dr["observaciones"]);
                        cmbUnidades.SelectedValue = Convert.ToInt32(dr["idunidades"]);
                        txtCantidad.Text = Convert.ToString(dr["cantidad"]);
                        txtValorUni.Text = Convert.ToString(dr["valorunidad"]);
                        string tipocom = "";
                        tipocom = Convert.ToString(dr["tipocomision"]);
                        if (tipocom == "p")
                        {
                            rbporcentaje.Checked = true;
                            txtPorcentaje.Text = Convert.ToString(dr["valorcomision"]);
                        }
                        else if (tipocom == "v")
                        {
                            rbvalorfijo.Checked = true;
                            txtValorFijo.Text = Convert.ToString(dr["valorcomision"]);
                        }
                        int pagodest = Convert.ToInt32(dr["pagodestino"]);
                        if (pagodest != 0)
                        {
                            chkPagoDest.Checked = true;
                        }
                        txtTotalViaje.Text = Convert.ToString(dr["totalviaje"]);
                        txtIvaViaje.Text = Convert.ToString(dr["ivaviaje"]);
                        txtComision.Text = Convert.ToString(dr["comision"]);
                        txtImporteCte.Text = Convert.ToString(dr["importecliente"]);
                        richTextBox1.Text = Convert.ToString(dr["observaciones"]);
                        txtValorUniCte.Text = Convert.ToString(dr["valorunidadcte"]);
                        txtIVACte.Text = Convert.ToString(dr["ivacliente"]);
                        maskedTextBox1.Text = Convert.ToDateTime(dr["fecha"]).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        checkBox1.Checked = true;
                        checkBox1.Enabled = false;
                    }
                    if (anulado != 0)
                    {
                        checkBox1.Enabled = false;
                        string obs = Convert.ToString(dr["observaciones"]);
                        richTextBox1.Text = obs;
                        button3.Enabled = false;
                    }
                    
                }
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }



        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                groupBox6.Enabled = true;
            }
            else
            {
                groupBox6.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbporcentaje.Checked)
            {
                txtPorcentaje.Enabled = true;
                txtValorFijo.Enabled = false;
            }
            else if (rbvalorfijo.Checked)
            {
                txtPorcentaje.Enabled = false;
                txtValorFijo.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaClientes frm = new frmBuscaClientes();
                frm.ShowDialog();
                u = frm.u;
                if (u != null)
                {
                    Acceso_BD oa = new Acceso_BD();
                    DataTable dt = oa.leerDatos("select count(*) as cant from ordenescarga o inner join clientes c on o.idclientes = c.idclientes inner join fleteros f on f.idfleteros = o.idfleteros inner join tiposcamion t on f.idtiposcamion = t.idtiposcamion left join empresas e on f.idempresas = e.idempresas inner join sucursales s on s.idsucursales = o.idsucursales where  o.idclientes = '" + u.Idclientes + "' and o.valorizado = '0' and o.anulado = '0'");
                    string where = "where  o.idclientes = '" + u.Idclientes + "' and o.valorizado = '0' and o.anulado = '0'";
                    int cant = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        cant = Convert.ToInt32(dr["cant"]);
                    }
                    if (cant > 0)
                    {
                        btnOrdenCte.Text = "Ord.Carga Pendientes " + cant.ToString();
                        btnOrdenCte.Enabled = true;
                    }
                    else
                    {
                        btnOrdenCte.Text = "";
                        btnOrdenCte.Enabled = false;
                    }
                    lblCliente.Text = Convert.ToString(u.Idclientes);
                    lblDireccionCte.Text = u.Direccion;
                    txtCliente.Text = u.Cliente;
                    dt = oa.leerDatos("SELECT SUM(DEBE-HABER) as saldo FROM CTACTECLIENTES WHERE IDCLIENTES = '" + u.Idclientes + "'");
                    foreach (DataRow dr in dt.Rows)
                    {
                        txtSaldoCte.Text = Convert.ToString(dr["saldo"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaFleteros frm = new frmBuscaFleteros();
                frm.ShowDialog();
                f = frm.u;
                if (f != null)
                {
                    Acceso_BD oa = new Acceso_BD();
                    DataTable dt = oa.leerDatos("select count(*) as cant from ordenescarga o inner join clientes c on o.idclientes = c.idclientes inner join fleteros f on f.idfleteros = o.idfleteros inner join tiposcamion t on f.idtiposcamion = t.idtiposcamion left join empresas e on f.idempresas = e.idempresas inner join sucursales s on s.idsucursales = o.idsucursales where  o.idfleteros = '" + f.Idfleteros + "' and o.valorizado = '0' and o.anulado = '0'");
                    int cant = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        cant = Convert.ToInt32(dr["cant"]);
                    }
                    if (cant > 0)
                    {
                        btnOrdenFlet.Text = "Ord.Carga Pendientes " + cant.ToString();
                        btnOrdenFlet.Enabled = true;
                    }
                    else
                    {
                        btnOrdenFlet.Text = "";
                        btnOrdenFlet.Enabled = false;
                    }
                    lblFletero.Text = Convert.ToString(f.Idfleteros);
                    lblEmpresa.Text = f.Empresas.Idempresas.ToString();
                    txtEmpresa.Text = f.Empresas.Empresa;
                    txtFletero.Text = f.Fletero;
                    txtDomicilio.Text = f.Direccion;
                    txtLocalidad.Text = f.Localidad;
                    txtTelefono.Text = f.Telefono;
                    txtCelular.Text = f.Celular;
                    txtModelo.Text = f.Camion;
                    cmbTipoCamion.SelectedValue = f.Tiposcamion.Idtiposcamion;
                    txtCP.Text = f.Cp.ToString();
                    txtChapaA.Text = f.Chapaacoplado;
                    txtChapaC.Text = f.Chapacamion;
                    txtDocumento.Text = f.Documento.ToString();
                    dt = oa.leerDatos("SELECT SUM(DEBE-HABER) as saldo FROM ctactefleteros  WHERE idfleteros = '" + f.Idfleteros + "' and idempresas = '" + f.Empresas.Idempresas + "'");
                    
                    foreach (DataRow dr in dt.Rows)
                    {
                        txtSaldoFlet.Text = Convert.ToString(dr["saldo"]);
                    }

                    dt = oa.leerDatos("SELECT SUM(DEBE-HABER) as saldo FROM ctactefleteros  WHERE idempresas = '" + f.Empresas.Idempresas + "'");

                    foreach (DataRow dr in dt.Rows)
                    {
                        txtSaldoEmp.Text = Convert.ToString(dr["saldo"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message);
            }
        }

        private void txtValorDec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtValorDec.Text.Length; i++)
            {
                if (txtValorDec.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void txtValorUni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtValorUni.Text.Length; i++)
            {
                if (txtValorUni.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void txtValorUniCte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtValorUniCte.Text.Length; i++)
            {
                if (txtValorUniCte.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void txtValorFijo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtValorFijo.Text.Length; i++)
            {
                if (txtValorFijo.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void txtIvaViaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && txtIvaViaje.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void txtIVACte_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && txtIVACte.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtPorcentaje.Text.Length; i++)
            {
                if (txtPorcentaje.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtValorUni.Text.Length; i++)
            {
                if (txtValorUni.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;  
        }

        public void limpiar()
        {
            txtConceptoFact.Text = "";
            txtCliente.Text = "";
            lblDireccionCte.Text = "Direccion:";
            lblCliente.Text = "";
            txtSaldoCte.Text = "$0.00";
            txtFletero.Text = "";
            txtSaldoFlet.Text = "$0.00";
            txtDocumento.Text = "";
            txtCP.Text = "";
            txtDomicilio.Text = "";
            txtTelefono.Text = "";
            txtLocalidad.Text = "";
            txtCelular.Text = "";
            lblFletero.Text = "";
            lblEmpresa.Text = "0";
            txtModelo.Text = "";
            txtChapaC.Text = "";
            txtChapaA.Text = "";
            txtEmpresa.Text = "";
            txtSaldoEmp.Text = "";
            txtRetiraPor.Text = "";
            txtProductos.Text = "";
            txtOrigen.Text = "";
            txtDestino.Text = "";
            txtValorDec.Text = "0";
            rbporcentaje.Checked = false;
            txtCantidad.Text = "";
            txtValorUni.Text = "";
            txtValorUniCte.Text = "";
            txtPorcentaje.Text = "";
            txtValorFijo.Text = "0";
            chkPagoDest.Checked = false;
            txtTotalViaje.Text = "$0.00";
            txtIvaViaje.Text = "0.00";
            txtComision.Text = "$0.00";
            txtImporteCte.Text = "0.00";
            txtIVACte.Text = "0.00";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblCliente.Text != "" && lblFletero.Text != "")
                {
                    Sucursales sucursales = new Sucursales(Convert.ToInt32(cmbSucursal.SelectedValue), "");
                    Clientes cliente = new Clientes(Convert.ToInt32(lblCliente.Text), txtCliente.Text, lblDireccionCte.Text, "", "", "", "", "", "", "", "", null, "");
                    TiposCamion t = new TiposCamion(0, cmbTipoCamion.Text);
                    Fleteros fletero = new Fleteros(Convert.ToInt32(lblFletero.Text), Convert.ToInt32(txtDocumento.Text), txtFletero.Text, txtDomicilio.Text,"" , "", txtTelefono.Text, txtCelular.Text, "", "", null, txtModelo.Text, t, txtChapaC.Text, txtChapaA.Text, "", null,"");
                    Empresas empresa = new Empresas(Convert.ToInt32(lblEmpresa.Text), txtEmpresa.Text, "", "", "", "", "", "", "");
                    Usuarios usuario = new Usuarios(idusuario, "", "");
                    int valorizado = 0;
                    Unidades unidad = null;
                    
                    
                    decimal valorcomision = 0;
                    
                    string tipocom = "p";
                    int pagodest = 0;
                    if (chkPagoDest.Checked)
                    {
                        pagodest = 1;

                    }
                    else
                    {
                        pagodest = 0;
                    }
                    if (rbporcentaje.Checked)
                    {
                        if (txtPorcentaje.Text == "")
                        {
                            valorcomision = 0;
                        }
                        else
                        {
                            valorcomision = Convert.ToDecimal(txtPorcentaje.Text);
                        }
                    }
                    else
                    {
                        tipocom = "v";
                        if (txtValorFijo.Text == "")
                        {
                            valorcomision = 0;
                        }
                        else
                        {
                            valorcomision = Convert.ToDecimal(txtValorFijo.Text);
                        }
                    }
                    if (checkBox1.Checked)
                    {
                        valorizado = 1;
                        unidad = new Unidades(Convert.ToInt32(cmbUnidades.SelectedValue), "");
                        if (txtCantidad.Text == "" || txtValorUni.Text == "" || txtValorUniCte.Text == "" || txtPorcentaje.Text == "" || txtValorFijo.Text == "" || Convert.ToDecimal(txtTotalViaje.Text) <= 0)
                        {
                            MessageBox.Show("Debe completar todos los campos para valorizar y calcular el importe del viaje");
                        }
                        else
                        {
                            OrdenesCarga oc = new OrdenesCarga(0, "0", idptoventa, idpuesto, Convert.ToDateTime(maskedTextBox1.Text), sucursales, cliente, fletero, empresa, txtRetiraPor.Text, txtProductos.Text, txtOrigen.Text, txtDestino.Text, Convert.ToDecimal(txtValorDec.Text.Replace('.', ',')), valorizado, unidad, Convert.ToDecimal(txtCantidad.Text.Replace('.', ',')), Convert.ToDecimal(txtValorUni.Text.Replace('.', ',')), Convert.ToDecimal(txtValorUniCte.Text.Replace('.', ',')), tipocom, valorcomision, pagodest, Convert.ToDecimal(txtTotalViaje.Text.Replace('.', ',')), Convert.ToDecimal(txtIvaViaje.Text.Replace('.', ',')), Convert.ToDecimal(txtIVACte.Text.Replace('.', ',')), Convert.ToDecimal(txtComision.Text.Replace('.', ',')), Convert.ToDecimal(txtImporteCte.Text.Replace('.', ',')), richTextBox1.Text, 0, usuario, txtConceptoFact.Text);
                            string nro = controlo.Agregar(oc);
                            oc.Nrocarga = nro;
                            frmImpOCarga frm = new frmImpOCarga(oc);
                            frm.ShowDialog();
                            MessageBox.Show("Orden de carga generada correctamente");                            
                            limpiar();
                        }
                    }
                    else
                    {
                        unidad = new Unidades(Convert.ToInt32(cmbUnidades.SelectedValue), "");
                        OrdenesCarga oc = new OrdenesCarga(0, "0", idptoventa, idpuesto, Convert.ToDateTime(maskedTextBox1.Text), sucursales, cliente, fletero, empresa, txtRetiraPor.Text, txtProductos.Text, txtOrigen.Text, txtDestino.Text, Convert.ToDecimal(txtValorDec.Text.Replace('.', ',')), valorizado, unidad, 0, 0, 0, tipocom, valorcomision, 0, 0, 0, 0, 0, 0, richTextBox1.Text, 0, usuario, txtConceptoFact.Text);
                        string nro = controlo.Agregar(oc);
                        MessageBox.Show("Orden de carga generada correctamente");
                        limpiar();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Debe seleccionar Cliente y Fletero para generar la Orden");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "" || txtValorUni.Text != "" || txtValorUniCte.Text != "")
            {
                txtTotalViaje.Text = (Convert.ToDecimal(txtCantidad.Text.Replace('.', ',')) * Convert.ToDecimal(txtValorUni.Text.Replace('.', ','))).ToString();
                txtImporteCte.Text = (Convert.ToDecimal(txtCantidad.Text.Replace('.', ',')) * Convert.ToDecimal(txtValorUniCte.Text.Replace('.', ','))).ToString();
                if (rbporcentaje.Checked && txtPorcentaje.Text != "")
                {
                    txtComision.Text = (Convert.ToDecimal(txtTotalViaje.Text.Replace('.', ',')) * Convert.ToDecimal(txtPorcentaje.Text.Replace('.', ',')) / 100).ToString();
                }
                else if (rbvalorfijo.Checked && txtValorFijo.Text != "")
                {
                    txtComision.Text = txtValorFijo.Text;
                }
            }
        }

        private void groupboxflet_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                decimal valorcomision = 0;
                Sucursales sucursales = new Sucursales(Convert.ToInt32(cmbSucursal.SelectedValue), "");
                Clientes cliente = new Clientes(Convert.ToInt32(lblCliente.Text), txtCliente.Text, "", "", "", "", "", "", "", "", "", null, "");
                Fleteros fletero = new Fleteros(Convert.ToInt32(lblFletero.Text), 0, "", "", "", "", "", "", "", "", null, "", null, "", "", "", null,"");
                Empresas empresa = new Empresas(Convert.ToInt32(lblEmpresa.Text), "", "", "", "", "", "", "", "");
                Usuarios usuario = new Usuarios(idusuario, "", "");
                string tipocom = "p";
                int pagodest = 0;
                if (chkPagoDest.Checked)
                {
                    pagodest = 1;

                }
                else
                {
                    pagodest = 0;
                }
                if (rbporcentaje.Checked)
                {
                    if (txtPorcentaje.Text == "")
                    {
                        valorcomision = 0;
                    }
                    else
                    {
                        valorcomision = Convert.ToDecimal(txtPorcentaje.Text);
                    }
                }
                else
                {
                    tipocom = "v";
                    if (txtValorFijo.Text == "")
                    {
                        valorcomision = 0;
                    }
                    else
                    {
                        valorcomision = Convert.ToDecimal(txtValorFijo.Text);
                    }
                }
                int valorizado = 1;
                Unidades unidad = new Unidades(Convert.ToInt32(cmbUnidades.SelectedValue), "");

                if (txtCantidad.Text == "" || txtValorUni.Text == "" || txtValorUniCte.Text == "" || txtPorcentaje.Text == "" || txtValorFijo.Text == "" || Convert.ToDecimal(txtTotalViaje.Text) <= 0)
                {
                    MessageBox.Show("Debe completar todos los campos para valorizar y calcular el importe del viaje");
                }
                else
                {
                    Acceso_BD oa = new Acceso_BD();
                    DataTable dt = oa.leerDatos("select idempresas from fleteros where idfleteros = '"+fletero.Idfleteros+"'");
                    int idempresas = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        idempresas = Convert.ToInt32(dr["idempresas"]);
                    }
                    if (idempresas == empresa.Idempresas)
                    {
                        OrdenesCarga oc = new OrdenesCarga(idordencarga, "0", idptoventa, idpuesto, Convert.ToDateTime(maskedTextBox1.Text), sucursales, cliente, fletero, empresa, txtRetiraPor.Text, txtProductos.Text, txtOrigen.Text, txtDestino.Text, Convert.ToDecimal(txtValorDec.Text.Replace('.', ',')), valorizado, unidad, Convert.ToDecimal(txtCantidad.Text.Replace('.', ',')), Convert.ToDecimal(txtValorUni.Text.Replace('.', ',')), Convert.ToDecimal(txtValorUniCte.Text.Replace('.', ',')), tipocom, valorcomision, pagodest, Convert.ToDecimal(txtTotalViaje.Text.Replace('.', ',')), Convert.ToDecimal(txtIvaViaje.Text.Replace('.', ',')), Convert.ToDecimal(txtIVACte.Text.Replace('.', ',')), Convert.ToDecimal(txtComision.Text.Replace('.', ',')), Convert.ToDecimal(txtImporteCte.Text.Replace('.', ',')), richTextBox1.Text, 0, null, txtConceptoFact.Text);
                        controlo.Modificar(oc);
                        MessageBox.Show("Orden de carga valorizada correctamente");
                        limpiar();
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Difiere empresa de Orden de carga con actual del fletero, desea actualizar la Orden de carga a empresa actual ?", "Valorizar", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {                            
                            empresa.Idempresas = idempresas;
                            OrdenesCarga oc = new OrdenesCarga(idordencarga, "0", idptoventa, idpuesto, Convert.ToDateTime(maskedTextBox1.Text), sucursales, cliente, fletero, empresa, txtRetiraPor.Text, txtProductos.Text, txtOrigen.Text, txtDestino.Text, Convert.ToDecimal(txtValorDec.Text.Replace('.', ',')), valorizado, unidad, Convert.ToDecimal(txtCantidad.Text.Replace('.', ',')), Convert.ToDecimal(txtValorUni.Text.Replace('.', ',')), Convert.ToDecimal(txtValorUniCte.Text.Replace('.', ',')), tipocom, valorcomision, pagodest, Convert.ToDecimal(txtTotalViaje.Text.Replace('.', ',')), Convert.ToDecimal(txtIvaViaje.Text.Replace('.', ',')), Convert.ToDecimal(txtIVACte.Text.Replace('.', ',')), Convert.ToDecimal(txtComision.Text.Replace('.', ',')), Convert.ToDecimal(txtImporteCte.Text.Replace('.', ',')), richTextBox1.Text, 0, null, txtConceptoFact.Text);
                            controlo.Modificar(oc);
                            MessageBox.Show("Orden de carga valorizada correctamente");
                            limpiar();
                        }
                        else
                        {
                            OrdenesCarga oc = new OrdenesCarga(idordencarga, "0", idptoventa, idpuesto, Convert.ToDateTime(maskedTextBox1.Text), sucursales, cliente, fletero, empresa, txtRetiraPor.Text, txtProductos.Text, txtOrigen.Text, txtDestino.Text, Convert.ToDecimal(txtValorDec.Text.Replace('.', ',')), valorizado, unidad, Convert.ToDecimal(txtCantidad.Text.Replace('.', ',')), Convert.ToDecimal(txtValorUni.Text.Replace('.', ',')), Convert.ToDecimal(txtValorUniCte.Text.Replace('.', ',')), tipocom, valorcomision, pagodest, Convert.ToDecimal(txtTotalViaje.Text.Replace('.', ',')), Convert.ToDecimal(txtIvaViaje.Text.Replace('.', ',')), Convert.ToDecimal(txtIVACte.Text.Replace('.', ',')), Convert.ToDecimal(txtComision.Text.Replace('.', ',')), Convert.ToDecimal(txtImporteCte.Text.Replace('.', ',')), richTextBox1.Text, 0, null, txtConceptoFact.Text);
                            controlo.Modificar(oc);
                            MessageBox.Show("Orden de carga valorizada correctamente");
                            limpiar();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void chkPagoDest_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPagoDest.Checked)
            {
                txtValorUniCte.Text = "0";
                txtValorUniCte.Enabled = false;
                richTextBox1.Text = "Pago destino";
            }
            else
            {
                txtValorUniCte.Text = "";
                txtValorUniCte.Enabled = true;
                richTextBox1.Text = "";
            }
        }

        private void btnOrdenCte_Click(object sender, EventArgs e)
        {
            string where = "where  o.idclientes = '" + u.Idclientes + "' and o.valorizado = '0' and o.anulado = '0'";
            frmListaOrdenesCarga frm = new frmListaOrdenesCarga(where, idusuario);
            frm.ShowDialog();
        }

        private void btnOrdenFlet_Click(object sender, EventArgs e)
        {
            string where = "where  o.idfleteros = '" + f.Idfleteros + "' and o.valorizado = '0' and o.anulado = '0'";
            frmListaOrdenesCarga frm = new frmListaOrdenesCarga(where, idusuario);
            frm.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
