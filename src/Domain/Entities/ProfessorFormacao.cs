namespace SistemaAcademicoMonolitico.src.Domain.Entities;

public class ProfessorFormacao
{
    public int ProfessorId { get; set; }

    public int FormacaoId { get; set;}

    public DateOnly Inicio { get; set; }

    public DateOnly Termino { get; set; } 

    public Professor Professor { get; set; }   

    public Formacao Formacao { get; set; }

}