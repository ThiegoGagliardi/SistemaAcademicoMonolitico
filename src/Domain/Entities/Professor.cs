namespace SistemaAcademicoMonolitico.src.Domain.Entities;

public class Professor
{
    public int Id { get; set; }
    public string Nome { get; set ;}  = string.Empty;
    public string RegistroMec { get; set; } = string.Empty;
    public double Pontuacao { get; set; }
    public int Nivel { get; set; }

    public DateTime DataContratacao { get; set;}
    
    public List<ProfessorFormacao> Formacoes { get; set; } = new();

    public List<GradeHoraria> Horarios { get; set; } = new();

    public void AtualizarPotuacao ()
    {
       TimeSpan periodo = DateTime.Now.Date - DataContratacao;
       this.Pontuacao = Math.Truncate(periodo.TotalDays/365.25) * this.Nivel;
        
       foreach (var pf in Formacoes)
       {
          this.Pontuacao += pf.Formacao.ValorPontuacao;
       }
    }
}
