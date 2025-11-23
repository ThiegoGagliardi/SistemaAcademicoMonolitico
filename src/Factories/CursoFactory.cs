using SistemaAcademicoMonolitico.src.DTOs;
using SistemaAcademicoMonolitico.src.Domain.Entities;
using SistemaAcademicoMonolitico.src.Factories.Interfaces;
using SistemaAcademicoMonolitico.Domain.Enums;

namespace SistemaAcademicoMonolitico.src.Factories;

public class CursoFactory : ICursoFactory
{

    public Curso CriaCurso(CursoEnvioDTO cursoDTO)
    {
        Curso curso = new()
        {
            Nome = cursoDTO.Nome,
            Descricao = cursoDTO.Descricao,
            AreaConhecimento = (AreaConhecimento)Enum.Parse(typeof(AreaConhecimento), cursoDTO.AreaConhecimento, true)
        };

        return curso;
    }


    public CursoRetornoDTO CriaCursoRetornoDTO(Curso curso,
                                                IDisciplinaFactory disciplinaFactory)
    {
        CursoRetornoDTO cursoDTO = new()
        {
            Id = curso.Id,

            Nome = curso.Nome,

            Descricao = curso.Descricao,

            AreaConhecimento = curso.AreaConhecimento.ToString(),


        };

        foreach (var d in curso.Disciplinas)
        {
            cursoDTO.Disciplinas.Add(disciplinaFactory.CriaDisplinaRetornoDTO(d.Disciplina));             
        }        

        return cursoDTO;
    }
}
