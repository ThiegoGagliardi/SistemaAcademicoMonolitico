using SistemaAcademicoMonolitico.src.DTOs;
using SistemaAcademicoMonolitico.src.Domain.Entities;

namespace SistemaAcademicoMonolitico.src.Factories.Interfaces;

public interface ICursoFactory
{
    Curso CriarCurso(CursoEnvioDTO cursoDTO);
  
    CursoRetornoDTO CriarCursoRetornoDTO(Curso curso,
                                         IDisciplinaFactory disciplinaFactory);

    CursoRetornoDTO CriarCursoRetornoDTO(Curso curso);                                         

    Curso CriarCurso(CursoAtualizaDTO cursoDTO);    

    CursoDisciplina CriarCursoDisciplinaDTO(CursoDisciplinaDTO cursoDisciplinaDTO);

}