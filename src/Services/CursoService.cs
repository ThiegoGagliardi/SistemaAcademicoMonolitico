using Microsoft.EntityFrameworkCore;

using SistemaAcademicoMonolitico.src.Domain.Entities;
using SistemaAcademicoMonolitico.src.Data;
using SistemaAcademicoMonolitico.src.Domain.Repositories.Interfaces;
using SistemaAcademicoMonolitico.src.Domain.Enum;
using SistemaAcademicoMonolitico.Domain.Enums;
using SistemaAcademicoMonolitico.src.Services.Interfaces;
using SistemaAcademicoMonolitico.src.Factories.Interfaces;
using SistemaAcademicoMonolitico.src.DTOs;

namespace SistemaAcademicoMonolitico.src.Services;

public class CursoService : ICursoService
{
    private readonly ICursoRepository _cursoRepository;
    private readonly ICursoFactory _cursoFactory;
    private readonly IDisciplinaFactory _disciplinaFactory;

    public CursoService(ICursoRepository cursoRepository,
                        ICursoFactory cursoFactory,
                        IDisciplinaFactory disciplinaFactory)
    {
        this._cursoRepository   = cursoRepository;
        this._cursoFactory      = cursoFactory;
        this._disciplinaFactory = disciplinaFactory;

    }

    public async Task<CursoRetornoDTO> AddAsync(CursoEnvioDTO cursoDTO)
    {
         var novoCurso = _cursoFactory.CriarCurso(cursoDTO);

        novoCurso = await _cursoRepository.AddAsync(novoCurso);
         
        return _cursoFactory.CriarCursoRetornoDTO(novoCurso,
                                                  _disciplinaFactory);       
    }

    public async Task<CursoRetornoDTO> GetByIdAsync(int id)
    {
        var curso = await _cursoRepository.GetByIdAsync(id);

        return _cursoFactory.CriarCursoRetornoDTO(curso,
                                                  _disciplinaFactory);       
    }
  
    public async Task<ICollection<CursoRetornoDTO>> GetAllAsync(int? pagina, int? quantidade)
    {
        var cursos = await _cursoRepository.GetAllAsync(pagina, quantidade);

        ICollection<CursoRetornoDTO> cursosDTOs = new List<CursoRetornoDTO>();

        foreach (var curso in cursos)
        {
            cursosDTOs.Add( _cursoFactory.CriarCursoRetornoDTO(curso,
                                                               _disciplinaFactory));
        }

        return cursosDTOs;        
    }
    public async Task<ICollection<CursoRetornoDTO>> GetByNomeAsync(string nome)
    {
        var cursos = await _cursoRepository.GetByNomeAsync(nome);

        ICollection<CursoRetornoDTO> cursosDTOs = new List<CursoRetornoDTO>();

        foreach (var curso in cursos)
        {
            cursosDTOs.Add(_cursoFactory.CriarCursoRetornoDTO(curso,
                                                             _disciplinaFactory));
        }

        return cursosDTOs;       
    }

    public async Task<CursoRetornoDTO> AdicionarDisciplinaCursoAsync(CursoDisciplinaDTO cursoDisciplinaDTO)
    {
        var cursoDisciplina = _cursoFactory.CriarCursoDisciplinaDTO(cursoDisciplinaDTO);

        var curso = await _cursoRepository.AdicionarDisciplinaCursoAsync(cursoDisciplina);

        return _cursoFactory.CriarCursoRetornoDTO(curso,
                                                  _disciplinaFactory);        
    }

    public async Task<CursoRetornoDTO> UpdateAsync(CursoAtualizaDTO cursoDto)
    {
        var curso = _cursoFactory.CriarCurso(cursoDto);

        curso = await _cursoRepository.UpdateAsync(curso);

        return _cursoFactory.CriarCursoRetornoDTO(curso, _disciplinaFactory);        
    }

    public async Task<CursoRetornoDTO> DeleteAsync(int id)
    {
       var curso = await _cursoRepository.DeleteAsync(id);
       return _cursoFactory.CriarCursoRetornoDTO(curso, _disciplinaFactory); 
    }
}