import { Component, OnInit } from '@angular/core';
import { Customer } from '../../_models/customer';
import { AccountService } from '../../_services/account.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { hasLowercaseLetterValidator, hasCapitalLetterValidator, hasNumberValidator, confirmPasswordValidator } from './passwordValidator';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  userRegistrationForm: FormGroup;
  customerRegistrationForm: FormGroup;

 minDate: Date;
 maxDate: Date;

  constructor(private accountService: AccountService,
              private formBuilder: FormBuilder
            ) {
    const currentYear = new Date().getFullYear();
    this.maxDate = new Date(currentYear - 16, 0, 1);
    }
  ngOnInit() {
    this.userRegistrationForm = this.formBuilder.group({
      userName: ['', [Validators.required]],
      // tslint:disable-next-line:max-line-length
      password: ['', [Validators.required, hasCapitalLetterValidator, hasNumberValidator, hasLowercaseLetterValidator, Validators.minLength(8)]],
      passwordConfirm: ['', [Validators.required, confirmPasswordValidator(this.userName)]],
      email: ['', [Validators.required, Validators.email]],
      userType: ['', [Validators.required]]
     });
    this.customerRegistrationForm = this.formBuilder.group({
      firstName: ['', [Validators.required, hasNumberValidator]],
      lastName: ['', [Validators.required, hasNumberValidator]],
      birthday: ['', [Validators.required]],
      gender: ['', [Validators.required]],
      avatar: [''],
      fileSource: ['']
     });
  }
  get userName(){
    return this.userRegistrationForm.get('userName');
  }
  get password(){
    return this.userRegistrationForm.get('password');
  }
  get userType(){
    return this.userRegistrationForm.get('userType');
  }
  onFileChange(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.customerRegistrationForm.patchValue({
        fileSource: file
      });
    }
  }
}
