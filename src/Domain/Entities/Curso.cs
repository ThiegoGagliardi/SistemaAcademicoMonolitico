using SistemaAcademicoMonolitico.Domain.Enums;

namespace SistemaAcademicoMonolitico.src.Domain.Entities;

public class Curso
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public AreaConhecimento AreaConhecimento { get; set;}

    public IList<CursoDisciplina> Disciplinas { get; set;} = new List<CursoDisciplina>();

    public List<GradeHoraria> Horarios { get; set; } = new();

}