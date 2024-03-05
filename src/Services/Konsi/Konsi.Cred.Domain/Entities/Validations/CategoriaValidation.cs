//using FluentValidation;

//namespace AssetTrack.Patrimony.Domain
//{
//    public class CategoriaValidation : AbstractValidator<Categoria>
//    {
//        public CategoriaValidation()
//        {
//            RuleFor(p => p.Nome)
//                .NotEmpty()
//                    .WithMessage("O campo nome precisa ser fornecido")
//                .Length(min: 2, max: 100)
//                    .WithMessage("O campo nome precisa ter entre {MinLength} e {MaxLength} caracteres");
//        }
//    }
//}
