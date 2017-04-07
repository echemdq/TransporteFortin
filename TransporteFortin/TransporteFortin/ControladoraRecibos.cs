using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class ControladoraRecibos : IDAO<Recibos>
    {
        BdRecibos bd = new BdRecibos();
        public void Agregar(Recibos dato)
        {
            //bd.Agregar(dato);
        }

        public List<Recibos> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public void Borrar(Recibos dato)
        {
            throw new NotImplementedException();
        }

        public Recibos Buscar(string dato)
        {
            throw new NotImplementedException();
        }

        public List<Recibos> BuscarEspecial(string dato)
        {
            throw new NotImplementedException();
        }

        public void Modificar(Recibos dato)
        {
            throw new NotImplementedException();
        }

        public int traerSigID()
        {
            throw new NotImplementedException();
        }
    }
}
