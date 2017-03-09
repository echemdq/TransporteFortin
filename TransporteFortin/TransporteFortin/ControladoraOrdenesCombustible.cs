using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class ControladoraOrdenesCombustible : IDAO<OrdenesCombustible>
    {
        BdOrdenesCombustible bd = new BdOrdenesCombustible();
        public void Agregar(OrdenesCombustible dato)
        {
            bd.Agregar(dato);
        }

        public List<OrdenesCombustible> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public void Borrar(OrdenesCombustible dato)
        {
            throw new NotImplementedException();
        }

        public OrdenesCombustible Buscar(string dato)
        {
            throw new NotImplementedException();
        }

        public List<OrdenesCombustible> BuscarEspecial(string dato)
        {
            throw new NotImplementedException();
        }

        public void Modificar(OrdenesCombustible dato)
        {
            throw new NotImplementedException();
        }

        public int traerSigID()
        {
            throw new NotImplementedException();
        }
    }
}
