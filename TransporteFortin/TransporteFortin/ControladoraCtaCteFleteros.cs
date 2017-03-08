using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteFortin
{
    public class ControladoraCtaCteFleteros : IDAO<CtaCteFleteros>
    {
        BdCtaCteFleteros bd = new BdCtaCteFleteros();

        public void Agregar(CtaCteFleteros dato)
        {
            throw new NotImplementedException();
        }

        public List<CtaCteFleteros> TraerTodos()
        {
            throw new NotImplementedException();
        }

        public void Borrar(CtaCteFleteros dato)
        {
            throw new NotImplementedException();
        }

        public CtaCteFleteros Buscar(string dato)
        {
            throw new NotImplementedException();
        }

        public List<CtaCteFleteros> BuscarEspecial(string dato)
        {
            return bd.BuscarEspecial(dato);
        }

        public void Modificar(CtaCteFleteros dato)
        {
            throw new NotImplementedException();
        }

        public int traerSigID()
        {
            throw new NotImplementedException();
        }
    }
}
