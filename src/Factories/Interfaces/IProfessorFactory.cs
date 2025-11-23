using SistemaAcademicoMonolitico.src.DTOs;
using SistemaAcademicoMonolitico.src.Domain.Entities;

namespace SistemaAcademicoMonolitico.src.Factories.Interfaces;

public interface IProfessorFactory
{
    Task<ProfessorRetornoDTO> CriarProfessorDTOAsync(Professor professor,
                                         IFormacaoFactory formacaoFactory,
                                         IHorarioFactory horarioFactory);

    Task<Professor> CriarProfessorAsync(ProfessorEnvioDTO professorDto);

    Task<Professor> CriarProfessorAsync(ProfessorAtualizaDTO professorDto);
    
    Task<ProfessorFormacao> CriarProfessorFormacaoAsync (ProfessorFormacaoDTO formacaoDTO);

    Task<GradeHoraria> CriarGradeHorariaAsync (GradeHorariaEnvioDTO gradeDTO);
}