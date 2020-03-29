using System;
using System.Collections.Generic;
using System.Linq;
using Interface;

namespace Dado
{
    public class EmprestimoDado : IEmprestimoDado
    {
        public int Id { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public ILivroDado Livro { get; set; }
        public IPessoaDado Pessoa { get; set; }

        public IEmprestimoDado BuscarEmprestimo(int id, List<IEmprestimoDado> listaEmprestimo)
        {
            return listaEmprestimo.Where(x => x.GetId() == id).FirstOrDefault();
        }

        public void RealizarEmprestimo(int id, DateTime data, ILivroDado l, IPessoaDado p)
        {
            Id = id;
            DataEmprestimo = data;
            Livro = l;
            Pessoa = p;
        }

        public int GetId()
        {
            return Id;
        }

        public ILivroDado GetLivro()
        {
            return Livro;
        }

        public IPessoaDado GetPessoa()
        {
            return Pessoa;
        }

        public IEmprestimoDado BuscarLivroEmprestimo(ILivroDado livro, List<IEmprestimoDado> emprestimos)
        {
            return emprestimos.Where(x => x.GetLivro() == livro).FirstOrDefault();
        }

        public IEmprestimoDado BuscarPessoaEmprestimo(IPessoaDado pessoa, List<IEmprestimoDado> emprestimos)
        {
            return emprestimos.Where(x => x.GetPessoa() == pessoa).FirstOrDefault();
        }
    }
}
