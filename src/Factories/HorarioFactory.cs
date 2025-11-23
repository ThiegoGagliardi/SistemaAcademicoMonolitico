using SistemaAcademicoMonolitico.src.DTOs;
using SistemaAcademicoMonolitico.src.Domain.Entities;
using SistemaAcademicoMonolitico.src.Factories.Interfaces;
using SistemaAcademicoMonolitico.Domain.Enums;

namespace SistemaAcademicoMonolitico.src.Factories;

public class HorarioFactory : IHorarioFactory
{
    public HorarioRetornoDTO CriarHorarioDTO(GradeHoraria horario)
    {
        HorarioRetornoDTO horarioDTO = new()
        {
             Curso           = horario.Curso.Nome,
             Disciplina      = horario.Disciplina.Nome,
             SiglaDisciplina = horario.Disciplina.Sigla,
             Dia             = horario.Dia.ToString(),
             HoraInicio      = horario.HoraInicio.ToString(), 
             HoraFim         = horario.HoraFim.ToString(),
             Duracao         = horario.Duracao.ToString()
            
        };

        return horarioDTO;
    }
}
