using SistemaAcademicoMonolitico.src.DTOs;

namespace SistemaAcademicoMonolitico.src.Services.Interfaces;

public interface IAtribuicaoAulaService
{
    Task<List<ProfessorDisciplinaRetornoDTO>> GetProfessoresRanqueadosAsync(int cursoId);

    Task<List<GradeHorariaRetornoDTO>> GetGradeByCursoIdAsync(int cursoId);
    Task<GradeHorariaRetornoDTO> AddGradeAsync(GradeHorariaEnvioDTO gradeDTO);
    Task<GradeHorariaRetornoDTO> RemoveGradeAsync(GradeHorariaBuscaDTO gradeDTO);    
}