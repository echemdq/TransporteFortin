using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class OrdenesCombustible
    {
        int idordenescombustible;

        public int Idordenescombustible
        {
            get { return idordenescombustible; }
            set { idordenescombustible = value; }
        }

        int nro;

        public int Nro
        {
            get { return nro; }
            set { nro = value; }
        }

        DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        Proveedores proveedores;

        public Proveedores Proveedores
        {
            get { return proveedores; }
            set { proveedores = value; }
        }

        Fleteros fleteros;

        public Fleteros Fleteros
        {
            get { return fleteros; }
            set { fleteros = value; }
        }

        decimal preciocombustible;

        public decimal Preciocombustible
        {
            get { return preciocombustible; }
            set { preciocombustible = value; }
        }

        decimal litros;

        public decimal Litros
        {
            get { return litros; }
            set { litros = value; }
        }

        int ptoventa;

        public int Ptoventa
        {
            get { return ptoventa; }
            set { ptoventa = value; }
        }

        public OrdenesCombustible(int i, int n, DateTime f, Proveedores p, Fleteros fl, decimal pr, decimal l, int pto)
        {
            idordenescombustible = i;
            nro = n;
            fecha = f;
            proveedores = p;
            fleteros = fl;
            preciocombustible = pr;
            litros = l;
            ptoventa = pto;
        }
    }
}
