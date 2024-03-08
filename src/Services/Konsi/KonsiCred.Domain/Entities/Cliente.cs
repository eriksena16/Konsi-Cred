
using System.Collections.Generic;

public class Cliente
{
    public Cliente(string cpf, List<Beneficio> beneficios)
    {
        Cpf = cpf;
        Beneficios = beneficios;
    }
    public string Cpf { get; private set; }
    public List<Beneficio> Beneficios { get; private set; }
}
