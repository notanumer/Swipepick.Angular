import { Component } from '@angular/core';
import {TestService} from "../shared/services/test.service";
import {ActivatedRoute, Params} from "@angular/router";
import {Observable, switchMap} from "rxjs";

@Component({
  selector: 'app-test-page',
  templateUrl: './test-page.component.html',
  styleUrls: ['./test-page.component.css']
})
export class TestPageComponent {
  test$: Observable<any> | undefined

  constructor(
    private route: ActivatedRoute,
    private testService: TestService
  ) {}

  ngOnInit() {
    this.test$ = this.route.params
      .pipe(switchMap((params: Params) => {
        return this.testService.getTest(params['id'])
      }))
  }
}
