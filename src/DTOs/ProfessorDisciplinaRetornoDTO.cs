namespace SistemaAcademicoMonolitico.src.DTOs;
public class ProfessorDisciplinaRetornoDTO
{
    public int Id { get; set; }
    public string Nome { get; set ;} = string.Empty;
    public double Pontuacao { get; set; }
    public IList<DisciplinaRetornoDTO> Disciplinas  { get; set; } = new List<DisciplinaRetornoDTO>();    
}