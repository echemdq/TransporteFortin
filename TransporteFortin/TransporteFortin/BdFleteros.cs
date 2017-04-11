using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TransporteFortin
{
    public class BdFleteros : IDAO<Fleteros>
    {
        Acceso_BD oacceso = new Acceso_BD();
        public void Agregar(Fleteros dato)
        {
            oacceso.ActualizarBD("insert into fleteros (documento, fletero, direccion, localidad, cp, telefono, celular, fax, mail, idempresas, camion, idtiposcamion, chapacamion, chapaacoplado, cuit, idtiposiva) values ('" + dato.Documento + "','" + dato.Fletero.ToUpper() + "','" + dato.Direccion.ToUpper() + "','" + dato.Localidad.ToUpper() + "','" + dato.Cp + "','" + dato.Telefono + "','" + dato.Celular + "','" + dato.Fax + "','" + dato.Mail.ToUpper() + "','" + dato.Empresas.Idempresas + "','" + dato.Camion + "','" + dato.Tiposcamion.Idtiposcamion + "','" + dato.Chapacamion + "','" + dato.Chapaacoplado + "','" + dato.Cuit + "','" + dato.TiposIVA.IdTiposIVA + "')");
        }

        public List<Fleteros> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public void Borrar(Fleteros dato)
        {
            oacceso.ActualizarBD("delete from fleteros where idfleteros = '" + dato.Idfleteros + "'");
        }

        public Fleteros Buscar(string dato)
        {
            throw new NotImplementedException();
        }

        public List<Fleteros> BuscarEspecial(string dato)
        {
            string cmdtext = "select * from fleteros c left join empresas e on c.idempresas = e.idempresas where fletero " + dato + " or documento " + dato +" order by fletero";
            DataTable dt = oacceso.leerDatos(cmdtext);
            Fleteros fletero = null;
            Empresas emp = null;
            TiposCamion tip = null;
            TiposIVA tipo = null;
            List<Fleteros> lista = new List<Fleteros>();
            foreach (DataRow dr in dt.Rows)
            {
                tipo = new TiposIVA(Convert.ToInt32(dr["idtiposiva"]), "", "");
                tip = new TiposCamion(Convert.ToInt32(dr["idtiposcamion"]), "");
                emp = new Empresas(Convert.ToInt32(dr["idempresas"]), Convert.ToString(dr["empresa"]), "", "", "", "", "", "", "");
                fletero = new Fleteros(Convert.ToInt32(dr["idfleteros"]), Convert.ToInt32(dr["documento"]), Convert.ToString(dr["fletero"]), Convert.ToString(dr["direccion"]), Convert.ToString(dr["localidad"]), Convert.ToString(dr["cp"]), Convert.ToString(dr["telefono"]), Convert.ToString(dr["celular"]), Convert.ToString(dr["fax"]), Convert.ToString(dr["mail"]), emp, Convert.ToString(dr["camion"]), tip, Convert.ToString(dr["chapacamion"]), Convert.ToString(dr["chapaacoplado"]), Convert.ToString(dr["cuit"]), tipo, Convert.ToString(dr["comentario"]));
                lista.Add(fletero);
            }
            return lista;
        }

        public void Modificar(Fleteros dato)
        {
            oacceso.ActualizarBD("update fleteros set documento = '" + dato.Documento + "', fletero = '" + dato.Fletero.ToUpper() + "', direccion = '" + dato.Direccion.ToUpper() + "', localidad = '" + dato.Localidad.ToUpper() + "', cp = '" + dato.Cp + "', telefono = '" + dato.Telefono + "', celular = '" + dato.Celular + "', fax = '" + dato.Fax + "', mail = '" + dato.Mail.ToUpper() + "', idempresas = '" + dato.Empresas.Idempresas + "', camion = '" + dato.Camion.ToUpper() + "', idtiposcamion = '" + dato.Tiposcamion.Idtiposcamion + "', chapacamion = '" + dato.Chapacamion + "', chapaacoplado = '" + dato.Chapaacoplado + "', cuit = '" + dato.Cuit + "', idtiposiva = '" + dato.TiposIVA.IdTiposIVA + "' where idfleteros = '" + dato.Idfleteros + "'");
        }

        public int traerSigID()
        {
            throw new NotImplementedException();
        }
    }
}
