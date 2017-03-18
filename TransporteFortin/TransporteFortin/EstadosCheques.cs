using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class EstadosCheques
    {
        int idestadoscheques;

        public int Idestadoscheques
        {
            get { return idestadoscheques; }
            set { idestadoscheques = value; }
        }

        string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public EstadosCheques(int i, string d)
        {
            idestadoscheques = i;
            descripcion = d;
        }
    }
}
