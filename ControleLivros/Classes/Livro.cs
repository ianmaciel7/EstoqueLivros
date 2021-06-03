using ControleLivros.Classes;
using EstoqueLivros.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueLivros.Classes
{
    public class Livro : EntidadeBase
    {
        public string Nome { get; set; }
        public int NumeroPaginas { get; set; }
        public string Autor { get; set; }
        public int Edicao { get; set; }
        public string Editora { get; set; }
        public Idioma Idioma { get; set; }

        public Livro(int id,string nome, int numeroPagina, string autor, int edicao, string editora, Idioma idioma)
        {
            Id = id;
            Nome = nome;
            NumeroPaginas = numeroPagina;
            Autor = autor;
            Edicao = edicao;
            Editora = editora;
            Idioma = idioma;
        }

        public Livro(int id,Livro l)
        {
            Id = id;
            Nome = l.Nome;
            NumeroPaginas = l.NumeroPaginas;
            Autor = l.Autor;
            Edicao = l.Edicao;
            Editora = l.Editora;
            Idioma = l.Idioma;
        }

        public override string ToString()
        {
            return $"{{{nameof(Nome)}={Nome}, {nameof(NumeroPaginas)}={NumeroPaginas}, {nameof(Autor)}={Autor}, {nameof(Edicao)}={Edicao.ToString()}, {nameof(Editora)}={Editora}, {nameof(Idioma)}={Idioma}, {nameof(Id)}={Id}}}";
        }
    }
}
