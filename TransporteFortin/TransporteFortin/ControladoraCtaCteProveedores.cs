using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class ControladoraCtaCteProveedores : IDAO<CtaCteProveedores>
    {
        BdCtaCteProveedores bd = new BdCtaCteProveedores();
        public void Agregar(CtaCteProveedores dato)
        {
            throw new NotImplementedException();
        }

        public List<CtaCteProveedores> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public void Borrar(CtaCteProveedores dato)
        {
            throw new NotImplementedException();
        }

        public CtaCteProveedores Buscar(string dato)
        {
            throw new NotImplementedException();
        }

        public List<CtaCteProveedores> BuscarEspecial(string dato)
        {
           return bd.BuscarEspecial(dato);
        }

        public void Modificar(CtaCteProveedores dato)
        {
            throw new NotImplementedException();
        }

        public int traerSigID()
        {
            throw new NotImplementedException();
        }
    }
}
