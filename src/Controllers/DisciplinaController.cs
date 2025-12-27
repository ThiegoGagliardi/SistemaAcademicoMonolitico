using Microsoft.AspNetCore.Mvc;
using System.Net;

using SistemaAcademicoMonolitico.src.Services.Interfaces;
using SistemaAcademicoMonolitico.src.DTOs;

namespace SistemaAcademicoMonolitico.src.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DisciplinaController : ControllerBase
{
     private readonly IDisciplinaService _service;

     public DisciplinaController(IDisciplinaService service)
     {
        this._service = service;
     }

    [HttpPost]
    public async Task<ActionResult<DisciplinaRetornoDTO>> AddAsync([FromBody] DisciplinaEnvioDTO disciplinaDTO)
    {
        try
        {
            var result = await _service.AddAsync(disciplinaDTO);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }

    [HttpPost("formacao")]
    public async Task<ActionResult<DisciplinaRetornoDTO>> AddFormacaoAsync([FromBody] DisciplinaFormacaoEnvioDTO disciplinaFormacaoDTO)
    {
        try
        {
            var result = await _service.AddDisciplinaFormacaoAsync(disciplinaFormacaoDTO);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }  

    [HttpGet("{id:int}")]
    public async Task<ActionResult<DisciplinaRetornoDTO>> GetByIdAsync(int id)
    {
        try
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }

    [HttpGet("formacao/{nomeFormacao}")]
    public async Task<ActionResult<DisciplinaRetornoDTO>> GetByFormacaoAsync(string formacao)
    {
        try
        {
            var result = await _service.GetByFormacaoAsync(formacao);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }    

   [HttpGet]
    public async Task<ActionResult<IEnumerable<DisciplinaRetornoDTO>>> GetAllAsync([FromQuery] int? pagina, 
                                                                                  [FromQuery] int? quantidade)
    {
        try
        {
            var result = await _service.GetAllAsync(pagina, quantidade);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }    

    [HttpPut]
    public async Task<ActionResult<DisciplinaRetornoDTO>> UpdateAsync([FromBody] DisciplinaAtualizaDTO disciplinaDto)
    {
        try
        {
            var result = await _service.UpdateAsync(disciplinaDto);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DisciplinaRetornoDTO>> DeleteAsync(int id)
    {
        try
        {
            var result = await _service.DeleteAsync(id);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }        
    }
}