using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interface;

namespace Dado
{
    public class LivroDado : ILivroDado
    {
        public int Tombo { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }

        public LivroDado()
        {

        }

        public LivroDado(int i, string t, string autor)
        {
            Tombo = i;
            Titulo = t;
            Autor = autor;
        }

        public ILivroDado BuscarLivro(int tombo, List<ILivroDado> listaLivro)
        {
            return listaLivro.Where(x => x.GetTombo() == tombo).FirstOrDefault();
        }

        public int GetTombo()
        {
            return Tombo;
        }

        public void ImprimirLivroDado()
        {
            Console.WriteLine("\nTombo: {2}\nTitulo: {0}\nAutor: {1}",Titulo, Autor, Tombo);
        }
    }
}
