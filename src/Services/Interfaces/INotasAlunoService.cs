using SistemaAcademicoMonolitico.src.DTOs;

namespace SistemaAcademicoMonolitico.src.Services.Interfaces;

public interface INotasAlunoService
{
    Task<AlunoNotaRetornoDTO> AddAsync(AlunoNotaEnvioDTO notaDTO);

    Task<AlunoNotaRetornoDTO> UpdateAsync(AlunoNotaEnvioDTO notaDTO);

    Task<AlunoNotaRetornoDTO> DeleteAsync(AlunoNotaConsultaDTO notaDTO);

    Task<IList<AlunoNotaRetornoDTO>> GetByAlunoIdAsync(int id);

    Task<List<AlunoCursoDisciplinaRetornoDTO>> FecharNotasCursoAsync(int CursoId);

    Task<List<AlunoCursoDisciplinaRetornoDTO>> FecharNotasAlunoAsync(int alunoId, int cursoId);
}