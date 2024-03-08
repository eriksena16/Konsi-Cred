namespace KonsiCred.Application
{
    public interface IClienteService
    {
        Task<ClienteDTO> BuscarPorCpf(string cpf);
    }
}
