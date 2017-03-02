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
            DataTable dt = oacceso.leerDatos("select * from acessos order by acceso asc");
            List<Accesos> listat1 = new List<Accesos>();
            foreach (DataRow dr in dt.Rows)
            {
                Accesos t = new Accesos(Convert.ToInt32(dr["idaccesos"]), Convert.ToString(dr["acceso"]));
                listat1.Add(t);
            }

            dt = oacceso.leerDatos("select * from acessosusuario order by acceso asc where idusuarios = 1");
            List<AccesosUsuarios> listat2 = new List<AccesosUsuarios>();
            foreach (DataRow dr in dt.Rows)
            {
                Accesos a = new Accesos(Convert.ToInt32(dr["idaccesos"]), "");
                Usuarios u = new Usuarios(Convert.ToInt32(dr["idusuarios"]), "", "");
                AccesosUsuarios t = new AccesosUsuarios(Convert.ToInt32(dr["idaccesosusuario"]), u, a);
                listat2.Add(t);
            }

            List<Accesos> otorg = new List<Accesos>();
            List<Accesos> disp = new List<Accesos>();

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
    }
}
