using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class Empresas
    {
        int idempresas;

        public int Idempresas
        {
            get { return idempresas; }
            set { idempresas = value; }
        }
        string empresa;

        public string Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }
        string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        string localidad;

        public string Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }
        string telefono;

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        string telefono2;

        public string Telefono2
        {
            get { return telefono2; }
            set { telefono2 = value; }
        }
        string celular;

        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }
        string mail;

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        string comentario;

        public string Comentario
        {
            get { return comentario; }
            set { comentario = value; }
        }

        public Empresas(int i, string e, string d, string l, string t, string t2, string c, string m, string com)
        {
            idempresas = i;
            empresa = e;
            direccion = d;
            localidad = l;
            telefono = t;
            telefono2 = t2;
            celular = c;
            mail = m;
            comentario = com;
        }
    }
}
