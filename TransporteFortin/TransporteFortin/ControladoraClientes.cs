using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class ControladoraClientes : IDAO<Clientes>
    {
        BdClientes bd = new BdClientes();
        public void Agregar(Clientes dato)
        {
            bd.Agregar(dato);
        }

        public List<Clientes> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public void Borrar(Clientes dato)
        {
            bd.Borrar(dato);
        }

        public Clientes Buscar(string dato)
        {
            throw new NotImplementedException();
        }

        public List<Clientes> BuscarEspecial(string dato)
        {
            return bd.BuscarEspecial(dato);
        }

        public void Modificar(Clientes dato)
        {
            bd.Modificar(dato);
        }

        public int traerSigID()
        {
            throw new NotImplementedException();
        }
    }
}
