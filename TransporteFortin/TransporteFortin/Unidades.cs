using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class Unidades
    {
        int idunidades;

        public int Idunidades
        {
            get { return idunidades; }
            set { idunidades = value; }
        }
        string detalle;

        public string Detalle
        {
            get { return detalle; }
            set { detalle = value; }
        }

        public Unidades(int i, string d)
        {
            idunidades = i;
            detalle = d;
        }
    }
}
