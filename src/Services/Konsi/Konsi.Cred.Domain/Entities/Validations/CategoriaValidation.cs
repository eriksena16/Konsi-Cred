using FluentValidation;
using KonsiCred.Domain.Entities;

namespace AssetTrack.Patrimony.Domain
{
    public class ClienteValidation : AbstractValidator<Response<Cliente>>
    {
        public ClienteValidation()
        {
            RuleFor(p => p.Success)
                .NotEqual(false)
                    .WithMessage("O campo nome precisa ser fornecido")
                .Length(min: 2, max: 100)
                    .WithMessage("O campo nome precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
