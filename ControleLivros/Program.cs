using EstoqueLivros.Classes;
using EstoqueLivros.Enum;
using EstoqueLivros.Interface;
using System;
using System.Linq;

namespace ControleLivros
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo!!!");
            RedirecionarParaOpcaoEscolhida();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("1 - Listar livro");
            Console.WriteLine("2 - Inserir novo livro");
            Console.WriteLine("3 - Atualizar livro");
            Console.WriteLine("4 - Excluir livro");
            Console.WriteLine("5 - Visualizar livro");
            Console.WriteLine("6 - Limpar tela");
            Console.WriteLine("7 - Sair");
            Console.WriteLine();

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }

        private static void RedirecionarParaOpcaoEscolhida()
        {
            IRepository<Livro> repository = new LivroRepository();
            Livro l; int id; string opcao;

            do
            {
                opcao = ObterOpcaoUsuario();
                switch (opcao)
                {
                    case "1":
                        ListarLivro(repository);
                        break;

                    case "2":
                        l = CapturarLivro(repository);
                        if (l != null) InserirLivro(repository, l);
                        else MensagemNaTela("Opção escolhida inválida");
                        break;

                    case "3":
                        id = CapturarId();
                        if (repository.RetornaPorId(id) != null)
                        {
                            l = CapturarLivro(repository);
                            if (l != null) AtualizarLivro(repository, id, l);
                        }
                        else
                        {
                            Console.WriteLine("Id invalido \nimpossível atualizar \n\n");
                        }
                        break;

                    case "4":
                        id = CapturarId();
                        ExcluirLivro(repository, id);
                        break;

                    case "5":
                        id = CapturarId();
                        VisualizarLivro(repository, id);
                        break;

                    case "6":
                        LimparTela();
                        break;

                    case "8":
                        Sair();
                        break;

                    default:
                        MensagemNaTela("Opção escolhida inválida");
                        break;
                }
            } while (opcao != "8");
        }

        private static void MensagemNaTela(string texto)
        {
            Console.WriteLine("--- " + texto + " ---");

        }

        private static void Sair()
        {
            Console.WriteLine("--- Sair ---");
        }

        private static void LimparTela()
        {
            Console.WriteLine("--- Limpar Tela ---");
            Console.Clear();
        }

        private static void VisualizarLivro(IRepository<Livro> repository, int id)
        {
            Console.WriteLine("--- Visualizar ---");
            var livro = repository.RetornaPorId(id);
            if (livro != null) Console.WriteLine(livro);
            else Console.WriteLine("id invalido");

        }

        private static void ExcluirLivro(IRepository<Livro> repository, int id)
        {
            Console.WriteLine("--- Excluir ---");
            var teveSucesso = repository.Excluir(id);
            if (teveSucesso) Console.WriteLine("sucesso na exclusão");
            else Console.WriteLine("falhou na exclusão");
        }

        private static void AtualizarLivro(IRepository<Livro> repository, int id, Livro livro)
        {
            Console.WriteLine("--- Atualizar ---");
            repository.Atualizar(id, livro);
        }

        private static void InserirLivro(IRepository<Livro> repository, Livro livro)
        {
            Console.WriteLine("--- Inserir ---");
            var teveSucesso = repository.Inserir(livro);
            if (teveSucesso) Console.WriteLine("sucesso ao inserir");
            else Console.WriteLine("falhou ao inserir");
        }

        private static void ListarLivro(IRepository<Livro> repository)
        {
            Console.WriteLine("--- Listar ---");
            var lista = repository.Listar();

            if (lista.Any()) lista.ForEach(l => Console.WriteLine(l));
            else Console.WriteLine("lista de livros vazia");
        }

        private static Livro CapturarLivro(IRepository<Livro> repository)
        {
            try
            {
                Console.Write("Nome: ");
                var nome = Console.ReadLine();

                Console.Write("Número Página: ");
                var numeroPagina = int.Parse(Console.ReadLine());

                Console.Write("Autor: ");
                var autor = Console.ReadLine();

                Console.Write("Edição: ");
                var edicao = int.Parse(Console.ReadLine());

                Console.Write("Editora: ");
                var editora = Console.ReadLine();

                Console.WriteLine("Idiomas*");
                Console.WriteLine("       | portugue - 1 ");
                Console.WriteLine("       | ingles - 2 ");
                Console.Write("idioma: ");
                var idioma = (Idioma)int.Parse(Console.ReadLine());

                switch (idioma)
                {
                    case Idioma.portugues:
                        return new Livro(repository.ProximoId(), nome, numeroPagina, autor, edicao, editora, Idioma.portugues);
                    case Idioma.ingles:
                        return new Livro(repository.ProximoId(), nome, numeroPagina, autor, edicao, editora, Idioma.ingles);
                    default:
                        return null;
                }
            }
            catch (System.FormatException)
            {
                Console.Write("Erro: campo númerico recebeu texto");
                return null;
            }

        }

        private static int CapturarId()
        {
            try
            {
                Console.Write("Id: ");
                var id = int.Parse(Console.ReadLine());
                return id;
            }
            catch (Exception)
            {
                return -1;
            }

        }
    }
}
