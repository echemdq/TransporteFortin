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
        

        public void Agregar(Clientes dato)
        {
            Acceso_BD oacceso = new Acceso_BD();
            oacceso.ActualizarBD("insert into clientes (cliente, direccion, localidad, cp, telefono, celular, fax, mail, contacto, cuit, idtiposiva, comentario) values ('" + dato.Cliente.ToUpper() + "','" + dato.Direccion.ToUpper() + "','" + dato.Localidad.ToUpper() + "','" + dato.Cp + "','" + dato.Telefono + "','" + dato.Celular + "','" + dato.Fax + "','" + dato.Mail.ToUpper() + "','" + dato.Contacto.ToUpper() + "','" + dato.Cuit + "','" + dato.TiposIVA.IdTiposIVA + "','" + dato.Comentario + "')");
        } 

        public List<Clientes> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public void Borrar(Clientes dato)
        {
            throw new NotImplementedException();
        }

        public Clientes Buscar(string dato)
        {
            throw new NotImplementedException();
        }

        public List<Clientes> BuscarEspecial(string dato)
        {
            throw new NotImplementedException();
        }

        public void Modificar(Clientes dato)
        {
            throw new NotImplementedException();
        }

        public int traerSigID()
        {
            throw new NotImplementedException();
        }
    }
}
