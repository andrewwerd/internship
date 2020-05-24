import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../../_services/customer.service';
import { CustomerForRegistration } from '../../../_models/customer/customerForRegistration';
import { FormGroup, FormBuilder, Validators, Form } from '@angular/forms';
import { Router } from '@angular/router';
import { TakenUserNameValidator, TakenEmailValidator } from 'src/app/components/validators/userNameValidator';
import { hasCapitalLetterValidator, hasNumberValidator, hasLowercaseLetterValidator, confirmPasswordValidator } from 'src/app/components/validators/passwordValidator';
import { AccountService } from 'src/app/_services/account.service';
import { Customer } from 'src/app/_models/customer/customer';


@Component({
  selector: 'app-edit-customer',
  templateUrl: './editCustomer.component.html',
  styleUrls: ['./editCustomer.component.css'],
})
export class EditCustomerComponent implements OnInit {
  customerId: number;
  customerEditForm: FormGroup;
  userEditForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private customerService: CustomerService,
    private accountService: AccountService
  ) {  }

  ngOnInit() {
    this.getCustomer();
    this.customerEditForm = this.formBuilder.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      birthday: ['', [Validators.required]],
      gender: ['', [Validators.required]],
    });
    this.userEditForm = this.formBuilder.group({
      userName: ['', {
        validators: [Validators.required],
        asyncValidators: [TakenUserNameValidator(this.accountService)],
        updateOn: 'blur'
      }],
      password: ['', [
        Validators.required,
        hasCapitalLetterValidator,
        hasNumberValidator,
        hasLowercaseLetterValidator,
        Validators.minLength(8)
      ]],
      passwordConfirm: ['', [
        Validators.required,
        confirmPasswordValidator('password')
      ]],
      email: ['', {
        validators: [Validators.required, Validators.email],
        asyncValidators: [TakenEmailValidator(this.accountService)],
        updateOn: 'blur'
      }],
      phoneNumber: ['', [
        Validators.required,
        Validators.min(9)
      ]]
    });
  }

  getCustomer() {
    this.customerService.getCustomer().subscribe((customer: Customer) => {
      this.customerEditForm.patchValue({
        ...customer
      });
    });
  }

  saveBook() {
    if (this.customerEditForm.dirty && this.customerEditForm.valid) {
       const customerToSave: Customer = {
         ...this.customerEditForm.value
       };

       this.customerService.editCustomer(customerToSave).subscribe();
    }
  }
}
