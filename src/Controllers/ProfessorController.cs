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
}
