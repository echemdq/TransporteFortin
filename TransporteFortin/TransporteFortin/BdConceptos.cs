using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class BdConceptos :IDAO<Conceptos>
    {
        Acceso_BD oacceso = new Acceso_BD();
        public void Agregar(Conceptos dato)
        {
            throw new NotImplementedException();
        }

        public List<Conceptos> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public void Borrar(Conceptos dato)
        {
            throw new NotImplementedException();
        }

        public Conceptos Buscar(string dato)
        {
            throw new NotImplementedException();
        }

        public List<Conceptos> BuscarEspecial(string dato)
        {
            throw new NotImplementedException();
        }

        public void Modificar(Conceptos dato)
        {
            throw new NotImplementedException();
        }

        public int traerSigID()
        {
            throw new NotImplementedException();
        }
    }
}
