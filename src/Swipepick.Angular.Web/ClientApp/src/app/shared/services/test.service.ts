import {Inject, Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {catchError, Observable, tap} from "rxjs";
import {UserLogin, UserLoginResponse, UserRegister} from "../interfaces/auth-interfaces";

@Injectable()
export class TestService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  getTest(id: string): Observable<any> {
    return this.http.get(this.baseUrl + `api/tests/${id}`)

  }


}
