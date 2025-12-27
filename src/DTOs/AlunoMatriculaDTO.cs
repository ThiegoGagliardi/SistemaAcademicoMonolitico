namespace SistemaAcademicoMonolitico.src.DTOs;
public class AlunoMatriculaDTO
{
    public int AlunoId { get; set; }

    public int CursoId { get; set; }

    public string DataInicio { get; set; }

    public string DataFim { get; set; }

    public string Status { get; set; }    
}