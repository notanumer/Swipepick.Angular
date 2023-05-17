import {Inject, Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {catchError, Observable, tap} from "rxjs";
import {UserLogin, UserLoginResponse, UserRegister} from "../interfaces/auth-interfaces";
import {Answers} from "../interfaces/test-interfaces";

@Injectable()
export class TestApiService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  getTest(id: string): Observable<any> {
    console.log(id)
    return this.http.get(this.baseUrl + `api/tests/${id}`)

  }

  submitAnswers(answers: Answers) {
    return this.http.post(this.baseUrl + `api/tests/`, answers)
  }

}



