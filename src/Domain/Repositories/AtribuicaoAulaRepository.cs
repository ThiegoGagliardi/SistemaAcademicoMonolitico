using Microsoft.EntityFrameworkCore;

using SistemaAcademicoMonolitico.src.Domain.Entities;
using SistemaAcademicoMonolitico.src.Data;
using SistemaAcademicoMonolitico.src.Domain.Repositories.Interfaces;
using SistemaAcademicoMonolitico.src.DTOs;

namespace SistemaAcademicoMonolitico.src.Domain.Repositories;

public class AtribuicaoAulaRepository : IAtribuicaoAulaRepository
{
    private SistemaAcademicoDbContext _context;

    public AtribuicaoAulaRepository(SistemaAcademicoDbContext context)
    {
        this._context = context;
    }

    public async Task<GradeHoraria> AddAsync(GradeHoraria aula)
    {
        var aulaLocate = await _context.GradeHoraria
                                           .FirstOrDefaultAsync(a => a.Dia  == aula.Dia &&
                                                                     a.CursoId == aula.CursoId &&
                                                                     a.HoraInicio == aula.HoraInicio);

        if (aulaLocate != null)
            throw new Exception("Horário já atribuido.");

        await _context.GradeHoraria.AddAsync(aula);
        await _context.SaveChangesAsync();

        return aula;
    }

    public async Task<GradeHoraria> DeleteAsync(GradeHorariaBuscaDTO aula)
    {
        var aulaLocate = await _context.GradeHoraria
                                       .Include(c => c.Curso)
                                       .Include(d => d.Disciplina)
                                       .Include(p => p.Professor)
                                       .FirstOrDefaultAsync(a => a.CursoId == aula.CursoId &&
                                                            a.DisciplinaId == aula.DisciplinaId &&
                                                            a.ProfessorId == aula.ProfessorId);

        if (aulaLocate == null)
            throw new Exception("Aula não localizado");

        _context.GradeHoraria.Remove(aulaLocate);
        await _context.SaveChangesAsync();

        return aulaLocate;
    }

    public async Task<IEnumerable<GradeHoraria>> GetAllAsync(int? pagina, int? quantidade)
    {
        pagina = pagina ?? 1;
        quantidade = quantidade ?? 10;

        return await this._context.GradeHoraria                                 
                                  .Skip(((int)pagina - 1) * (int)quantidade)
                                  .Take((int)quantidade)
                                  .ToListAsync();
    }

    public async Task<GradeHoraria> GetByIdAsync(GradeHorariaBuscaDTO aula)
    {
        var aulaLocate = await _context.GradeHoraria
                                       .Include(c => c.Curso)
                                       .Include(d => d.Disciplina)
                                       .Include(p => p.Professor)
                                       .FirstOrDefaultAsync(a => a.CursoId == aula.CursoId &&
                                                                 a.DisciplinaId == aula.DisciplinaId &&
                                                                 a.ProfessorId == aula.ProfessorId);

        if (aulaLocate == null)
            throw new Exception("Aula não localizado");

        return aulaLocate;
    }

    public async Task<List<GradeHoraria>> GetByCursoIdAsync(int CursoId)
    {
        var aulaLocate = await _context.GradeHoraria
                                       .Include(c => c.Curso)
                                       .Include(d => d.Disciplina)
                                       .Include(p => p.Professor)
                                       .Where(a => a.CursoId == CursoId).ToListAsync();

        if (aulaLocate == null)
            throw new Exception("Aula não localizado");
        
        return aulaLocate;  
    }    

    public Task<GradeHoraria> UpdateAsync(GradeHoraria entity)
    {
        throw new NotImplementedException();
    }

    public async Task<Curso> GetDadosCursoAsync(int cursoId)
    {
        var curso = await _context.Cursos.Include(c => c.Disciplinas)
                                          .ThenInclude(d => d.Disciplina)
                                          .ThenInclude(d => d.Formacoes)
                                          .ThenInclude(f => f.Professores)
                                          .ThenInclude(pf => pf.Professor)
                                          .ThenInclude(f => f.Formacoes)
                                          .ThenInclude(f => f.Formacao)
                                          .FirstOrDefaultAsync(c => c.Id == cursoId);

        if (curso == null)
        {
            throw new Exception("Curso não encontrado.");
        }

        return curso;
    }

    public async Task<List<Disciplina>> GetDisciplinasProfessoresAsync(int professorId, int cursoId)
    {
        var disciplinas = await _context.Professores.Where(prf => prf.Id == professorId)
                                             .SelectMany(prf => prf.Formacoes) // Navega para a tabela intermediária
                                             .Select(pf => pf.Formacao)               // Navega para a Formação
                                             .SelectMany(f => f.Disciplinas)          // Navega para a lista de Disciplinas
                                             .Where(d => d.Id == cursoId)        // Filtra pelo Curso específico
                                             .Distinct()                              // Remove duplicatas (caso formações diferentes tenham a mesma disciplina)
                                             .ToListAsync();

        return disciplinas;
    }   

}