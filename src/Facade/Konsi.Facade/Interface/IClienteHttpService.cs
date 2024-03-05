namespace KonsiCred.Facade
{
    public interface IClienteHttpService
    {
        Task<ClienteDTO> ObterPorCpf(long cpf);
    }
}
