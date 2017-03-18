using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class BdConceptosCaja : IDAO<ConceptosCaja>
    {
        Acceso_BD oacceso = new Acceso_BD();
        public void Agregar(ConceptosCaja dato)
        {
            throw new NotImplementedException();
        }

        public List<ConceptosCaja> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public void Borrar(ConceptosCaja dato)
        {
            throw new NotImplementedException();
        }

        public ConceptosCaja Buscar(string dato)
        {
            throw new NotImplementedException();
        }

        public List<ConceptosCaja> BuscarEspecial(string dato)
        {
            throw new NotImplementedException();
        }

        public void Modificar(ConceptosCaja dato)
        {
            throw new NotImplementedException();
        }

        public int traerSigID()
        {
            throw new NotImplementedException();
        }
    }
}
