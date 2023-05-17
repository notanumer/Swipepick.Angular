export interface Question {
  queId: string,
  question: string,
  options: string[]
}

export interface Answer {
  queId: string
  answ: number
}

export interface Answers {
  testUri: string
  selectedAnsws: Answer[]
}
