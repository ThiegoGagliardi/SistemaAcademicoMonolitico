using SistemaAcademicoMonolitico.src.DTOs;
using SistemaAcademicoMonolitico.src.Domain.Entities;

namespace SistemaAcademicoMonolitico.src.Factories.Interfaces;

public interface IDisciplinaFactory
{
    Disciplina CriarDisciplina (DisciplinaEnvioDTO disciplinaEnvioDTO);

    Disciplina CriarDisciplina (DisciplinaAtualizaDTO disciplinaEnvioDTO);

    DisciplinaRetornoDTO CriarDisciplinaRetornoDTO (Disciplina disciplina, IFormacaoFactory formacaoFactory);

    DisciplinaRetornoDTO CriarDisciplinaRetornoDTO (Disciplina disciplina);
}