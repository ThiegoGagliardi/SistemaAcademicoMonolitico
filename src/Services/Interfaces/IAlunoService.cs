using SistemaAcademicoMonolitico.src.DTOs;

namespace SistemaAcademicoMonolitico.src.Services.Interfaces;

public interface IAlunoService
{
    Task<AlunoRetornoDTO> AddAsync(AlunoEnvioDTO alunoDTO);

    Task<AlunoRetornoDTO> AddMatriculaAlunoAsync(AlunoMatriculaDTO alunoDTO);

    Task<AlunoRetornoDTO> GetByIdAsync(int id);
  
    Task<ICollection<AlunoRetornoDTO>> GetAllAsync(int? pagina, int? quantidade);

    Task<ICollection<AlunoRetornoDTO>> GetByNomeAsync(string nome);

    Task<AlunoRetornoDTO> UpdateAsync(AlunoEnvioAtualizaDTO alunoDTO);

    Task<AlunoRetornoDTO> DeleteAsync(int id);
 
}
