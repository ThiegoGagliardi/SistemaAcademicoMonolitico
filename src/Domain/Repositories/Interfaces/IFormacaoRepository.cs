using SistemaAcademicoMonolitico.src.Domain.Entities;
using SistemaAcademicoMonolitico.Domain.Enums;

namespace SistemaAcademicoMonolitico.src.Domain.Repositories.Interfaces;

public interface IFormacaoRepository : IRepository<Formacao>
{   
    Task<IEnumerable<Formacao>> GetByNivelAsync(NivelFormacao nivel);

    Task<IEnumerable<Formacao>> GetByNomeAsync(string nome);
}
