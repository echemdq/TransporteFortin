using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class CtaCteProveedores
    {
        int idctacteproveedores;

        public int Idctacteproveedores
        {
            get { return idctacteproveedores; }
            set { idctacteproveedores = value; }
        }

        Proveedores proveedores;

        public Proveedores Proveedores
        {
            get { return proveedores; }
            set { proveedores = value; }
        }

        OrdenesCombustible ordenescomb;

        public OrdenesCombustible Ordenescomb
        {
            get { return ordenescomb; }
            set { ordenescomb = value; }
        }

        Recibos recibos;

        public Recibos Recibos
        {
            get { return recibos; }
            set { recibos = value; }
        }

        DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
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

        int ptoventa;

        public int Ptoventa
        {
            get { return ptoventa; }
            set { ptoventa = value; }
        }

        public CtaCteProveedores(int i, Proveedores p, OrdenesCombustible o, Recibos r, DateTime f, Conceptos cp, string d, decimal de, decimal ha, int pv)
        {
            ptoventa = pv;
            idctacteproveedores = i;
            proveedores = p;
            ordenescomb = o;
            recibos = r;
            fecha = f;
            conceptos = cp;
            descripcion = d;
            debe = de;
            haber = ha;            
        }
    }
}
