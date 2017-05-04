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

        string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public EstadosCheques(int i, string d)
        {
            idestadoscheques = i;
            estado = d;
        }
    }
}
