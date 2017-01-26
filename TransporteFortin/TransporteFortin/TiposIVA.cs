using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class TiposIVA
    {
        int idTiposIVA;

        public int IdTiposIVA
        {
            get { return idTiposIVA; }
            set { idTiposIVA = value; }
        }
        string detalle;

        public string Detalle
        {
            get { return detalle; }
            set { detalle = value; }
        }
        string tipo;

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public TiposIVA(int i, string d, string t)
        {
            idTiposIVA = i;
            detalle = d;
            tipo = t;
        }
    }
}
