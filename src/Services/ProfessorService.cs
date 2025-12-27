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
        var novoProfessor = _professorFactory.CriarProfessor(professorDTO);

        novoProfessor = await _professorRepository.AddAsync(novoProfessor);                                                         
         
        return _professorFactory.CriarProfessorDTO(novoProfessor,
                                                             _formacaoFactory,
                                                             _horarioFactory);
    }

    public async Task<ICollection<ProfessorRetornoDTO>> GetAllAsync(int? pagina, int? quantidade)
    {
        var professores = await _professorRepository.GetAllAsync(pagina, quantidade);

        ICollection<ProfessorRetornoDTO> professoresRequestDTOs = new List<ProfessorRetornoDTO>();

        foreach (var professor in professores)
        {
            professoresRequestDTOs.Add(_professorFactory.CriarProfessorDTO(professor,
                                                                           _formacaoFactory,
                                                                           _horarioFactory));
        }

        return professoresRequestDTOs;
    }

    public async Task<ProfessorRetornoDTO> GetByRegistroMecAsync(string registroMec)
    {
        var professor = await _professorRepository.GetByRegistroMecAsync(registroMec);

        return _professorFactory.CriarProfessorDTO(professor,
                                                   _formacaoFactory,
                                                   _horarioFactory);        
    }

    public async Task<ProfessorRetornoDTO> GetByIdAsync(int id)
    {
        var professor = await _professorRepository.GetByIdAsync(id);

        return _professorFactory.CriarProfessorDTO(professor,
                                                   _formacaoFactory,
                                                   _horarioFactory);
    }

    public async Task<ProfessorRetornoDTO> UpdateAsync(ProfessorAtualizaDTO professorDto)
    {
        var professor = _professorFactory.CriarProfessor(professorDto);

        professor = await _professorRepository.UpdateAsync(professor);

        return _professorFactory.CriarProfessorDTO(professor,
                                                   _formacaoFactory,
                                                   _horarioFactory);
    }

    public async Task<ProfessorRetornoDTO> AdicionarFormacaoProfessorAsync(ProfessorFormacaoDTO professorFormacaoDTO)
    {
        var formacao  = _professorFactory.CriarProfessorFormacao(professorFormacaoDTO);

        await _professorRepository.AdicionarFormacaoProfessorAsync(formacao);

        var professor = await _professorRepository.GetByIdAsync(professorFormacaoDTO.ProfessorId);

        return _professorFactory.CriarProfessorDTO(professor,
                                                   _formacaoFactory,
                                                   _horarioFactory);        
    }

    public async Task<ProfessorRetornoDTO> DeleteAsync(int id)
    {
        var professor = await _professorRepository.DeleteAsync(id);
        return _professorFactory.CriarProfessorDTO(professor,
                                                   _formacaoFactory,
                                                   _horarioFactory);
    }

    public async Task<ProfessorRetornoDTO> AdicionarGradeHorariaProfessorAsync(GradeHorariaEnvioDTO gradeDTO)
    {

        var grade  = _professorFactory.CriarGradeHoraria(gradeDTO);

        await _professorRepository.AdicionarGradeHorariaProfessorAsync(grade);

        var professor = await _professorRepository.GetByIdAsync(gradeDTO.ProfessorId);

        return _professorFactory.CriarProfessorDTO(professor,
                                                   _formacaoFactory,
                                                   _horarioFactory);        
   }

    public async Task<ProfessorRetornoDTO> AtualizaPontuacaoAsync(int id)
    {
        var professor = await _professorRepository.GetByIdAsync(id);

        professor.AtualizarPotuacao();

        return _professorFactory.CriarProfessorDTO(professor,
                                                   _formacaoFactory,
                                                   _horarioFactory);
    }   

}
