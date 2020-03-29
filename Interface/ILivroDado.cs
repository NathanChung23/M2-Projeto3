using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    public interface ILivroDado
    {
        int GetTombo();

        ILivroDado BuscarLivro(int tombo, List<ILivroDado> listLivro);

        void ImprimirLivroDado();
    }
}
