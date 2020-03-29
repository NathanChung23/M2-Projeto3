using System;
using System.Collections.Generic;
using System.Text;
using Interface;
using Dado;
using BibliotecaNegocio;


namespace M2_Projeto3
{
    public class Program
    {
        public static List<IPessoaDado> pessoas = new List<IPessoaDado>();
        public static List<ILivroDado> livros = new List<ILivroDado>();
        public static List<IEmprestimoDado> emprestimos = new List<IEmprestimoDado>();
        static void Main(string[] args)
        {
            int menu = 0;
            do
            {
                try
                {
                    Menu();
                    menu = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.Write("Tente novamente!!");
                }
                switch (menu)
                {
                    case 11:
                        CadastrarLivro();
                        break;
                    case 12:
                        PesquisarLivro();
                        break;
                    case 13:
                        ExcluirLivro();
                        break;
                    case 21:
                        CadastrarPessoa();
                        break;
                    case 22:
                        PesquisarPessoa();
                        break;
                    case 23:
                        ExcluirPessoa();
                        break;
                    case 3:
                        AlugarLivro();
                        break;
                    case 4:
                        DevolverLivro();
                        break;
                    default:
                        break;
                }

            } while (menu != 5);
        }

        static void Menu()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("\nMENU");
            builder.Append("\nLivro");
            builder.Append("\n11 - Cadastrar Livro");   
            builder.Append("\n12 - Pesquisar Livro");   
            builder.Append("\n13 - Excluir Livro");
            builder.Append("\nPessoa");
            builder.Append("\n21 - Cadastrar Pessoa");
            builder.Append("\n22 - Pesquisar Pessoa");
            builder.Append("\n23 - Excluir Pessoa");
            builder.Append("\n3 - Alugar Livro");
            builder.Append("\n4 - Devolver Livro");
            builder.Append("\n5 - Sair");

            Console.WriteLine(builder.ToString());
        }

        static void CadastrarLivro()
        {
            string titulo, autor;
            do
            {
            Console.Write("Informe o titulo: ");
            titulo = Console.ReadLine();
            } while (string.IsNullOrEmpty(titulo));

            do
            {
            Console.Write("Informe o autor: ");
            autor = Console.ReadLine();
            } while (string.IsNullOrEmpty(autor));

            ILivroDado livro = new LivroDado(livros.Count, titulo, autor);
            livros.Add(livro);
            Console.WriteLine("Livro Cadastrado!!");
        }

        static void PesquisarLivro()
        {
            Negocio negocio = new Negocio();
            ILivroDado livro;

            do
            {
                livro = new LivroDado();

                Console.Write("Digite o tombo para Pesquisa: ");
                int tombo = Convert.ToInt32(Console.ReadLine());

                livro = negocio.BuscarLivro(livro, tombo, livros);
                if (livro == null)
                    Console.WriteLine("Livro invalido, tente novamente!!");
            } while (livro == null);
            livro.ImprimirLivroDado();
        }

        static void ExcluirLivro()
        {
            Negocio negocio = new Negocio();
            IEmprestimoDado emprestimo;
            ILivroDado livro;

            do
            {
                livro = new LivroDado();
                Console.Write("Digite o tombo para Excluir: ");
                int tombo = Convert.ToInt32(Console.ReadLine());

                livro = negocio.BuscarLivro(livro, tombo, livros);

                if (livro == null)
                    Console.WriteLine("Livro invalido, tente novamente!!");

            } while (livro == null);
            emprestimo = new EmprestimoDado();

            emprestimo = negocio.BuscarLivroEmprestimo(emprestimo, livro, emprestimos);

            if (emprestimo == null)
            {
                livros.Remove(livro);
                Console.WriteLine("Livro removido com sucesso!!");
            }
            else
                Console.WriteLine("Livro sendo usado!!");

        }

        static void CadastrarPessoa()
        {
            string nome, email;
            int cpf;
            do
            {
                Console.Write("Informe o nome: ");
                nome = Console.ReadLine();
            } while (string.IsNullOrEmpty(nome));

            Console.Write("Informe o CPF: ");
            cpf = Convert.ToInt32(Console.ReadLine());

            do
            {
                Console.Write("Informe o email: ");
                email = Console.ReadLine();
            } while (string.IsNullOrEmpty(email));

            IPessoaDado pessoa = new PessoaDado(cpf, nome, email);
            pessoas.Add(pessoa);

            Console.WriteLine("Cadastro Realizado");
        }

        static void PesquisarPessoa()
        {
            Negocio negocio = new Negocio();
            IPessoaDado pessoa;

            int cpf;
            do
            {
                pessoa = new PessoaDado();

                Console.Write("Informe o CPF: ");
                cpf = Convert.ToInt32(Console.ReadLine());

                pessoa = negocio.BuscarPessoa(pessoa, cpf, pessoas);

                if (pessoa == null)
                    Console.WriteLine("Pessoa invalida, tente novamente!!");
            } while (pessoa == null);

            pessoa.ImprimirPessoaDado();
        }

        static void ExcluirPessoa()
        {
            Negocio negocio = new Negocio();
            IEmprestimoDado emprestimo;
            IPessoaDado pessoa;
            int cpf;

            do
            {
                pessoa = new PessoaDado();

                Console.Write("Informe o CPF: ");
                cpf = Convert.ToInt32(Console.ReadLine());

                pessoa = negocio.BuscarPessoa(pessoa, cpf, pessoas);

                if (pessoa == null)
                    Console.WriteLine("Pessoa invalida, tente novamente!!");
            } while (pessoa == null);
            emprestimo = new EmprestimoDado();

            emprestimo = negocio.BuscarPessoaEmprestimo(emprestimo, pessoa, emprestimos);
            if (emprestimo == null)
            {
                pessoas.Remove(pessoa);
                Console.WriteLine("Pessoa excluida com sucesso!!");
            }
            else
                Console.WriteLine("Pessoa possui um emprestimo!!");
        }

        static void AlugarLivro()
        {
            Negocio biblioteca = new Negocio();
            IEmprestimoDado emprestimo = new EmprestimoDado();
            IPessoaDado pessoaDado;
            ILivroDado livroDado;

            do
            {
                pessoaDado = new PessoaDado();
                livroDado = new LivroDado();

                Console.Write("Informe o cpf: ");
                int cpf = Convert.ToInt32(Console.ReadLine());
                Console.Write("Informe o tombo do livro: ");
                int tombo = Convert.ToInt32(Console.ReadLine());

                pessoaDado = biblioteca.BuscarPessoa(pessoaDado, cpf, pessoas);
                livroDado = biblioteca.BuscarLivro(livroDado, tombo, livros);

            } while (pessoaDado == null || livroDado == null);
            emprestimos.Add(biblioteca.Emprestar(livroDado, pessoaDado, emprestimo, emprestimos));

            Console.WriteLine("Emprestimo realizado!!");
        }

        static void DevolverLivro()
        {
            Negocio negocio = new Negocio();
            IEmprestimoDado emprestimo;
            do
            {
                emprestimo = new EmprestimoDado();
                Console.Write("Informe o ID do emprestimo: ");
                int id = Convert.ToInt32(Console.ReadLine());

                emprestimo = negocio.BuscarEmprestimo(emprestimo, id, emprestimos);
                if (emprestimo == null)
                    Console.WriteLine("Emprestimo nao existe, tente novamente!!");
            } while (emprestimo == null);
            emprestimos.Remove(emprestimo);
            Console.WriteLine("Devolução realizada com sucesso!!"); ;

        }
    }
}
