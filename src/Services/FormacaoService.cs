using SistemaAcademicoMonolitico.src.Domain.Repositories.Interfaces;
using SistemaAcademicoMonolitico.src.Factories.Interfaces;
using SistemaAcademicoMonolitico.src.DTOs;
using SistemaAcademicoMonolitico.Domain.Enums;

namespace SistemaAcademicoMonolitico.src.Services.Interfaces;

public class FormacaoService : IFormacaoService
{
    
    private IFormacaoRepository _formacaoRepository;

    private readonly IFormacaoFactory _formacaoFactory;

    public FormacaoService(IFormacaoRepository formacaoRepository,
                           IFormacaoFactory formacaoFactory)
    {
        this._formacaoRepository = formacaoRepository;
        this._formacaoFactory    = formacaoFactory;        
    }

    public async Task<FormacaoRetornoDTO> AddAsync(FormacaoEnvioDTO formacaoDTO)
    {
        var novaFormacao = _formacaoFactory.CriarFormacao(formacaoDTO);

        novaFormacao = await _formacaoRepository.AddAsync(novaFormacao);                                                         
         
        return _formacaoFactory.CriarFormacaoRetornoDTO(novaFormacao);
    }

    public async Task<ICollection<FormacaoRetornoDTO>> GetAllAsync(int? pagina, int? quantidade)
    {
        var formacoes = await _formacaoRepository.GetAllAsync(pagina, quantidade);

        ICollection<FormacaoRetornoDTO> formacoesDTOs = new List<FormacaoRetornoDTO>();

        foreach (var formacao in formacoes)
        {
            formacoesDTOs.Add(_formacaoFactory.CriarFormacaoRetornoDTO(formacao));
        }

        return formacoesDTOs;
    }

    public async Task<ICollection<FormacaoRetornoDTO>> GetByNomeAsync(string nome)
    {
        var formacoes = await _formacaoRepository.GetByNomeAsync(nome);

        ICollection<FormacaoRetornoDTO> formacoesDTOs = new List<FormacaoRetornoDTO>();

        foreach (var formacao in formacoes)
        {
            formacoesDTOs.Add(_formacaoFactory.CriarFormacaoRetornoDTO(formacao));
        }

        return formacoesDTOs;
    }

    public async Task<ICollection<FormacaoRetornoDTO>> GetByNivelAsync(string nivel)
    {
        var nivelFormacao = (NivelFormacao)Enum.Parse(typeof(NivelFormacao),nivel,true);

        var formacoes = await _formacaoRepository.GetByNivelAsync(nivelFormacao);

        ICollection<FormacaoRetornoDTO> formacoesDTOs = new List<FormacaoRetornoDTO>();

        foreach (var formacao in formacoes)
        {
            formacoesDTOs.Add(_formacaoFactory.CriarFormacaoRetornoDTO(formacao));
        }

        return formacoesDTOs;
    }      

    public async Task<FormacaoRetornoDTO> GetByIdAsync(int id)
    {
        var formacao = await _formacaoRepository.GetByIdAsync(id);

        return _formacaoFactory.CriarFormacaoRetornoDTO(formacao);
    }

    public async Task<FormacaoRetornoDTO> UpdateAsync(FormacaoAtualizaDTO formacaoDto)
    {
        var formacao = _formacaoFactory.CriarFormacaoAtualizaAsync(formacaoDto);

        formacao = await _formacaoRepository.UpdateAsync(formacao);

        return _formacaoFactory.CriarFormacaoRetornoDTO(formacao);
    }

    public async Task<FormacaoRetornoDTO> DeleteAsync(int id)
    {
        var formacao = await _formacaoRepository.DeleteAsync(id);
        return _formacaoFactory.CriarFormacaoRetornoDTO(formacao);
    }
}