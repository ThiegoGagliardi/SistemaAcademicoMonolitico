namespace SistemaAcademicoMonolitico.src.DTOs;

public class ProfessorAtualizaDTO
{
    public int Id { get; set ;} 
    public string Nome { get; set ;} = string.Empty;
    public string RegistroMec { get; set; } = string.Empty;
    public string DataContratacao { get; set; } = string.Empty;
}
