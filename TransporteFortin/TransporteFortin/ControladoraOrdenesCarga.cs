using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class ControladoraOrdenesCarga
    {
        BdOrdenesCarga bd = new BdOrdenesCarga();
        public string Agregar(OrdenesCarga dato)
        {
           return bd.Agregar(dato);
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
            return bd.BuscarEspecial(dato);
        }

        public void Modificar(OrdenesCarga dato)
        {
            bd.Modificar(dato);
        }

        public int traerSigID()
        {
            throw new NotImplementedException();
        }
    }
}
