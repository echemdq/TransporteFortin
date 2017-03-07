﻿using System;
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
           dt = oacceso.leerDatos("start transaction; update contadores set nro = nro + 1 where detalle = 'ocarga' and ptoventa = '"+dato.Ptoventa+"'; select nro from contadores where detalle = 'ocarga'; commit;");
           string nro = "";
           foreach (DataRow dr in dt.Rows)
           {
               nro = Convert.ToString(dr["nro"]);
           }
           oacceso.ActualizarBD("insert into ordenescarga (nrocarga, idsucursales, idclientes, idfleteros, idempresas, porcuentade, productos, origen, destino, valordeclarado, valorizado, idunidades, cantidad, valorunidad, tipocomision, valorcomision, pagodestino, totalviaje, ivaviaje, comision, importecliente, observaciones, valorunidadcte, ivacliente, ptoventa, puesto, fecha, idusuarios) values ('" + nro + "','" + dato.Sucursales.Idsucursales + "','" + dato.Clientes.Idclientes + "','" + dato.Fleteros.Idfleteros + "','" + dato.Empresas.Idempresas + "','" + dato.Porcuentade + "','" + dato.Productos + "','" + dato.Origen + "','" + dato.Destino + "','" + dato.Valordeclarado.ToString().Replace(',', '.') + "','" + dato.Valorizado + "','" + dato.Unidades.Idunidades + "','" + dato.Cantidad + "','" + dato.Valorunidad.ToString().Replace(',', '.') + "','" + dato.Tipocomision + "','" + dato.Valorcomision.ToString().Replace(',', '.') + "','" + dato.Pagodestino + "','" + dato.Totalviaje.ToString().Replace(',', '.') + "','" + dato.Ivaviaje.ToString().Replace(',', '.') + "','" + dato.Comision.ToString().Replace(',', '.') + "','" + dato.Importecliente.ToString().Replace(',', '.') + "','" + dato.Observaciones + "','" + dato.Valorunidadcte.ToString().Replace(',', '.') + "','" + dato.Ivacliente.ToString().Replace(',', '.') + "','" + dato.Ptoventa + "','" + dato.Puesto + "','" + dato.Fecha.ToString("yyyy-MM-dd") + "','"+dato.Usu.Idusuarios+"')");
           dt = oacceso.leerDatos("select idordenescarga from ordenescarga where nrocarga = '"+nro+"' and ptoventa = '"+dato.Ptoventa+"'");
            int idoc = 0;
            foreach (DataRow dr in dt.Rows)
            {
                idoc = Convert.ToInt32(dr["idordenescarga"]);
            }
           if (dato.Valorizado == 1)
           {

               if (dato.Totalviaje > 0 && dato.Pagodestino == 0)
               {
                   oacceso.ActualizarBD("insert into ctactefleteros(idfleteros, idempresas, fecha, idconceptos, descripcion, ptoventa, idordenescarga, debe, haber, idrecibos) values('" + dato.Fleteros.Idfleteros + "','" + dato.Empresas.Idempresas + "','" + dato.Fecha.ToString("yyyy-MM-dd") + "','999','GS - Orden de Carga','" + dato.Ptoventa + "','" + idoc + "','0','" + dato.Totalviaje.ToString().Replace(',', '.') + "','0')");
                   if (dato.Ivaviaje > 0)
                   {
                       oacceso.ActualizarBD("insert into ctactefleteros(idfleteros, idempresas, fecha, idconceptos, descripcion, ptoventa, idordenescarga, debe, haber, idrecibos) values('" + dato.Fleteros.Idfleteros + "','" + dato.Empresas.Idempresas + "','" + dato.Fecha.ToString("yyyy-MM-dd") + "','17','GS - IVA','" + dato.Ptoventa + "','" + idoc + "','0','" + dato.Ivaviaje.ToString().Replace(',', '.') + "','0')");
                   }                   
               }
               if (dato.Comision > 0)
               {
                   oacceso.ActualizarBD("insert into ctactefleteros(idfleteros, idempresas, fecha, idconceptos, descripcion, ptoventa, idordenescarga, debe, haber, idrecibos) values('" + dato.Fleteros.Idfleteros + "','" + dato.Empresas.Idempresas + "','" + dato.Fecha.ToString("yyyy-MM-dd") + "','948','GS - Comision','" + dato.Ptoventa + "','" + idoc + "','" + dato.Comision.ToString().Replace(',', '.') + "','0','0')");
               }
           }
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
            DataTable dt = oacceso.leerDatos("select idusuarios, idordenescarga, ptoventa, nrocarga, o.idsucursales, sucursal, fecha, o.idclientes, c.cliente, o.idfleteros, f.fletero, totalviaje, comision, anulado, valorizado from ordenescarga o inner join clientes c on o.idclientes = c.idclientes inner join fleteros f on f.idfleteros = o.idfleteros inner join sucursales s on s.idsucursales = o.idsucursales "+dato); 
            Clientes c = null;
            Fleteros f = null;
            Sucursales s = null;
            OrdenesCarga o = null;
            Usuarios u = null;
            List<OrdenesCarga> lista = new List<OrdenesCarga>();
            foreach (DataRow dr in dt.Rows)
            {
                c = new Clientes(Convert.ToInt32(dr["idclientes"]), Convert.ToString(dr["cliente"]), "", "", 0, "", "", "", "", "", "", null, "");
                f = new Fleteros(Convert.ToInt32(dr["idfleteros"]), 0, Convert.ToString(dr["fletero"]), "", "", "", "", "", "", "", null, "", null, "", "", "", null);
                s = new Sucursales(Convert.ToInt32(dr["idsucursales"]), Convert.ToString(dr["sucursal"]));
                u = new Usuarios(Convert.ToInt32(dr["idusuarios"]), "", "");
                o = new OrdenesCarga(Convert.ToInt32(dr["idordenescarga"]), Convert.ToInt32(dr["nrocarga"]), Convert.ToInt32(dr["ptoventa"]), 0, Convert.ToDateTime(dr["fecha"]), s, c, f, null, "", "", "", "", 0, Convert.ToInt32(dr["valorizado"]), null, 0, 0, 0, "", 0, 0, Convert.ToDecimal(dr["totalviaje"]), 0, 0, Convert.ToDecimal(dr["comision"]), 0, "", Convert.ToInt32(dr["anulado"]),u);
                lista.Add(o);
            }
            return lista;
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
