using Microsoft.EntityFrameworkCore;

using SistemaAcademicoMonolitico.src.Domain.Entities;
using SistemaAcademicoMonolitico.src.Data;
using SistemaAcademicoMonolitico.src.Domain.Repositories.Interfaces;
using SistemaAcademicoMonolitico.src.Domain.Enum;
using SistemaAcademicoMonolitico.Domain.Enums;
using SistemaAcademicoMonolitico.src.Services.Interfaces;
using SistemaAcademicoMonolitico.src.Factories.Interfaces;
using SistemaAcademicoMonolitico.src.DTOs;
using SistemaAcademicoMonolitico.src.Domain.Repositories;
using SistemaAcademicoMonolitico.src.Factories;

namespace SistemaAcademicoMonolitico.src.Services;

public class DisciplinaService : IDisciplinaService
{

    private readonly IDisciplinaRepository _repository;
    private readonly IDisciplinaFactory    _factory;
    private readonly IFormacaoFactory    _factoryFormacao;

    public DisciplinaService(IDisciplinaRepository repository,
                             IDisciplinaFactory    factroy,
                             IFormacaoFactory factoryFormacao)
    {
        this._factory = factroy;
        this._repository = repository; 
        this._factoryFormacao = factoryFormacao;
    }

    public async Task<DisciplinaRetornoDTO> AddAsync(DisciplinaEnvioDTO disciplinaDTO)
    {
        var novaDisciplina = _factory.CriarDisciplina(disciplinaDTO);

        novaDisciplina = await _repository.AddAsync(novaDisciplina);                                                         
         
        return _factory.CriarDisciplinaRetornoDTO(novaDisciplina);
    }

    public async Task<DisciplinaRetornoDTO> AddDisciplinaFormacaoAsync(DisciplinaFormacaoEnvioDTO disciplinaFormacaoDTO)
    {
        var novaDisciplina = await _repository.AddDisciplinaFormacaoAsync(disciplinaFormacaoDTO);

        return _factory.CriarDisciplinaRetornoDTO(novaDisciplina);
    }    

    public async Task<ICollection<DisciplinaRetornoDTO>> GetAllAsync(int? pagina, int? quantidade)
    {
        var disciplinas = await _repository.GetAllAsync(pagina, quantidade);

        ICollection<DisciplinaRetornoDTO> disciplinasRequestDTOs = new List<DisciplinaRetornoDTO>();

        foreach (var d in disciplinas)
        {
            disciplinasRequestDTOs.Add(_factory.CriarDisciplinaRetornoDTO(d));
        }

        return disciplinasRequestDTOs;
    }

    public async Task<ICollection<DisciplinaRetornoDTO>> GetByFormacaoAsync(string formacao)
    {
        var disciplinas = await _repository.GetByFormacaoAsync((Formacao) Enum.Parse(typeof(Formacao),formacao,true));

        ICollection<DisciplinaRetornoDTO> disciplinasRequestDTOs = new List<DisciplinaRetornoDTO>();

        foreach (var d in disciplinas)
        {
            disciplinasRequestDTOs.Add(_factory.CriarDisciplinaRetornoDTO(d));
        }

        return disciplinasRequestDTOs;       
    }

    public async Task<DisciplinaRetornoDTO> GetByIdAsync(int id)
    {
        var discplina = await _repository.GetByIdAsync(id);

        return _factory.CriarDisciplinaRetornoDTO(discplina,_factoryFormacao);
    }

    public async Task<DisciplinaRetornoDTO> UpdateAsync(DisciplinaAtualizaDTO disciplinaDto)
    {
        var disciplina = _factory.CriarDisciplina(disciplinaDto);

        disciplina = await _repository.UpdateAsync(disciplina);

        return _factory.CriarDisciplinaRetornoDTO(disciplina);
    }

    public async Task<DisciplinaRetornoDTO> DeleteAsync(int id)
    {
        var disciplina = await _repository.DeleteAsync(id);
        return _factory.CriarDisciplinaRetornoDTO(disciplina);
    }
}
