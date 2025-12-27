using SistemaAcademicoMonolitico.src.DTOs;
using SistemaAcademicoMonolitico.src.Domain.Entities;

namespace SistemaAcademicoMonolitico.src.Factories.Interfaces;

public interface IProfessorFactory
{
    ProfessorRetornoDTO CriarProfessorDTO(Professor professor,
                                          IFormacaoFactory formacaoFactory,
                                          IHorarioFactory horarioFactory);

    Professor CriarProfessor(ProfessorEnvioDTO professorDto);

    Professor CriarProfessor(ProfessorAtualizaDTO professorDto);
    
    ProfessorFormacao CriarProfessorFormacao(ProfessorFormacaoDTO formacaoDTO);

    GradeHoraria CriarGradeHoraria(GradeHorariaEnvioDTO gradeDTO);
}