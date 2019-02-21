using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TransporteFortin
{
    public class BdCtaCteProveedores : IDAO<CtaCteProveedores>
    {
        Acceso_BD oacceso = new Acceso_BD();
        public void Agregar(CtaCteProveedores dato)
        {
            throw new NotImplementedException();
        }

        public List<CtaCteProveedores> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public void Borrar(CtaCteProveedores dato)
        {
            throw new NotImplementedException();
        }

        public CtaCteProveedores Buscar(string dato)
        {
            throw new NotImplementedException();
        }

        public List<CtaCteProveedores> BuscarEspecial(string dato)
        {
            DataTable dt = oacceso.leerDatos("select f.idctacteproveedores as id, f.fecha, c.descripcion as concepto, f.descripcion as descripcion, f.ptoventa, debe, haber, case when o.nro is not null then concat(cast(o.nro as char), '- Ordenes de Combustible') else case when r.nro is not null and r.tipo = 0 then concat(cast(r.nro as char), '- Recibo') else case when r.nro is not null and r.tipo = 1 then concat(cast(r.nro as char), '- Orden de Pago') end end end as nrocarga  from ctacteproveedores f inner join conceptos c on f.idconceptos = c.codigo left join ordenescombustible o on f.idordenescombustible = o.idordenescombustible left join recibos r on r.idrecibos = f.idrecibos where f.idproveedores = '" + dato + "' order by f.fecha, f.idctacteproveedores");
            List<CtaCteProveedores> lista = new List<CtaCteProveedores>();
            foreach (DataRow dr in dt.Rows)
            {
                Conceptos c = new Conceptos(0, Convert.ToString(dr["concepto"]),"");
                OrdenesCombustible o = new OrdenesCombustible(0, Convert.ToString(dr["nrocarga"]), DateTime.Now, null, null, 0, 0, 0);
                CtaCteProveedores cp = new CtaCteProveedores(Convert.ToInt32(dr["id"]), null, o, null, Convert.ToDateTime(dr["fecha"]), c, Convert.ToString(dr["descripcion"]), Convert.ToDecimal(dr["debe"]), Convert.ToDecimal(dr["haber"]), Convert.ToInt32(dr["ptoventa"]));                 
                lista.Add(cp);
            }
            return lista;
        }

        public void Modificar(CtaCteProveedores dato)
        {
            throw new NotImplementedException();
        }

        public int traerSigID()
        {
            throw new NotImplementedException();
        }
    }
}
