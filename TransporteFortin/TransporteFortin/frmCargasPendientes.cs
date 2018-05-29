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
    public partial class frmCargasPendientes : Form
    {
        Acceso_BD oacceso = new Acceso_BD();
        int i = 0;
        int idu = 0;
        public frmCargasPendientes(int idusuario)
        {
            idu = idusuario;
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (radioButton1.Checked)
            {

                DataTable dt = oacceso.leerDatos("select ifnull(cv.idcargaspendientesv, 0) as visto, c.idcargaspendientes as id, e.empresa as empresa, c.origen as origen, c.destino as destino, c.observaciones as obs, CASE    WHEN c.estado = 0 THEN 'Pendiente'    WHEN c.estado = 1 THEN 'Tomado'    ELSE 'Anulado' END as estado, u.usuario as creador, u1.usuario as tomador, c.fechac as fechac, c.fechar as fechar from cargaspendientes c left join cargaspendientesv cv on c.idcargaspendientes = cv.idcargaspendientes and cv.idusuarios = " + idu + " left join empresas e on c.idempresas = e.idempresas left join usuarios u on c.creador = u.idusuarios left join usuarios u1 on c.tomador = u1.idusuarios where c.estado = 0 order by c.idcargaspendientes desc");
                i = dt.Rows.Count;
                int x = 0;
                if (i > 0)
                {
                    dataGridView1.Rows.Add(i);
                    foreach (DataRow dr in dt.Rows)
                    {
                        dataGridView1.Rows[x].Cells[0].Value = Convert.ToInt32(dr["id"]);
                        dataGridView1.Rows[x].Cells[1].Value = Convert.ToString(dr["empresa"]);
                        dataGridView1.Rows[x].Cells[2].Value = Convert.ToString(dr["origen"]);
                        dataGridView1.Rows[x].Cells[3].Value = Convert.ToString(dr["destino"]);
                        dataGridView1.Rows[x].Cells[4].Value = Convert.ToString(dr["obs"]);
                        dataGridView1.Rows[x].Cells[5].Value = Convert.ToString(dr["creador"]);
                        dataGridView1.Rows[x].Cells[6].Value = Convert.ToString(dr["tomador"]);
                        dataGridView1.Rows[x].Cells[7].Value = Convert.ToString(dr["fechac"]);
                        dataGridView1.Rows[x].Cells[8].Value = Convert.ToString(dr["fechar"]);
                        dataGridView1.Rows[x].Cells[9].Value = Convert.ToString(dr["estado"]);
                        dataGridView1.Rows[x].Cells[10].Value = Convert.ToString(dr["visto"]);
                        x++;
                    }
                }
            }
            else if (radioButton2.Checked)
            {
                DataTable dt = oacceso.leerDatos("select ifnull(cv.idcargaspendientesv, 0) as visto, c.idcargaspendientes as id, e.empresa as empresa, c.origen as origen, c.destino as destino, c.observaciones as obs, CASE    WHEN c.estado = 0 THEN 'Pendiente'    WHEN c.estado = 1 THEN 'Tomado'    ELSE 'Anulado' END as estado, u.usuario as creador, u1.usuario as tomador, c.fechac as fechac, c.fechar as fechar from cargaspendientes c left join cargaspendientesv cv on c.idcargaspendientes = cv.idcargaspendientes and cv.idusuarios = " + idu + " left join empresas e on c.idempresas = e.idempresas left join usuarios u on c.creador = u.idusuarios left join usuarios u1 on c.tomador = u1.idusuarios where c.estado = 1 order by c.idcargaspendientes desc");
                i = dt.Rows.Count;
                int x = 0;
                if (i > 0)
                {
                    dataGridView1.Rows.Add(i);
                    foreach (DataRow dr in dt.Rows)
                    {
                        dataGridView1.Rows[x].Cells[0].Value = Convert.ToInt32(dr["id"]);
                        dataGridView1.Rows[x].Cells[1].Value = Convert.ToString(dr["empresa"]);
                        dataGridView1.Rows[x].Cells[2].Value = Convert.ToString(dr["origen"]);
                        dataGridView1.Rows[x].Cells[3].Value = Convert.ToString(dr["destino"]);
                        dataGridView1.Rows[x].Cells[4].Value = Convert.ToString(dr["obs"]);
                        dataGridView1.Rows[x].Cells[5].Value = Convert.ToString(dr["creador"]);
                        dataGridView1.Rows[x].Cells[6].Value = Convert.ToString(dr["tomador"]);
                        dataGridView1.Rows[x].Cells[7].Value = Convert.ToString(dr["fechac"]);
                        dataGridView1.Rows[x].Cells[8].Value = Convert.ToString(dr["fechar"]);
                        dataGridView1.Rows[x].Cells[9].Value = Convert.ToString(dr["estado"]);
                        dataGridView1.Rows[x].Cells[10].Value = Convert.ToString(dr["visto"]);
                        x++;
                    }
                }
            }
            else if (radioButton3.Checked)
            {
                DataTable dt = oacceso.leerDatos("select ifnull(cv.idcargaspendientesv, 0) as visto, c.idcargaspendientes as id, e.empresa as empresa, c.origen as origen, c.destino as destino, c.observaciones as obs, CASE    WHEN c.estado = 0 THEN 'Pendiente'    WHEN c.estado = 1 THEN 'Tomado'    ELSE 'Anulado' END as estado, u.usuario as creador, u1.usuario as tomador, c.fechac as fechac, c.fechar as fechar from cargaspendientes c left join cargaspendientesv cv on c.idcargaspendientes = cv.idcargaspendientes and cv.idusuarios = " + idu + "  left join empresas e on c.idempresas = e.idempresas left join usuarios u on c.creador = u.idusuarios left join usuarios u1 on c.tomador = u1.idusuarios where c.estado = 2 order by c.idcargaspendientes desc");
                i = dt.Rows.Count;
                int x = 0;
                if (i > 0)
                {
                    dataGridView1.Rows.Add(i);
                    foreach (DataRow dr in dt.Rows)
                    {
                        dataGridView1.Rows[x].Cells[0].Value = Convert.ToInt32(dr["id"]);
                        dataGridView1.Rows[x].Cells[1].Value = Convert.ToString(dr["empresa"]);
                        dataGridView1.Rows[x].Cells[2].Value = Convert.ToString(dr["origen"]);
                        dataGridView1.Rows[x].Cells[3].Value = Convert.ToString(dr["destino"]);
                        dataGridView1.Rows[x].Cells[4].Value = Convert.ToString(dr["obs"]);
                        dataGridView1.Rows[x].Cells[5].Value = Convert.ToString(dr["creador"]);
                        dataGridView1.Rows[x].Cells[6].Value = Convert.ToString(dr["tomador"]);
                        dataGridView1.Rows[x].Cells[7].Value = Convert.ToString(dr["fechac"]);
                        dataGridView1.Rows[x].Cells[8].Value = Convert.ToString(dr["fechar"]);
                        dataGridView1.Rows[x].Cells[9].Value = Convert.ToString(dr["estado"]);
                        dataGridView1.Rows[x].Cells[10].Value = Convert.ToString(dr["visto"]);
                        x++;
                    }
                }
            }
            else if (radioButton4.Checked)
            {
                DataTable dt = oacceso.leerDatos("select ifnull(cv.idcargaspendientesv, 0) as visto, c.idcargaspendientes as id, e.empresa as empresa, c.origen as origen, c.destino as destino, c.observaciones as obs, CASE    WHEN c.estado = 0 THEN 'Pendiente'    WHEN c.estado = 1 THEN 'Tomado'    ELSE 'Anulado' END as estado, u.usuario as creador, u1.usuario as tomador, c.fechac as fechac, c.fechar as fechar from cargaspendientes c left join cargaspendientesv cv on c.idcargaspendientes = cv.idcargaspendientes and cv.idusuarios = " + idu + " left join empresas e on c.idempresas = e.idempresas left join usuarios u on c.creador = u.idusuarios left join usuarios u1 on c.tomador = u1.idusuarios order by c.idcargaspendientes desc");
                i = dt.Rows.Count;
                int x = 0;
                if (i > 0)
                {
                    dataGridView1.Rows.Add(i);
                    foreach (DataRow dr in dt.Rows)
                    {
                        dataGridView1.Rows[x].Cells[0].Value = Convert.ToInt32(dr["id"]);
                        dataGridView1.Rows[x].Cells[1].Value = Convert.ToString(dr["empresa"]);
                        dataGridView1.Rows[x].Cells[2].Value = Convert.ToString(dr["origen"]);
                        dataGridView1.Rows[x].Cells[3].Value = Convert.ToString(dr["destino"]);
                        dataGridView1.Rows[x].Cells[4].Value = Convert.ToString(dr["obs"]);
                        dataGridView1.Rows[x].Cells[5].Value = Convert.ToString(dr["creador"]);
                        dataGridView1.Rows[x].Cells[6].Value = Convert.ToString(dr["tomador"]);
                        dataGridView1.Rows[x].Cells[7].Value = Convert.ToString(dr["fechac"]);
                        dataGridView1.Rows[x].Cells[8].Value = Convert.ToString(dr["fechar"]);
                        dataGridView1.Rows[x].Cells[9].Value = Convert.ToString(dr["estado"]);
                        dataGridView1.Rows[x].Cells[10].Value = Convert.ToString(dr["visto"]);

                        x++;
                    }
                }
            }
        }

        private void frmCargasPendientes_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 11;
            dataGridView1.Columns[0].Name = "idcargaspendientes";
            dataGridView1.Columns[1].Name = "Empresa";
            dataGridView1.Columns[2].Name = "Origen";
            dataGridView1.Columns[3].Name = "Destino";
            dataGridView1.Columns[4].Name = "Observaciones";
            dataGridView1.Columns[5].Name = "Creador";
            dataGridView1.Columns[6].Name = "Tomador";
            dataGridView1.Columns[7].Name = "Fecha Creado";
            dataGridView1.Columns[8].Name = "Fecha Tomado";
            dataGridView1.Columns[9].Name = "Estado";
            dataGridView1.Columns[10].Name = "Visto";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[10].Visible = false;

            DataTable dt = oacceso.leerDatos("select ifnull(cv.idcargaspendientesv, 0) as visto, c.idcargaspendientes as id, e.empresa as empresa, c.origen as origen, c.destino as destino, c.observaciones as obs, CASE    WHEN c.estado = 0 THEN 'Pendiente'    WHEN c.estado = 1 THEN 'Tomado'    ELSE 'Anulado' END as estado, u.usuario as creador, u1.usuario as tomador, c.fechac as fechac, c.fechar as fechar from cargaspendientes c left join cargaspendientesv cv on c.idcargaspendientes = cv.idcargaspendientes and cv.idusuarios = " + idu + " left join empresas e on c.idempresas = e.idempresas left join usuarios u on c.creador = u.idusuarios left join usuarios u1 on c.tomador = u1.idusuarios where c.estado = 0 and cv.idcargaspendientesv is null order by c.idcargaspendientes desc");
            i = dt.Rows.Count;
            int x = 0;
            if (i > 0)
            {
                dataGridView1.Rows.Add(i);
                foreach (DataRow dr in dt.Rows)
                {
                    dataGridView1.Rows[x].Cells[0].Value = Convert.ToInt32(dr["id"]);
                    dataGridView1.Rows[x].Cells[1].Value = Convert.ToString(dr["empresa"]);
                    dataGridView1.Rows[x].Cells[2].Value = Convert.ToString(dr["origen"]);
                    dataGridView1.Rows[x].Cells[3].Value = Convert.ToString(dr["destino"]);
                    dataGridView1.Rows[x].Cells[4].Value = Convert.ToString(dr["obs"]);
                    dataGridView1.Rows[x].Cells[5].Value = Convert.ToString(dr["creador"]);
                    dataGridView1.Rows[x].Cells[6].Value = Convert.ToString(dr["tomador"]);
                    dataGridView1.Rows[x].Cells[7].Value = Convert.ToString(dr["fechac"]);
                    dataGridView1.Rows[x].Cells[8].Value = Convert.ToString(dr["fechar"]);
                    dataGridView1.Rows[x].Cells[9].Value = Convert.ToString(dr["estado"]);
                    dataGridView1.Rows[x].Cells[10].Value = Convert.ToString(dr["visto"]);
                    x++;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    int x = Convert.ToInt32(row.Cells[10].Value);
                    if (x == 0)
                    {
                        oacceso.ActualizarBD("insert into cargaspendientesv (idcargaspendientes, idusuarios) values ("+row.Cells[0].Value+", "+idu+")");
                        i++;
                    }
                }
                if (i > 0)
                {
                    MessageBox.Show("Notificaciones marcadas como vistas satisfactoriamente");
                    dataGridView1.Rows.Clear();
                    button4_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int filaseleccionada = Convert.ToInt32(this.dataGridView1.CurrentRow.Index);
                if (Convert.ToString(dataGridView1[9, filaseleccionada].Value) == "Tomado")
                {
                    
                    string id = Convert.ToString(dataGridView1[0, filaseleccionada].Value);
                    DialogResult dialogResult = MessageBox.Show("Esta seguro de liberar notificacion", "Quita Marca", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        oacceso.ActualizarBD("update cargaspendientes set estado = 0, fechar = NULL, tomador = NULL where idcargaspendientes = '" + id + "'");
                        dataGridView1.Rows.Clear();
                        button4_Click(sender, e);
                    }
                }
                else if (Convert.ToString(dataGridView1[9, filaseleccionada].Value) == "Pendiente")
                {
                    string id = Convert.ToString(dataGridView1[0, filaseleccionada].Value);
                    DialogResult dialogResult = MessageBox.Show("Esta seguro de tomar carga pendiente", "Tomar Carga Pendiente", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        oacceso.ActualizarBD("update cargaspendientes set estado = 1, fechar = now(), tomador = "+idu+" where idcargaspendientes = '" + id + "'");
                        dataGridView1.Rows.Clear();
                        button4_Click(sender, e);
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
