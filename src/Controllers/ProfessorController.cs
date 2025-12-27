using Microsoft.AspNetCore.Mvc;
using System.Net;

using SistemaAcademicoMonolitico.src.Services.Interfaces;
using SistemaAcademicoMonolitico.src.DTOs;

namespace SistemaAcademicoMonolitico.src.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProfessorController : ControllerBase
{
     private readonly IProfessorService _professorService;

     public ProfessorController(IProfessorService professorService)
     {
        this._professorService = professorService;
     }

    [HttpPost]
    public async Task<ActionResult<ProfessorRetornoDTO>> AddAsync([FromBody] ProfessorEnvioDTO professorDTO)
    {
        try
        {
            var result = await _professorService.AddAsync(professorDTO);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }

    [HttpPost("Formacao")]
    public async Task<ActionResult<ProfessorRetornoDTO>> AddFromacaoProfessorAsync([FromBody] ProfessorFormacaoDTO professorFormacaoDTO)
    {
        try
        {
            var result = await _professorService.AdicionarFormacaoProfessorAsync(professorFormacaoDTO);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }    

    [HttpGet("{id}")]
    public async Task<ActionResult<ProfessorRetornoDTO>> GetByIdAsync(int id)
    {
        try
        {
            var result = await _professorService.GetByIdAsync(id);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }

    [HttpGet("pontuacao/{id}")]
    public async Task<ActionResult<ProfessorRetornoDTO>> GetPontuacaoAsync(int id)
    {
        try
        {
            var result = await _professorService.AtualizaPontuacaoAsync(id);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }    

    [HttpGet("mec")]
    public async Task<ActionResult<ProfessorRetornoDTO>> GetByRegistroMecAsync(string mec)
    {
        try
        {
            var result = await _professorService.GetByRegistroMecAsync(mec);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }    

   [HttpGet]
    public async Task<ActionResult<IEnumerable<ProfessorRetornoDTO>>> GetAllAsync([FromQuery] int? pagina, 
                                                                                  [FromQuery] int? quantidade)
    {
        try
        {
            var result = await _professorService.GetAllAsync(pagina, quantidade);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }    

    [HttpPut]
    public async Task<ActionResult<ProfessorRetornoDTO>> UpdateAsync([FromBody] ProfessorAtualizaDTO professorDTO)
    {
        try
        {
            var result = await _professorService.UpdateAsync(professorDTO);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }
    

    [HttpDelete("{id}")]
    public async Task<ActionResult<ProfessorRetornoDTO>> DeleteAsync(int id)
    {
        try
        {
            var result = await _professorService.DeleteAsync(id);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }        
    }
}
