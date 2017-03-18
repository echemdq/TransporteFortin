using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class ConceptosCaja
    {
        int idconceptoscaja;

        public int Idconceptoscaja
        {
            get { return idconceptoscaja; }
            set { idconceptoscaja = value; }
        }
        string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        string doc;

        public string Doc
        {
            get { return doc; }
            set { doc = value; }
        }

        public ConceptosCaja(int i, string c, string t)
        {
            idconceptoscaja = i;
            descripcion = c;
            doc = t;
        }
              
    }
}
