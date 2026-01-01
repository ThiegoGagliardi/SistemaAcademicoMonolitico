using Microsoft.AspNetCore.Mvc;
using System.Net;

using SistemaAcademicoMonolitico.src.Services.Interfaces;
using SistemaAcademicoMonolitico.src.DTOs;

namespace SistemaAcademicoMonolitico.src.Controllers;

[ApiController]
[Route("api/[controller]")]

public class NotasAlunosController : ControllerBase
{
    private readonly INotasAlunoService _notasAulunoService;

    public NotasAlunosController(INotasAlunoService notasAulunoService)
    {
        this._notasAulunoService = notasAulunoService;        
    }

    [HttpPost]
    public async Task<ActionResult<AlunoNotaRetornoDTO>> AddAsync([FromBody] AlunoNotaEnvioDTO notaDTO)
    {
        try
        {
            var result = await _notasAulunoService.AddAsync(notaDTO);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }

    [HttpGet("aluno/id")]
    public async Task<ActionResult<IEnumerable<AlunoNotaRetornoDTO>>> GetByIdAlunoAsync(int id)
    {
        try
        {
            var result = await _notasAulunoService.GetByAlunoIdAsync(id);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }

    [HttpGet("mediafinal/cursoid")]
    public async Task<ActionResult<IEnumerable<AlunoCursoDisciplinaRetornoDTO>>> GetMediaFinalByCursoIdAsync(int id)
    {
        try
        {
            var result = await _notasAulunoService.FecharNotasCursoAsync(id);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }

    [HttpGet("mediafinal")]
    public async Task<ActionResult<IEnumerable<AlunoCursoDisciplinaRetornoDTO>>> GetMediaFinalByAlunoAsync([FromQuery]int alunoId, [FromQuery]int cursoId)
    {
        try
        {
            var result = await _notasAulunoService.FecharNotasAlunoAsync(alunoId,cursoId);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }

    [HttpDelete]
    public async Task<ActionResult<AlunoNotaRetornoDTO>> DeleteAsync([FromBody] AlunoNotaConsultaDTO notaDTO)
    {
        try
        {
            var result = await _notasAulunoService.DeleteAsync(notaDTO);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }

   [HttpPut]
    public async Task<ActionResult<AlunoNotaRetornoDTO>> UpdateAsync([FromBody] AlunoNotaEnvioDTO notaDTO)
    {
        try
        {
            var result = await _notasAulunoService.UpdateAsync(notaDTO);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }         
}