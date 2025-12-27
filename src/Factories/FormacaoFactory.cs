using SistemaAcademicoMonolitico.src.DTOs;
using SistemaAcademicoMonolitico.src.Domain.Entities;
using SistemaAcademicoMonolitico.src.Factories.Interfaces;
using SistemaAcademicoMonolitico.Domain.Enums;

namespace SistemaAcademicoMonolitico.src.Factories;

public class FormacaoFactory : IFormacaoFactory
{

    public Formacao CriarFormacao (FormacaoEnvioDTO formacaoDTO)
    {
        Formacao formacao = new ()
        {
                        
           Nome             = formacaoDTO.Nome,
           Instituicao      = formacaoDTO.Instituicao,
           ValorPontuacao   = formacaoDTO.ValorPontuacao,
           Nivel            = (NivelFormacao) Enum.Parse(typeof(NivelFormacao), formacaoDTO.Nivel, true),
           AreaConhecimento = (AreaConhecimento) Enum.Parse(typeof(AreaConhecimento), formacaoDTO.AreaConhecimento, true)
        };
        
        return formacao;
    }

    public Formacao CriarFormacaoAtualizaAsync(FormacaoAtualizaDTO formacaoDTO)
    {
        Formacao formacao = new ()
        {

           Id               = formacaoDTO.Id,             
           Nome             = formacaoDTO.Nome,
           Instituicao      = formacaoDTO.Instituicao,
           ValorPontuacao   = formacaoDTO.ValorPontuacao,
           Nivel            = (NivelFormacao) Enum.Parse(typeof(NivelFormacao), formacaoDTO.Nivel, true),
           AreaConhecimento = (AreaConhecimento) Enum.Parse(typeof(AreaConhecimento), formacaoDTO.AreaConhecimento, true)
        };
        
        return formacao;
    }

    public FormacaoRetornoDTO CriarFormacaoRetornoDTO (Formacao formacao)
    {
        FormacaoRetornoDTO formacaoDTO = new ()
        {
           Id               = formacao.Id,                        
           Nome             = formacao.Nome,
           Instituicao      = formacao.Instituicao,
           ValorPontuacao   = formacao.ValorPontuacao,
           Nivel            = formacao.Nivel.ToString(),
           AreaConhecimento = formacao.AreaConhecimento.ToString()
        };
        
        return formacaoDTO;
    }    
}