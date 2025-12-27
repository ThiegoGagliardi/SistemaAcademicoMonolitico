using SistemaAcademicoMonolitico.src.DTOs;
using SistemaAcademicoMonolitico.src.Domain.Entities;
using SistemaAcademicoMonolitico.src.Factories.Interfaces;
using SistemaAcademicoMonolitico.Domain.Enums;
using SistemaAcademicoMonolitico.src.Domain.Enum;

namespace SistemaAcademicoMonolitico.src.Factories;

public class GradeHorariaFactory : IGradeHorariaFactory
{

    public GradeHoraria CriaGradeHoraria(GradeHorariaEnvioDTO gradeHoraraiDTO,
                                         Curso curso,
                                         Disciplina disciplina,
                                         Professor professor)
    {
        GradeHoraria grade = new()
        {
            CursoId      = gradeHoraraiDTO.CursoId,
            DisciplinaId = gradeHoraraiDTO.DisciplinaId,
            ProfessorId  = gradeHoraraiDTO.ProfessorId,
            Dia          = (DiaSemana)Enum.Parse(typeof(DiaSemana),gradeHoraraiDTO.Dia,true),
            HoraInicio   = TimeSpan.Parse(gradeHoraraiDTO.HoraInicio),
            HoraFim      = TimeSpan.Parse(gradeHoraraiDTO.HoraFim),
            Duracao      = TimeSpan.Parse(gradeHoraraiDTO.Duracao),
            Professor    = professor,
            Disciplina   = disciplina,
            Curso        = curso
        };

        return grade;
    }

    public GradeHoraria CriaGradeHoraria(GradeHorariaEnvioDTO gradeHoraraiDTO)
    {
        GradeHoraria grade = new()
        {
            CursoId      = gradeHoraraiDTO.CursoId,
            DisciplinaId = gradeHoraraiDTO.DisciplinaId,
            ProfessorId  = gradeHoraraiDTO.ProfessorId,
            Dia          = (DiaSemana)Enum.Parse(typeof(DiaSemana),gradeHoraraiDTO.Dia,true),
            HoraInicio   = TimeSpan.Parse(gradeHoraraiDTO.HoraInicio),
            HoraFim      = TimeSpan.Parse(gradeHoraraiDTO.HoraFim),
            Duracao      = TimeSpan.Parse(gradeHoraraiDTO.Duracao)
        };

        return grade;
    }    

    public GradeHorariaRetornoDTO CriaGradeHorariaRetornoDTO(GradeHoraria grade)
    { 
        GradeHorariaRetornoDTO gradeDto = new()
        {
            Curso           = grade.Curso.Nome,
            Disciplina      = grade.Disciplina.Nome,
            SiglaDisciplina = grade.Disciplina.Sigla,
            Professor       = grade.Professor.Nome,            
            Dia             = grade.Dia.ToString(),            
            HoraInicio      = grade.HoraInicio.ToString(),
            HoraFim         = grade.HoraFim.ToString(),
            Duracao         = grade.Duracao.ToString()           
        }; 

        return gradeDto;
    }  

}