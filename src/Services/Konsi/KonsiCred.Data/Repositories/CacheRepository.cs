using KonsiCred.Domain;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;


namespace KonsiCred.Data
{
    public class CacheRepository : ICacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        public CacheRepository(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        public async Task InserirValor<T>(string cpf, T obj)
        {
            var key = cpf.ToLower();
            var newValue = JsonConvert.SerializeObject(obj);

            await _distributedCache.SetStringAsync(key, newValue);
        }

        public async Task<T> ObterValor<T>(string cpf)
        {
            var key = cpf.ToLower();

            var result = await _distributedCache.GetStringAsync(key);

            if (result == null)
                return default;

            return JsonConvert.DeserializeObject<T>(result);

        }
    }
}
