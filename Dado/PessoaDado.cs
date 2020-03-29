using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interface;

namespace Dado
{
    public class PessoaDado : IPessoaDado
    {
        public int CPF { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public PessoaDado()
        {

        }

        public PessoaDado(int c, string n,string m)
        {
            CPF = c;
            Nome = n;
            Email = m;
        }

        public IPessoaDado BuscarPessoa(int cpf, List<IPessoaDado> listaPessoa)
        {
            return listaPessoa.Where(x => x.GetCPF() == cpf).FirstOrDefault();
        }

        public int GetCPF()
        {
            return CPF;
        }

        public void ImprimirPessoaDado()
        {
            Console.WriteLine($"\nNome: {Nome}\nCPF: {CPF}\nEmail: {Email}");
        }
    }
}
