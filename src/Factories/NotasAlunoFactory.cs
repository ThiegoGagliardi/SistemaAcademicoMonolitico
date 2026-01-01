using SistemaAcademicoMonolitico.src.DTOs;
using SistemaAcademicoMonolitico.src.Domain.Entities;
using SistemaAcademicoMonolitico.src.Factories.Interfaces;

namespace SistemaAcademicoMonolitico.src.Factories;

public class NotasAlunoFactory : INotasAlunoFactory
{
    public AlunoCursoDisciplinaNota CriarNota(AlunoNotaEnvioDTO notaDTO)
    {
        AlunoCursoDisciplinaNota nota = new()
        {
            AlunoId = notaDTO.AlunoId,
            CursoId = notaDTO.CursoId,
            DisciplinaId = notaDTO.DisciplinaId,
            Bimestre = notaDTO.Bimestre,
            Nota = notaDTO.Nota,
            Data = notaDTO.Data,
            Peso = notaDTO.Peso
        };

        return nota;
    }

    public AlunoNotaRetornoDTO CriarNotaRetornoDTO(AlunoCursoDisciplinaNota nota)
    {
        AlunoNotaRetornoDTO notaDTO = new()
        {
            Aluno = nota.Aluno.Nome,
            Curso = nota.Curso.Nome,
            Disciplina = nota.Disciplina.Nome,
            Bimestre = nota.Bimestre,
            Nota = nota.Nota
        };

        return notaDTO;
    }

    public AlunoCursoDisciplinaRetornoDTO CriaMediaFinalRetorno(AlunoCursoDisciplina media)
    {
        var disciplina = media.Curso.Disciplinas.FirstOrDefault(d => d.DisciplinaId == media.DisciplinaId);

        var mediaFinal = new AlunoCursoDisciplinaRetornoDTO
        {
            Aluno = media.Aluno.Nome,

            Curso = media.Curso.Nome,

            Disciplina = media.Disciplina.Nome,

            SiglaDisciplina = media.Disciplina.Sigla,

            MediaFinal = media.MediaFinal.ToString(),

            Status = media.Status.ToString()
        };

        return mediaFinal;
    }
}