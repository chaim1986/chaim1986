import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './Components/nav-menu/nav-menu.component';
import { HomeComponent } from './Components/home/home.component';
import { CounterComponent } from './Components/counter/counter.component';
import { FetchDataComponent } from './Components/fetch-data/fetch-data.component';
import { AuthModule, AuthService } from '@auth0/auth0-angular';
import { AuthButtonComponent } from './auth-button-component/auth-button-component.component';
import { HttpModule } from '@angular/http';
import { LoginComponent } from './login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ManagerModule } from './Modules/manager/manager.module';
import { RegisterComponent } from './register/register.component';
import { UserDetailsComponent } from './Modules/user/user-details/user-details.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    AuthButtonComponent,
    LoginComponent,
    RegisterComponent
  //  UserAreaComponent,   
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    HttpModule ,
    FormsModule,
    BrowserAnimationsModule,
    AuthModule.forRoot({
      domain: 'dev-xrak7kth.us.auth0.com',
      clientId: 'VQ0JqM2YUZOjvtrWGDYkZFAwYwbvNQdU'
    }),
    RouterModule.forRoot([
     
      {
        path: 'user',
        loadChildren: () => import('./Modules/user/user.module').then(m => m.UserModule)
      },

     
      {
          path: 'manager',
          loadChildren: () => import('./Modules/manager/manager.module').then(m => m.ManagerModule)
      },

      //{ path: 'userArea/:id', component: UserAreaComponent },     
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'authbotton', component: AuthButtonComponent },
      { path: 'login', component: LoginComponent },
      { path: 'userdetails', component: UserDetailsComponent },
      //{
      //  path: "parent", component: HomeComponent, children: [
      //    {path : "chil}
      //  ]
      //}
      { path: 'inspector', loadChildren: () => import('./Modules/inspector/inspector.module').then(m => m.InspectorModule) },
     
    ])
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
