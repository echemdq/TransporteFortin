using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class CuentasBanco
    {
        int idcuentasbanco;

        public int Idcuentasbanco
        {
            get { return idcuentasbanco; }
            set { idcuentasbanco = value; }
        }

        Bancos bancos;

        public Bancos Bancos
        {
            get { return bancos; }
            set { bancos = value; }
        }

        string nrocuenta;

        public string Nrocuenta
        {
            get { return nrocuenta; }
            set { nrocuenta = value; }
        }

        string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public CuentasBanco(int i, Bancos b, string n, string d)
        {
            idcuentasbanco = i;
            bancos = b;
            nrocuenta = n;
            descripcion = d;
        }
    }
}
