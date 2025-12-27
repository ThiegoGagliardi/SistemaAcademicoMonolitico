using SistemaAcademicoMonolitico.src.DTOs;
using SistemaAcademicoMonolitico.src.Domain.Enum;

namespace SistemaAcademicoMonolitico.src.Services.Interfaces;

public interface IDisciplinaService
{
    Task<DisciplinaRetornoDTO> AddAsync(DisciplinaEnvioDTO disciplinaDTO);

    Task<DisciplinaRetornoDTO> AddDisciplinaFormacaoAsync(DisciplinaFormacaoEnvioDTO disciplinaFormacaoDTO);

    Task<ICollection<DisciplinaRetornoDTO>> GetAllAsync(int? pagina, int? quantidade);

    Task<ICollection<DisciplinaRetornoDTO>> GetByFormacaoAsync(string formacao);
    Task<DisciplinaRetornoDTO> GetByIdAsync(int id);

    Task<DisciplinaRetornoDTO> UpdateAsync(DisciplinaAtualizaDTO professorDto);

   Task<DisciplinaRetornoDTO> DeleteAsync(int id);    
}
