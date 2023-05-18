export interface Question {
  questionId: number,
  questionContent: string,
  answers: Answer[]
}

export interface Answer {
  answerVariants: AnswerVariant[]
  questionId: number
}

export interface AnswerVariant {
  variant: string
}

export interface SelectedResponses {
  testUri: string
  selectedAnsws: SelectedResponse[]
}


export interface SelectedResponse {
  queId: number
  answ: number
}


// Интерфейсы для создания теста


export  interface CreatedTest {
  userEmail: string
  testDto: {}
}

export interface TestDto {
  questions: CreatedQuestion[]
}

export interface CreatedQuestion {
  questionContent: string
  answers: CreatedAnswers[]
}

export interface CreatedAnswers {
  answerVariants: AnswerVariant[]
  correctAnswer: number
}

