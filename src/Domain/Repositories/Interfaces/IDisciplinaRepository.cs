using SistemaAcademicoMonolitico.src.Domain.Entities;
using SistemaAcademicoMonolitico.src.DTOs;

namespace SistemaAcademicoMonolitico.src.Domain.Repositories.Interfaces;

public interface IDisciplinaRepository : IRepository<Disciplina>
{    
    Task<IEnumerable<Disciplina>> GetByFormacaoAsync(Formacao formacao);

    Task<Disciplina> AddDisciplinaFormacaoAsync(DisciplinaFormacaoEnvioDTO disciplina);
}