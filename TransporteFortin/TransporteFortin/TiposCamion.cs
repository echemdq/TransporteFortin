using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class TiposCamion
    {
        int idtiposcamion;

        public int Idtiposcamion
        {
            get { return idtiposcamion; }
            set { idtiposcamion = value; }
        }
        string detalle;

        public string Detalle
        {
            get { return detalle; }
            set { detalle = value; }
        }

        public TiposCamion(int i, string d)
        {
            idtiposcamion = i;
            detalle = d;
        }
    }
}
