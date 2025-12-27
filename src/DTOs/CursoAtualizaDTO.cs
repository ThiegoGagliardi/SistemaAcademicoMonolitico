namespace SistemaAcademicoMonolitico.src.DTOs;

public class CursoAtualizaDTO
{

    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public String AreaConhecimento { get; set; } = string.Empty;
}