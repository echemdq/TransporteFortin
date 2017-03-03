using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace TransporteFortin
{
    public class BdUsuarios : IDAO<Usuarios>
    {
        Acceso_BD oacceso = new Acceso_BD();
        public void Agregar(Usuarios dato)
        {
            throw new NotImplementedException();
        }

        public List<Usuarios> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public void Borrar(Usuarios dato)
        {
            throw new NotImplementedException();
        }

        public Usuarios Buscar(string dato)
        {
            throw new NotImplementedException();
        }

        public List<Usuarios> BuscarEspecial(string dato)
        {
            DataTable dt = oacceso.leerDatos("select * from usuarios where usuario" + dato);
            List<Usuarios> list = new List<Usuarios>();
            foreach (DataRow dr in dt.Rows)
            {
                Usuarios u = new Usuarios(Convert.ToInt32(dr["idusuarios"]), Convert.ToString(dr["usuario"]), Convert.ToString(dr["contrasena"]));
                list.Add(u);
            }
            return list;
        }

        public void Modificar(Usuarios dato)
        {
            throw new NotImplementedException();
        }

        public int traerSigID()
        {
            throw new NotImplementedException();
        }
    }
}
