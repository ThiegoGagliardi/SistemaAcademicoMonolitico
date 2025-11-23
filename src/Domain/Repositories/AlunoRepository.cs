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

        if (aluno == null)
            throw new Exception("Aluno inválido.");

        await _context.Alunos.AddAsync(aluno);
        await _context.SaveChangesAsync();

        return aluno;
    }

    public async Task<Aluno> MatricularAlunoCursoAsync(MatriculaAlunoCurso matricula)
    {
        var alunoLocate = await _context.Alunos
                                           .FirstOrDefaultAsync(a => a.Id == matricula.AlunoId);

        if (alunoLocate == null)
            throw new Exception("Professor não localizado.");

        var matriculaLocate = alunoLocate.Matriculas.FirstOrDefault(m => m.CursoId == matricula.CursoId);

        if (matriculaLocate != null)
            throw new Exception("Aluno já matriculado.");

        alunoLocate.Matriculas.Add(matricula);
        await _context.SaveChangesAsync();

        return alunoLocate;       
    }

    public async Task<int> DeleteAsync(int id)
    {
        var alunoLocate = await _context.Professores.FirstOrDefaultAsync(a => a.Id == id);

        if (alunoLocate == null)
            throw new Exception("Alunos não localizado");

        _context.Professores.Remove(alunoLocate);
        await _context.SaveChangesAsync();

        return alunoLocate.Id;
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
        var alunoLocate = await _context.Alunos.FirstOrDefaultAsync(a => a.Id == id);

        if (alunoLocate == null)
            throw new Exception("Aluno não localizado");

        return alunoLocate;
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