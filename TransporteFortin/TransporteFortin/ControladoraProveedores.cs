using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class ControladoraProveedores : IDAO<Proveedores>
    {
        BdProveedores bd = new BdProveedores();
        public void Agregar(Proveedores dato)
        {
            bd.Agregar(dato);
        }

        public List<Proveedores> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public void Borrar(Proveedores dato)
        {
            bd.Borrar(dato);
        }

        public Proveedores Buscar(string dato)
        {
            throw new NotImplementedException();
        }

        public List<Proveedores> BuscarEspecial(string dato)
        {
            return bd.BuscarEspecial(dato);
        }

        public void Modificar(Proveedores dato)
        {
            bd.Modificar(dato);
        }

        public int traerSigID()
        {
            throw new NotImplementedException();
        }
    }
}
