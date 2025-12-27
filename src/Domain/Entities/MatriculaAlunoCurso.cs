using SistemaAcademicoMonolitico.src.Domain.Enum;

namespace SistemaAcademicoMonolitico.src.Domain.Entities;

public class MatriculaAlunoCurso
{
    public int AlunoId  { get; set; }

    public int CursoId { get; set; }

    public DateOnly DataInicio { get; set; }

    public DateOnly DataFim { get; set; }

    public StatusAlunoCurso Status { get; set; }

    public Aluno Aluno { get; set; }
    
    public Curso Curso { get; set;}
}