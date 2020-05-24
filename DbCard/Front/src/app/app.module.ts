import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatInputModule} from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatRippleModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatStepperModule } from '@angular/material/stepper';
import { MatSelectModule } from '@angular/material/select';
import { MatRadioModule} from '@angular/material/radio';
import { MatDatepickerModule} from '@angular/material/datepicker';
import { MatMomentDateModule} from '@angular/material-moment-adapter';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatCardModule } from '@angular/material/card';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app.routing';
import { CommonModule } from '@angular/common';
import {MatNativeDateModule} from '@angular/material/core';


import { NotFoundPageComponent } from './pages/NotFoundPage/notFoundPage.component';
import { LoginComponent } from './pages/login/login.component';
import { AppComponent } from './app.component';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { RegistrationComponent } from './pages/registration/registration.component';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatGridListModule } from '@angular/material/grid-list';
import { ConfirmRegistrationDialogComponent } from './pages/registration/conirmDialog/confirmRegistrationDialog.component';
import { MatDialogModule } from '@angular/material/dialog';



@NgModule({
  declarations: [
    LoginComponent,
    AppComponent,
    RegistrationComponent,
    NotFoundPageComponent,
    ConfirmRegistrationDialogComponent
  ],
  imports: [
    MatNativeDateModule,
    CommonModule,
    MatDialogModule,
    MatGridListModule,
    MatListModule,
    MatIconModule,
    MatCheckboxModule,
    MatAutocompleteModule,
    MatSelectModule,
    MatCardModule,
    MatFormFieldModule,
    MatButtonModule,
    MatInputModule,
    MatRippleModule,
    MatDatepickerModule,
    MatProgressSpinnerModule,
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
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]

})
export class AppModule { }
