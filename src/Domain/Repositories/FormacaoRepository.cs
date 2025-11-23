using Microsoft.EntityFrameworkCore;

using SistemaAcademicoMonolitico.src.Domain.Entities;
using SistemaAcademicoMonolitico.src.Data;
using SistemaAcademicoMonolitico.src.Domain.Repositories.Interfaces;

namespace SistemaAcademicoMonolitico.src.Domain.Repositories;

public class FormacaoRepository : IFormacaoRepository
{
    private SistemaAcademicoDbContext _context;

    public FormacaoRepository(SistemaAcademicoDbContext context)
    {
        this._context = context;        
    }

    public async Task<Formacao> AddAsync(Formacao formacao)
    {
        var formacaoLocate = await _context.Formacoes
                                           .FirstOrDefaultAsync(f => f.Nome == formacao.Nome);

        if (formacaoLocate != null)
            throw new Exception("Formação já existe.");

        if (formacao == null)
            throw new Exception("Formação inválido.");

        await _context.Formacoes.AddAsync(formacao);
        await _context.SaveChangesAsync();

        return formacao;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var formacoesLocate = await _context.Formacoes.FirstOrDefaultAsync(p => p.Id == id);

        if (formacoesLocate == null)
            throw new Exception("Formação não localizado");

        _context.Formacoes.Remove(formacoesLocate);
        await _context.SaveChangesAsync();

        return formacoesLocate.Id;
    }

    public async Task<IEnumerable<Formacao>> GetAllAsync(int? pagina, int? quantidade)
    {
        pagina = pagina ?? 1;
        quantidade = quantidade ?? 10;

        return await this._context.Formacoes                                 
                                  .Skip(((int)pagina - 1) * (int)quantidade)
                                  .Take((int)quantidade)
                                  .ToListAsync();
    }

    public async Task<Formacao> GetByIdAsync(int id)
    {
        var formacoesLocate = await _context.Formacoes.FirstOrDefaultAsync(p => p.Id == id);

        if (formacoesLocate == null)
            throw new Exception("Formação não localizado");

        return formacoesLocate;
    }

    public async Task<Formacao> UpdateAsync(Formacao formacao)
    {
        var formacoesLocate = await _context.Formacoes.FirstOrDefaultAsync(p => p.Id == formacao.Id);

        if (formacoesLocate == null)
            throw new Exception("Professor não localizado.");

        formacoesLocate.Nome             = formacao.Nome;
        formacoesLocate.Instituicao      = formacao.Instituicao;
        formacoesLocate.AreaConhecimento = formacao.AreaConhecimento;
        formacoesLocate.Nivel            = formacao.Nivel;
        formacoesLocate.ValorPontuacao   = formacao.ValorPontuacao;

        _context.Formacoes.Update(formacoesLocate);
        await _context.SaveChangesAsync();

        return formacoesLocate;
    }
}