using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class Bancos
    {
        int idbancos;

        public int Idbancos
        {
            get { return idbancos; }
            set { idbancos = value; }
        }

        string banco;

        public string Banco
        {
            get { return banco; }
            set { banco = value; }
        }

        public Bancos(int i, string b)
        {
            idbancos = i;
            banco = b;
        }
    }
}
