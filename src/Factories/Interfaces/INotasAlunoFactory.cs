using SistemaAcademicoMonolitico.src.DTOs;
using SistemaAcademicoMonolitico.src.Domain.Entities;

namespace SistemaAcademicoMonolitico.src.Factories.Interfaces;

public interface INotasAlunoFactory
{
    AlunoCursoDisciplinaNota CriarNota(AlunoNotaEnvioDTO notaDTO);

    AlunoNotaRetornoDTO CriarNotaRetornoDTO(AlunoCursoDisciplinaNota nota);

    AlunoCursoDisciplinaRetornoDTO CriaMediaFinalRetorno(AlunoCursoDisciplina media);
}
