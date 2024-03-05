namespace KonsiCred.Application
{
    public static class AutoMapperBeneficio
    {
        public static BeneficioDTO ParaBeneficioDTO(this Beneficio beneficio) => new(
           beneficio.Numero_beneficio,
           beneficio.Codigo_tipo_beneficio);

        public static List<BeneficioDTO> ParaListaBeneficioDTO(this List<Beneficio> beneficios) => beneficios.Select(beneficio => beneficio.ParaBeneficioDTO()).ToList();

    }
}
