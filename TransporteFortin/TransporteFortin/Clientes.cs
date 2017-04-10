using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class Clientes
    {
        int idclientes;

        public int Idclientes
        {
            get { return idclientes; }
            set { idclientes = value; }
        }
        string cliente;

        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; }
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
        string cp;

        public string Cp
        {
            get { return cp; }
            set { cp = value; }
        }
        string telefono;

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        string celular;

        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }
        string fax;

        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }
        string mail;

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        string contacto;

        public string Contacto
        {
            get { return contacto; }
            set { contacto = value; }
        }
        string cuit;

        public string Cuit
        {
            get { return cuit; }
            set { cuit = value; }
        }
        string comentario;

        public string Comentario
        {
            get { return comentario; }
            set { comentario = value; }
        }
        TiposIVA tiposIVA;

        public TiposIVA TiposIVA
        {
            get { return tiposIVA; }
            set { tiposIVA = value; }
        }



        public Clientes(int i, string c, string d, string l, string cp1, string t, string cel, string f, string m, string cont, string cu, TiposIVA ti, string com)
        {
            idclientes = i;
            cliente = c;
            direccion = d;
            localidad = l;
            cp = cp1;
            telefono = t;
            celular = cel;
            fax = f;
            mail = m;
            contacto = cont;
            cuit = cu;
            tiposIVA = ti;
            comentario = com;
        }

    }
}
