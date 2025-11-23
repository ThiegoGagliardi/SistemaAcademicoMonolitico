using SistemaAcademicoMonolitico.src.DTOs;
using SistemaAcademicoMonolitico.src.Domain.Entities;
using SistemaAcademicoMonolitico.src.Factories.Interfaces;
using SistemaAcademicoMonolitico.Domain.Enums;

namespace SistemaAcademicoMonolitico.src.DTOs;

public class GradeHorariaRetornoDTO
{
    public string Curso { get; set; } = string.Empty;

    public string AreaConehcimentoCurso { get; set; } = string.Empty;

    public string Disciplina { get; set; } = string.Empty;      

    public string CodigoDisciplina { get; set; } = string.Empty;

    public string SiglaDisciplina { get; set; } = string.Empty;    

    public string AreaConehcimentoDisciplina { get; set; } = string.Empty;

    public string Professor { get; set; } = string.Empty;

    public string Dia { get; set; } = string.Empty;

    public string HoraInicio { get; set; } = string.Empty;

    public string HoraFim { get; set; } = string.Empty;
    
    public string Duracao { get; set; } = string.Empty;
}
