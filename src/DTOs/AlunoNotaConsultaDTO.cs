namespace SistemaAcademicoMonolitico.src.DTOs;

public class AlunoNotaConsultaDTO
{
    public int AlunoId { get; set; }

    public int CursoId { get; set; }

    public int DisciplinaId { get; set; }

    public string Bimestre { get; set; } = string.Empty;
}
