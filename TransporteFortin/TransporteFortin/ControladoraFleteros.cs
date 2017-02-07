using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class ControladoraFleteros : IDAO<Fleteros>
    {
        BdFleteros bd = new BdFleteros();
        public void Agregar(Fleteros dato)
        {
            bd.Agregar(dato);
        }

        public List<Fleteros> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public void Borrar(Fleteros dato)
        {
            bd.Borrar(dato);
        }

        public Fleteros Buscar(string dato)
        {
            throw new NotImplementedException();
        }

        public List<Fleteros> BuscarEspecial(string dato)
        {
            throw new NotImplementedException();
        }

        public void Modificar(Fleteros dato)
        {
            bd.Modificar(dato);
        }

        public int traerSigID()
        {
            throw new NotImplementedException();
        }
    }
}
