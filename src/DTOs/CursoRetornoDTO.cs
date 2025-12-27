using System.Text.Json;
using System.Text.Json.Serialization;
using System;


namespace SistemaAcademicoMonolitico.src.DTOs;

public class CursoRetornoDTO
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public string AreaConhecimento { get; set;} = string.Empty;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public IList<DisciplinaRetornoDTO> Disciplinas { get; set; } = new List<DisciplinaRetornoDTO>();

}