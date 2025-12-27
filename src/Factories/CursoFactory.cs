using SistemaAcademicoMonolitico.src.DTOs;
using SistemaAcademicoMonolitico.src.Domain.Entities;
using SistemaAcademicoMonolitico.src.Factories.Interfaces;
using SistemaAcademicoMonolitico.Domain.Enums;

namespace SistemaAcademicoMonolitico.src.Factories;

public class CursoFactory : ICursoFactory
{

    public Curso CriarCurso(CursoEnvioDTO cursoDTO)
    {
        Curso curso = new()
        {
            Nome = cursoDTO.Nome,
            Descricao = cursoDTO.Descricao,
            AreaConhecimento = (AreaConhecimento)Enum.Parse(typeof(AreaConhecimento), cursoDTO.AreaConhecimento, true)
        };

        return curso;
    }

    public Curso CriarCurso(CursoAtualizaDTO cursoDTO)
    {
        Curso curso = new()
        {
            Id   = cursoDTO.Id,
            Nome = cursoDTO.Nome,
            Descricao = cursoDTO.Descricao,
            AreaConhecimento = (AreaConhecimento)Enum.Parse(typeof(AreaConhecimento), cursoDTO.AreaConhecimento, true)
        };

        return curso;
    }

    public CursoRetornoDTO CriarCursoRetornoDTO(Curso curso,
                                                IDisciplinaFactory disciplinaFactory)
    {
        CursoRetornoDTO cursoDTO = new()
        {
            Id = curso.Id,

            Nome = curso.Nome,

            Descricao = curso.Descricao,

            AreaConhecimento = curso.AreaConhecimento.ToString()

        };

        foreach (var d in curso.Disciplinas)
        {
            cursoDTO.Disciplinas.Add(disciplinaFactory.CriarDisciplinaRetornoDTO(d.Disciplina));             
        }        

        return cursoDTO;
    }

    public CursoRetornoDTO CriarCursoRetornoDTO(Curso curso)
    {
        CursoRetornoDTO cursoDTO = new()
        {
            Id = curso.Id,

            Nome = curso.Nome,

            Descricao = curso.Descricao,

            AreaConhecimento = curso.AreaConhecimento.ToString()

        };  

        return cursoDTO;
    }    

    public CursoDisciplina CriarCursoDisciplinaDTO(CursoDisciplinaDTO cursoDisciplinaDTO)
    {
        CursoDisciplina cursoDisciplina =  new CursoDisciplina()
        {
            CursoId      = cursoDisciplinaDTO.CursoId,
            DisciplinaId = cursoDisciplinaDTO.DisciplinaId
            
        };

        return cursoDisciplina;        
    }
}
