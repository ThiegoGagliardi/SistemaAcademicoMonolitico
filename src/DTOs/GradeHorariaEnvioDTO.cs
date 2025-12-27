namespace SistemaAcademicoMonolitico.src.DTOs;

public class GradeHorariaEnvioDTO
{
    public int CursoId { get; set; }

    public int DisciplinaId { get; set; }

    public int ProfessorId { get; set; }

    public string Dia { get; set; } = string.Empty;

    public string HoraInicio { get; set; } = string.Empty;

    public string HoraFim { get; set; } = string.Empty;
    
    public string Duracao { get; set; } = string.Empty;

}
