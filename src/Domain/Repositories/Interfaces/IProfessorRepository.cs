using SistemaAcademicoMonolitico.src.Domain.Entities;

namespace SistemaAcademicoMonolitico.src.Domain.Repositories.Interfaces;

public interface IProfessorRepository : IRepository<Professor>
{
    Task<Professor> GetByRegistroMecAsync(string registroMec);

    Task<Professor> AdicionarFormacaoProfessorAsync(ProfessorFormacao professorFormacao);

    Task<Professor> AdicionarGradeHorariaProfessorAsync(GradeHoraria grade);
    
}