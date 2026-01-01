using SistemaAcademicoMonolitico.src.Domain.Entities;

namespace SistemaAcademicoMonolitico.src.Domain.Repositories.Interfaces;

public interface IAlunoRepository : IRepository<Aluno>
{
    Task<Aluno> MatricularAlunoCursoAsync(MatriculaAlunoCurso matricula);

    Task<IEnumerable<Aluno>> GetByNomeAsync(string nome);

    Task<IEnumerable<Aluno>> GetByCursoId(int cursoId);
}
