import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { CategoryService } from 'src/app/_services/category.service';
import { DateAdapter, MAT_DATE_LOCALE, MAT_DATE_FORMATS } from '@angular/material/core';
import { MomentDateAdapter, MAT_MOMENT_DATE_ADAPTER_OPTIONS, MAT_MOMENT_DATE_FORMATS } from '@angular/material-moment-adapter';
import { MY_FORMATS } from 'src/app/components/dateFormat/dataFormat';
import { AccountService } from 'src/app/_services/account.service';
import { TakenUserNameValidator, TakenEmailValidator } from 'src/app/components/validators/userNameValidator';
import { hasCapitalLetterValidator, hasNumberValidator, hasLowercaseLetterValidator, confirmPasswordValidator } from 'src/app/components/validators/passwordValidator';
import { Category } from 'src/app/_models/category';
import { PartnerForRegistration } from 'src/app/_models/partners/partnerForRegistration';
import { CustomerForRegistration } from 'src/app/_models/customer/customerForRegistration';
import { Router } from '@angular/router';
import { ConfirmRegistrationDialogComponent } from './conirmDialog/confirmRegistrationDialog.component';
import { MatDialog } from '@angular/material/dialog';
import { MomentUtcDateAdapter} from '../../_workaround/dateLocale.workaround';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
  providers: [
    {provide: DateAdapter, useClass: MomentUtcDateAdapter, deps: [MAT_DATE_LOCALE]},
    {provide: MAT_DATE_FORMATS, useValue: MY_FORMATS},
    CategoryService
  ]
})
export class RegistrationComponent implements OnInit {
  userRegistrationForm: FormGroup;
  customerRegistrationForm: FormGroup;
  partnerRegistrationForm: FormGroup;
  categoryValid: boolean;
  categories: Category[];
  subcategories: Category[];
  success: boolean;
  maxDate: Date;
  birthdayDiscount = false;
  dialogRef: any;


  constructor(
    private accountService: AccountService,
    private categoryService: CategoryService,
    private formBuilder: FormBuilder,
    private router: Router,
    private dialog: MatDialog
  ) {
    const currentYear = new Date().getFullYear();
    this.maxDate = new Date(currentYear - 16, 0, 0);
  }

  ngOnInit() {
    this.loadCategories();
    this.partnerRegistrationForm = this.formBuilder.group({
      name: ['', [Validators.required]],
      categoryId: ['', [Validators.required]],
      subcategoryId: ['', [Validators.required]],
      birthdayDiscount: [''],
      site: [''],
      description: ['', [Validators.required]],
      filial: this.formBuilder.group({
        region: ['', [Validators.required]],
        city: ['', [Validators.required]],
        street: ['', [Validators.required]],
        houseNumber: ['', [Validators.required]],
        phoneNumber: ['', [Validators.required]]
      })
    });
    this.customerRegistrationForm = this.formBuilder.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      dateOfBirth: ['', [Validators.required]],
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
      email: ['', {
        validators: [Validators.required, Validators.email],
        asyncValidators: [TakenEmailValidator(this.accountService)],
        updateOn: 'blur'
      }],
      phoneNumber: ['', [
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

  get filialForm() {
    return (this.partnerRegistrationForm.get('filial') as FormGroup).controls;
  }

  get category() {
    if (this.partnerForm.categoryId?.value) {
      return this.categories.find(x => x.id === this.partnerForm.categoryId.value)?.name;
    }
  }

  get subcategory() {
    if (this.partnerForm.subcategoryId?.value) {
      return this.subcategories.find(x => x.id === this.partnerForm.subcategoryId.value)?.name;
    }
  }

  onCategorySelected(id: number) {
    if (id) {
      this.categoryService.getSubcategories(id)
        .subscribe((arg: Category[]) => this.subcategories = arg);
    }
  }

  loadCategories() {
    this.categoryService.getCategories()
      .subscribe((categories: Category[]) => this.categories = categories);
  }

  onRegisterSubmit() {
    if (this.userForm.userType.value === 'customer') {
      const customer: CustomerForRegistration = { ...this.customerRegistrationForm.value };
      customer.email = this.userForm.email.value;
      customer.userName = this.userForm.userName.value;
      customer.password = this.userForm.password.value;
      this.accountService.customerRegistration(customer).subscribe(
        result => {
          this.success = result;
          this.openDialog();
        }
      );
    }
    else if (this.userForm.userType.value === 'partner') {
      const partner: PartnerForRegistration = { ...this.partnerRegistrationForm.value };
      if (!this.birthdayDiscount){
        partner.birthdayDiscount = null;
      }
      partner.phoneNumber = this.userForm.phoneNumber.value;
      partner.email = this.userForm.email.value;
      partner.userName = this.userForm.userName.value;
      partner.password = this.userForm.password.value;
      this.accountService.partnerRegistration(partner).subscribe(
        result => {
          this.success = result;
          this.openDialog();
        }
      );
    }
  }

  openDialog(): void {
    this.dialogRef = this.dialog.open(ConfirmRegistrationDialogComponent, { data: this.success });
    this.dialogRef.afterClosed().subscribe(result => {
      if (this.success) {
        this.router.navigate(['/login']);
      }
    });
  }

}

