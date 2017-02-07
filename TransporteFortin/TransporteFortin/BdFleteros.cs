using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class BdFleteros : IDAO<Fleteros>
    {
        Acceso_BD oacceso = new Acceso_BD();
        public void Agregar(Fleteros dato)
        {
            oacceso.ActualizarBD("insert into fleteros (documento, fletero, direccion, localidad, cp, telefono, celular, fax, mail, idempresas, camion, idtiposcamion, chapacamion, chapaacoplado) values ('" + dato.Documento + "','" + dato.Fletero.ToUpper() + "','" + dato.Direccion.ToUpper() + "','" + dato.Localidad.ToUpper() + "','" + dato.Cp + "','" + dato.Telefono + "','" + dato.Celular + "','" + dato.Fax + "','" + dato.Mail.ToUpper() + "','" + dato.Empresas.Idempresas + "','" + dato.Camion + "','" + dato.Tiposcamion.Idtiposcamion + "','" + dato.Chapacamion + "','" + dato.Chapaacoplado + "')");
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
            throw new NotImplementedException();
        }

        public void Modificar(Fleteros dato)
        {
            oacceso.ActualizarBD("update fleteros set documento = '" + dato.Documento + "', fletero = '" + dato.Fletero.ToUpper() + "', direccion = '" + dato.Direccion.ToUpper() + "', localidad = '" + dato.Localidad.ToUpper() + "', cp = '" + dato.Cp + "', telefono = '" + dato.Telefono + "', celular = '" + dato.Celular + "', fax = '" + dato.Fax + "', mail = '" + dato.Mail.ToUpper() + "', idempresas = '" + dato.Empresas.Idempresas + "', camion = '" + dato.Camion.ToUpper() + "', idtiposcamion = '" + dato.Tiposcamion.Idtiposcamion + "', chapacamion = '" + dato.Chapacamion + "', chapaacoplado = '" + dato.Chapaacoplado + "' where idfleteros = '" + dato.Idfleteros + "'");
        }

        public int traerSigID()
        {
            throw new NotImplementedException();
        }
    }
}
