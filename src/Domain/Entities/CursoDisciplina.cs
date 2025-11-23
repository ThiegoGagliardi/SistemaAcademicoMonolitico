namespace SistemaAcademicoMonolitico.src.Domain.Entities;

public class CursoDisciplina
{
    public int CursoId { get; set;}

    public int DisciplinaId { get; set; }      

    public int CargaHoraria { get; set; }

    public string Ementa { get; set; } = string.Empty;

    public bool Ativo { get; set; } = true;    

    public Curso Curso { get; set; } 

    public Disciplina Disciplina { get; set; }

}