import {Component, OnDestroy, OnInit} from '@angular/core';
import {TestApiService} from "../shared/services/test-api.service";
import {ActivatedRoute, Params} from "@angular/router";
import {Observable, Subscription, switchMap} from "rxjs";
import {Question, Answer} from "../shared/interfaces/test-interfaces";

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
  answers: Answer[] = []
  result: string = ''
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
    })
  }

  ngOnDestroy(): void {
    this.testSubscription.unsubscribe()
  }

  saveUserResponse(answer: number) {
    this.questionNumber++
    this.answers.push({
      queId: this.test[this.questionNumber].queId,
      answ: answer
    })
    if (this.questionNumber + 1 === this.test.length) {
      this.isEnd = true
      this.testService.submitAnswers(
      {
        testUri: this.testId,
        selectedAnsws: this.answers
      }
      )
    }
  }
}
