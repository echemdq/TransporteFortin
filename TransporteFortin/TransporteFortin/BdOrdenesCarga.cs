using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class BdOrdenesCarga : IDAO<OrdenesCarga>
    {
        Acceso_BD oacceso = new Acceso_BD();
        public void Agregar(OrdenesCarga dato)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
