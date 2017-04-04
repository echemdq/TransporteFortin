using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class FormasPago
    {
        int idformaspago;

        public int Idformaspago
        {
            get { return idformaspago; }
            set { idformaspago = value; }
        }

        string detalle;

        public string Detalle
        {
            get { return detalle; }
            set { detalle = value; }
        }

        public FormasPago(int i, string d)
        {
            idformaspago = i;
            detalle = d;
        }
    }
}
