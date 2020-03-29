using System;
using System.Collections.Generic;
using System.Linq;
using Interface;

namespace BibliotecaNegocio
{
    public class Negocio
    {
        public IEmprestimoDado Emprestar(ILivroDado livro, IPessoaDado pessoa, IEmprestimoDado emprestimo, List<IEmprestimoDado> listaEmprestimo)
        {
            DateTime dataEmprestimo = DateTime.Now;
            emprestimo.RealizarEmprestimo(listaEmprestimo.Count, dataEmprestimo, livro, pessoa);
            return emprestimo;
        }

        public IEmprestimoDado BuscarEmprestimo(IEmprestimoDado emprestimo, int id, List<IEmprestimoDado> listaEmprestimo)
        {
            return emprestimo.BuscarEmprestimo(id, listaEmprestimo);
        }

        public ILivroDado BuscarLivro(ILivroDado livro, int tombo, List<ILivroDado> listLivro)
        {
            return livro.BuscarLivro(tombo, listLivro);
        }

        public IPessoaDado BuscarPessoa(IPessoaDado pessoa, int cpf, List<IPessoaDado> listaPessoa)
        {
            return pessoa.BuscarPessoa(cpf, listaPessoa);
        }

        public IEmprestimoDado BuscarLivroEmprestimo(IEmprestimoDado emprestimo, ILivroDado livro, List<IEmprestimoDado> emprestimos)
        {
            return emprestimo.BuscarLivroEmprestimo(livro, emprestimos);
        }

        public IEmprestimoDado BuscarPessoaEmprestimo(IEmprestimoDado emprestimo, IPessoaDado pessoa, List<IEmprestimoDado> emprestimos)
        {
            return emprestimo.BuscarPessoaEmprestimo(pessoa, emprestimos);
        }
    }
}
