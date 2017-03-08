using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class CtaCteFleteros
    {
        int idctactefleteros;

        public int Idctactefleteros
        {
            get { return idctactefleteros; }
            set { idctactefleteros = value; }
        }
        Fleteros fleteros;

        public Fleteros Fleteros
        {
            get { return fleteros; }
            set { fleteros = value; }
        }
        Empresas empresas;

        public Empresas Empresas
        {
            get { return empresas; }
            set { empresas = value; }
        }
        DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        DateTime fecactual;

        public DateTime Fecactual
        {
            get { return fecactual; }
            set { fecactual = value; }
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
        Recibos recibos;

        public Recibos Recibos
        {
            get { return recibos; }
            set { recibos = value; }
        }

        public CtaCteFleteros(int i, Fleteros f, Empresas e, DateTime fe, DateTime fea, Conceptos c, string d, int p, OrdenesCarga o, decimal de, decimal ha, Recibos r)
        {
            idctactefleteros = i;
            fleteros = f;
            empresas = e;
            fecha = fe;
            fecactual = fea;
            conceptos = c;
            descripcion = d;
            ptoventa = p;
            ordenescarga = o;
            debe = de;
            haber = ha;
            recibos = r;
        }
    }
}
