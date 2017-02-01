using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TransporteFortin
{
    public class BdClientes : IDAO<Clientes>
    {

        Acceso_BD oacceso = new Acceso_BD();

        public void Agregar(Clientes dato)
        {
            oacceso.leerDatos("insert into clientes (cliente, direccion, localidad, cp, telefono, celular, fax, mail, contacto, cuit, idtiposiva, comentario) values ('" + dato.Cliente.ToUpper() + "','" + dato.Direccion.ToUpper() + "','" + dato.Localidad.ToUpper() + "','" + dato.Cp + "','" + dato.Telefono + "','" + dato.Celular + "','" + dato.Fax + "','" + dato.Mail.ToUpper() + "','" + dato.Contacto.ToUpper() + "','" + dato.Cuit + "','" + dato.TiposIVA.IdTiposIVA + "','" + dato.Comentario + "')");
        } 

        public List<Clientes> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public void Borrar(Clientes dato)
        {
            oacceso.ActualizarBD("delete from clientes where idclientes = '" + dato.Idclientes + "'");
        }

        public Clientes Buscar(string dato)
        {
            throw new NotImplementedException();
        }

        public List<Clientes> BuscarEspecial(string dato)
        {
            string cmdtext = "select * from clientes c where cliente " + dato + " order by cliente";
            DataTable dt = oacceso.leerDatos(cmdtext);
            Clientes cliente = null;
            TiposIVA tipod = null;
            List<Clientes> lista = new List<Clientes>();
            foreach (DataRow dr in dt.Rows)
            {
                tipod = new TiposIVA(Convert.ToInt32(dr["idtiposiva"]), "","");
                cliente = new Clientes(Convert.ToInt32(dr["idclientes"]), Convert.ToString(dr["cliente"]), Convert.ToString(dr["direccion"]), Convert.ToString(dr["localidad"]), Convert.ToInt32(dr["cp"]), Convert.ToString(dr["telefono"]), Convert.ToString(dr["celular"]), Convert.ToString(dr["fax"]), Convert.ToString(dr["mail"]), Convert.ToString(dr["contacto"]), Convert.ToString(dr["cuit"]), tipod, Convert.ToString(dr["comentario"]));
                lista.Add(cliente);
            }
            return lista;
        }

        public void Modificar(Clientes dato)
        {
            oacceso.ActualizarBD("update clientes set cliente = '" + dato.Cliente.ToUpper() + "', direccion = '" + dato.Direccion.ToUpper() + "', localidad = '" + dato.Localidad.ToUpper() + "', cp = '" + dato.Cp + "', telefono = '" + dato.Telefono + "', celular = '" + dato.Celular + "', fax = '" + dato.Fax + "', mail = '" + dato.Mail.ToUpper() + "', contacto = '" + dato.Contacto.ToUpper() + "', cuit = '" + dato.Cuit + "', idtiposiva = '" + dato.TiposIVA.IdTiposIVA + "', comentario = '" + dato.Comentario + "' where idclientes = '" + dato.Idclientes + "'");
        }

        public int traerSigID()
        {
            throw new NotImplementedException();
        }
    }
}
