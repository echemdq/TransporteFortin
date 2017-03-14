using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class CtaCteClientes
    {
        int idctacteclientes;

        public int Idctacteclientes
        {
            get { return idctacteclientes; }
            set { idctacteclientes = value; }
        }

        Clientes clientes;

        public Clientes Clientes
        {
            get { return clientes; }
            set { clientes = value; }
        }

        Conceptos conceptos;

        public Conceptos Conceptos
        {
            get { return conceptos; }
            set { conceptos = value; }
        }

        string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        int ptoventa;

        public int Ptoventa
        {
            get { return ptoventa; }
            set { ptoventa = value; }
        }

        OrdenesCarga ordenescarga;

        public OrdenesCarga Ordenescarga
        {
            get { return ordenescarga; }
            set { ordenescarga = value; }
        }

        decimal debe;

        public decimal Debe
        {
            get { return debe; }
            set { debe = value; }
        }

        decimal haber;

        public decimal Haber
        {
            get { return haber; }
            set { haber = value; }
        }

        DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        Recibos recibos;

        public Recibos Recibos
        {
            get { return recibos; }
            set { recibos = value; }
        }

        public CtaCteClientes(int i, Clientes c, Conceptos con, string d, int pt, OrdenesCarga o, decimal de, decimal ha, DateTime fe, Recibos r)
        {
            idctacteclientes = i;
            clientes = c;
            conceptos = con;
            descripcion = d;
            ptoventa = pt;
            ordenescarga = o;
            debe = de;
            haber = ha;
            fecha = fe;
            recibos = r;
        }
    }
}
