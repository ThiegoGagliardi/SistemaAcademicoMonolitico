namespace SistemaAcademicoMonolitico.src.DTOs;

public class FormacaoRetornoDTO
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Instituicao { get; set; } = string.Empty;

    public string Nivel { get; set;} = string.Empty;

    public string AreaConhecimento { get; set; } = string.Empty;    

    public decimal ValorPontuacao { get; set; }
}