using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class ControladoraUsuarios : IDAO<Usuarios>
    {
        BdUsuarios bd = new BdUsuarios();
        public void Agregar(Usuarios dato)
        {
            throw new NotImplementedException();
        }

        public List<Usuarios> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public void Borrar(Usuarios dato)
        {
            throw new NotImplementedException();
        }

        public Usuarios Buscar(string dato)
        {
            throw new NotImplementedException();
        }

        public List<Usuarios> BuscarEspecial(string dato)
        {
            return bd.BuscarEspecial(dato);
        }

        public void Modificar(Usuarios dato)
        {
            throw new NotImplementedException();
        }

        public int traerSigID()
        {
            throw new NotImplementedException();
        }
    }
}
