using Microsoft.EntityFrameworkCore;

using SistemaAcademicoMonolitico.src.Domain.Entities;
using SistemaAcademicoMonolitico.src.Data;
using SistemaAcademicoMonolitico.src.Domain.Repositories.Interfaces;
using SistemaAcademicoMonolitico.src.DTOs;

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

        await _context.Disciplinas.AddAsync(disciplina);
        await _context.SaveChangesAsync();

        return disciplina;
    }

    public async Task<Disciplina> AddDisciplinaFormacaoAsync(DisciplinaFormacaoEnvioDTO disciplina)
    {
        var disciplinaLocate = await _context.Disciplinas
                                             .Include(df => df.Formacoes)                                             
                                             .FirstOrDefaultAsync(d => d.Id == disciplina.DisciplinaId);

        if (disciplinaLocate == null)
            throw new Exception("Disciplina não localizada.");

        var formacaoLocate = await _context.Formacoes
                                           .FirstOrDefaultAsync(f => f.Id == disciplina.FormacaoId);


        if (formacaoLocate == null)
            throw new Exception("formacao não localizada.");

        disciplinaLocate.Formacoes.Add(formacaoLocate);                  

        await _context.SaveChangesAsync();

        return disciplinaLocate;
   }    

    public async Task<Disciplina> DeleteAsync(int id)
    {
        var disciplinaLocate = await _context.Disciplinas.FirstOrDefaultAsync(d => d.Id == id);

        if (disciplinaLocate == null)
            throw new Exception("Disciplina não localizada.");

        _context.Disciplinas.Remove(disciplinaLocate);
        await _context.SaveChangesAsync();

        return disciplinaLocate;
    }

    public async Task<IEnumerable<Disciplina>> GetAllAsync(int? pagina, int? quantidade)
    {
        pagina = pagina ?? 1;
        quantidade = quantidade ?? 10;

        return await this._context.Disciplinas
                                  .AsNoTracking()
                                  .Include(df => df.Formacoes)                                 
                                  .Skip(((int)pagina - 1) * (int)quantidade)
                                  .Take((int)quantidade)
                                  .ToListAsync();
    }

    public async Task<IEnumerable<Disciplina>> GetByFormacaoAsync(Formacao formacao)
    {
        return await this._context.Disciplinas
                                  .Include(df => df.Formacoes)
                                  .Where (d => d.Formacoes.Contains(formacao))                                  
                                  .ToListAsync();
    }

    public  async Task<Disciplina> GetByIdAsync(int id)
    {
        var disciplinasLocate = await _context.Disciplinas
                                              .AsNoTracking()
                                              .Include(df => df.Formacoes)
                                              .FirstOrDefaultAsync(d => d.Id == id);                                          

        if (disciplinasLocate == null)
            throw new Exception("Disciplina não localizada.");

        return disciplinasLocate;
    }

    public  async Task<Disciplina> UpdateAsync(Disciplina disciplina)
    {
        var disciplinaLocate = await _context.Disciplinas.FirstOrDefaultAsync(p => p.Id == disciplina.Id);

        if (disciplinaLocate == null)
            throw new Exception("Disciplina não localizada.");

        disciplinaLocate.Nome   = disciplina.Nome;
        disciplinaLocate.Codigo = disciplina.Codigo;
        disciplinaLocate.Sigla  = disciplina.Sigla;
        disciplinaLocate.AreaConhecimento = disciplina.AreaConhecimento;
        
        _context.Disciplinas.Update(disciplinaLocate);
        await _context.SaveChangesAsync();

        return disciplinaLocate;
    }
}