using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class Fleteros
    {
        int idfleteros;
        int documento;
        string fletero;
        string direccion;
        string localidad;
        string cp;
        string telefono;
        string celular;
        string fax;
        string mail;
        Empresas empresas;
        string camion;
        TiposCamion tiposcamion;
        string chapacamion;
        string chapaacoplado;

        public Fleteros(int i, int d, string f, string dir, string l, string cp1, string t, string c, string fa, string m, Empresas e, string cam, TiposCamion tc, string chc, string cha)
        {
            idfleteros = i;
            documento = d;
            fletero = f;
            direccion = dir;
            localidad = l;
            cp = cp1;
            telefono = t;
            celular = c;
            fax = fa;
            mail = m;
            empresas = e;
            camion = cam;
            tiposcamion = tc;
            chapacamion = chc;
            chapaacoplado = cha;
        }
    }
}
