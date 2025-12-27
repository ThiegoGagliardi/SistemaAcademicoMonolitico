using Microsoft.AspNetCore.Mvc;
using System.Net;

using SistemaAcademicoMonolitico.src.Services.Interfaces;
using SistemaAcademicoMonolitico.src.DTOs;

namespace SistemaAcademicoMonolitico.src.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CursoController : ControllerBase
{
     private readonly ICursoService _cursoService;

     public CursoController(ICursoService cursoService)
     {
        this._cursoService = cursoService;        
     }

    [HttpPost]
    public async Task<ActionResult<CursoRetornoDTO>> AddAsync([FromBody] CursoEnvioDTO cursoDTO)
    {
        try
        {
            var result = await _cursoService.AddAsync(cursoDTO);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    } 


    [HttpPost("Disciplina")]
    public async Task<ActionResult<CursoRetornoDTO>> AddADisciplinaAsync([FromBody] CursoDisciplinaDTO disciplinaDTO)
    {
        try
        {
            var result = await _cursoService.AdicionarDisciplinaCursoAsync(disciplinaDTO);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    } 

    [HttpGet("{id}")]
    public async Task<ActionResult<CursoRetornoDTO>> GetByIdAsync(int id)
    {
        try
        {
            var result = await _cursoService.GetByIdAsync(id);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }

    [HttpGet("nome")]
    public async Task<ActionResult<CursoRetornoDTO>> GetByNomeMecAsync(string nome)
    {
        try
        {
            var result = await _cursoService.GetByNomeAsync(nome);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }

   [HttpGet]
    public async Task<ActionResult<IEnumerable<CursoRetornoDTO>>> GetAllAsync([FromQuery] int? pagina, 
                                                                                  [FromQuery] int? quantidade)
    {
        try
        {
            var result = await _cursoService.GetAllAsync(pagina, quantidade);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    } 

    [HttpPut]
    public async Task<ActionResult<CursoRetornoDTO>> UpdateAsync([FromBody] CursoAtualizaDTO cursoDTO)
    {
        try
        {
            var result = await _cursoService.UpdateAsync(cursoDTO);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<CursoRetornoDTO>> DeleteAsync(int id)
    {
        try
        {
            var result = await _cursoService.DeleteAsync(id);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }        
    }                          
}
