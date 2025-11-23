using SistemaAcademicoMonolitico.src.Data;
using SistemaAcademicoMonolitico.src.Domain.Entities;
using SistemaAcademicoMonolitico.src.Domain.Enum;
using SistemaAcademicoMonolitico.src.Domain.Repositories;
using SistemaAcademicoMonolitico.src.Domain.Repositories.Interfaces;
using SistemaAcademicoMonolitico.src.Factories.Interfaces;
using SistemaAcademicoMonolitico.src.DTOs;
using SistemaAcademicoMonolitico.src.Services.Interfaces;

namespace SistemaAcademicoMonolitico.src.Services;

public class ProfessorService : IProfessorService
{
    private readonly IProfessorRepository _professorRepository;    
    private readonly IFormacaoFactory _formacaoFactory;
    private readonly IHorarioFactory _horarioFactory;   
    private readonly IProfessorFactory _professorFactory; 

    public ProfessorService(IProfessorRepository professorRepository,
                            IFormacaoFactory formacaoFactory,
                            IHorarioFactory horarioFactory,
                            IProfessorFactory professorFactory)
    {
        this._professorRepository = professorRepository;
        this._formacaoFactory     = formacaoFactory;
        this._horarioFactory      = horarioFactory;
        this._professorFactory    = professorFactory;
    }

    public async Task<ProfessorRetornoDTO> AddAsync(ProfessorEnvioDTO professorDTO)
    {
        var novoProfessor = await _professorFactory.CriarProfessorAsync(professorDTO);

        novoProfessor = await _professorRepository.AddAsync(novoProfessor);                                                         
         
        return await _professorFactory.CriarProfessorDTOAsync(novoProfessor,
                                                             _formacaoFactory,
                                                             _horarioFactory);
    }

    public async Task<ICollection<ProfessorRetornoDTO>> GetAllAsync(int? pagina, int? quantidade)
    {
        var professores = await _professorRepository.GetAllAsync(pagina, quantidade);

        ICollection<ProfessorRetornoDTO> productRequestDTOs = new List<ProfessorRetornoDTO>();

        foreach (var professor in professores)
        {
            productRequestDTOs.Add(await _professorFactory.CriarProfessorDTOAsync(professor,
                                                                                _formacaoFactory,
                                                                                _horarioFactory));
        }

        return productRequestDTOs;
    }

    public async Task<ProfessorRetornoDTO> GetByRegistroMecAsync(string registroMec)
    {
        var professor = await _professorRepository.GetByRegistroMecAsync(registroMec);

        return await _professorFactory.CriarProfessorDTOAsync(professor,
                                                             _formacaoFactory,
                                                             _horarioFactory);        
    }

    public async Task<ProfessorRetornoDTO> GetByIdAsync(int id)
    {
        var professor = await _professorRepository.GetByIdAsync(id);

        return await _professorFactory.CriarProfessorDTOAsync(professor,
                                                             _formacaoFactory,
                                                             _horarioFactory);
    }

    public async Task<ProfessorRetornoDTO> UpdateAsync(ProfessorAtualizaDTO professorDto)
    {
        var professor = await _professorFactory.CriarProfessorAsync(professorDto);

        professor = await _professorRepository.UpdateAsync(professor);

        return await _professorFactory.CriarProfessorDTOAsync(professor,
                                                             _formacaoFactory,
                                                             _horarioFactory);
    }

    public async Task<ProfessorRetornoDTO> AdicionarFormacaoProfessorAsync(ProfessorFormacaoDTO formacaoDTO)
    {
        var formacao  = await _professorFactory.CriarProfessorFormacaoAsync(formacaoDTO);

        await _professorRepository.AdicionarFormacaoProfessorAsync(formacao);

        var professor = await _professorRepository.GetByIdAsync(formacaoDTO.ProfessorId);

        return await _professorFactory.CriarProfessorDTOAsync(professor,
                                                             _formacaoFactory,
                                                             _horarioFactory);        
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _professorRepository.DeleteAsync(id);
    }

    public async Task<ProfessorRetornoDTO> AdicionarGradeHorariaProfessorAsync(GradeHorariaEnvioDTO gradeDTO)
    {

        var grade  = await _professorFactory.CriarGradeHorariaAsync(gradeDTO);

        await _professorRepository.AdicionarGradeHorariaProfessorAsync(grade);

        var professor = await _professorRepository.GetByIdAsync(gradeDTO.ProfessorId);

        return await _professorFactory.CriarProfessorDTOAsync(professor,
                                                             _formacaoFactory,
                                                             _horarioFactory);        
    }             
}
