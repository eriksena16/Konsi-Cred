namespace KonsiCred.Application
{
    public interface IElasticsearchService<T>
    {
        Task<bool> CriarDocumentoAsync(T documento);
        Task<T> ObterDocumentoAsync(string cpf);

    }
}
