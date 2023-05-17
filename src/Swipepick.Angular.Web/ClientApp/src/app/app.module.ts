import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import {RouterLink, RouterOutlet} from "@angular/router";
import { BeginPageComponent } from './begin-page/begin-page.component';
import { AuthPageComponent } from './auth-page/auth-page.component';
import { ProfilePageComponent } from './profile-page/profile-page.component';
import { StartPageComponent } from './start-page/start-page.component';
import {AppRoutingModule} from "./app-routing.module";
import {AuthApiService} from "./shared/services/auth-api.service";
import { TestPageComponent } from './test-page/test-page.component';
import {TestApiService} from "./shared/services/test-api.service";
import {ValidationMessageComponent} from "./shared/components/validation-message/validation-message.component";


@NgModule({
  declarations: [
    AppComponent,
    BeginPageComponent,
    AuthPageComponent,
    ProfilePageComponent,
    StartPageComponent,
    TestPageComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    RouterOutlet,
    RouterLink,
    ReactiveFormsModule,
    ValidationMessageComponent,
  ],
  providers: [AuthApiService, TestApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
