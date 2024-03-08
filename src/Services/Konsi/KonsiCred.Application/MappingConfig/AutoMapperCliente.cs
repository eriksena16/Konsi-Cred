namespace KonsiCred.Application
{
    public static class AutoMapperCliente
    {
        public static ClienteDTO ParaClienteDTO(this Cliente cliente) => new(
            cliente.Cpf.ToString(),
            cliente.Beneficios.ParaListaBeneficioDTO());

    }
}
