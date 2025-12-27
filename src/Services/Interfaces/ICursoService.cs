using SistemaAcademicoMonolitico.src.DTOs;

namespace SistemaAcademicoMonolitico.src.Services.Interfaces;

public interface ICursoService
{
    Task<CursoRetornoDTO> AddAsync(CursoEnvioDTO cursoDTO);

    Task<CursoRetornoDTO> GetByIdAsync(int id);
  
   Task<ICollection<CursoRetornoDTO>> GetAllAsync(int? pagina, int? quantidade);

    Task<ICollection<CursoRetornoDTO>> GetByNomeAsync(string nome);

    Task<CursoRetornoDTO> AdicionarDisciplinaCursoAsync(CursoDisciplinaDTO cursoDisciplinaDTO);

    Task<CursoRetornoDTO> UpdateAsync(CursoAtualizaDTO cursoDto);
 
    Task<CursoRetornoDTO> DeleteAsync(int id);
}
