using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TransporteFortin
{
    public class BdCtaCteFleteros : IDAO<CtaCteFleteros>
    {
        Acceso_BD oacceso = new Acceso_BD();

        public void Agregar(CtaCteFleteros dato)
        {
            throw new NotImplementedException();
        }

        public List<CtaCteFleteros> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public void Borrar(CtaCteFleteros dato)
        {
            throw new NotImplementedException();
        }

        public CtaCteFleteros Buscar(string dato)
        {
            throw new NotImplementedException();
        }

        public List<CtaCteFleteros> BuscarEspecial(string dato)
        {
            DataTable dt = oacceso.leerDatos("select f.fecha, c.descripcion as concepto, f.descripcion as descripcion, f.ptoventa, ifnull(o.nrocarga,0) as nrocarga, debe, haber from ctactefleteros f inner join conceptos c on f.idconceptos = c.codigo left join ordenescarga o on f.idordenescarga = o.idordenescarga where " + dato + "");
            List<CtaCteFleteros> lista = new List<CtaCteFleteros>();
            foreach (DataRow dr in dt.Rows)
            {
                Conceptos c = new Conceptos(0, Convert.ToString(dr["concepto"]));
                OrdenesCarga o = new OrdenesCarga(0,Convert.ToInt32(dr["nrocarga"]),0,0,DateTime.Now,null,null,null,null,"","","","",0,0,null,0,0,0,"",0,0,0,0,0,0,0,"",0,null);
                CtaCteFleteros cf = new CtaCteFleteros(0,null,null,Convert.ToDateTime(dr["fecha"]),DateTime.Now,c,Convert.ToString(dr["descripcion"]),Convert.ToInt32(dr["ptoventa"]), o, Convert.ToDecimal(Convert.ToString(dr["debe"]).Replace('.',',')), Convert.ToDecimal(Convert.ToString(dr["haber"]).Replace('.',',')),null);
                lista.Add(cf);
            }
            return lista;
        }

        public void Modificar(CtaCteFleteros dato)
        {
            throw new NotImplementedException();
        }

        public int traerSigID()
        {
            throw new NotImplementedException();
        }
    }
}
