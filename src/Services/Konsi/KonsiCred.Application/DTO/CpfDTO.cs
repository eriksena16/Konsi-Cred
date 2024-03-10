using Konsi.Core;
using System.ComponentModel.DataAnnotations;

namespace KonsiCred.Application
{
    public class CpfDTO(string cpf)
    {
        [Required(ErrorMessage = "O Campo {0} é Obrigatório")]
        public string Cpf { get; private set; } = cpf;

        public void ValidarCPF()
        {
            if (!string.IsNullOrEmpty(Cpf))
            {
                if (!Cpf.IsCpfValid())
                    Cpf = Cpf.FormatCPF();
            }
        }

        public override string ToString()
        {
            return Cpf;
        }
    }
}
