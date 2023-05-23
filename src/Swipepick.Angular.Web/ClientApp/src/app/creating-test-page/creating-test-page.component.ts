import {Component, OnInit} from '@angular/core';
import {AuthApiService} from "../shared/services/auth-api.service";
import {FormArray, FormControl, FormGroup} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-creating-test-page',
  templateUrl: './creating-test-page.component.html',
  styleUrls: ['./creating-test-page.component.css']
})
export class CreatingTestPageComponent implements OnInit{

  testForm!: FormGroup

  constructor(
    private router: Router,
  ) {}

  ngOnInit(): void {
    this.testForm = new FormGroup({
      question: new FormGroup({
        questionContent: new FormControl(null),

      })
    })
  }


}
