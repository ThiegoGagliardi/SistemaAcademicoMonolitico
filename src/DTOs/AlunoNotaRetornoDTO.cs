
namespace SistemaAcademicoMonolitico.src.DTOs;

public class AlunoNotaRetornoDTO
{
    public string Aluno { get; set; } = string.Empty;

    public string Curso { get; set; } = string.Empty;

    public string Disciplina { get; set; }  = string.Empty;

    public string Bimestre { get; set; }  = string.Empty;

    public decimal Nota { get; set; }
}