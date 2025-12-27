using SistemaAcademicoMonolitico.Domain.Enums;

namespace SistemaAcademicoMonolitico.src.Domain.Entities;

public class Formacao
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Instituicao { get; set; } = string.Empty;

    public NivelFormacao Nivel { get; set;}

    public AreaConhecimento AreaConhecimento { get; set; }    

    public double ValorPontuacao { get; set; }

    public IList<Disciplina> Disciplinas { get; set;} = new List<Disciplina>();

    public IList<ProfessorFormacao> Professores { get; set;} = new List<ProfessorFormacao>();

}
