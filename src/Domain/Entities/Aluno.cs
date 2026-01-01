namespace SistemaAcademicoMonolitico.src.Domain.Entities;

public class Aluno
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string RA { get; set; } = string.Empty;

    public IList<MatriculaAlunoCurso> Matriculas { get; set; }  = new List<MatriculaAlunoCurso>();

    public IList<AlunoCursoDisciplina> Disciplinas { get; set; }  = new List<AlunoCursoDisciplina>();

    public IList<AlunoCursoDisciplinaNota> Notas { get; set; }  = new List<AlunoCursoDisciplinaNota>();

}