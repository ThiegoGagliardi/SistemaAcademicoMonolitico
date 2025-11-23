using SistemaAcademicoMonolitico.src.Domain.Entities;

namespace SistemaAcademicoMonolitico.src.Domain.Repositories.Interfaces;

public interface ICursoRepository : IRepository<Curso>
{
    Task<Curso> AdicionarDisciplinaCursoAsync(CursoDisciplina cursoDisciplina);

}