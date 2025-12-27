using SistemaAcademicoMonolitico.src.Domain.Enum;

namespace SistemaAcademicoMonolitico.src.Domain.Entities;

public class AlunoCursoDisciplina
{
    public int AlunoId  { get; set; }

    public int CursoId { get; set; }

    public int DisciplinaId { get; set; }

    public DateOnly DataInicio { get; set; }

    public DateOnly DataFim { get; set; }    

    public StatusAlunoDisciplina Status { get; set; }

    public decimal Nota { get; set;}

    public Aluno Aluno { get; set; }

    public Curso Curso { get; set;}

    public Disciplina Disciplina { get; set;}
}