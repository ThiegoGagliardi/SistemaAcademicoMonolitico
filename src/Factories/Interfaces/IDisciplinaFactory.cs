using SistemaAcademicoMonolitico.src.DTOs;
using SistemaAcademicoMonolitico.src.Domain.Entities;

namespace SistemaAcademicoMonolitico.src.Factories.Interfaces;

public interface IDisciplinaFactory
{
    Disciplina CriaDisciplina(DisciplinaEnvioDTO disciplinaEnvioDTO);

    DisplinaRetornoDTO CriaDisplinaRetornoDTO (Disciplina disciplina, IFormacaoFactory formacaoFactory);

    DisplinaRetornoDTO CriaDisplinaRetornoDTO (Disciplina disciplina);
}