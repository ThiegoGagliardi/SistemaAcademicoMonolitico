using SistemaAcademicoMonolitico.src.Domain.Entities;
using SistemaAcademicoMonolitico.src.DTOs;

namespace SistemaAcademicoMonolitico.src.Domain.Repositories.Interfaces;

public interface IAtribuicaoAulaRepository 
{
    Task<GradeHoraria> AddAsync(GradeHoraria aula);

    Task<GradeHoraria> DeleteAsync(GradeHorariaBuscaDTO aula);

    Task<IEnumerable<GradeHoraria>> GetAllAsync(int? pagina, int? quantidade);

    Task<List<GradeHoraria>> GetByCursoIdAsync(int CursoId);

    Task<GradeHoraria> GetByIdAsync(GradeHorariaBuscaDTO aula);

    Task<Curso> GetDadosCursoAsync(int cursoId);

    Task<List<Disciplina>> GetDisciplinasProfessoresAsync(int professorId, int cursoId);    

}