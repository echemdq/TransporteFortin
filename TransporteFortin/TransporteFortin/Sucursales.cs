using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class Sucursales
    {
        int idsucursales;

        public int Idsucursales
        {
            get { return idsucursales; }
            set { idsucursales = value; }
        }
        string sucursal;

        public string Sucursal
        {
            get { return sucursal; }
            set { sucursal = value; }
        }

        public Sucursales(int i, string s)
        {
            idsucursales = i;
            sucursal = s;
        }
    }
}
