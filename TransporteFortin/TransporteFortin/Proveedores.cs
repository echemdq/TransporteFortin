using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class Proveedores
    {
        int idproveedores;

        public int Idproveedores
        {
            get { return idproveedores; }
            set { idproveedores = value; }
        }
        string proveedor;

        public string Proveedor
        {
            get { return proveedor; }
            set { proveedor = value; }
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
        int cp;

        public int Cp
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
        decimal valor;

        public decimal Valor
        {
            get { return valor; }
            set { valor = value; }
        }


        public Proveedores(int i, string c, string d, string l, int cp1, string t, string cel, string f, string m, string cont, string cu, TiposIVA ti, string com, decimal v)
        {
            idproveedores = i;
            proveedor = c;
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
            valor = v;
        }
    }
}
