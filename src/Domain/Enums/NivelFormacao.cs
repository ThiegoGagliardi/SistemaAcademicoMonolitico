namespace SistemaAcademicoMonolitico.Domain.Enums;

public enum NivelFormacao
{
    // 0 - Pode ser usado como valor padrão (não especificado)
    NaoEspecificado = 0,

    // Nível Fundamental e Médio (para fins de registro básico, se necessário)
    EnsinoMedio = 1,
    EnsinoTecnico = 2,

    // Nível Superior
    SuperiorGraduacao = 3,

    // Nível Pós-Graduação (Lato Sensu - Especialização / MBA)
    PosGraduacaoLatoSensu = 4,
    MBA = 5,
    Especializacao = 6, // Pode ser mantido separado ou englobado em LatoSensu

    // Nível Pós-Graduação (Stricto Sensu - Mestrado / Doutorado)
    Mestrado = 7,
    Doutorado = 8,
    PosDoutorado = 9
}