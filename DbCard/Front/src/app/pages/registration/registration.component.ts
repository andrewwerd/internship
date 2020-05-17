import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { PartnerService } from 'src/app/_services/partner.service';
import { DateAdapter, MAT_DATE_LOCALE, MAT_DATE_FORMATS } from '@angular/material/core';
import { MomentDateAdapter, MAT_MOMENT_DATE_ADAPTER_OPTIONS } from '@angular/material-moment-adapter';
import { MY_FORMATS } from 'src/app/components/dateFormat/dataFormat';
import { AccountService } from 'src/app/_services/account.service';
import { TakenUserNameValidator } from 'src/app/components/validators/userNameValidator';
import { hasCapitalLetterValidator, hasNumberValidator, hasLowercaseLetterValidator, confirmPasswordValidator } from 'src/app/components/validators/passwordValidator';
import { categoryValidator } from '../../components/validators/categoryValidator';
import { Category } from 'src/app/_models/category';


@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
  providers: [
    {
      provide: DateAdapter,
      useClass: MomentDateAdapter,
      deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS]
    },
    { provide: MAT_DATE_FORMATS, useValue: MY_FORMATS },
    { provide: MAT_MOMENT_DATE_ADAPTER_OPTIONS, useValue: 'ru' }
  ]
})
export class RegistrationComponent implements OnInit {
  userRegistrationForm: FormGroup;
  customerRegistrationForm: FormGroup;
  partnerRegistrationForm: FormGroup;
  categoryValid: boolean;
  categories: Category[];
  subcategories: Category[];
  foto: File;
  maxDate: Date;
  birthdayDiscount = false;

  constructor(
    private accountService: AccountService,
    private partnerService: PartnerService,
    private formBuilder: FormBuilder) {
    const currentYear = new Date().getFullYear();
    this.maxDate = new Date(currentYear - 16, 0, 1);
  }

  ngOnInit() {
    this.loadCategories();
    this.partnerRegistrationForm = this.formBuilder.group({
      name: ['', [Validators.required]],
      category: ['', [Validators.required]],
      subcategory: ['', [Validators.required]],
      birthdayDiscount: [''],
      description: ['', [Validators.required]],
    });
    this.customerRegistrationForm = this.formBuilder.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      birthday: ['', [Validators.required]],
      gender: ['', [Validators.required]],
    });
    this.userRegistrationForm = this.formBuilder.group({
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
      email: ['', [
        Validators.required,
        Validators.email
      ]],
      phone: ['', [
        Validators.required,
        Validators.min(9)
      ]],
      userType: ['', [Validators.required]]
    });
  }
  get userForm() {
    return this.userRegistrationForm.controls;
  }
  get customerForm() {
    return this.customerRegistrationForm.controls;
  }
  get partnerForm() {
    return this.partnerRegistrationForm.controls;
  }
  get birthday(){
    return new Date(this.customerForm.birthday.value);
  }
  onCategorySelected() {
    if (this.partnerForm.category.valid) {
      this.partnerService.getSubcategories(this.partnerForm.category.value)
      .subscribe((arg: Category[]) => this.subcategories = arg);
    }
  }
  loadCategories(){
    this.partnerService.getCategories()
    .subscribe((categories: Category[]) => this.categories = categories);
  }
  onRegisterSubmit(){
  }
  onFileSelected(event) {
    this.foto = event.target.files[0];
  }
}

