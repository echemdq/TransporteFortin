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
    public partial class frmCheques : Form
    {
        int tipoc;
        int idusuario;
        public frmCheques(int tipo, int idusu)
        {
            tipoc = tipo;
            idusuario = idusu;
            InitializeComponent();
        }

        private void frmCheques_Load(object sender, EventArgs e)
        {
            if (tipoc == 4)
            {
                this.Text = "Consulta transferencia";
                label15.Text = "Numero Transf";
            }
            else if(tipoc == 3)
            {
                this.Text = "Consulta Cheques Terceros";
                label36.Visible = true;
                Acceso_BD oacceso = new Acceso_BD();
                DataTable dt = oacceso.leerDatos("select * from estadoscheques order by estado asc");
                List<EstadosCheques> listat = new List<EstadosCheques>();
                foreach (DataRow dr in dt.Rows)
                {
                    EstadosCheques t = new EstadosCheques(Convert.ToInt32(dr["idestadoscheques"]),Convert.ToString(dr["estado"]));
                    listat.Add(t);
                }
                cmbEstados.DataSource = listat;
                cmbEstados.DisplayMember = "estado";
                cmbEstados.ValueMember = "idestadoscheques";

            }
            else if (tipoc == 2)
            {
                this.Text = "Consulta Cheques Propios";

            }

            //Acceso_BD oa = new Acceso_BD();
            //dataGridView1.DataSource = oa.leerDatos("select date_format(fp.fechaentrega,'%d/%m/%Y') as 'Fecha Emision', date_format(fp.fechadeposito,'%d/%m/%Y') as 'Fecha Deposito', case when fp.idrecibos = 0 then '' else case when r.idfleteros = 0 then c.cliente else f.fletero end end as Origen, case when fp.idordenespago = 0 then '' else case when r1.idfleteros = 0 then p.proveedor else f1.fletero end end  as Destino, e.estado as 'Estado Cheque',cheque as 'Nro Cheque', fp.importe as Importe, fs.detalle as 'Forma de Pago', ifnull(b.banco, ' ') as Banco, ifnull(concat(b1.banco, ' ',cb.nrocuenta, ' ',cb.descripcion), ' ') as 'Cuenta Banco', ifnull(concat(cast(r.ptoventa as char), '-', cast(r.nro as char)), ' ') as 'Talon-Recibo',  ifnull(concat(cast(r1.ptoventa as char), '-',cast(r1.nro as char)), ' ') as 'Talon-Orden de Pago', fp.comentarios as Comentario from formasdepago fp left join bancos b on fp.idbancos = b.idbancos left join cuentasbanco cb on fp.idcuentasbanco = cb.idcuentasbanco left join bancos b1 on cb.idbancos = b1.idbancos left join recibos r on fp.idrecibos = r.idrecibos left join recibos r1 on fp.idordenespago = r1.idrecibos left join clientes c on r.idclientes = c.idclientes left join fleteros f on r.idfleteros = f.idfleteros left join fleteros f1 on r1.idfleteros = f1.idfleteros left join proveedores p on r1.idproveedores = p.idproveedores left join estadoscheques e on fp.idestadoscheques = e.idestadoscheques left join formaspago fs on fp.idformaspago = fs.idformaspago where fp.idformaspago = 2 or fp.idformaspago = 3");
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int filaseleccionada = Convert.ToInt32(this.dataGridView1.CurrentRow.Index);
            txtfechaemi.Text = dataGridView1[0, filaseleccionada].Value.ToString();
            txtfechadep.Text = dataGridView1[1, filaseleccionada].Value.ToString();
            txtorigen.Text = dataGridView1[5, filaseleccionada].Value.ToString();
            txtdestino.Text = dataGridView1[6, filaseleccionada].Value.ToString();
            txtEstado.Text = dataGridView1[2, filaseleccionada].Value.ToString();
            txtnro.Text = dataGridView1[3, filaseleccionada].Value.ToString();
            txtimporte.Text = dataGridView1[4, filaseleccionada].Value.ToString();
            txtforma.Text = dataGridView1[7, filaseleccionada].Value.ToString();
            txtBanco.Text = dataGridView1[8, filaseleccionada].Value.ToString();
            txtCuentaBanco.Text = dataGridView1[9, filaseleccionada].Value.ToString();
            txtrecibo.Text = dataGridView1[10, filaseleccionada].Value.ToString();
            txtordenpago.Text = dataGridView1[11, filaseleccionada].Value.ToString();
            txtcomentarios.Text = dataGridView1[12, filaseleccionada].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime desde;
            DateTime hasta;
            string where = "";
            if (DateTime.TryParse(maskedTextBox1.Text, out desde) && DateTime.TryParse(maskedTextBox2.Text, out hasta))
            {
                if (rbfechaemi.Checked)
                {
                    where = " and fp.fechaentrega between '" + desde.ToString("yyyy-MM-dd") + "' and '" + hasta.ToString("yyyy-MM-dd") + "'";
                }
                else
                {
                    where = " and fp.fechadeposito between '" + desde.ToString("yyyy-MM-dd") + "' and '" + hasta.ToString("yyyy-MM-dd") + "'";
                }
            }
            if (textBox1.Text != "")
            {
                if (where != "")
                {
                    where = where + " and cheque like '%" + textBox1.Text + "%'";
                }
                else
                {
                    where = " and cheque like '%" + textBox1.Text + "%'";
                }
            }

            if (checkBox1.Checked)
            {
                if (where != "")
                {
                    where = where + " and fp.idestadoscheques like '%" + cmbEstados.SelectedValue + "%'";
                }
                else
                {
                    where = " and fp.idestadoscheques like '%" + cmbEstados.SelectedValue + "%'";
                }
            }

            Acceso_BD oa = new Acceso_BD();
            dataGridView1.DataSource = oa.leerDatos("select date_format(fp.fechaentrega,'%d/%m/%Y') as 'Fecha Emision', date_format(fp.fechadeposito,'%d/%m/%Y') as 'Fecha Deposito', e.estado as 'Estado Cheque', cheque as 'Nro Cheque', fp.importe as Importe, case when fp.idrecibos = 0 then '' else case when r.idfleteros = 0 then c.cliente else f.fletero end end as Origen, case when fp.idordenespago = 0 then '' else case when r1.idfleteros = 0 then p.proveedor else f1.fletero end end  as Destino, fs.detalle as 'Forma de Pago', ifnull(b.banco, ' ') as Banco, ifnull(concat(b1.banco, ' ',cb.nrocuenta, ' ',cb.descripcion), ' ') as 'Cuenta Banco', ifnull(concat(cast(r.ptoventa as char), '-', cast(r.nro as char)), ' ') as 'Talon-Recibo',  ifnull(concat(cast(r1.ptoventa as char), '-',cast(r1.nro as char)), ' ') as 'Talon-Orden de Pago', fp.comentarios as Comentario, fp.idformasdepago as id from formasdepago fp left join bancos b on fp.idbancos = b.idbancos left join cuentasbanco cb on fp.idcuentasbanco = cb.idcuentasbanco left join bancos b1 on cb.idbancos = b1.idbancos left join recibos r on fp.idrecibos = r.idrecibos left join recibos r1 on fp.idordenespago = r1.idrecibos left join clientes c on r.idclientes = c.idclientes left join fleteros f on r.idfleteros = f.idfleteros left join fleteros f1 on r1.idfleteros = f1.idfleteros left join proveedores p on r1.idproveedores = p.idproveedores left join estadoscheques e on fp.idestadoscheques = e.idestadoscheques left join formaspago fs on fp.idformaspago = fs.idformaspago where fp.idformaspago = '" + tipoc + "' " + where);
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                cmbEstados.Enabled = true;
            }
            else
            {
                cmbEstados.Enabled = false;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Funciones f = new Funciones();
                if (f.acceder(36, idusuario))
                {
                    int filaseleccionada = Convert.ToInt32(this.dataGridView1.CurrentRow.Index);
                    int idfp = Convert.ToInt32(dataGridView1[13, filaseleccionada].Value);
                    if (txtEstado.Text == "En cartera")
                    {
                        DialogResult dialogResult = MessageBox.Show("Esta seguro de depositar el cheque: " + txtnro.Text + " con importe: $" + txtimporte.Text, "Depositar Cheque", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            frmDepositoCheque frm = new frmDepositoCheque(idfp, txtnro.Text, txtBanco.Text, txtimporte.Text, txtfechadep.Text);
                            frm.ShowDialog();
                            button4_Click(sender, e);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El estado del cheque no permite deposito");
                    }
                }
                else
                {
                    if (idusuario == 0)
                    {
                        MessageBox.Show("Debe iniciar sesion para acceder");
                    }
                    else
                    {
                        MessageBox.Show("Imposible acceder: usuario sin acceso");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
