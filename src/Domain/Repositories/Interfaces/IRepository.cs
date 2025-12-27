
namespace SistemaAcademicoMonolitico.src.Domain.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetByIdAsync(int id);
    Task<IEnumerable<TEntity>> GetAllAsync(int? pagina, int? quantidade);
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> DeleteAsync(int id);
}
