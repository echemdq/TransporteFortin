﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TransporteFortin
{
    public class BdRecibos
    {
        Acceso_BD oacceso = new Acceso_BD();
        public void Agregar(Recibos dato)
        {            
            DataTable dt = new DataTable();
            //obtengo nro de recibo u orden pago
            if (dato.Clientes.Idclientes != 0)
            {
                dt = oacceso.leerDatos("start transaction; update contadores set nro = nro + 1 where detalle = 'recibo clientes' and ptoventa = '" + dato.Ptoventa + "'; select nro from contadores where detalle = 'recibo clientes' and ptoventa = '" + dato.Ptoventa + "'; commit;");
            }
            else if (dato.Fleteros.Idfleteros != 0)
            {
                if (dato.Tipo == 0)
                {
                    dt = oacceso.leerDatos("start transaction; update contadores set nro = nro + 1 where detalle = 'recibo fleteros' and ptoventa = '" + dato.Ptoventa + "'; select nro from contadores where detalle = 'recibo fleteros' and ptoventa = '" + dato.Ptoventa + "'; commit;");
                }
                else
                {
                    dt = oacceso.leerDatos("start transaction; update contadores set nro = nro + 1 where detalle = 'opago fleteros' and ptoventa = '" + dato.Ptoventa + "'; select nro from contadores where detalle = 'opago fleteros' and ptoventa = '" + dato.Ptoventa + "'; commit;");
                }
            }
            else if (dato.Proveedores.Idproveedores != 0)
            {
                dt = oacceso.leerDatos("start transaction; update contadores set nro = nro + 1 where detalle = 'opago proveedores' and ptoventa = '" + dato.Ptoventa + "'; select nro from contadores where detalle = 'opago proveedores' and ptoventa = '" + dato.Ptoventa + "'; commit;");
            }
            string nro = "";
            foreach (DataRow dr in dt.Rows)
            {
                nro = Convert.ToString(dr["nro"]);
            }


            //inserto en recibo
            dt = oacceso.leerDatos("begin; insert into recibos (fecha, concepto, nro, importe, comentarios, idclientes, idfleteros, idproveedores, ptoventa, puesto, idusuarios, idsucursales, tipo) values ('"+dato.Fecha.ToString("yyyy-MM-dd")+"','"+dato.Conceptos.Codigo+"','"+nro+"','"+dato.Importe.ToString().Replace(',','.')+"','"+dato.Comentarios+"','"+dato.Clientes.Idclientes+"','"+dato.Fleteros.Idfleteros+"','"+dato.Proveedores.Idproveedores+"','"+dato.Ptoventa+"','"+dato.Puesto+"','"+dato.Usuarios.Idusuarios+"','"+dato.Sucursales.Idsucursales+"','"+dato.Tipo+"'); select max(idrecibos) as idrecibos from recibos; commit;");
            int idrecibo = 0;
            foreach (DataRow dr in dt.Rows)
            {
                idrecibo = Convert.ToInt32(dr["idrecibos"]);
            }


            //inserto en cuenta corriente
            if (dato.Clientes.Idclientes != 0)
            {
                oacceso.ActualizarBD("insert into ctacteclientes (idclientes, idconceptos, descripcion, ptoventa, idordenescarga, debe, haber, fecha, idrecibos) values ('" + dato.Clientes.Idclientes + "','" + dato.Conceptos.Codigo + "','GS - Recibo Cobro','" + dato.Ptoventa + "',0,0,'" + dato.Importe.ToString().Replace(',', '.') + "',now(),'" + idrecibo + "')");
            }
            else if (dato.Fleteros.Idfleteros != 0)
            {
                if (dato.Tipo == 0)
                {
                    oacceso.ActualizarBD("insert into ctactefleteros (idfleteros, idempresas, fecha, fecactual, idconceptos, descripcion, ptoventa, idordenescarga, debe, haber, idrecibos, idordenescombustible) values ('" + dato.Fleteros.Idfleteros + "','" + dato.Fleteros.Empresas.Idempresas + "',now(),now(),'" + dato.Conceptos.Codigo + "','GS - Recibo Cobro','" + dato.Ptoventa + "',0,0,'" + dato.Importe.ToString().Replace(',', '.') + "','" + idrecibo + "',0)");
                }
                else
                {
                    oacceso.ActualizarBD("insert into ctactefleteros (idfleteros, idempresas, fecha, fecactual, idconceptos, descripcion, ptoventa, idordenescarga, debe, haber, idrecibos, idordenescombustible) values ('" + dato.Fleteros.Idfleteros + "','" + dato.Fleteros.Empresas.Idempresas + "',now(),now(),'" + dato.Conceptos.Codigo + "','GS - Orden de Pago','" + dato.Ptoventa + "',0,'" + dato.Importe.ToString().Replace(',', '.') + "',0,'" + idrecibo + "',0)");
                }
            }
            else if (dato.Proveedores.Idproveedores != 0)
            {
                oacceso.ActualizarBD("insert into ctacteproveedores (idproveedores, idordenescombustible, idrecibos, fecha, idconceptos, descripcion, debe, haber, ptoventa) values ('" + dato.Proveedores.Idproveedores + "',0,'" + idrecibo + "', now(),'" + dato.Conceptos.Codigo + "','GS - Orden de Pago','" + dato.Importe.ToString().Replace(',', '.') + "',0,'" + dato.Ptoventa + "')");
            }
        }

        public List<Recibos> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public void Borrar(Recibos dato)
        {
            throw new NotImplementedException();
        }

        public Recibos Buscar(string dato)
        {
            throw new NotImplementedException();
        }

        public List<Recibos> BuscarEspecial(string dato)
        {
            throw new NotImplementedException();
        }

        public void Modificar(Recibos dato)
        {
            throw new NotImplementedException();
        }

        public int traerSigID()
        {
            throw new NotImplementedException();
        }
    }
}
