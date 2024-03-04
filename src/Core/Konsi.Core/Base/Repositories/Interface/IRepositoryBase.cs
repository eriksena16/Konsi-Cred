using System.Linq.Expressions;

namespace Konsi.Core.Repositories.Interface
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : Entity
    {
        Task<List<TEntity>> ObterLista();
        Task<TEntity> ObterPorId(long id);
        Task<TEntity> ObterPorIdAsNoTracking(long id);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<bool> Adicionar(TEntity objeto);
        Task<bool> Atualizar(TEntity objeto);
        Task Excluir(long id);
        Task<int> SaveChanges();
    }
}
