using Microsoft.EntityFrameworkCore;

using SistemaAcademicoMonolitico.src.Domain.Entities;
using SistemaAcademicoMonolitico.src.Data;
using SistemaAcademicoMonolitico.src.Domain.Repositories.Interfaces;

namespace SistemaAcademicoMonolitico.src.Domain.Repositories;

public class AlunoRepository : IAlunoRepository
{
    private SistemaAcademicoDbContext _context;

    public AlunoRepository(SistemaAcademicoDbContext context)
    {
        this._context = context;        
    }

    public async Task<Aluno> AddAsync(Aluno aluno)
    {
        var alunoLocate = await _context.Alunos
                                           .FirstOrDefaultAsync(a => a.Nome == aluno.Nome);

        if (alunoLocate != null)
            throw new Exception("Aluno já existe.");

        await _context.Alunos.AddAsync(aluno);
        await _context.SaveChangesAsync();

        return aluno;
    }

    public async Task<Aluno> MatricularAlunoCursoAsync(MatriculaAlunoCurso matricula)
    {
        var alunoLocate = await _context.Alunos
                                           .FirstOrDefaultAsync(a => a.Id == matricula.AlunoId);

        if (alunoLocate == null)
            throw new Exception("Aluno não localizado.");

        var matriculaLocate = alunoLocate.Matriculas.FirstOrDefault(m => m.CursoId == matricula.CursoId);

        if (matriculaLocate != null)
            throw new Exception("Aluno já matriculado.");

        alunoLocate.Matriculas.Add(matricula);

        var curso = await _context.Cursos
                                  .Include(d => d.Disciplinas)
                                  .FirstOrDefaultAsync(c => c.Id == matricula.CursoId);

        foreach(var d in curso.Disciplinas)
        {
            AlunoCursoDisciplina disciplina = new()
            {
                AlunoId = matricula.AlunoId,
                CursoId = matricula.CursoId,
                DisciplinaId = d.DisciplinaId,

                DataInicio = matricula.DataInicio,
                DataFim    = matricula.DataInicio.AddMonths(6),

                Status = Enum.StatusAlunoDisciplina.EmCurso
            };

            alunoLocate.Disciplinas.Add(disciplina);                        
        }

        await _context.SaveChangesAsync();

        return alunoLocate;       
    }

    public async Task<Aluno> DeleteAsync(int id)
    {
        var alunoLocate = await _context.Alunos.FirstOrDefaultAsync(a => a.Id == id);

        if (alunoLocate == null)
            throw new Exception("Alunos não localizado");

        _context.Alunos.Remove(alunoLocate);
        await _context.SaveChangesAsync();

        return alunoLocate;
    }

    public async Task<IEnumerable<Aluno>> GetAllAsync(int? pagina, int? quantidade)
    {
        pagina = pagina ?? 1;
        quantidade = quantidade ?? 10;

        return await this._context.Alunos                                 
                                  .Skip(((int)pagina - 1) * (int)quantidade)
                                  .Take((int)quantidade)
                                  .ToListAsync();
    }

    public async Task<Aluno> GetByIdAsync(int id)
    {
        var alunoLocate = await _context.Alunos
                                        .Include(m => m.Matriculas)
                                        .ThenInclude(c => c.Curso)
                                        .Include(d => d.Disciplinas)
                                        .ThenInclude(c => c.Disciplina)
                                        .FirstOrDefaultAsync(a => a.Id == id);

        if (alunoLocate == null)
            throw new Exception("Aluno não localizado");

        return alunoLocate;
    }

    public async Task<IEnumerable<Aluno>> GetByNomeAsync(string nome)
    {
        var alunoLocalizado = await _context.Alunos.Where(a => a.Nome == nome).ToListAsync();

        if (alunoLocalizado == null)
            throw new Exception("Aluno não localizado");

        return alunoLocalizado;
    }    

    public async Task<Aluno> UpdateAsync(Aluno aluno)
    {
        var alunoLocate = await _context.Alunos.FirstOrDefaultAsync(a => a.Id == aluno.Id);

        if (alunoLocate == null)
            throw new Exception("Aluno não localizado.");

        alunoLocate.Nome = aluno.Nome;
        alunoLocate.RA   = aluno.RA;
        
        _context.Alunos.Update(alunoLocate);
        await _context.SaveChangesAsync();

        return alunoLocate;
    }
}