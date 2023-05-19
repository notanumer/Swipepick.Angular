import {Inject, Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {catchError, Observable, tap} from "rxjs";
import {UserLogin, UserLoginResponse, UserRegister} from "../interfaces/auth-interfaces";
import {SelectedResponses, Question, SelectedResponse, CreatedTest} from "../interfaces/test-interfaces";

@Injectable()
export class TestApiService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  getTest(id: string): Observable<Question[]> {
    console.log(id)
    return this.http.get<Question[]>(this.baseUrl + `api/tests/${id}`)

  }

  submitAnswers(answers: SelectedResponses) {
    return this.http.post(this.baseUrl + 'api/tests/submit-answers', answers)
  }

  creatingTest(createdTest: CreatedTest): Observable<any> {
    return this.http.post(this.baseUrl + 'api/tests/create', createdTest)
  }

}



