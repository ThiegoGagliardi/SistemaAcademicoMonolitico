using SistemaAcademicoMonolitico.src.DTOs;
using SistemaAcademicoMonolitico.src.Domain.Entities;
using SistemaAcademicoMonolitico.src.Factories.Interfaces;
using SistemaAcademicoMonolitico.Domain.Enums;

namespace SistemaAcademicoMonolitico.src.Factories;

public class AlunoFactory : IAlunoFactory
{
    public Aluno CriaAluno(AlunoEnvioDTO alunoDTO)
    {
        Aluno aluno = new()
        {
            Nome = alunoDTO.Nome,
            RA   = alunoDTO.RA            
        };

        return aluno;
    }

    public AlunoRetornoDTO CriaAlunoRetornoDTO(Aluno aluno,
                                               IGradeHorariaFactory gradeFactory)
    {
        AlunoRetornoDTO alunoDTO =  new ()
        {
            Id     = aluno.Id,
            Nome   = aluno.Nome,
            RA     = aluno.RA
        };

        foreach (var a in aluno.Matriculas)
        {
            foreach (var h in a.Curso.Horarios){
              alunoDTO.GradeHorarios.Add(gradeFactory.CriaGradeHorariaRetornoDTO(h));
            }
        };

        return alunoDTO;
    }
}
