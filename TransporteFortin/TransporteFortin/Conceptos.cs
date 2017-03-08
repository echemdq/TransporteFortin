using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class Conceptos
    {
        int idconceptos;

        public int Idconceptos
        {
            get { return idconceptos; }
            set { idconceptos = value; }
        }
        string concepto;

        public string Concepto
        {
            get { return concepto; }
            set { concepto = value; }
        }

        public Conceptos(int i, string c)
        {
            idconceptos = i;
            concepto = c;
        }
    }
}
