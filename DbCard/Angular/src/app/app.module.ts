import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatInputModule} from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
// import { JwtModule } from '@auth0/angular-jwt';

import { NotFoundPageComponent } from './shared/NotFoundPage/notFoundPage.component';
import { LoginComponent } from './Login/Login.component';
import { AppComponent } from './app.component';
import { environment } from 'src/environments/environment';
import { MatRippleModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';


@NgModule({
  declarations: [
    LoginComponent,
    AppComponent,
    NotFoundPageComponent
  ],
  imports: [
    MatFormFieldModule,
    MatButtonModule,
    MatInputModule,
    MatRippleModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]

})
export class AppModule { }
