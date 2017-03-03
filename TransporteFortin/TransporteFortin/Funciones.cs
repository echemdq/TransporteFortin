using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TransporteFortin
{
    public class Funciones
    {
        Acceso_BD oacceso = new Acceso_BD();
        public bool acceder(int a, int u)
        {
            DataTable dt = oacceso.leerDatos("select ifnull(1,0) as ok from accesosusuario where idusuarios = '" + u + "' and idaccesos = '" + a + "'");
            int x = 0;
            foreach (DataRow dr in dt.Rows)
            {
                
                if (Convert.ToInt32(dr["ok"]) == 1)
                {
                    x = 1;
                }
                else
                {
                    x = 0;
                }
            }
            if (x == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
