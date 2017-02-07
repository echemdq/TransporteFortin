using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class Fleteros
    {
        int idfleteros;

        public int Idfleteros
        {
            get { return idfleteros; }
            set { idfleteros = value; }
        }
        int documento;

        public int Documento
        {
            get { return documento; }
            set { documento = value; }
        }
        string fletero;

        public string Fletero
        {
            get { return fletero; }
            set { fletero = value; }
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
        Empresas empresas;

        public Empresas Empresas
        {
            get { return empresas; }
            set { empresas = value; }
        }
        string camion;

        public string Camion
        {
            get { return camion; }
            set { camion = value; }
        }
        TiposCamion tiposcamion;

        public TiposCamion Tiposcamion
        {
            get { return tiposcamion; }
            set { tiposcamion = value; }
        }
        string chapacamion;

        public string Chapacamion
        {
            get { return chapacamion; }
            set { chapacamion = value; }
        }
        string chapaacoplado;

        public string Chapaacoplado
        {
            get { return chapaacoplado; }
            set { chapaacoplado = value; }
        }

        public Fleteros(int i, int d, string f, string dir, string l, string cp1, string t, string c, string fa, string m, Empresas e, string cam, TiposCamion tc, string chc, string cha)
        {
            idfleteros = i;
            documento = d;
            fletero = f;
            direccion = dir;
            localidad = l;
            cp = cp1;
            telefono = t;
            celular = c;
            fax = fa;
            mail = m;
            empresas = e;
            camion = cam;
            tiposcamion = tc;
            chapacamion = chc;
            chapaacoplado = cha;
        }
    }
}
