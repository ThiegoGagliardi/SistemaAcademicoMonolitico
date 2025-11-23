using SistemaAcademicoMonolitico.src.DTOs;
using SistemaAcademicoMonolitico.src.Domain.Entities;

namespace SistemaAcademicoMonolitico.src.Factories.Interfaces;

public interface IAlunoFactory
{
    Aluno CriaAluno (AlunoEnvioDTO alunoDTO);

    AlunoRetornoDTO CriaAlunoRetornoDTO (Aluno aluno, IGradeHorariaFactory gradeFactory);
}