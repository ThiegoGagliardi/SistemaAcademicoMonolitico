using SistemaAcademicoMonolitico.src.DTOs;
using SistemaAcademicoMonolitico.src.Domain.Entities;


namespace SistemaAcademicoMonolitico.src.Factories.Interfaces;

public interface IGradeHorariaFactory
{
    GradeHoraria CriaGradeHoraria(GradeHorariaEnvioDTO gradeHoraraiDTO,
                                  Curso curso,
                                  Disciplina disciplina,
                                  Professor professor);

    GradeHoraria CriaGradeHoraria(GradeHorariaEnvioDTO gradeHoraraiDTO);                                  
  
    GradeHorariaRetornoDTO CriaGradeHorariaRetornoDTO(GradeHoraria grade);
}