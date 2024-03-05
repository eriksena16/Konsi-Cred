using System.ComponentModel.DataAnnotations;

namespace KonsiCred.Application
{
    public class LoginUser
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string username { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string password { get; set; }
    }
}
