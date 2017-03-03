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
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
            //listBox1.Items.AddRange(new object[] { "one", "two", "three" });
            listBox1.MouseDown += new MouseEventHandler(listBox1_MouseDown);
            listBox1.MouseMove += new MouseEventHandler(listBox1_MouseMove);
            listBox2.AllowDrop = true;
            listBox2.DragEnter += new DragEventHandler(listBox2_DragEnter);
            listBox2.DragDrop += new DragEventHandler(listBox2_DragDrop);

            listBox2.MouseDown += new MouseEventHandler(listBox2_MouseDown);
            listBox2.MouseMove += new MouseEventHandler(listBox2_MouseMove);
            listBox1.AllowDrop = true;
            listBox1.DragEnter += new DragEventHandler(listBox1_DragEnter);
            listBox1.DragDrop += new DragEventHandler(listBox1_DragDrop);
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            Acceso_BD oacceso = new Acceso_BD();
            DataTable dt = oacceso.leerDatos("select a.idaccesos, a.acceso, ifnull(au.idaccesosusuario,0) as idaccesosusuario, ifnull(au.idusuarios,0) as idusuarios from accesos a left join accesosusuario au on a.idaccesos = au.idaccesos");
            List<AccesosUsuarios> listat1 = new List<AccesosUsuarios>();
            foreach (DataRow dr in dt.Rows)
            {
                Accesos a = new Accesos(Convert.ToInt32(dr["idaccesos"]), Convert.ToString(dr["acceso"]));
                Usuarios u = new Usuarios(Convert.ToInt32(dr["idusuarios"]), "", "");
                AccesosUsuarios t = new AccesosUsuarios(Convert.ToInt32(dr["idaccesosusuario"]), u, a);
                listat1.Add(t);
                listBox1.Items.Add(t.Accesos.Acceso);
            }
        }

        public void limpiar()
        {
            txtPassword.Text = "";
            txtUsuario.Text = "";
            lblUsuario.Text = "";
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }

        public void deshabilitar()
        {
            txtPassword.Enabled = false;
            txtUsuario.Enabled = false;
            listBox1.Enabled = false;
            listBox2.Enabled = false;
        }

        public void habilitar()
        {
            txtPassword.Enabled = true;
            txtUsuario.Enabled = true;
            listBox1.Enabled = true;
            listBox2.Enabled = true;
        }

        private Point mDownPos;
        void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mDownPos = e.Location;
        }
        void listBox2_MouseDown(object sender, MouseEventArgs e)
        {
            mDownPos = e.Location;
        }
        void listBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            int index = listBox1.IndexFromPoint(e.Location);
            if (index < 0) return;
            if (Math.Abs(e.X - mDownPos.X) >= SystemInformation.DragSize.Width ||
                Math.Abs(e.Y - mDownPos.Y) >= SystemInformation.DragSize.Height)
                DoDragDrop(new DragObject(listBox1, listBox1.Items[index]), DragDropEffects.Move);
        }

        void listBox2_DragEnter(object sender, DragEventArgs e)
        {
            DragObject obj = e.Data.GetData(typeof(DragObject)) as DragObject;
            if (obj != null && obj.source != listBox2) e.Effect = e.AllowedEffect;
        }
        void listBox2_DragDrop(object sender, DragEventArgs e)
        {
            DragObject obj = e.Data.GetData(typeof(DragObject)) as DragObject;
            listBox2.Items.Add(obj.item);
            obj.source.Items.Remove(obj.item);
        }

        void listBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            int index = listBox2.IndexFromPoint(e.Location);
            if (index < 0) return;
            if (Math.Abs(e.X - mDownPos.X) >= SystemInformation.DragSize.Width ||
                Math.Abs(e.Y - mDownPos.Y) >= SystemInformation.DragSize.Height)
                DoDragDrop(new DragObject(listBox2, listBox2.Items[index]), DragDropEffects.Move);
        }

        void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            DragObject obj = e.Data.GetData(typeof(DragObject)) as DragObject;
            if (obj != null && obj.source != listBox1) e.Effect = e.AllowedEffect;
        }
        void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            DragObject obj = e.Data.GetData(typeof(DragObject)) as DragObject;
            listBox1.Items.Add(obj.item);
            obj.source.Items.Remove(obj.item);
        }

        private class DragObject
        {
            public ListBox source;
            public object item;
            public DragObject(ListBox box, object data) { source = box; item = data; }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiar();
                deshabilitar();
                frmBuscaUsuarios frm = new frmBuscaUsuarios();
                frm.ShowDialog();
                Usuarios us = frm.u;
                if (us != null)
                {
                    txtUsuario.Text = us.Usuario;
                    lblUsuario.Text = us.Idusuarios.ToString();
                    txtPassword.Text = us.Password;

                    Acceso_BD oacceso = new Acceso_BD();
                    DataTable dt = oacceso.leerDatos("select a.idaccesos, a.acceso, ifnull(au.idaccesosusuario,0) as idaccesosusuario, ifnull(au.idusuarios,0) as idusuarios from accesos a left join accesosusuario au on a.idaccesos = au.idaccesos and au.idusuarios = '"+us.Idusuarios+"'");
                    List<AccesosUsuarios> listat1 = new List<AccesosUsuarios>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Accesos a = new Accesos(Convert.ToInt32(dr["idaccesos"]), Convert.ToString(dr["acceso"]));
                        Usuarios u = new Usuarios(Convert.ToInt32(dr["idusuarios"]), "", "");
                        AccesosUsuarios t = new AccesosUsuarios(Convert.ToInt32(dr["idaccesosusuario"]), u, a);
                        listat1.Add(t);
                        if (t.Idaccesosusuarios == 0)
                        {
                            listBox1.Items.Add(t.Accesos.Acceso);
                        }
                        else
                        {
                            listBox2.Items.Add(t.Accesos.Acceso);
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            habilitar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
            deshabilitar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (lblUsuario.Text != "")
            {
                habilitar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblUsuario.Text != "")
                {
                    Usuarios u = new Usuarios(Convert.ToInt32(lblUsuario.Text), "", "");
                    DialogResult dialogResult = MessageBox.Show("Esta seguro de eliminar el Usuario: " + txtUsuario.Text, "Eliminar Usuario", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //controlc.Borrar(c);
                        Acceso_BD oacceso = new Acceso_BD();
                        oacceso.ActualizarBD("begin; delete from accesosusuario where idusuarios='" + lblUsuario.Text + "'; delete from usuarios where idusuarios = '" + lblUsuario.Text + "'; commit;");
                        limpiar();
                        deshabilitar();
                        MessageBox.Show("Usuario eliminado correctamente");
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un Usuario para eliminarlo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Eliminar: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsuario.Text != "")
                {
                    //Clientes r = new Clientes(0, txtCliente.Text, txtDomicilio.Text, txtLocalidad.Text, Convert.ToInt32(txtCP.Text), txtTelefono.Text, txtCelular.Text, txtFax.Text, txtMail.Text, txtContacto.Text, maskedTextBox1.Text, tipoiva, txtComentarios.Text);
                    if (lblUsuario.Text == "")
                    {
                        //controlc.Agregar(r);
                        Acceso_BD oacceso = new Acceso_BD();
                        List<AccesosUsuarios> lista = new List<AccesosUsuarios>();
                        foreach (var listBoxItem in listBox2.Items)
                        {
                            Accesos a = new Accesos(0, listBox2.Items.ToString());
                            AccesosUsuarios au = new AccesosUsuarios(0, null, a);
                            lista.Add(au);
                        }
                        MessageBox.Show("Usuario guardado correctamente");
                    }
                    else
                    {
                        //r.Idclientes = Convert.ToInt32(lblId.Text);
                        //controlu.Modificar(r);
                        MessageBox.Show("Cliente modificado correctamente");
                    }
                    limpiar();
                    deshabilitar();
                }
                else
                {
                    MessageBox.Show("Debe completar el nombre y apellido del Cliente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar: " + ex.Message);
            }
        }
    }
}
