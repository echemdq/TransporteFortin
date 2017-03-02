using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class AccesosUsuarios
    {
        int idaccesosusuarios;

        public int Idaccesosusuarios
        {
            get { return idaccesosusuarios; }
            set { idaccesosusuarios = value; }
        }
        Usuarios usuarios;

        public Usuarios Usuarios
        {
            get { return usuarios; }
            set { usuarios = value; }
        }
        Accesos accesos;

        public Accesos Accesos
        {
            get { return accesos; }
            set { accesos = value; }
        }

        public AccesosUsuarios(int i, Usuarios u, Accesos a)
        {
            idaccesosusuarios = i;
            usuarios = u;
            accesos = a;
        }
    }
}
