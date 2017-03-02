using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class Accesos
    {
        int idaccesos;

        public int Idaccesos
        {
            get { return idaccesos; }
            set { idaccesos = value; }
        }
        string acceso;

        public string Acceso
        {
            get { return acceso; }
            set { acceso = value; }
        }

        public Accesos(int i, string a)
        {
            idaccesos = i;
            acceso = a;
        }
    }
}
