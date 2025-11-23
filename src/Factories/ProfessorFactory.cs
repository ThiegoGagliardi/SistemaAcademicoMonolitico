using SistemaAcademicoMonolitico.src.DTOs;
using SistemaAcademicoMonolitico.src.Domain.Entities;
using SistemaAcademicoMonolitico.src.Factories.Interfaces;
using SistemaAcademicoMonolitico.src.Domain.Enum;

namespace SistemaAcademicoMonolitico.src.Factories;

public class ProfessorFactory : IProfessorFactory
{
    public async Task<Professor> CriarProfessorAsync(ProfessorEnvioDTO professorDto)
    {
        Professor professor = new()
        {
            Nome = professorDto.Nome,
            RegistroMec = professorDto.RegistroMec,
            DataContratacao = DateOnly.Parse(professorDto.DataContratacao)
        };

        return professor;        
    }

    public async Task<Professor> CriarProfessorAsync(ProfessorAtualizaDTO professorDto)
    {
        Professor professor = new()
        {
            Id              = professorDto.Id,
            Nome            = professorDto.Nome,
            RegistroMec     = professorDto.RegistroMec,
            DataContratacao = DateOnly.Parse(professorDto.DataContratacao)
        };

        return professor;        
    }
   

    public async Task<ProfessorRetornoDTO> CriarProfessorDTOAsync(Professor professor, 
                                                           IFormacaoFactory formacaoFactory,
                                                           IHorarioFactory horarioFactory)
    {
        ProfessorRetornoDTO professorDto = new()
        {
            Id          = professor.Id,
            Nome        = professor.Nome,
            RegistroMec = professor.RegistroMec,
            Pontuacao   = professor.Pontuacao,
            DataContratacao = professor.DataContratacao            
        };

        foreach (var f in professor.Formacoes)
        {
          professorDto.Formacoes.Add(formacaoFactory.CriarFormacaoRetornoDTO(f.Formacao));  
        }

        foreach (var cd in professor.Horarios)
        {
          professorDto.Horarios.Add(horarioFactory.CriarHorarioDTO(cd));  
        }

        return professorDto;       
    }

    public async Task<ProfessorFormacao> CriarProfessorFormacaoAsync(ProfessorFormacaoDTO formacaoDTO)
    {
        ProfessorFormacao formacao = new()
        {
           FormacaoId  = formacaoDTO.FormacaoId,
           ProfessorId = formacaoDTO.ProfessorId,
           Inicio      = formacaoDTO.Inicio,
           Termino     = formacaoDTO.Termino            
        };

        return formacao;   
    }

    public async Task<GradeHoraria> CriarGradeHorariaAsync (GradeHorariaEnvioDTO gradeDTO)
    {
        GradeHoraria grade = new ()
        {
            CursoId      = gradeDTO.CursoId,
            DisciplinaId = gradeDTO.DisciplinaId,
            ProfessorId  = gradeDTO.ProfessorId,
            Dia          = (DiaSemana)Enum.Parse(typeof(DiaSemana), gradeDTO.Dia, true),
            HoraInicio   = TimeSpan.Parse(gradeDTO.HoraInicio),
            HoraFim      = TimeSpan.Parse(gradeDTO.HoraFim),
            Duracao      = TimeSpan.Parse(gradeDTO.Duracao)
        };

        return grade;
    }
}