using EstoqueLivros.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueLivros.Classes
{
    public class LivroRepository : IRepository<Livro>
    {
        private readonly List<Livro> _livros = new List<Livro>() {
                    new Livro(1,"teste nome 1",100,"autor teste 1",1,"editora teste 1",Enum.Idioma.portugues),
                    new Livro(2,"teste nome 2",200,"autor teste 2",2,"editora teste 2",Enum.Idioma.portugues)
                };
        public bool Atualizar(int id, Livro entidade)
        {
            var novaEntidade = new Livro(id, entidade);
            var livro = _livros.FirstOrDefault(l => l.Id == novaEntidade.Id);
            livro.Autor = novaEntidade.Autor;
            livro.Edicao = novaEntidade.Edicao;
            livro.Idioma = novaEntidade.Idioma;
            livro.Nome = novaEntidade.Nome;
            livro.NumeroPaginas = novaEntidade.NumeroPaginas;

            return _livros.Contains(novaEntidade);
        }

        public bool Excluir(int id)
        {
            var livro = _livros.Find(l => l.Id == id);
            return _livros.Remove(livro);
        }

        public bool Inserir(Livro entidade)
        {
            _livros.Add(entidade);
            return _livros.Contains(entidade);
        }

        public List<Livro> Listar()
        {
            return _livros.ToList();
        }

        public int ProximoId()
        {
           return _livros.Max(l => l.Id)+1;
        }

        public Livro RetornaPorId(int id)
        {
           return _livros.Find(l => l.Id == id);
        }
    }
}
