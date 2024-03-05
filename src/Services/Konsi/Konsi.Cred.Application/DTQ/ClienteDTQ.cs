using System.ComponentModel.DataAnnotations;

namespace KonsiCred.Application
{
    public class ClienteDTQ
    {
        [Required(ErrorMessage = "O Campo {0} é Obrigatório")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "O CPF deve conter exatamente 11 dígitos numéricos")]
        public string Cpf { get; set; }
    }
}
