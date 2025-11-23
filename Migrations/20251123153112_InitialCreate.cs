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
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RA = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    Codigo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sigla = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValue: ""),
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
                    DataContratacao = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matricula_Aluno_Curso",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateOnly>(type: "Date", nullable: false),
                    DataFim = table.Column<DateOnly>(type: "Date", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AlunoId1 = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Matricula_Aluno_Curso_Alunos_AlunoId1",
                        column: x => x.AlunoId1,
                        principalTable: "Alunos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matricula_Aluno_Curso_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Aluno_Cruso_Discplina",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateOnly>(type: "Date", nullable: false),
                    DataFim = table.Column<DateOnly>(type: "Date", nullable: false),
                    Status = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Nota = table.Column<decimal>(type: "Decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno_Cruso_Discplina", x => new { x.AlunoId, x.DisciplinaId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_Aluno_Cruso_Discplina_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aluno_Cruso_Discplina_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aluno_Cruso_Discplina_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cursos_Disciplinas",
                columns: table => new
                {
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false),
                    Carga_Horaria = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Ementa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    CursoId1 = table.Column<int>(type: "int", nullable: true),
                    DisciplinaId1 = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Cursos_Disciplinas_Cursos_CursoId1",
                        column: x => x.CursoId1,
                        principalTable: "Cursos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cursos_Disciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cursos_Disciplinas_Disciplinas_DisciplinaId1",
                        column: x => x.DisciplinaId1,
                        principalTable: "Disciplinas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DisciplinaFormacao",
                columns: table => new
                {
                    DisciplinasId = table.Column<int>(type: "int", nullable: false),
                    FormacoesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinaFormacao", x => new { x.DisciplinasId, x.FormacoesId });
                    table.ForeignKey(
                        name: "FK_DisciplinaFormacao_Disciplinas_DisciplinasId",
                        column: x => x.DisciplinasId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplinaFormacao_Formacoes_FormacoesId",
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
                    Duracao = table.Column<TimeSpan>(type: "time", nullable: false),
                    CursoId1 = table.Column<int>(type: "int", nullable: true),
                    ProfessorId1 = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Grade_Horaria_Cursos_CursoId1",
                        column: x => x.CursoId1,
                        principalTable: "Cursos",
                        principalColumn: "Id");
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
                    table.ForeignKey(
                        name: "FK_Grade_Horaria_Professores_ProfessorId1",
                        column: x => x.ProfessorId1,
                        principalTable: "Professores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProfessoresFormacoes",
                columns: table => new
                {
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    FormacaoId = table.Column<int>(type: "int", nullable: false),
                    Inicio = table.Column<DateOnly>(type: "Date", nullable: false),
                    Termino = table.Column<DateOnly>(type: "Date", nullable: false),
                    FormacaoId1 = table.Column<int>(type: "int", nullable: true),
                    ProfessorId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessoresFormacoes", x => new { x.ProfessorId, x.FormacaoId });
                    table.ForeignKey(
                        name: "FK_ProfessoresFormacoes_Formacoes_FormacaoId",
                        column: x => x.FormacaoId,
                        principalTable: "Formacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfessoresFormacoes_Formacoes_FormacaoId1",
                        column: x => x.FormacaoId1,
                        principalTable: "Formacoes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProfessoresFormacoes_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfessoresFormacoes_Professores_ProfessorId1",
                        column: x => x.ProfessorId1,
                        principalTable: "Professores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_Cruso_Discplina_CursoId",
                table: "Aluno_Cruso_Discplina",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_Cruso_Discplina_DisciplinaId",
                table: "Aluno_Cruso_Discplina",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_Disciplinas_CursoId1",
                table: "Cursos_Disciplinas",
                column: "CursoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_Disciplinas_DisciplinaId",
                table: "Cursos_Disciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_Disciplinas_DisciplinaId1",
                table: "Cursos_Disciplinas",
                column: "DisciplinaId1");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaFormacao_FormacoesId",
                table: "DisciplinaFormacao",
                column: "FormacoesId");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_Horaria_CursoId1",
                table: "Grade_Horaria",
                column: "CursoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_Horaria_DisciplinaId",
                table: "Grade_Horaria",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_Horaria_ProfessorId",
                table: "Grade_Horaria",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_Horaria_ProfessorId1",
                table: "Grade_Horaria",
                column: "ProfessorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_Aluno_Curso_AlunoId1",
                table: "Matricula_Aluno_Curso",
                column: "AlunoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_Aluno_Curso_CursoId",
                table: "Matricula_Aluno_Curso",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessoresFormacoes_FormacaoId",
                table: "ProfessoresFormacoes",
                column: "FormacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessoresFormacoes_FormacaoId1",
                table: "ProfessoresFormacoes",
                column: "FormacaoId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessoresFormacoes_ProfessorId1",
                table: "ProfessoresFormacoes",
                column: "ProfessorId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluno_Cruso_Discplina");

            migrationBuilder.DropTable(
                name: "Cursos_Disciplinas");

            migrationBuilder.DropTable(
                name: "DisciplinaFormacao");

            migrationBuilder.DropTable(
                name: "Grade_Horaria");

            migrationBuilder.DropTable(
                name: "Matricula_Aluno_Curso");

            migrationBuilder.DropTable(
                name: "ProfessoresFormacoes");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Formacoes");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
