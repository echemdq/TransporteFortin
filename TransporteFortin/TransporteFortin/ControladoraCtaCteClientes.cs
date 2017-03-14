using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class ControladoraCtaCteClientes : IDAO<CtaCteClientes>
    {
        BdCtaCteClientes bd = new BdCtaCteClientes();
        public void Agregar(CtaCteClientes dato)
        {
            throw new NotImplementedException();
        }

        public List<CtaCteClientes> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public void Borrar(CtaCteClientes dato)
        {
            throw new NotImplementedException();
        }

        public CtaCteClientes Buscar(string dato)
        {
            throw new NotImplementedException();
        }

        public List<CtaCteClientes> BuscarEspecial(string dato)
        {
            return bd.BuscarEspecial(dato);
        }

        public void Modificar(CtaCteClientes dato)
        {
            throw new NotImplementedException();
        }

        public int traerSigID()
        {
            throw new NotImplementedException();
        }
    }
}
