
namespace SistemaAcademicoMonolitico.src.Domain.Entities;

public class RanqueiaProfessor
{
    private Curso _curso;

    private IList<Professor> _professores = new List<Professor>();
    
    public RanqueiaProfessor(Curso curso)
    {       
        this._curso = curso;
        var professores = new List<Professor>();      
        
        foreach (var cd in _curso.Disciplinas)
        {
            foreach (var f in cd.Disciplina.Formacoes)
            {
               foreach (var p in f.Professores)
                {
                   p.Professor.AtualizarPotuacao();
                   professores.Add(p.Professor);
                }                
            }
        }

        _professores = professores.OrderByDescending(r => r.Pontuacao).DistinctBy(p => p.Id).ToList();
    }

    public IList<Professor> GetRanque()
    {
        return _professores.AsReadOnly();
    }
}