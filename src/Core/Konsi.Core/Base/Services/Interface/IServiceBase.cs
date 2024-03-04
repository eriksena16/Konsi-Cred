using Konsi.Core.Extensions;

namespace Konsi.Core
{
    public interface IServiceBase<TEntity, GFilter, TEntityDTO, TEntityDTQ> where TEntity : Entity, new() where TEntityDTO : Entity
    {
        Task<TEntityDTO> AddAsync(TEntityDTQ objeto);
        Task<QueryBaseResponse<TEntityDTO>> GetAsync(GFilter filter);
        Task<TEntityDTO> GetIdAsync(long id);
        TEntity GetAsNoTrackingId(long id);
        //Task PatchAsync(long id, ExpandoObject patch);
        Task UpdateAsync(long id, TEntityDTQ objeto);
        Task DeleteAsync(long id);

    }
}
