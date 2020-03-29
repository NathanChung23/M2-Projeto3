using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    public interface IEmprestimoDado
    {
        IEmprestimoDado BuscarEmprestimo(int id, List<IEmprestimoDado> listaEmprestimo);

        void RealizarEmprestimo(int id, DateTime data, ILivroDado l, IPessoaDado p);

        int GetId();

        ILivroDado GetLivro();

        IEmprestimoDado BuscarLivroEmprestimo(ILivroDado livro, List<IEmprestimoDado> emprestimos);

        IPessoaDado GetPessoa();

        IEmprestimoDado BuscarPessoaEmprestimo(IPessoaDado pessoa, List<IEmprestimoDado> emprestimos);
    }
}
