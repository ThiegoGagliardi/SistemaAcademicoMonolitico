using Microsoft.EntityFrameworkCore;

using SistemaAcademicoMonolitico.src.DTOs;
using SistemaAcademicoMonolitico.src.Domain.Entities;
using SistemaAcademicoMonolitico.src.Data;
using SistemaAcademicoMonolitico.src.Domain.Repositories.Interfaces;

namespace SistemaAcademicoMonolitico.src.Domain.Repositories;

public class ProfessorRepository : IProfessorRepository
{
    private SistemaAcademicoDbContext _context;

    public ProfessorRepository(SistemaAcademicoDbContext context)
    {
        this._context = context;
    }

    public async Task<Professor> AddAsync(Professor professor)
    {
        var professorLocate = await _context.Professores
                                           .Include(pf => pf.Formacoes)
                                           .ThenInclude(f => f.Formacao)
                                           .FirstOrDefaultAsync(p => p.RegistroMec == professor.RegistroMec);

        if (professorLocate != null)
            throw new Exception("Professor já existe.");

        await _context.Professores.AddAsync(professor);
        await _context.SaveChangesAsync();

        return professor;
    }

    public async Task<Professor> AdicionarFormacaoProfessorAsync(ProfessorFormacao professorFormacao)
    {
        var professorLocate = await _context.Professores
                                           .Include(pf => pf.Formacoes)
                                           .ThenInclude(f => f.Formacao)
                                           .FirstOrDefaultAsync(p => p.Id == professorFormacao.ProfessorId);

        if (professorLocate == null)
            throw new Exception("Professor não localizado.");

        var formacaoLocate = professorLocate.Formacoes.FirstOrDefault(f => f.FormacaoId == professorFormacao.FormacaoId);

        if (formacaoLocate != null)
            throw new Exception("Formação já adicionada para o professor.");

        professorLocate.Formacoes.Add(professorFormacao);
        await _context.SaveChangesAsync();

        return professorLocate;       
    }

    public async Task<Professor> DeleteAsync(int id)
    {
        var professorLocate = await _context.Professores.FirstOrDefaultAsync(p => p.Id == id);

        if (professorLocate == null)
            throw new Exception("Professor não localizado");

        _context.Professores.Remove(professorLocate);
        await _context.SaveChangesAsync();

        return professorLocate;
    }

    public async Task<IEnumerable<Professor>> GetAllAsync(int? pagina, int? quantidade)
    {
        pagina = pagina ?? 1;
        quantidade = quantidade ?? 10;

        return await this._context.Professores                                 
                                  .Skip(((int)pagina - 1) * (int)quantidade)
                                  .Take((int)quantidade)
                                  .ToListAsync();
    }

    public async Task<Professor> GetByIdAsync(int id)
    {
        var professorLocate = await _context.Professores
                                            .Include(f => f.Formacoes)
                                            .ThenInclude(f => f.Formacao)
                                            .FirstOrDefaultAsync(p => p.Id == id);

        if (professorLocate == null)
            throw new Exception("Professor não localizado");

        return professorLocate;
    }

    public async Task<Professor> GetByRegistroMecAsync(string registroMec)
    {
        var professor = await _context.Professores
                                           .FirstOrDefaultAsync(p => p.RegistroMec == registroMec);

        if (professor == null)
            throw new Exception("Professor não localizado.");

        return professor;
    }
    public async Task<Professor> UpdateAsync(Professor professor)
    {
        var professorLocate = await _context.Professores.FirstOrDefaultAsync(p => p.Id == professor.Id);

        if (professorLocate == null)
            throw new Exception("Professor não localizado.");

        professorLocate.Nome = professor.Nome;
        professorLocate.RegistroMec = professor.RegistroMec;

        _context.Professores.Update(professorLocate);
        await _context.SaveChangesAsync();

        return professorLocate;
    }

    public async Task<Professor> AdicionarGradeHorariaProfessorAsync(GradeHoraria grade)
    {
        if (grade == null)
            throw new Exception("Horario inválido.");

        var professorLocalizado = await _context.Professores
                                           .FirstOrDefaultAsync(p => p.Id == grade.ProfessorId);

        if (professorLocalizado == null)
          throw new Exception("Professor não localizado.");

        Formacao formacaoLocalizada = null;

        foreach (var f in professorLocalizado.Formacoes)
        {
             formacaoLocalizada = grade.Disciplina.Formacoes.FirstOrDefault(df => df.Id == f.FormacaoId);

             if (formacaoLocalizada != null) 
               break;
        };

        if (formacaoLocalizada == null)
            throw new Exception("Professor não tem formação para lecionar.");        


        foreach (var g in professorLocalizado.Horarios)
        {
             if ((g.HoraInicio >= grade.HoraInicio) && 
                 (g.HoraFim <= grade.HoraFim))
               throw new Exception("Professor já tem horário preenchido.");
        };
        
        professorLocalizado.Horarios.Add(grade);
        await _context.SaveChangesAsync();

        return professorLocalizado;
    }
}