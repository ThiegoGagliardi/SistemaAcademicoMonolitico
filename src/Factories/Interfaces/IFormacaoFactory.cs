using SistemaAcademicoMonolitico.src.DTOs;
using SistemaAcademicoMonolitico.src.Domain.Entities;

namespace SistemaAcademicoMonolitico.src.Factories.Interfaces;

public interface IFormacaoFactory
{
    Formacao CriarFormacao (FormacaoEnvioDTO formacaoDTO);

    FormacaoRetornoDTO CriarFormacaoRetornoDTO (Formacao formacao);  

    Formacao CriarFormacaoAtualizaAsync (FormacaoAtualizaDTO formacaoDTO); 
}
