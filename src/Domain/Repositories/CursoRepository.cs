using Microsoft.EntityFrameworkCore;

using SistemaAcademicoMonolitico.src.Domain.Entities;
using SistemaAcademicoMonolitico.src.Data;
using SistemaAcademicoMonolitico.src.Domain.Repositories.Interfaces;
using SistemaAcademicoMonolitico.Domain.Enums;

namespace SistemaAcademicoMonolitico.src.Domain.Repositories.Interfaces;

public class CursoRepository : ICursoRepository
{
    private SistemaAcademicoDbContext _context;

    public CursoRepository(SistemaAcademicoDbContext context)
    {
        this._context = context;
    }

    public async Task<Curso> AddAsync(Curso curso)
    {
        var cursoLocate = await _context.Cursos
                                           .FirstOrDefaultAsync(c => c.Nome == curso.Nome);

        if (cursoLocate != null)
            throw new Exception("Curso já existe.");

        await _context.Cursos.AddAsync(curso);
        await _context.SaveChangesAsync();

        return curso;
    }

    public async Task<Curso> AdicionarDisciplinaCursoAsync(CursoDisciplina cursoDisciplina)
    {
        var cursoLocate = await _context.Cursos.FirstOrDefaultAsync(c => c.Id == cursoDisciplina.CursoId);

        if (cursoLocate == null)
            throw new Exception("Curso não localizado");

        var disciplinaLocate = await _context.Disciplinas.FirstOrDefaultAsync(d => d.Id == cursoDisciplina.DisciplinaId);

        if (disciplinaLocate == null)
            throw new Exception("Discplina não localizado");

        cursoLocate.Disciplinas.Add(cursoDisciplina);
        await _context.SaveChangesAsync();

        return cursoLocate;
    }

    public async Task<Curso> DeleteAsync(int id)
    {
        var cursoLocate = await _context.Cursos.FirstOrDefaultAsync(c => c.Id == id);

        if (cursoLocate == null)
            throw new Exception("Curso não localizado");

        _context.Cursos.Remove(cursoLocate);
        await _context.SaveChangesAsync();

        return cursoLocate;
    }

    public async Task<IEnumerable<Curso>> GetAllAsync(int? pagina, int? quantidade)
    {
        pagina = pagina ?? 1;
        quantidade = quantidade ?? 10;

        return await this._context.Cursos
                                  .Skip(((int)pagina - 1) * (int)quantidade)
                                  .Take((int)quantidade)
                                  .ToListAsync();
    }

    public async Task<IEnumerable<Curso>> GetByNomeAsync(string nome)
    {
        var cursoLocalizado = await _context.Cursos.Where(c => c.Nome == nome).ToListAsync();

        if (cursoLocalizado == null)
            throw new Exception("Curso não localizado");

        return cursoLocalizado;
    }

    public async Task<IEnumerable<Curso>> GetByAreaConhecimentoAsync(AreaConhecimento area)
    {
        var cursoLocalizado = await _context.Cursos.Where(c => c.AreaConhecimento == area).ToListAsync();

        if (cursoLocalizado == null)
            throw new Exception("Curso não localizado");

        return cursoLocalizado;
    }

    public async Task<Curso> GetByIdAsync(int id)
    {
        var cursoLocate = await _context.Cursos.FirstOrDefaultAsync(p => p.Id == id);

        if (cursoLocate == null)
            throw new Exception("Curso não localizado");

        return cursoLocate;
    }

    public async Task<Curso> UpdateAsync(Curso curso)
    {
        var cursoLocate = await _context.Cursos.FirstOrDefaultAsync(c => c.Id == curso.Id);

        if (cursoLocate == null)
            throw new Exception("Curso não localizado.");

        cursoLocate.Nome = curso.Nome;
        cursoLocate.Descricao = curso.Descricao;
        cursoLocate.AreaConhecimento = cursoLocate.AreaConhecimento;

        _context.Cursos.Update(cursoLocate);
        await _context.SaveChangesAsync();

        return cursoLocate;
    }
}