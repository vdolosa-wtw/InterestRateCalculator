import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSnackBarModule } from '@angular/material/snack-bar';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { InterestRateCalculatorComponent } from './interest-rate-calculator/interest-rate-calculator.component';
import { CalculationSessionListComponent } from './calculation-session/calculation-session-list.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CalculationSessionDetailsComponent } from './calculation-session/calculation-session-details/calculation-session-details.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,    
    InterestRateCalculatorComponent,
    CalculationSessionListComponent,
    CalculationSessionDetailsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },      
      { path: 'calculate', component: InterestRateCalculatorComponent, canActivate: [AuthorizeGuard] },
      { path: 'sessions', component: CalculationSessionListComponent, canActivate: [AuthorizeGuard] },
      { path: 'session/:id', component: CalculationSessionDetailsComponent, canActivate: [AuthorizeGuard] }
    ]),
    BrowserAnimationsModule,
    MatPaginatorModule,
    MatSnackBarModule,
    NgbModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
