﻿using System;
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
        public frmCheques()
        {
            InitializeComponent();
        }

        private void frmCheques_Load(object sender, EventArgs e)
        {
            Acceso_BD oa = new Acceso_BD();
            dataGridView1.DataSource = oa.leerDatos("select date_format(fp.fechaentrega,'%d/%m/%Y') as 'Fecha Emision', date_format(fp.fechadeposito,'%d/%m/%Y') as 'Fecha Deposito', case when fp.idrecibos = 0 then '' else case when r.idfleteros = 0 then c.cliente else f.fletero end end as Origen, case when fp.idordenespago = 0 then '' else case when r1.idfleteros = 0 then p.proveedor else f1.fletero end end  as Destino, e.estado as 'Estado Cheque',cheque as 'Nro Cheque', fp.importe as Importe, fs.detalle as 'Forma de Pago', ifnull(b.banco, ' ') as Banco, ifnull(concat(b1.banco, ' ',cb.nrocuenta, ' ',cb.descripcion), ' ') as 'Cuenta Banco', ifnull(concat(cast(r.ptoventa as char), '-', cast(r.nro as char)), ' ') as 'Talon-Recibo',  ifnull(concat(cast(r1.ptoventa as char), '-',cast(r1.nro as char)), ' ') as 'Talon-Orden de Pago', fp.comentarios as Comentario from formasdepago fp left join bancos b on fp.idbancos = b.idbancos left join cuentasbanco cb on fp.idcuentasbanco = cb.idcuentasbanco left join bancos b1 on cb.idbancos = b1.idbancos left join recibos r on fp.idrecibos = r.idrecibos left join recibos r1 on fp.idordenespago = r1.idrecibos left join clientes c on r.idclientes = c.idclientes left join fleteros f on r.idfleteros = f.idfleteros left join fleteros f1 on r1.idfleteros = f1.idfleteros left join proveedores p on r1.idproveedores = p.idproveedores left join estadoscheques e on fp.idestadoscheques = e.idestadoscheques left join formaspago fs on fp.idformaspago = fs.idformaspago where fp.idformaspago = 2 or fp.idformaspago = 3");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
