using SistemaAcademicoMonolitico.src.DTOs;
using SistemaAcademicoMonolitico.src.Domain.Entities;
using SistemaAcademicoMonolitico.src.Factories.Interfaces;
using SistemaAcademicoMonolitico.Domain.Enums;

namespace SistemaAcademicoMonolitico.src.Factories;

public class AlunoFactory : IAlunoFactory
{
    public Aluno CriarAluno(AlunoEnvioDTO alunoDTO)
    {
        Aluno aluno = new()
        {
            Nome = alunoDTO.Nome,
            RA   = alunoDTO.RA            
        };

        return aluno;
    }

    public Aluno CriarAluno (AlunoEnvioAtualizaDTO alunoDTO)
    {
        Aluno aluno = new()
        {
            Id   = alunoDTO.Id,
            Nome = alunoDTO.Nome,
            RA   = alunoDTO.RA            
        };

        return aluno;
    }    

    public AlunoRetornoDTO CriarAlunoRetornoDTO(Aluno aluno,
                                                IDisciplinaFactory disciplinaFactory,
                                                ICursoFactory cursoFactory)
    {
        AlunoRetornoDTO alunoDTO =  new ()
        {
            Id     = aluno.Id,
            Nome   = aluno.Nome,
            RA     = aluno.RA 
        };
        
        foreach (var c in aluno.Matriculas)
        {
            alunoDTO.CursosMatriculados.Add(cursoFactory.CriarCursoRetornoDTO(c.Curso));
        };        

        foreach (var d in aluno.Disciplinas)
        {
            alunoDTO.GradeHorarios.Add(disciplinaFactory.CriarDisciplinaRetornoDTO(d.Disciplina));            
        };

        return alunoDTO;
    }

    public AlunoRetornoDTO CriarAlunoRetornoDTO(Aluno aluno)
    {
        AlunoRetornoDTO alunoDTO =  new ()
        {
            Id     = aluno.Id,
            Nome   = aluno.Nome,
            RA     = aluno.RA
        };

        return alunoDTO;
    }    
}
