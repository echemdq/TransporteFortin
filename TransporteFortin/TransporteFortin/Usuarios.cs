using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class Usuarios
    {
        int idusuarios;

        public int Idusuarios
        {
            get { return idusuarios; }
            set { idusuarios = value; }
        }

        string usuario;

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public Usuarios(int i, string u, string p)
        {
            idusuarios = i;
            usuario = u;
            password = p;
        }

    }
}
