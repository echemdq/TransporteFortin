using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace TransporteFortin
{
    public class BdOrdenesCombustible
    {
        Acceso_BD oacceso = new Acceso_BD();
        public string Agregar(OrdenesCombustible dato)
        {
            DataTable dt = new DataTable();
           dt = oacceso.leerDatos("start transaction; update contadores set nro = nro + 1 where detalle = 'ocombustible' and ptoventa = '"+dato.Ptoventa+"'; select nro from contadores where detalle = 'ocombustible' and ptoventa = '"+dato.Ptoventa+"'; commit;");
           string nro = "";
           foreach (DataRow dr in dt.Rows)
           {
               nro = Convert.ToString(dr["nro"]);
           }
           dt = oacceso.leerDatos("begin; insert into ordenescombustible (nro, fecha, idproveedores, idfleteros, preciocombustible, litros, ptoventa) values ('" + nro + "','" + dato.Fecha.ToString("yyyy-MM-dd") + "','" + dato.Proveedores.Idproveedores + "','" + dato.Fleteros.Idfleteros + "','" + dato.Preciocombustible.ToString().Replace(',', '.') + "','" + dato.Litros.ToString().Replace(',', '.') + "','" + dato.Ptoventa + "'); select idordenescombustible from ordenescombustible where nro = '" + nro + "' and ptoventa = '" + dato.Ptoventa + "'; commit;");
           int idoc = 0;
           foreach (DataRow dr in dt.Rows)
           {
               idoc = Convert.ToInt32(dr["idordenescombustible"]);
           }
           oacceso.ActualizarBD("begin; insert into ctactefleteros(idfleteros, idempresas, fecha, idconceptos, descripcion, ptoventa, idordenescarga, debe, haber, idrecibos,idordenescombustible) values('" + dato.Fleteros.Idfleteros + "','" + dato.Fleteros.Empresas.Idempresas + "','" + dato.Fecha.ToString("yyyy-MM-dd") + "','946','GS - Orden de Combustible','" + dato.Ptoventa + "','0','" + Convert.ToString(dato.Litros * dato.Preciocombustible).Replace(',', '.') + "','0','0','" + idoc + "'); insert into ctacteproveedores(idproveedores, idordenescombustible, idrecibos, fecha, idconceptos, descripcion, debe, haber, ptoventa) values ('" + dato.Proveedores.Idproveedores + "','" + idoc + "','0','" + dato.Fecha.ToString("yyyy-MM-dd") + "','996','GS - Orden de Combustible','0','" + Convert.ToString(dato.Litros * dato.Preciocombustible).Replace(',', '.') + "','"+dato.Ptoventa+"'); commit;");
           return nro;
        }

        public List<OrdenesCombustible> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public void Borrar(OrdenesCombustible dato)
        {
            throw new NotImplementedException();
        }

        public OrdenesCombustible Buscar(string dato)
        {
            throw new NotImplementedException();
        }

        public List<OrdenesCombustible> BuscarEspecial(string dato)
        {
            throw new NotImplementedException();
        }

        public void Modificar(OrdenesCombustible dato)
        {
            throw new NotImplementedException();
        }

        public int traerSigID()
        {
            throw new NotImplementedException();
        }
    }
}
