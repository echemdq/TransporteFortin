using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TransporteFortin
{
    public class BdCtaCteClientes : IDAO<CtaCteClientes>
    {
        Acceso_BD oacceso = new Acceso_BD();
        public void Agregar(CtaCteClientes dato)
        {
            throw new NotImplementedException();
        }

        public List<CtaCteClientes> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public void Borrar(CtaCteClientes dato)
        {
            throw new NotImplementedException();
        }

        public CtaCteClientes Buscar(string dato)
        {
            throw new NotImplementedException();
        }

        public List<CtaCteClientes> BuscarEspecial(string dato)
        {
            DataTable dt = oacceso.leerDatos("select f.idctacteclientes as idc, f.fecha, case when f.idrecibos = 0 then c.descripcion else cc.descripcion end as concepto , f.descripcion as descripcion, f.ptoventa, debe, haber, case when o.nrocarga is not null then concat(cast(o.nrocarga as char), '- Ordenes de Carga') else concat(cast(r.nro as char), '- Recibo') end  as nrocarga from ctacteclientes f inner join conceptos c on f.idconceptos = c.codigo left join conceptoscc cc on f.idconceptos = cc.idconceptoscc left join ordenescarga o on f.idordenescarga = o.idordenescarga left join recibos r on r.idrecibos = f.idrecibos where f.idclientes = '" + dato + "'");
            List<CtaCteClientes> lista = new List<CtaCteClientes>();
            foreach (DataRow dr in dt.Rows)
            {
                Conceptos c = new Conceptos(0, Convert.ToString(dr["concepto"]),"");
                OrdenesCarga o = new OrdenesCarga(0, Convert.ToString(dr["nrocarga"]), 0, 0, DateTime.Now, null, null, null, null, "", "", "", "", 0, 0, null, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, "", 0, null,"");
                CtaCteClientes cp = new CtaCteClientes(Convert.ToInt32(dr["idc"]), null, c, Convert.ToString(dr["descripcion"]), Convert.ToInt32(dr["ptoventa"]), o, Convert.ToDecimal(dr["debe"]), Convert.ToDecimal(dr["haber"]), Convert.ToDateTime(dr["fecha"]), null);
                lista.Add(cp);
            }
            return lista;
        }

        public void Modificar(CtaCteClientes dato)
        {
            throw new NotImplementedException();
        }

        public int traerSigID()
        {
            throw new NotImplementedException();
        }
    }
}
