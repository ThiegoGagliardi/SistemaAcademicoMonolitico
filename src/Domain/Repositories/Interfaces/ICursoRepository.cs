using SistemaAcademicoMonolitico.Domain.Enums;
using SistemaAcademicoMonolitico.src.Domain.Entities;

namespace SistemaAcademicoMonolitico.src.Domain.Repositories.Interfaces;

public interface ICursoRepository : IRepository<Curso>
{
    Task<Curso> AdicionarDisciplinaCursoAsync(CursoDisciplina cursoDisciplina);

    Task<IEnumerable<Curso>> GetByNomeAsync(string nome);
     
    Task<IEnumerable<Curso>> GetByAreaConhecimentoAsync(AreaConhecimento area);


}