using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class ControladoraEmpresas : IDAO<Empresas>
    {
        BdEmpresas bd = new BdEmpresas();
        public void Agregar(Empresas dato)
        {
            bd.Agregar(dato);
        }

        public List<Empresas> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public void Borrar(Empresas dato)
        {
            bd.Borrar(dato);
        }

        public Empresas Buscar(string dato)
        {
            throw new NotImplementedException();
        }

        public List<Empresas> BuscarEspecial(string dato)
        {
            return bd.BuscarEspecial(dato);
        }

        public void Modificar(Empresas dato)
        {
            bd.Modificar(dato);
        }

        public int traerSigID()
        {
            throw new NotImplementedException();
        }
    }
}
