namespace SistemaAcademicoMonolitico.src.Domain.Entities;

public class Aluno
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string RA { get; set; } = string.Empty;

    public IList<MatriculaAlunoCurso> Matriculas { get; set; }  = new List<MatriculaAlunoCurso>();

}