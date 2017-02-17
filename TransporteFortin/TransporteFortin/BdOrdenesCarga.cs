using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace TransporteFortin
{
    public class BdOrdenesCarga : IDAO<OrdenesCarga>
    {
        Acceso_BD oacceso = new Acceso_BD();
        public void Agregar(OrdenesCarga dato)
        {
           DataTable dt = new DataTable();
           dt = oacceso.leerDatos("start transaction; update contadores set nro = nro + 1 where detalle = 'ocarga'; select nro from contadores where detalle = 'ocarga'; commit;");
           string nro = "";
           foreach (DataRow dr in dt.Rows)
           {
               nro = Convert.ToString(dr["nro"]);
           }
           oacceso.ActualizarBD("insert into ordenescarga (nrocarga, idsucursales, idclientes, idfleteros, idempresas, porcuentade, productos, origen, destino, valordeclarado, valorizado, idunidades, cantidad, valorunidad, tipocomision, valorcomision, pagodestino, totalviaje, ivaviaje, comision, importecliente, observaciones, valorunidadcte, ivacliente, ptoventa, puesto, fecha) values ('" + nro + "','" + dato.Sucursales.Idsucursales + "','" + dato.Clientes.Idclientes + "','" + dato.Fleteros.Idfleteros + "','" + dato.Empresas.Idempresas + "','" + dato.Porcuentade + "','" + dato.Productos + "','" + dato.Origen + "','" + dato.Destino + "','" + dato.Valordeclarado.ToString().Replace(',', '.') + "','" + dato.Valorizado + "','" + dato.Unidades.Idunidades + "','" + dato.Cantidad + "','" + dato.Valorunidad.ToString().Replace(',', '.') + "','" + dato.Tipocomision + "','" + dato.Valorcomision.ToString().Replace(',', '.') + "','" + dato.Pagodestino + "','" + dato.Totalviaje.ToString().Replace(',', '.') + "','" + dato.Ivaviaje.ToString().Replace(',', '.') + "','" + dato.Comision.ToString().Replace(',', '.') + "','" + dato.Importecliente.ToString().Replace(',', '.') + "','" + dato.Observaciones + "','" + dato.Valorunidadcte.ToString().Replace(',', '.') + "','" + dato.Ivacliente.ToString().Replace(',', '.') + "','" + dato.Ptoventa + "','" + dato.Puesto + "','" + dato.Fecha.ToString("yyyy-MM-dd") + "')");
        }

        public List<OrdenesCarga> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public void Borrar(OrdenesCarga dato)
        {
            throw new NotImplementedException();
        }

        public OrdenesCarga Buscar(string dato)
        {
            throw new NotImplementedException();
        }

        public List<OrdenesCarga> BuscarEspecial(string dato)
        {
            throw new NotImplementedException();
        }

        public void Modificar(OrdenesCarga dato)
        {
            throw new NotImplementedException();
        }

        public int traerSigID()
        {
            throw new NotImplementedException();
        }
    }
}
