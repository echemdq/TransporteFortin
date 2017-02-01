using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TransporteFortin
{
    public class BdProveedores : IDAO<Proveedores>
    {
        Acceso_BD oacceso = new Acceso_BD();

        public void Agregar(Proveedores dato)
        {
            oacceso.leerDatos("insert into proveedores (proveedor, direccion, localidad, cp, telefono, celular, fax, mail, contacto, cuit, idtiposiva, comentario, valor) values ('" + dato.Proveedor.ToUpper() + "','" + dato.Direccion.ToUpper() + "','" + dato.Localidad.ToUpper() + "','" + dato.Cp + "','" + dato.Telefono + "','" + dato.Celular + "','" + dato.Fax + "','" + dato.Mail.ToUpper() + "','" + dato.Contacto.ToUpper() + "','" + dato.Cuit + "','" + dato.TiposIVA.IdTiposIVA + "','" + dato.Comentario + "','" + dato.Valor.ToString().Replace(',','.') + "')");
        }

        public List<Proveedores> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public void Borrar(Proveedores dato)
        {
            oacceso.ActualizarBD("delete from proveedores where idproveedores = '" + dato.Idproveedores + "'");
        }

        public Proveedores Buscar(string dato)
        {
            throw new NotImplementedException();
        }

        public List<Proveedores> BuscarEspecial(string dato)
        {
            string cmdtext = "select * from proveedores c where proveedor " + dato + " order by proveedor";
            DataTable dt = oacceso.leerDatos(cmdtext);
            Proveedores prov = null;
            TiposIVA tipod = null;
            List<Proveedores> lista = new List<Proveedores>();
            foreach (DataRow dr in dt.Rows)
            {
                tipod = new TiposIVA(Convert.ToInt32(dr["idtiposiva"]), "", "");
                prov = new Proveedores(Convert.ToInt32(dr["idproveedores"]), Convert.ToString(dr["proveedor"]), Convert.ToString(dr["direccion"]), Convert.ToString(dr["localidad"]), Convert.ToInt32(dr["cp"]), Convert.ToString(dr["telefono"]), Convert.ToString(dr["celular"]), Convert.ToString(dr["fax"]), Convert.ToString(dr["mail"]), Convert.ToString(dr["contacto"]), Convert.ToString(dr["cuit"]), tipod, Convert.ToString(dr["comentario"]), Convert.ToDecimal(Convert.ToString(dr["valor"]).Replace('.',',')));
                lista.Add(prov);
            }
            return lista;
        }

        public void Modificar(Proveedores dato)
        {
            oacceso.ActualizarBD("update proveedores set proveedor = '" + dato.Proveedor.ToUpper() + "', direccion = '" + dato.Direccion.ToUpper() + "', localidad = '" + dato.Localidad.ToUpper() + "', cp = '" + dato.Cp + "', telefono = '" + dato.Telefono + "', celular = '" + dato.Celular + "', fax = '" + dato.Fax + "', mail = '" + dato.Mail.ToUpper() + "', contacto = '" + dato.Contacto.ToUpper() + "', cuit = '" + dato.Cuit + "', idtiposiva = '" + dato.TiposIVA.IdTiposIVA + "', comentario = '" + dato.Comentario + "', valor = '" + dato.Valor.ToString().Replace(',', '.') + "' where idproveedores = '" + dato.Idproveedores + "'");
        }

        public int traerSigID()
        {
            throw new NotImplementedException();
        }
    }
}
