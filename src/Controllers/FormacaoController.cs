using Microsoft.AspNetCore.Mvc;
using System.Net;

using SistemaAcademicoMonolitico.src.Services.Interfaces;
using SistemaAcademicoMonolitico.src.DTOs;

namespace SistemaAcademicoMonolitico.src.Controllers;

[ApiController]
[Route("api/[controller]")]

public class FormacaoController : ControllerBase
{
    private readonly IFormacaoService _formacaoService;

    public FormacaoController(IFormacaoService formacaoService)
    {
        this._formacaoService = formacaoService;        
    }
    
    [HttpPost]
    public async Task<ActionResult<FormacaoRetornoDTO>> AddAsync([FromBody] FormacaoEnvioDTO formacaoDTO)
    {
        try
        {
            var result = await _formacaoService.AddAsync(formacaoDTO);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }    

    [HttpGet("{id}")]
    public async Task<ActionResult<FormacaoRetornoDTO>> GetByIdAsync(int id)
    {
        try
        {
            var result = await _formacaoService.GetByIdAsync(id);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }

    [HttpGet("nome/{nome}")]
    public async Task<ActionResult<IEnumerable<FormacaoRetornoDTO>>> GetByNomeAsync([FromQuery] string nome)
    {
        try
        {
            var result = await _formacaoService.GetByNomeAsync(nome);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }

    [HttpGet("nivel/{nivel}")]
    public async Task<ActionResult<IEnumerable<FormacaoRetornoDTO>>> GetByNivelAsync(string nivel)
    {
        try
        {
            var result = await _formacaoService.GetByNivelAsync(nivel);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }      

   [HttpGet]
    public async Task<ActionResult<IEnumerable<FormacaoRetornoDTO>>> GetAllAsync([FromQuery] int? pagina, 
                                                                                  [FromQuery] int? quantidade)
    {
        try
        {
            var result = await _formacaoService.GetAllAsync(pagina, quantidade);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }    

    [HttpPut]
    public async Task<ActionResult<FormacaoRetornoDTO>> UpdateAsync([FromBody] FormacaoAtualizaDTO formacaoDTO)
    {
        try
        {
            var result = await _formacaoService.UpdateAsync(formacaoDTO);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<FormacaoRetornoDTO>> DeleteAsync(int id)
    {
        try
        {
            var result = await _formacaoService.DeleteAsync(id);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }        
    }
}
