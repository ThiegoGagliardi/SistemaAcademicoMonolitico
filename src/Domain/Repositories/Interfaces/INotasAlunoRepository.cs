using SistemaAcademicoMonolitico.src.Domain.Entities;
using SistemaAcademicoMonolitico.src.DTOs;
using SistemaAcademicoMonolitico.Domain.Enums;

namespace SistemaAcademicoMonolitico.src.Domain.Repositories.Interfaces;

public interface INotasAlunoRepository
{
    Task<AlunoCursoDisciplinaNota> AddAsync(AlunoCursoDisciplinaNota notaDTO);
    Task<IList<AlunoCursoDisciplinaNota>> GetByAlunoIdAsync(int id);
    Task<AlunoCursoDisciplinaNota> UpdateAsync(AlunoCursoDisciplinaNota nota);
    Task<AlunoCursoDisciplinaNota> DeleteAsync(AlunoNotaConsultaDTO notaDTO);
    Task<AlunoCursoDisciplina> FechaMediaDisciplinaAsync(AlunoCursoDisciplina disciplina);
    Task<IList<AlunoCursoDisciplinaNota>> GetNotasByCursoIdAlunoId(int cursoId, int alunoId);
}