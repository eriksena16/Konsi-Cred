namespace KonsiCred.Application
{
    public interface IClienteService
    {
        Task<ClienteDTO> BuscarClienteKonsi(string cpf);
        Task<ClienteDTO> BuscarCliente(CpfDTO cpf);
    }
}
