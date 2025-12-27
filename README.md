🏫 Sistema Acadêmico Monolítico - Gestão e Atribuição de Aulas

Este projeto é uma solução monolítica em C# e .NET 8, utilizando Entity Framework Core (EF Core) para acesso a dados, focada na gestão de informações acadêmicas, ranqueamento de professores e automatização do processo de atribuição de aulas.

🎯 Objetivo Principal

O principal objetivo é gerenciar o ciclo de vida acadêmico de alunos, cursos e disciplinas, mas com ênfase especial na meritocracia da atribuição de aulas. Professores são ranqueados com base em sua formação e outros critérios, e a prioridade de escolha de turmas é dada aos que possuírem maior pontuação.

💻 Arquitetura e Tecnologias

Estrutura: Solução Monolítica (.NET 8).

Linguagem: C#.

ORM: Entity Framework Core (EF Core) para mapeamento de objetos e gerenciamento de Migrations.

Banco de Dados: MS SQL Server Express (utilizado via Docker).

Padrão: Domain-Driven Design (DDD) leve, com separação clara de responsabilidades em Entidades, Services e Controllers.

🔗 Entidades do Domínio

As entidades centrais do projeto e as entidades auxiliares (também conhecidas como "Join Entities" ou entidades de associação) garantem a correta modelagem dos relacionamentos Muitos-Para-Muitos (N:N).

Entidades Principais

Entidade

Descrição

Curso

Informações sobre o curso (Análise e Desenvolvimento de Sistemas, por exemplo).

Disciplina

O conteúdo que será lecionado (Estrutura de Dados, por exemplo).

Professor

Dados cadastrais e qualificações do corpo docente.

Aluno

Dados cadastrais do discente e status geral de matrícula (Ativo, Trancado).

Formacao

Tipos e registros de formação acadêmica dos professores (MBA, Mestrado, etc.).

Entidades de Associação e Auxiliares

Entidade Auxiliar

Relacionamento (N:N)

Propósito Principal

Turma / GradeHoraria

Disciplina x Professor x Horário

Define uma instância da disciplina com horário e professor alocado.

ProfessorFormacao

Professor x Formacao

Armazena o registro de qual professor possui qual formação.

CursoDisciplina

Curso x Disciplina

Define o currículo, quais disciplinas pertencem a qual curso.

MatriculaAlunoCurso

Aluno x Curso

Associa o aluno ao curso e registra a data de matrícula.

RegistroDisciplina

Aluno x Turma

Histórico do aluno em uma disciplina, armazenando nota, faltas e o StatusDisciplina (Aprovado, Reprovado, Recuperação).

PontuacaoProfessor

Professor

Armazena o resultado do cálculo de ranqueamento.

🚀 Fluxos de Negócio Implementados

1. Sistema de Ranqueamento de Professor (Prioridade de Escolha)

Este é o fluxo principal para automatizar a montagem da grade horária.

Cálculo da Pontuação: O ProfessorRankingService acessa a tabela ProfessorFormacao para somar pontos com base nas qualificações do professor.

Ordenação: As pontuações são consolidadas e armazenadas na entidade PontuacaoProfessor, que é ordenada em ordem decrescente (Professor 1º, 2º, 3º...).

Atribuição de Aulas: Durante o período de alocação, o sistema permite que os professores com maior pontuação (PontuacaoProfessor.Rank = 1) escolham suas Turmas primeiro. Esta lógica define o ProfessorID para cada Turma disponível.

2. Análise de Notas e Aprovação/Reprovação

Lançamento: Notas e faltas são lançadas na entidade RegistroDisciplina.

Cálculo: O AlunoService processa as notas e a frequência ao final do semestre.

Resultado: O resultado final é persistido no campo StatusDisciplina da entidade RegistroDisciplina, podendo ser Aprovado, ReprovadoPorNota, ReprovadoPorFalta ou Recuperação.

🐳 Configuração de Ambiente (Docker)

O projeto é configurado para ser executado em um ambiente Docker, incluindo o banco de dados e o serviço de migração.

Arquivos de Configuração

docker-compose.yml: Orquestra três serviços: sqlserver-db (MS SQL Server Express), migrations (que garante que o banco de dados seja atualizado com as migrações do EF Core) e SistemaAcademicoApp-api (o servidor web).

Dockerfile (Target debug): Imagem principal da API, incluindo o vsdbg para permitir o anexo do depurador do VS Code.

Dockerfile.Migrations: Imagem auxiliar que tem como ENTRYPOINT o comando dotnet ef database update, garantindo a criação do esquema antes de a API ser iniciada.

Debug no VS Code

O arquivo launch.json está configurado para o modo Docker Compose Debug, permitindo que você inicie todos os serviços e anexe o depurador .NET ao contêiner da API com um único comando. Isso facilita o desenvolvimento e a depuração do fluxo de ranqueamento.