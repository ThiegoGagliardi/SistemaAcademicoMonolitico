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
           AreaConhecimento = (AreaConhecimento) Enum.Parse(typeof(AreaConhecimento), formacaoDTO.Nivel, true)
        };
        
        return formacao;
    }

    public FormacaoRetornoDTO CriarFormacaoRetornoDTO (Formacao formacao)
    {
        FormacaoRetornoDTO formacaoDTO = new ()
        {
                        
           Nome             = formacao.Nome,
           Instituicao      = formacao.Instituicao,
           ValorPontuacao   = formacao.ValorPontuacao,
           Nivel            = formacao.Nivel.ToString(),
           AreaConhecimento = formacao.AreaConhecimento.ToString()
        };
        
        return formacaoDTO;
    }    
}