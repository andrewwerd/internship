import { Component, OnInit } from '@angular/core';
import { UserForLogin } from '../../_models/account/userForLogin';
import { AccountService } from '../../_services/account.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loading = false;
  submitted = false;
  error = '';
  userLoginForm: FormGroup;
  hide = true;

  constructor(private accountService: AccountService,
              private router: Router,
              private formBuilder: FormBuilder
  ) {
    if (this.accountService.currentUserValue) {
      this.router.navigate([`/${this.accountService.currentUserValue.role.toLowerCase()}`]);
    }
  }

  ngOnInit() {
    this.userLoginForm = this.formBuilder.group({
      userName: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });
  }
  get userName() {
    return this.userLoginForm.get('userName');
  }
  get password() {
    return this.userLoginForm.get('password');
  }
  onSubmit() {

    this.submitted = true;
    if (this.userLoginForm.invalid) {
      return;
    }

    this.loading = true;
    const userLogin: UserForLogin = {
      ...this.userLoginForm.value
    };
    this.accountService.login(userLogin).subscribe
      (
        data => {
          this.router.navigate([`/${this.accountService.currentUserValue.role.toLowerCase()}`]);
        },
        (error) => {
          this.error = 'Логин или пароль неверны';
          this.loading = false;
        });
  }
}
