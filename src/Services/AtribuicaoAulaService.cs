using Microsoft.EntityFrameworkCore;

using SistemaAcademicoMonolitico.src.DTOs;
using SistemaAcademicoMonolitico.src.Domain.Entities;
using SistemaAcademicoMonolitico.src.Data;
using SistemaAcademicoMonolitico.src.Domain.Repositories.Interfaces;
using SistemaAcademicoMonolitico.src.Services.Interfaces;
using SistemaAcademicoMonolitico.src.Factories;
using SistemaAcademicoMonolitico.src.Factories.Interfaces;

namespace SistemaAcademicoMonolitico.src.Services;

public class AtribuicaoAulaService : IAtribuicaoAulaService
{
    private IAtribuicaoAulaRepository _repository;
    private IDisciplinaFactory _disciplinaFactory;
    private IGradeHorariaFactory _gradeFactory;

    public AtribuicaoAulaService(IAtribuicaoAulaRepository repository,
                                 IDisciplinaFactory disciplinaFactory,
                                 IGradeHorariaFactory gradeFactory)
    {
        this._repository = repository;
        this._disciplinaFactory = disciplinaFactory;
        this._gradeFactory = gradeFactory;
    }

    public async Task<GradeHorariaRetornoDTO> AddGradeAsync(GradeHorariaEnvioDTO gradeDTO)
    {
        var aulaAtribuida = _gradeFactory.CriaGradeHoraria(gradeDTO);
        
        await _repository.AddAsync(aulaAtribuida);

        GradeHorariaBuscaDTO localizarAulaDTO = new()
        {
            CursoId      = gradeDTO.CursoId,
            ProfessorId  = gradeDTO.ProfessorId,
            DisciplinaId = gradeDTO.DisciplinaId
        };

        var retorno = await _repository.GetByIdAsync(localizarAulaDTO);
                
        var gradeRetornoDTO = _gradeFactory.CriaGradeHorariaRetornoDTO(retorno);

        return gradeRetornoDTO;
    }

    public async Task<List<GradeHorariaRetornoDTO>> GetGradeByCursoIdAsync(int cursoId)
    {        
        var retorno = await _repository.GetByCursoIdAsync(cursoId);

        List<GradeHorariaRetornoDTO> lista = new();

        foreach (var g in retorno) {
                  
          lista.Add(_gradeFactory.CriaGradeHorariaRetornoDTO(g));       
        }

        return lista;
    }    

    public async Task<List<ProfessorDisciplinaRetornoDTO>> GetProfessoresRanqueadosAsync(int cursoId)
    {        
        var curso = await _repository.GetDadosCursoAsync(cursoId);

        RanqueiaProfessor ranqueia = new(curso);

        var professores = ranqueia.GetRanque();   

        List<ProfessorDisciplinaRetornoDTO> professoresDTO = new List<ProfessorDisciplinaRetornoDTO>();

        foreach (var p in professores){           

            ProfessorDisciplinaRetornoDTO professor = new(){ 
                Id = p.Id,
                Nome = p.Nome,
                Pontuacao = p.Pontuacao
            };

            var disciplinas =  await _repository.GetDisciplinasProfessoresAsync(p.Id, cursoId);

            foreach (var d in disciplinas) {
               professor.Disciplinas.Add(_disciplinaFactory.CriarDisciplinaRetornoDTO(d));
            }              

            professoresDTO.Add(professor);
        }

        return professoresDTO;        
    }

    public async Task<GradeHorariaRetornoDTO> RemoveGradeAsync(GradeHorariaBuscaDTO gradeDTO)
    {     
        var aula = await _repository.DeleteAsync(gradeDTO);

        return _gradeFactory.CriaGradeHorariaRetornoDTO(aula);
    }
}