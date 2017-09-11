using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class ControladoraOrdenesCombustible
    {
        BdOrdenesCombustible bd = new BdOrdenesCombustible();
        public string Agregar(OrdenesCombustible dato)
        {
            return bd.Agregar(dato);
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
            return bd.BuscarEspecial(dato);
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
