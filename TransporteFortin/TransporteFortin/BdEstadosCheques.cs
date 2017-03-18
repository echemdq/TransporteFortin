using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class BdEstadosCheques : IDAO<EstadosCheques>
    {
        Acceso_BD oacceso = new Acceso_BD();
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
