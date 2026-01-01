namespace SistemaAcademicoMonolitico.src.DTOs;

public class AlunoNotaEnvioDTO
{
    public int AlunoId { get; set; }

    public int CursoId { get; set; }

    public int DisciplinaId { get; set; }

    public string Bimestre { get; set; }

    public int Peso { get; set; }

    public DateOnly Data { get; set; }

    public decimal Nota { get; set; }
}