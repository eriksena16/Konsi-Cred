using Konsi.Core.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Konsi.Core
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity, new()
    {
        private readonly DbSet<TEntity> DbSet;
        private readonly DbContext _context;
        protected readonly long ContaId;
        public RepositoryBase(DbContext context, IUsuario usuario)
        {
            _context = context;
            DbSet = context.Set<TEntity>();
            ContaId = usuario.GetAccountId();
        }
        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate) => await DbSet.AsNoTrackingWithIdentityResolution().Where(predicate).ToListAsync();

        public virtual async Task<List<TEntity>> ObterLista() => await DbSet.Where(c => c.ContaId == ContaId).ToListAsync();

        public virtual async Task<TEntity> ObterPorId(long id) => await DbSet.FindAsync(id);
        public virtual async Task<TEntity> ObterPorIdAsNoTracking(long id) => await DbSet.AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync(e => e.Id.Equals(id));

        //public async Task<QueryBaseResponse<TEntity>> GetResponseAsync(IQueryable<TEntity> query, GFilter filter, IQueryable<TEntity> includeQuery = null)
        //{
        //if (filter.Id.Any())
        //    query = query.Where(c => filter.Id.Contains(c.Id));

        //if (filter.ExcludeId.Any())
        //    query = query.Where(c => !filter.ExcludeId.Contains(c.Id));

        // Order By
        //query = query.ApplyOrdering(filter);

        //var result = new QueryBaseResponse<TEntity>(filter)
        //{
        //    TotalItems = await query.CountAsync()
        //};

        // Pagination
        //if (filter.GetAll != true)
        //    query = query.ApplyPaging(filter);

        //result.Items = await query.ToListAsync();

        //if (filter.IncludeId.Any())
        //{
        //    var alreadyIn = result.Items.Select(c => c.Id).ToList();
        //    var newQuery = includeQuery ?? entities;
        //    var included = newQuery.Where(c => filter.IncludeId.Contains(c.Id) && !alreadyIn.Contains(c.Id)).ToList();
        //    result.Items = result.Items.Concat(included);
        //}

        //    return result;
        //}
        public virtual async Task<bool> Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            return await SaveChanges() > 0;
        }
        public virtual async Task<bool> Atualizar(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return await SaveChanges() > 0;
        }
        public virtual async Task Excluir(long id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges() => await _context.SaveChangesAsync();

        public void Dispose() =>
       _context?.Dispose();
    }
}
