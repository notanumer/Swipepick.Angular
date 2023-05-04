import {NgModule} from '@angular/core';
import {Routes, RouterModule, PreloadAllModules} from '@angular/router';
import {StartPageComponent} from "./start-page/start-page.component";
import {AuthPageComponent} from "./auth-page/auth-page.component";
import {ProfilePageComponent} from "./profile-page/profile-page.component";
import {TestPageComponent} from "./test-page/test-page.component";


const routes: Routes = [
  {path: '', component: StartPageComponent},
  {path: 'login', component: AuthPageComponent},
  {path: 'profile', component: ProfilePageComponent},
  {path: 'test/:id', component: TestPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    preloadingStrategy: PreloadAllModules
  })],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
