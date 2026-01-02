using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAcademicoMonolitico.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Area_Conhecimento = table.Column<int>(type: "int", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sigla = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, defaultValue: ""),
                    Area_Conhecimento = table.Column<int>(type: "int", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Formacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Instituicao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nivel = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Area_Conhecimento = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Valor_Pontuacao = table.Column<decimal>(type: "decimal(12,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegistroMec = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Pontuacao = table.Column<decimal>(type: "decimal(12,4)", nullable: false, defaultValue: 0m),
                    Nivel = table.Column<int>(type: "int", nullable: false),
                    DataContratacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RA = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alunos_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cursos_Disciplinas",
                columns: table => new
                {
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false),
                    Carga_Horaria = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Ementa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos_Disciplinas", x => new { x.CursoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_Cursos_Disciplinas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cursos_Disciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DisciplinasFormacoes",
                columns: table => new
                {
                    DisciplinasId = table.Column<int>(type: "int", nullable: false),
                    FormacoesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinasFormacoes", x => new { x.DisciplinasId, x.FormacoesId });
                    table.ForeignKey(
                        name: "FK_DisciplinasFormacoes_Disciplinas_DisciplinasId",
                        column: x => x.DisciplinasId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplinasFormacoes_Formacoes_FormacoesId",
                        column: x => x.FormacoesId,
                        principalTable: "Formacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grade_Horaria",
                columns: table => new
                {
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false),
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    Dia = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Hora_Inicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    Hora_Fim = table.Column<TimeSpan>(type: "time", nullable: false),
                    Duracao = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade_Horaria", x => new { x.CursoId, x.DisciplinaId, x.ProfessorId });
                    table.ForeignKey(
                        name: "FK_Grade_Horaria_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grade_Horaria_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grade_Horaria_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Professores_Formacoes",
                columns: table => new
                {
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    FormacaoId = table.Column<int>(type: "int", nullable: false),
                    Inicio = table.Column<DateOnly>(type: "Date", nullable: false),
                    Termino = table.Column<DateOnly>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores_Formacoes", x => new { x.ProfessorId, x.FormacaoId });
                    table.ForeignKey(
                        name: "FK_Professores_Formacoes_Formacoes_FormacaoId",
                        column: x => x.FormacaoId,
                        principalTable: "Formacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Professores_Formacoes_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Aluno_Curso_Discplina",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateOnly>(type: "Date", nullable: false),
                    DataFim = table.Column<DateOnly>(type: "Date", nullable: false),
                    Status = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    MediaFinal = table.Column<decimal>(type: "Decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno_Curso_Discplina", x => new { x.AlunoId, x.DisciplinaId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_Aluno_Curso_Discplina_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aluno_Curso_Discplina_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aluno_Curso_Discplina_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Aluno_Curso_Discplina_Nota",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false),
                    Bimestre = table.Column<string>(type: "varchar(20)", nullable: false),
                    Data = table.Column<DateOnly>(type: "Date", nullable: false),
                    Nota = table.Column<decimal>(type: "Decimal(10,2)", nullable: false),
                    Peso = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno_Curso_Discplina_Nota", x => new { x.AlunoId, x.DisciplinaId, x.CursoId, x.Bimestre });
                    table.ForeignKey(
                        name: "FK_Aluno_Curso_Discplina_Nota_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aluno_Curso_Discplina_Nota_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aluno_Curso_Discplina_Nota_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matricula_Aluno_Curso",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateOnly>(type: "Date", nullable: false),
                    DataFim = table.Column<DateOnly>(type: "Date", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matricula_Aluno_Curso", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_Matricula_Aluno_Curso_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matricula_Aluno_Curso_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_Curso_Discplina_CursoId",
                table: "Aluno_Curso_Discplina",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_Curso_Discplina_DisciplinaId",
                table: "Aluno_Curso_Discplina",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_Curso_Discplina_Nota_CursoId",
                table: "Aluno_Curso_Discplina_Nota",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_Curso_Discplina_Nota_DisciplinaId",
                table: "Aluno_Curso_Discplina_Nota",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_DisciplinaId",
                table: "Alunos",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_Disciplinas_DisciplinaId",
                table: "Cursos_Disciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinasFormacoes_FormacoesId",
                table: "DisciplinasFormacoes",
                column: "FormacoesId");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_Horaria_DisciplinaId",
                table: "Grade_Horaria",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_Horaria_ProfessorId",
                table: "Grade_Horaria",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_Aluno_Curso_CursoId",
                table: "Matricula_Aluno_Curso",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Professores_Formacoes_FormacaoId",
                table: "Professores_Formacoes",
                column: "FormacaoId");


            migrationBuilder.Sql(@"
/* SCRIPT DE POPULAÇÃO - SISTEMA ACADÊMICO
   Ordem: Professores/Formações -> Disciplinas -> Cursos -> Ligações -> Alunos -> Notas
*/

-- 1. PROFESSORES
SET IDENTITY_INSERT Professores ON;
INSERT INTO Professores (Id, Nome, RegistroMec, DataContratacao, Nivel, Pontuacao) VALUES 
(1, 'Dr. Alan Turing', 'MEC-123', '2020-01-01', 3, 100.00),
(2, 'Profa. Ada Lovelace', 'MEC-456', '2021-02-15', 2, 85.50);
SET IDENTITY_INSERT Professores OFF;

-- 2. FORMAÇÕES
SET IDENTITY_INSERT Formacoes ON;
INSERT INTO Formacoes (Id, Nome, Instituicao, Nivel, Area_Conhecimento, Valor_Pontuacao) VALUES 
(1, 'Doutorado em Computação', 'USP', 4, 1, 50.0000),
(2, 'Mestrado em Matemática', 'UNICAMP', 3, 1, 30.0000);
SET IDENTITY_INSERT Formacoes OFF;

-- 3. LIGAÇÃO PROFESSOR-FORMAÇÃO
INSERT INTO Professores_Formacoes (ProfessorId, FormacaoId, Inicio, Termino) VALUES 
(1, 1, '2015-01-01', '2019-01-01'),
(2, 2, '2018-01-01', '2020-01-01');

-- 4. DISCIPLINAS
SET IDENTITY_INSERT Disciplinas ON;
INSERT INTO Disciplinas (Id, Nome, Sigla, Codigo, Area_Conhecimento) VALUES 
(1, 'Algoritmos e Estrutura de Dados', 'AED', 'INF001', 1),
(2, 'Cálculo Diferencial e Integral', 'CALC1', 'MAT001', 1);
SET IDENTITY_INSERT Disciplinas OFF;

-- 5. CURSOS
SET IDENTITY_INSERT Cursos ON;
INSERT INTO Cursos (Id, Nome, Descricao, Area_Conhecimento) VALUES 
(1, 'Engenharia de Software', 'Bacharelado em Software', 1),
(2, 'Análise de Sistemas', 'Tecnólogo', 1);
SET IDENTITY_INSERT Cursos OFF;

-- 6. LIGAÇÃO CURSO-DISCIPLINA (Grade Curricular)
INSERT INTO Cursos_Disciplinas (CursoId, DisciplinaId, Carga_Horaria, Ativo, Ementa) VALUES 
(1, 1, 80, 1, 'Ementa de Algoritmos para Engenharia'),
(2, 1, 60, 1, 'Ementa de Algoritmos para Análise'),
(1, 2, 80, 1, 'Cálculo para Engenheiros');

-- 7. LIGAÇÃO DISCIPLINA-FORMAÇÃO (Requisitos)
INSERT INTO DisciplinasFormacoes (DisciplinasId, FormacoesId) VALUES 
(1, 1), 
(2, 2);

-- 8. ALUNOS
SET IDENTITY_INSERT Alunos ON;
INSERT INTO Alunos (Id, Nome, RA) VALUES 
(1, 'João Silva', 'RA2024001'),
(2, 'Maria Oliveira', 'RA2024002');
SET IDENTITY_INSERT Alunos OFF;

-- 9. MATRÍCULA ALUNO NO CURSO
INSERT INTO Matricula_Aluno_Curso (AlunoId, CursoId, DataInicio, DataFim, Status) VALUES 
(1, 1, '2024-01-10', '2028-12-31', 1),
(2, 2, '2024-01-15', '2026-12-31', 1);

-- 10. ALUNO CURSANDO DISCIPLINA (Relação de Semestre)
INSERT INTO Aluno_Curso_Discplina (AlunoId, DisciplinaId, CursoId, DataInicio, DataFim, MediaFinal, Status) VALUES 
(1, 1, 1, '2024-02-01', '2024-06-30', 0.00, 1),
(2, 1, 2, '2024-02-01', '2024-06-30', 0.00, 1);

-- 11. NOTAS (Avaliações por Bimestre)
INSERT INTO Aluno_Curso_Discplina_Nota (AlunoId, DisciplinaId, CursoId, Bimestre, Data, Nota, Peso) VALUES 
(1, 1, 1, '1º Bimestre', '2024-04-15', 8.50, 4),
(1, 1, 1, '2º Bimestre', '2024-06-10', 9.00, 6),
(2, 1, 2, '1º Bimestre', '2024-04-15', 7.00, 1);

-- 12. GRADE HORÁRIA (Alocação de Professor na Turma)
INSERT INTO Grade_Horaria (CursoId, DisciplinaId, ProfessorId, Dia, Hora_Inicio, Hora_Fim, Duracao) VALUES 
(1, 1, 1, 1, '19:00:00', '20:40:00', '01:40:00'),
(2, 1, 2, 2, '19:00:00', '20:40:00', '01:40:00');
        ");                

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluno_Curso_Discplina");

            migrationBuilder.DropTable(
                name: "Aluno_Curso_Discplina_Nota");

            migrationBuilder.DropTable(
                name: "Cursos_Disciplinas");

            migrationBuilder.DropTable(
                name: "DisciplinasFormacoes");

            migrationBuilder.DropTable(
                name: "Grade_Horaria");

            migrationBuilder.DropTable(
                name: "Matricula_Aluno_Curso");

            migrationBuilder.DropTable(
                name: "Professores_Formacoes");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Formacoes");

            migrationBuilder.DropTable(
                name: "Professores");

            migrationBuilder.DropTable(
                name: "Disciplinas");
        }
    }
}
