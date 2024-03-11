namespace KonsiCred.Application
{
    public interface IElasticsearchService
    {
        Task<bool> CriarDocumentoAsync(ClienteDTO documento);
        Task<ClienteDTO> ObterDocumentoAsync(string cpf);

    }
}
