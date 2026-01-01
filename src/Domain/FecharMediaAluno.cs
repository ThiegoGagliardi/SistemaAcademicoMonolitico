using SistemaAcademicoMonolitico.src.Domain.Entities;

namespace SistemaAcademicoMonolitico.src.Domain;

public class FecharMediaAluno
{
    private Aluno _aluno;
    private int _idCurso;
    private IList<AlunoCursoDisciplinaNota> _notas = [];

    public FecharMediaAluno(Aluno aluno, int idCurso, IList<AlunoCursoDisciplinaNota> notas)
    {
        this._aluno = aluno;
        this._idCurso = idCurso;
        this._notas = notas;
    }

    public List<AlunoCursoDisciplina> CalcularMediaFinal()
    {
        var disciplinas = _aluno.Disciplinas.Where(n => n.CursoId == _idCurso).ToList();

        var mediasDosAlunos = _notas.Where(n => n.CursoId == _idCurso)
                                    .GroupBy(n => new { n.AlunoId, n.DisciplinaId })
                                    .Select(g => new{
                                              g.Key.AlunoId,
                                              g.Key.DisciplinaId,
                                              MediaPonderada = g.Sum(x => x.Nota * x.Peso) / g.Sum(x => x.Peso)
                                             }
                                            ).ToList();

        foreach (var d in _aluno.Disciplinas.Where(v => v.CursoId == _idCurso))
        {
            // Buscamos o cálculo correspondente para este Aluno e esta Disciplina
            var calculo = mediasDosAlunos.FirstOrDefault(m =>
                m.AlunoId == d.AlunoId &&
                m.DisciplinaId == d.DisciplinaId);

            if (calculo != null)
            {
                // Ao atribuir, o seu setter chamará automaticamente o AtualizarStatusAlunoDisciplina()
                d.MediaFinal = calculo.MediaPonderada;
                disciplinas.Add(d);
            }           
        }

        return disciplinas.Distinct().ToList();
    }
}