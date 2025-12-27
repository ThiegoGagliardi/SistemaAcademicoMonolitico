namespace SistemaAcademicoMonolitico.src.DTOs;

public class ProfessorEnvioDTO
{
    public string Nome { get; set ;} = string.Empty;
    public string RegistroMec { get; set; } = string.Empty;
    public int Nivel { get; set; } = 1;
    public string DataContratacao { get; set; } = string.Empty;
}