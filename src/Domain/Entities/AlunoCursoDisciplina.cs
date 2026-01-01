using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using SistemaAcademicoMonolitico.src.Domain.Enum;

namespace SistemaAcademicoMonolitico.src.Domain.Entities;

public class AlunoCursoDisciplina
{
    public int AlunoId  { get; set; }

    public int CursoId { get; set; }

    public int DisciplinaId { get; set; }

    public DateOnly DataInicio { get; set; }

    public DateOnly DataFim { get; set; }    

    public StatusAlunoDisciplina Status { get; private set; } = Enum.StatusAlunoDisciplina.EmCurso;

    private decimal _mediaFinal;

    public decimal MediaFinal { get => _mediaFinal; 
                                set {
                                       _mediaFinal = value;
                                       AtualizarStatusAlunoDisciplina();
                                    }
                              }

    public Aluno Aluno { get; set; }

    public Curso Curso { get; set;}

    public Disciplina Disciplina { get; set;}

    public void AtualizarStatusAlunoDisciplina()
    {
        if (_mediaFinal >= 7)
           Status = StatusAlunoDisciplina.Aprovado;
        else if (_mediaFinal >= 5)
          Status = StatusAlunoDisciplina.Recuperacao;
        else
          Status = StatusAlunoDisciplina.ReprovadoPorNota;
    }
}