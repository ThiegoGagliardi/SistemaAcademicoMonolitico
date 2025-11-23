using SistemaAcademicoMonolitico.Domain.Enums;

namespace SistemaAcademicoMonolitico.src.Domain.Entities;

public class Disciplina
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Codigo { get; set; } = string.Empty;

    public string Sigla { get; set; } = string.Empty;

    public AreaConhecimento AreaConhecimento { get; set; }

    public IList<CursoDisciplina> Cursos { get; set;} = new List<CursoDisciplina>();

     public IList<Formacao> Formacoes { get; set;} = new List<Formacao>();

}