using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class FormasDePago
    {
        int idformasdepago;

        public int Idformasdepago
        {
            get { return idformasdepago; }
            set { idformasdepago = value; }
        }

        decimal importe;

        public decimal Importe
        {
            get { return importe; }
            set { importe = value; }
        }

        int idbanco;

        public int Idbanco
        {
            get { return idbanco; }
            set { idbanco = value; }
        }

        int idcuentabanco;

        public int Idcuentabanco
        {
            get { return idcuentabanco; }
            set { idcuentabanco = value; }
        }

        DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        string nrocheque;

        public string Nrocheque
        {
            get { return nrocheque; }
            set { nrocheque = value; }
        }

        string comentario;

        public string Comentario
        {
            get { return comentario; }
            set { comentario = value; }
        }

        int idformaspago;

        public int Idformaspago
        {
            get { return idformaspago; }
            set { idformaspago = value; }
        }

        int idordenpago;

        public int Idordenpago
        {
            get { return idordenpago; }
            set { idordenpago = value; }
        }

        int idrecibo;

        public int Idrecibo
        {
            get { return idrecibo; }
            set { idrecibo = value; }
        }

        public FormasDePago(int i, decimal im, int idb, int idc, DateTime f, string nro, string com, int idf, int ido, int idr)
        {
            idformasdepago = i;
            importe = im;
            idbanco = idb;
            idcuentabanco = idc;
            fecha = f;
            nrocheque = nro;
            comentario = com;
            idformaspago = idf;
            idordenpago = ido;
            idrecibo = idr;
        }
    }
}
