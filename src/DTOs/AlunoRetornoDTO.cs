using System.Text.Json;
using System.Text.Json.Serialization;
using System;

namespace SistemaAcademicoMonolitico.src.DTOs;

public class AlunoRetornoDTO
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string RA { get; set; } = string.Empty;

   [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public IList<CursoRetornoDTO> CursosMatriculados { get; set; } = [];
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public IList<DisciplinaRetornoDTO> GradeHoraria { get; set; } = [];
    
}