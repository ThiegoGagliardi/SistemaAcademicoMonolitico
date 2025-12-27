using Microsoft.AspNetCore.Mvc;
using System.Net;

using SistemaAcademicoMonolitico.src.Services.Interfaces;
using SistemaAcademicoMonolitico.src.DTOs;

namespace SistemaAcademicoMonolitico.src.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AtribuicaoAulaController : ControllerBase
{
    private readonly IAtribuicaoAulaService _atribuicaoAulaService;

    public AtribuicaoAulaController(IAtribuicaoAulaService atribuicaoAulaService)
    {
        this._atribuicaoAulaService = atribuicaoAulaService;        
    }

    [HttpGet("curso/id")]
    public async Task<ActionResult<List<GradeHorariaRetornoDTO>>> GetGradeCursoIdAsync(int Id)
    {
        try
        {            
            var result = await _atribuicaoAulaService.GetGradeByCursoIdAsync(Id);
            
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }    

    [HttpGet("ProfessoresRanqueados")]
    public async Task<ActionResult<ProfessorDisciplinaRetornoDTO>> GetProfessorRanqueadoAsync(int id)
    {
        try
        {            
            var result = await _atribuicaoAulaService.GetProfessoresRanqueadosAsync(id);
            
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }

    [HttpPost]
    public async Task<ActionResult<ProfessorRetornoDTO>> AddGradeAsync([FromBody] GradeHorariaEnvioDTO gradeDTO)
    {
        try
        {
            var result = await _atribuicaoAulaService.AddGradeAsync(gradeDTO);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }

    [HttpDelete]
    public async Task<ActionResult<ProfessorRetornoDTO>> RemoveGradeAsync([FromBody] GradeHorariaBuscaDTO gradeDTO)
    {
        try
        {
            var result = await _atribuicaoAulaService.RemoveGradeAsync(gradeDTO);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }           

}