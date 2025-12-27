using SistemaAcademicoMonolitico.src.DTOs;
using SistemaAcademicoMonolitico.src.Domain.Entities;

namespace SistemaAcademicoMonolitico.src.Factories.Interfaces;

public interface IAlunoFactory
{
    Aluno CriarAluno (AlunoEnvioDTO alunoDTO);

    Aluno CriarAluno (AlunoEnvioAtualizaDTO alunoDTO);

    AlunoRetornoDTO CriarAlunoRetornoDTO (Aluno aluno, 
                                          IDisciplinaFactory disciplinaFactory,
                                          ICursoFactory cursoFactory);
    
    AlunoRetornoDTO CriarAlunoRetornoDTO (Aluno aluno);
}