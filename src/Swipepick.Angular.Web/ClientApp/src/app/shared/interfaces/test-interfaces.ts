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
