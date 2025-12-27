using SistemaAcademicoMonolitico.src.DTOs;

namespace SistemaAcademicoMonolitico.src.Services.Interfaces;

public interface IFormacaoService
{
    Task<FormacaoRetornoDTO> AddAsync(FormacaoEnvioDTO formacaoDTO);
    
    Task<ICollection<FormacaoRetornoDTO>> GetAllAsync(int? pagina, int? quantidade);  

    Task<FormacaoRetornoDTO> GetByIdAsync(int id);

    Task<ICollection<FormacaoRetornoDTO>> GetByNomeAsync(string nome);
    
    Task<ICollection<FormacaoRetornoDTO>> GetByNivelAsync(string nivel);

    Task<FormacaoRetornoDTO> UpdateAsync(FormacaoAtualizaDTO formacaoDTO);

    Task<FormacaoRetornoDTO> DeleteAsync(int id);
}