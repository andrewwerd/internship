import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatInputModule} from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatStepperModule } from '@angular/material/stepper';
import { MatRadioModule} from '@angular/material/radio';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
// import { JwtModule } from '@auth0/angular-jwt';

import { NotFoundPageComponent } from './pages/NotFoundPage/notFoundPage.component';
import { LoginComponent } from './pages/login/Login.component';
import { AppComponent } from './app.component';
import { environment } from 'src/environments/environment';
import { MatRippleModule, MAT_DATE_LOCALE } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { RegistrationComponent } from './pages/registration/registration.component';
import { MatDatepickerModule} from '@angular/material/datepicker';
import { MatMomentDateModule, MAT_MOMENT_DATE_ADAPTER_OPTIONS} from '@angular/material-moment-adapter';


@NgModule({
  declarations: [
    LoginComponent,
    RegistrationComponent,
    AppComponent,
    NotFoundPageComponent
  ],
  imports: [
    MatFormFieldModule,
    MatButtonModule,
    MatInputModule,
    MatRippleModule,
    MatDatepickerModule,
    MatStepperModule,
    MatRadioModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatMomentDateModule
  ],
  providers: [
    {provide: MAT_MOMENT_DATE_ADAPTER_OPTIONS, useValue: 'ru-ru'}
  ],
  bootstrap: [AppComponent]

})
export class AppModule { }
