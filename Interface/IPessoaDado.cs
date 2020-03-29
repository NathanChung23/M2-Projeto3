using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    public interface IPessoaDado
    {
        IPessoaDado BuscarPessoa(int cpf, List<IPessoaDado> listaPessoa);

        int GetCPF();

        void ImprimirPessoaDado();
    }
}
