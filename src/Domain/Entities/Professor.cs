namespace SistemaAcademicoMonolitico.src.Domain.Entities;

public class Professor
{
    public int Id { get; set; }
    public string Nome { get; set ;}
    public string RegistroMec { get; set; }
    public double Pontuacao { get; set; }
    public DateOnly DataContratacao { get; set;}
    public List<ProfessorFormacao> Formacoes { get; set; } = new();

    public List<GradeHoraria> Horarios { get; set; } = new();
}
