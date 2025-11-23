namespace SistemaAcademicoMonolitico.src.DTOs;

public class ProfessorFormacaoDTO
{
    public int ProfessorId { get; set; }

    public int FormacaoId { get; set;}

    public DateOnly Inicio { get; set; }

    public DateOnly Termino { get; set; }
}