using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class ControladoraEstadosCheques : IDAO<EstadosCheques>
    {
        BdEstadosCheques bd = new BdEstadosCheques();
        public void Agregar(EstadosCheques dato)
        {
            throw new NotImplementedException();
        }

        public List<EstadosCheques> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public void Borrar(EstadosCheques dato)
        {
            throw new NotImplementedException();
        }

        public EstadosCheques Buscar(string dato)
        {
            throw new NotImplementedException();
        }

        public List<EstadosCheques> BuscarEspecial(string dato)
        {
            throw new NotImplementedException();
        }

        public void Modificar(EstadosCheques dato)
        {
            throw new NotImplementedException();
        }

        public int traerSigID()
        {
            throw new NotImplementedException();
        }
    }
}
