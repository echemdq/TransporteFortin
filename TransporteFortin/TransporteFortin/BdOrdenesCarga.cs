using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace TransporteFortin
{
    public class BdOrdenesCarga
    {
        Acceso_BD oacceso = new Acceso_BD();
        public string Agregar(OrdenesCarga dato)
        {
           DataTable dt = new DataTable();
           dt = oacceso.leerDatos("start transaction; update contadores set nro = nro + 1 where detalle = 'ocarga' and ptoventa = '" + dato.Ptoventa + "'; select nro from contadores where detalle = 'ocarga' and ptoventa = '" + dato.Ptoventa + "'; commit;");
           string nro = "";
           foreach (DataRow dr in dt.Rows)
           {
               nro = Convert.ToString(dr["nro"]);
           }
           dt = oacceso.leerDatos("begin; insert into ordenescarga (nrocarga, idsucursales, idclientes, idfleteros, idempresas, porcuentade, productos, origen, destino, valordeclarado, valorizado, idunidades, cantidad, valorunidad, tipocomision, valorcomision, pagodestino, totalviaje, ivaviaje, comision, importecliente, observaciones, valorunidadcte, ivacliente, ptoventa, puesto, fecha, idusuarios, conceptofactura) values ('" + nro + "','" + dato.Sucursales.Idsucursales + "','" + dato.Clientes.Idclientes + "','" + dato.Fleteros.Idfleteros + "','" + dato.Empresas.Idempresas + "','" + dato.Porcuentade + "','" + dato.Productos + "','" + dato.Origen + "','" + dato.Destino + "','" + dato.Valordeclarado.ToString().Replace(',', '.') + "','" + dato.Valorizado + "','" + dato.Unidades.Idunidades + "','" + dato.Cantidad.ToString().Replace(',','.') + "','" + dato.Valorunidad.ToString().Replace(',', '.') + "','" + dato.Tipocomision + "','" + dato.Valorcomision.ToString().Replace(',', '.') + "','" + dato.Pagodestino + "','" + dato.Totalviaje.ToString().Replace(',', '.') + "','" + dato.Ivaviaje.ToString().Replace(',', '.') + "','" + dato.Comision.ToString().Replace(',', '.') + "','" + dato.Importecliente.ToString().Replace(',', '.') + "','" + dato.Observaciones + "','" + dato.Valorunidadcte.ToString().Replace(',', '.') + "','" + dato.Ivacliente.ToString().Replace(',', '.') + "','" + dato.Ptoventa + "','" + dato.Puesto + "','" + dato.Fecha.ToString("yyyy-MM-dd") + "','" + dato.Usu.Idusuarios + "','"+dato.Conceptfact+"'); select idordenescarga from ordenescarga where nrocarga = '" + nro + "' and ptoventa = '" + dato.Ptoventa + "'; commit;");
            int idoc = 0;
            foreach (DataRow dr in dt.Rows)
            {
                idoc = Convert.ToInt32(dr["idordenescarga"]);
            }
           if (dato.Valorizado == 1)
           {

               if (dato.Totalviaje > 0 && dato.Pagodestino == 0)
               {
                   oacceso.ActualizarBD("insert into ctactefleteros(idfleteros, idempresas, fecha, idconceptos, descripcion, ptoventa, idordenescarga, debe, haber, idrecibos) values('" + dato.Fleteros.Idfleteros + "','" + dato.Empresas.Idempresas + "','" + dato.Fecha.ToString("yyyy-MM-dd") + "','999','GS - Orden de Carga - "+dato.Clientes.Cliente+"','" + dato.Ptoventa + "','" + idoc + "','0','" + dato.Totalviaje.ToString().Replace(',', '.') + "','0')");
                   if (dato.Ivaviaje > 0)
                   {
                       oacceso.ActualizarBD("insert into ctactefleteros(idfleteros, idempresas, fecha, idconceptos, descripcion, ptoventa, idordenescarga, debe, haber, idrecibos) values('" + dato.Fleteros.Idfleteros + "','" + dato.Empresas.Idempresas + "','" + dato.Fecha.ToString("yyyy-MM-dd") + "','17','GS - IVA - " + dato.Clientes.Cliente + "','" + dato.Ptoventa + "','" + idoc + "','0','" + dato.Ivaviaje.ToString().Replace(',', '.') + "','0')");
                   }                   
               }
               if (dato.Comision > 0)
               {
                   oacceso.ActualizarBD("insert into ctactefleteros(idfleteros, idempresas, fecha, idconceptos, descripcion, ptoventa, idordenescarga, debe, haber, idrecibos) values('" + dato.Fleteros.Idfleteros + "','" + dato.Empresas.Idempresas + "','" + dato.Fecha.ToString("yyyy-MM-dd") + "','948','GS - Comision - " + dato.Clientes.Cliente + "','" + dato.Ptoventa + "','" + idoc + "','" + dato.Comision.ToString().Replace(',', '.') + "','0','0')");
               }
               if (dato.Importecliente > 0 && dato.Pagodestino == 0)
               {
                   oacceso.ActualizarBD("insert into ctacteclientes(idclientes, idconceptos, descripcion, ptoventa, idordenescarga, debe, haber, fecha) values('" + dato.Clientes.Idclientes + "','949','GS - Orden de Carga - " + dato.Clientes.Cliente + "','" + dato.Ptoventa + "','" + idoc + "','" + dato.Importecliente.ToString().Replace(',', '.') + "','0','" + dato.Fecha.ToString("yyyy-MM-dd") + "')");
                   if (dato.Ivacliente > 0)
                   {
                       oacceso.ActualizarBD("insert into ctacteclientes(idclientes, idconceptos, descripcion, ptoventa, idordenescarga, debe, haber, fecha) values('" + dato.Clientes.Idclientes + "','15','GS - IVA - " + dato.Clientes.Cliente + "','" + dato.Ptoventa + "','" + idoc + "','" + dato.Ivacliente.ToString().Replace(',', '.') + "','0','" + dato.Fecha.ToString("yyyy-MM-dd") + "')");
                   }   
               }
           }
           return nro;
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
            DataTable dt = oacceso.leerDatos("select o.observaciones as ob, o.valordeclarado as valord, o.cantidad as cant, o.pagodestino as pagod, f.direccion as dir, o.porcuentade as porcuenta, o.productos as prod, o.origen as origen, o.destino as destino, t.detalle as tipo, f.chapacamion as chapacamion, f.camion as camion, f.chapaacoplado as chapaacoplado, e.empresa as empresa, e.telefono as teemp, idusuarios, idordenescarga, o.ptoventa, nrocarga, o.idsucursales, sucursal, fecha, o.idclientes, c.cliente, o.idfleteros, f.fletero, totalviaje, comision, anulado, valorizado from ordenescarga o inner join clientes c on o.idclientes = c.idclientes inner join fleteros f on f.idfleteros = o.idfleteros inner join tiposcamion t on f.idtiposcamion = t.idtiposcamion left join empresas e on f.idempresas = e.idempresas inner join sucursales s on s.idsucursales = o.idsucursales "+dato); 
            Clientes c = null;
            Fleteros f = null;
            Empresas e = null;
            Sucursales s = null;
            OrdenesCarga o = null;
            TiposCamion t = null;
            Usuarios u = null;
            List<OrdenesCarga> lista = new List<OrdenesCarga>();
            foreach (DataRow dr in dt.Rows)
            {
                c = new Clientes(Convert.ToInt32(dr["idclientes"]), Convert.ToString(dr["cliente"]), "", "","", "", "", "", "", "", "", null, "");
                e = new Empresas(0, Convert.ToString(dr["empresa"]), "", "", Convert.ToString(dr["teemp"]), "", "", "", "");
                t = new TiposCamion(0, Convert.ToString(dr["tipo"]));
                f = new Fleteros(Convert.ToInt32(dr["idfleteros"]), 0, Convert.ToString(dr["fletero"]), Convert.ToString(dr["dir"]), "", "", "", "", "", "", e, Convert.ToString(dr["camion"]), t, Convert.ToString(dr["chapacamion"]), Convert.ToString(dr["chapaacoplado"]), "", null, "");
                s = new Sucursales(Convert.ToInt32(dr["idsucursales"]), Convert.ToString(dr["sucursal"]));
                u = new Usuarios(Convert.ToInt32(dr["idusuarios"]), "", "");
                o = new OrdenesCarga(Convert.ToInt32(dr["idordenescarga"]), Convert.ToString(dr["nrocarga"]), Convert.ToInt32(dr["ptoventa"]), 0, Convert.ToDateTime(dr["fecha"]), s, c, f, e, Convert.ToString(dr["porcuenta"]), Convert.ToString(dr["prod"]), Convert.ToString(dr["origen"]), Convert.ToString(dr["destino"]),Convert.ToDecimal(dr["valord"]), Convert.ToInt32(dr["valorizado"]), null,Convert.ToDecimal(dr["cant"]), 0,0,"", 0, Convert.ToInt32(dr["pagod"]), Convert.ToDecimal(dr["totalviaje"]), 0, 0, Convert.ToDecimal(dr["comision"]), 0, Convert.ToString(dr["ob"]), Convert.ToInt32(dr["anulado"]), u,"");
                lista.Add(o);
            }
            return lista;
        }

        public void Modificar(OrdenesCarga dato)
        {
            oacceso.ActualizarBD("update ordenescarga set valorizado = '1', idunidades = '" + dato.Unidades.Idunidades + "', cantidad = '" + dato.Cantidad.ToString().Replace(',', '.') + "', valorunidad ='" + dato.Valorunidad.ToString().Replace(',', '.') + "', tipocomision = '" + dato.Tipocomision + "', valorcomision = '" + dato.Valorcomision.ToString().Replace(',', '.') + "', pagodestino = '" + dato.Pagodestino + "', totalviaje = '" + dato.Totalviaje.ToString().Replace(',', '.') + "', ivaviaje = '" + dato.Ivaviaje.ToString().Replace(',', '.') + "', comision = '" + dato.Comision.ToString().Replace(',', '.') + "', importecliente = '" + dato.Importecliente.ToString().Replace(',', '.') + "', valorunidadcte = '" + dato.Valorunidadcte.ToString().Replace(',', '.') + "', ivacliente = '" + dato.Ivacliente.ToString().Replace(',', '.') + "', conceptofactura = '" + dato.Conceptfact + "' where idordenescarga = '" + dato.Idordenescarga + "'");
            if (dato.Valorizado == 1)
            {

                if (dato.Totalviaje > 0 && dato.Pagodestino == 0)
                {
                    oacceso.ActualizarBD("insert into ctactefleteros(idfleteros, idempresas, fecha, idconceptos, descripcion, ptoventa, idordenescarga, debe, haber, idrecibos) values('" + dato.Fleteros.Idfleteros + "','" + dato.Empresas.Idempresas + "','" + dato.Fecha.ToString("yyyy-MM-dd") + "','999','GS - Orden de Carga - " + dato.Clientes.Cliente + "','" + dato.Ptoventa + "','" + dato.Idordenescarga + "','0','" + dato.Totalviaje.ToString().Replace(',', '.') + "','0')");
                    if (dato.Ivaviaje > 0)
                    {
                        oacceso.ActualizarBD("insert into ctactefleteros(idfleteros, idempresas, fecha, idconceptos, descripcion, ptoventa, idordenescarga, debe, haber, idrecibos) values('" + dato.Fleteros.Idfleteros + "','" + dato.Empresas.Idempresas + "','" + dato.Fecha.ToString("yyyy-MM-dd") + "','17','GS - IVA - " + dato.Clientes.Cliente + "','" + dato.Ptoventa + "','" + dato.Idordenescarga + "','0','" + dato.Ivaviaje.ToString().Replace(',', '.') + "','0')");
                    }
                }
                if (dato.Comision > 0)
                {
                    oacceso.ActualizarBD("insert into ctactefleteros(idfleteros, idempresas, fecha, idconceptos, descripcion, ptoventa, idordenescarga, debe, haber, idrecibos) values('" + dato.Fleteros.Idfleteros + "','" + dato.Empresas.Idempresas + "','" + dato.Fecha.ToString("yyyy-MM-dd") + "','948','GS - Comision - " + dato.Clientes.Cliente + "','" + dato.Ptoventa + "','" + dato.Idordenescarga + "','" + dato.Comision.ToString().Replace(',', '.') + "','0','0')");
                }
                if (dato.Importecliente > 0 && dato.Pagodestino == 0)
                {
                    oacceso.ActualizarBD("insert into ctacteclientes(idclientes, idconceptos, descripcion, ptoventa, idordenescarga, debe, haber, fecha) values('" + dato.Clientes.Idclientes + "','949','GS - Orden de Carga - " + dato.Clientes.Cliente + "','" + dato.Ptoventa + "','" + dato.Idordenescarga + "','" + dato.Importecliente.ToString().Replace(',', '.') + "','0','" + dato.Fecha.ToString("yyyy-MM-dd") + "')");
                    if (dato.Ivacliente > 0)
                    {
                        oacceso.ActualizarBD("insert into ctacteclientes(idclientes, idconceptos, descripcion, ptoventa, idordenescarga, debe, haber, fecha) values('" + dato.Clientes.Idclientes + "','15','GS - IVA - " + dato.Clientes.Cliente + "','" + dato.Ptoventa + "','" + dato.Idordenescarga + "','" + dato.Ivacliente.ToString().Replace(',', '.') + "','0','" + dato.Fecha.ToString("yyyy-MM-dd") + "')");
                    }
                }
            }
        }

        public int traerSigID()
        {
            throw new NotImplementedException();
        }
    }
}
