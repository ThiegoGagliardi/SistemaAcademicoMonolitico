using Microsoft.EntityFrameworkCore;

using SistemaAcademicoMonolitico.src.Domain.Entities;
using SistemaAcademicoMonolitico.src.Data;
using SistemaAcademicoMonolitico.src.Domain.Repositories.Interfaces;

namespace SistemaAcademicoMonolitico.src.Domain.Repositories;

public class DisciplinaRepository : IDisciplinaRepository
{
    private SistemaAcademicoDbContext _context;

    public DisciplinaRepository(SistemaAcademicoDbContext context)
    {
        this._context = context;       
    }    

    public async Task<Disciplina> AddAsync(Disciplina disciplina)
    {
        var disciplinaLocate = await _context.Disciplinas
                                           .FirstOrDefaultAsync(c => c.Nome == disciplina.Nome);

        if (disciplinaLocate != null)
            throw new Exception("Disciplina já existe.");

        if (disciplinaLocate == null)
            throw new Exception("Disiplina inválida.");

        await _context.Disciplinas.AddAsync(disciplina);
        await _context.SaveChangesAsync();

        return disciplina;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var disciplinaLocate = await _context.Disciplinas.FirstOrDefaultAsync(d => d.Id == id);

        if (disciplinaLocate == null)
            throw new Exception("Disciplina não localizado");

        _context.Disciplinas.Remove(disciplinaLocate);
        await _context.SaveChangesAsync();

        return disciplinaLocate.Id;
    }

    public async Task<IEnumerable<Disciplina>> GetAllAsync(int? pagina, int? quantidade)
    {
        pagina = pagina ?? 1;
        quantidade = quantidade ?? 10;

        return await this._context.Disciplinas                                 
                                  .Skip(((int)pagina - 1) * (int)quantidade)
                                  .Take((int)quantidade)
                                  .ToListAsync();
    }

    public  async Task<Disciplina> GetByIdAsync(int id)
    {
        var disciplinasLocate = await _context.Disciplinas.FirstOrDefaultAsync(p => p.Id == id);

        if (disciplinasLocate == null)
            throw new Exception("Disciplina não localizado");

        return disciplinasLocate;
    }

    public  async Task<Disciplina> UpdateAsync(Disciplina disciplina)
    {
        var disciplinaLocate = await _context.Disciplinas.FirstOrDefaultAsync(p => p.Id == disciplina.Id);

        if (disciplinaLocate == null)
            throw new Exception("Disciplina não localizado.");

        disciplinaLocate.Nome   = disciplina.Nome;
        disciplinaLocate.Codigo = disciplina.Codigo;
        disciplinaLocate.Sigla  = disciplina.Sigla;
        disciplinaLocate.AreaConhecimento = disciplina.AreaConhecimento;
        
        _context.Disciplinas.Update(disciplinaLocate);
        await _context.SaveChangesAsync();

        return disciplinaLocate;
    }
}