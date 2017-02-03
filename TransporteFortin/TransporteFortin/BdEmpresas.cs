using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TransporteFortin
{
    public class BdEmpresas : IDAO<Empresas>
    {
        Acceso_BD oacceso = new Acceso_BD();

        public void Agregar(Empresas dato)
        {
            oacceso.leerDatos("insert into empresas (empresa, direccion, localidad, telefono, telefono2, celular, mail, comentario) values ('" + dato.Empresa.ToUpper() + "','" + dato.Direccion.ToUpper() + "','" + dato.Localidad.ToUpper() + "','" + dato.Telefono + "','" + dato.Telefono2 + "','" + dato.Celular + "','" + dato.Mail.ToUpper() + "','" + dato.Comentario + "')");
        }

        public List<Empresas> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public void Borrar(Empresas dato)
        {
            oacceso.ActualizarBD("delete from empresas where idempresas = '" + dato.Idempresas + "'");
        }

        public Empresas Buscar(string dato)
        {
            throw new NotImplementedException();
        }

        public List<Empresas> BuscarEspecial(string dato)
        {
            string cmdtext = "select * from empresas c where empresa " + dato + " order by empresa";
            DataTable dt = oacceso.leerDatos(cmdtext);
            Empresas prov = null;
            List<Empresas> lista = new List<Empresas>();
            foreach (DataRow dr in dt.Rows)
            {
                prov = new Empresas(Convert.ToInt32(dr["idempresas"]), Convert.ToString(dr["empresa"]), Convert.ToString(dr["direccion"]), Convert.ToString(dr["localidad"]), Convert.ToString(dr["telefono"]), Convert.ToString(dr["telefono2"]), Convert.ToString(dr["celular"]), Convert.ToString(dr["mail"]), Convert.ToString(dr["comentario"]));
                lista.Add(prov);
            }
            return lista;
        }

        public void Modificar(Empresas dato)
        {
            oacceso.ActualizarBD("update empresas set empresa = '" + dato.Empresa.ToUpper() + "', direccion = '" + dato.Direccion.ToUpper() + "', localidad = '" + dato.Localidad.ToUpper() + "', telefono2 = '" + dato.Telefono2 + "', telefono = '" + dato.Telefono + "', celular = '" + dato.Celular + "', mail = '" + dato.Mail.ToUpper() + "', comentario = '" + dato.Comentario + "' where idempresas = '" + dato.Idempresas + "'");
        }

        public int traerSigID()
        {
            throw new NotImplementedException();
        }
    }
}
