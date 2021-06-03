using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueLivros.Interface
{
    public interface IRepository<T>
    {
        List<T> Listar();
        T RetornaPorId(int id);
        bool Inserir(T entidade);
        bool Excluir(int id);
        bool Atualizar(int id, T entidade);
        int ProximoId();
    }
}
