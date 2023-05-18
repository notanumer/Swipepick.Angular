import {Component, OnDestroy, OnInit} from '@angular/core';
import {TestApiService} from "../shared/services/test-api.service";
import {ActivatedRoute, Params} from "@angular/router";
import {Observable, Subscription, switchMap} from "rxjs";
import {Question, Answer, SelectedResponse} from "../shared/interfaces/test-interfaces";

@Component({
  selector: 'app-test-page',
  templateUrl: './test-page.component.html',
  styleUrls: ['./test-page.component.css'],
})
export class TestPageComponent implements OnInit, OnDestroy{
  test$!: Observable<Question[]>
  testId!: string
  test!: Question[]
  questionNumber = 0
  isEnd = false;
  answers: SelectedResponse[] = []
  result$!: Observable<any>
  testSubscription!: Subscription

  constructor(
    private route: ActivatedRoute,
    private testService: TestApiService
  ) {}

  ngOnInit() {
    this.test$ = this.route.params
      .pipe(switchMap((params: Params) => {
        this.testId = params['id']
        return this.testService.getTest(this.testId)
      }))

    this.testSubscription = this.test$.subscribe((test) => {
      this.test = test
      console.log(this.test)
    })
  }

  ngOnDestroy(): void {
    this.testSubscription.unsubscribe()
  }

  saveUserResponse(answer: number) {
    this.answers.push({
      queId: this.test[this.questionNumber].questionId,
      answ: answer
    })
    if (this.questionNumber + 1 === this.test.length) {
      this.isEnd = true
      this.result$ = this.testService.submitAnswers(
      {
        testUri: this.testId,
        selectedAnsws: this.answers
      }
      )
    }
    this.questionNumber++
  }
}
