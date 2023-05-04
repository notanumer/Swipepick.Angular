import { Component } from '@angular/core';
import {AuthApiService} from "../shared/services/auth-api.service";
import {ActivatedRoute, Router} from "@angular/router";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {UserLogin, UserRegister} from "../shared/interfaces/auth-interfaces";

@Component({
  selector: 'app-auth-page',
  templateUrl: './auth-page.component.html',
  styleUrls: ['./auth-page.component.css']
})
export class AuthPageComponent {

  isLogin: boolean = true

  formLogin!: FormGroup
  formRegister!: FormGroup
  submitted = false

  constructor(
    public auth: AuthApiService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.formLogin = new FormGroup({
      emailLogin: new FormControl(null, [
        Validators.required,
        Validators.email
      ]),
      passwordLogin: new FormControl(null, [
        Validators.required,
        Validators.minLength(6)
      ])
    })

    this.formRegister = new FormGroup({
      emailRegister: new FormControl(null, [
        Validators.required,
        Validators.email
      ]),
      passwordRegister: new FormControl(null, [
        Validators.required,
        Validators.minLength(6)
      ]),
      nameRegister: new FormControl(null, [
      ]),
      lastnameRegister: new FormControl(null, [
      ])
    })
  }

  loginSubmit() {
    if (this.formLogin.invalid) {
      return
    }

    this.submitted = true

    const user: UserLogin = {
      email: this.formLogin.value.emailLogin,
      password: this.formLogin.value.passwordLogin
    }

    this.auth.login(user).subscribe(() => {
      this.formLogin.reset()
      this.submitted = false
    }, () => {
      this.submitted = false
    })
  }

  registerSubmit() {
    if (this.formRegister.invalid) {
      return
    }


    const user: UserRegister = {
      email: this.formLogin.value.emailRegister,
      password: this.formLogin.value.passwordRegister,
      name: this.formLogin.value.nameRegister,
      lastname: this.formLogin.value.lastnameRegister
    }

    this.auth.register(user).subscribe((r) => {
      console.log(r)
      this.formLogin.reset()
      this.submitted = false
    }, () => {
      this.submitted = false
    })
  }
}
