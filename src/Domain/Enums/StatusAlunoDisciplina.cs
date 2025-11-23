namespace SistemaAcademicoMonolitico.src.Domain.Enum;

public enum StatusAlunoDisciplina
{
    // 0. Default/Em Andamento
    EmCurso = 0,         // Aluno está atualmente cursando a disciplina

    // 1. Status de Aprovação e Reprovação (Resultados Finais)
    Aprovado = 1,         // Aluno obteve média e frequência suficientes
    ReprovadoPorNota = 2, // Aluno não atingiu a nota mínima (DP)
    ReprovadoPorFalta = 3, // Aluno não atingiu a frequência mínima (DP)

    // 2. Status Intermediário ou Condicional
    Recuperacao = 4,      // Aluno com direito a exame/avaliação final

    // 3. Status Especiais
    Dispensa = 5,         // Aluno teve a disciplina dispensada (aproveitamento de estudos)
    Trancada = 6
}