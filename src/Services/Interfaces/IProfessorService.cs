using SistemaAcademicoMonolitico.src.Data;
using SistemaAcademicoMonolitico.src.Domain.Entities;
using SistemaAcademicoMonolitico.src.Domain.Enum;
using SistemaAcademicoMonolitico.src.Domain.Repositories;
using SistemaAcademicoMonolitico.src.Domain.Repositories.Interfaces;
using SistemaAcademicoMonolitico.src.Factories.Interfaces;
using SistemaAcademicoMonolitico.src.DTOs;
using SistemaAcademicoMonolitico.src.Services.Interfaces;

namespace SistemaAcademicoMonolitico.src.Services.Interfaces;

public interface IProfessorService
{
    Task<ProfessorRetornoDTO> AddAsync(ProfessorEnvioDTO professorDTO);
    
    Task<ICollection<ProfessorRetornoDTO>> GetAllAsync(int? pagina, int? quantidade);
    
    Task<ProfessorRetornoDTO> GetByRegistroMecAsync(string registroMec);

    Task<ProfessorRetornoDTO> GetByIdAsync(int id);

    Task<ProfessorRetornoDTO> UpdateAsync(ProfessorAtualizaDTO professorDto);

    Task<ProfessorRetornoDTO> DeleteAsync(int id);

    Task<ProfessorRetornoDTO> AdicionarFormacaoProfessorAsync(ProfessorFormacaoDTO professorFormacaoDTO);
    
    Task<ProfessorRetornoDTO> AdicionarGradeHorariaProfessorAsync(GradeHorariaEnvioDTO gradeDTO);

    Task<ProfessorRetornoDTO> AtualizaPontuacaoAsync(int id);
    
}