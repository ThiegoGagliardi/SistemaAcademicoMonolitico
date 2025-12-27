using Microsoft.AspNetCore.Mvc;
using System.Net;

using SistemaAcademicoMonolitico.src.Services.Interfaces;
using SistemaAcademicoMonolitico.src.DTOs;

namespace SistemaAcademicoMonolitico.src.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AlunoController : ControllerBase
{
    private readonly IAlunoService _service;

    public AlunoController(IAlunoService service)
    {
        this._service = service;        
    }

    [HttpPost]
    public async Task<ActionResult<AlunoRetornoDTO>> AddAsync([FromBody] AlunoEnvioDTO alunoDTO)
    {
        try
        {
            var result = await _service.AddAsync(alunoDTO);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }

    [HttpPost("matricula")]
    public async Task<ActionResult<AlunoRetornoDTO>> AddMatriculaAlunoAsync([FromBody] AlunoMatriculaDTO alunoDTO)
    {
        try
        {
            var result = await _service.AddMatriculaAlunoAsync(alunoDTO);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }    
 

    [HttpGet("{id:int}")]
    public async Task<ActionResult<AlunoRetornoDTO>> GetByIdAsync(int id)
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

   [HttpGet]
    public async Task<ActionResult<IEnumerable<AlunoRetornoDTO>>> GetAllAsync([FromQuery] int? pagina, 
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
    public async Task<ActionResult<AlunoRetornoDTO>> UpdateAsync([FromBody] AlunoEnvioAtualizaDTO alunoDTO)
    {
        try
        {
            var result = await _service.UpdateAsync(alunoDTO);
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
