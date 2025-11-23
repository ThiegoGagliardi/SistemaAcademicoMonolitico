namespace SistemaAcademicoMonolitico.src.Domain.Enum;

public enum StatusAlunoCurso
{
    // 0. Default/Inativo
    NaoMatriculado = 0,

    // 1. Status Principal
    Ativo = 1,              // Aluno está cursando e realizando atividades

    // 2. Status Temporários ou de Pausa
    Trancado = 2,           // Aluno solicitou trancamento da matrícula temporariamente
    Afastado = 3,           // Afastamento por motivos específicos (saúde, intercâmbio, etc.)

    // 3. Status Finais
    Formado = 4,            // Aluno concluiu o curso com sucesso
    Jubilado = 5,           // Aluno excedeu o tempo máximo para conclusão (desligamento acadêmico)
    Desligado = 6,          // Aluno que solicitou a desistência ou foi desligado por outros motivos
    Transferido = 7         // Aluno que deixou a instituição para estudar em outra
}
