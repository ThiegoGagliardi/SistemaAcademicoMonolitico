using System.Text.Json;
using System.Text.Json.Serialization;
using System;

namespace SistemaAcademicoMonolitico.src.DTOs;
public class ProfessorRetornoDTO
{
    public int Id { get; set; }
    public string Nome { get; set ;} = string.Empty;
    public string RegistroMec { get; set; } = string.Empty;
    public double Pontuacao { get; set; }
    public DateOnly DataContratacao { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public IList<HorarioRetornoDTO> Horarios { get; set; } = [];
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public IList<FormacaoRetornoDTO> Formacoes { get; set; } = [];
}
