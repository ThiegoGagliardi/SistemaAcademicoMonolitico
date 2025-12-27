namespace SistemaAcademicoMonolitico.src.DTOs;

public class DisciplinaAtualizaDTO
{
    public int Id { get; set; }   

    public string Nome { get; set; } = string.Empty;

    public string Codigo { get; set; } = string.Empty;

    public string Sigla { get; set; } = string.Empty;

    public string AreaConhecimento { get; set; } = string.Empty;

}