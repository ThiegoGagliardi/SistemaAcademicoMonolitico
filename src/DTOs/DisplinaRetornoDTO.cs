using System.Text.Json;
using System.Text.Json.Serialization;
using System;

namespace SistemaAcademicoMonolitico.src.DTOs;

public class DisplinaRetornoDTO
{

    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;      

    public string Codigo { get; set; } = string.Empty;

    public string Sigla { get; set; } = string.Empty;

    public string AreaConhecimento { get; set; } = string.Empty;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public  IList<FormacaoRetornoDTO> Formacoes { get; set; } = [];    
}
