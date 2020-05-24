import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../../_services/customer.service';
import { FormGroup, FormBuilder, Validators, Form } from '@angular/forms';
import { TakenUserNameValidator, TakenEmailValidator } from 'src/app/components/validators/userNameValidator';
import { hasCapitalLetterValidator, hasNumberValidator, hasLowercaseLetterValidator, confirmPasswordValidator } from 'src/app/components/validators/passwordValidator';
import { AccountService } from 'src/app/_services/account.service';
import { Customer } from 'src/app/_models/customer/customer';
import { UserForEdit } from 'src/app/_models/account/userForEdit';
import { checkPassword } from 'src/app/components/validators/passwordCheckValidator';
import { PasswordForEdit } from 'src/app/_models/account/passwordForEdit';
import { DateAdapter, MAT_DATE_LOCALE, MAT_DATE_FORMATS } from '@angular/material/core';
import { MomentUtcDateAdapter } from 'src/app/_workaround/dateLocale.workaround';
import { MY_FORMATS } from 'src/app/components/dateFormat/dataFormat';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmDialogComponent } from './confirmDialog/confirmDialog.component';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-edit-customer',
  templateUrl: './editCustomer.component.html',
  styleUrls: ['./editCustomer.component.css'],
  providers: [
    { provide: DateAdapter, useClass: MomentUtcDateAdapter, deps: [MAT_DATE_LOCALE] },
    { provide: MAT_DATE_FORMATS, useValue: MY_FORMATS },
  ]
})
export class EditCustomerComponent implements OnInit {
  customerEditForm: FormGroup;
  userEditForm: FormGroup;
  passwordEditForm: FormGroup;
  maxDate: Date;
  constructor(
    private formBuilder: FormBuilder,
    private customerService: CustomerService,
    private accountService: AccountService,
    private dialog: MatDialog,
    private snackBar: MatSnackBar
  ) {
    const currentYear = new Date().getFullYear();
    this.maxDate = new Date(currentYear - 16, 0, 0);
  }

  ngOnInit() {
    this.getCustomer();
    this.getUser();
    this.customerEditForm = this.formBuilder.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      dateOfBirth: ['', [Validators.required]],
      gender: ['', [Validators.required]],
      barcode: ['', [Validators.required]]
    });
    this.userEditForm = this.formBuilder.group({
      userName: ['', {
        validators: [Validators.required],
        updateOn: 'blur'
      }],
      email: ['', {
        validators: [Validators.required, Validators.email],
        updateOn: 'blur'
      }],
      phoneNumber: ['', [
        Validators.required,
        Validators.min(9)
      ]]
    });
    this.passwordEditForm = this.formBuilder.group({
      currentPassword: ['', {
        validators: [Validators.required],
        asyncValidators: [checkPassword(this.accountService)],
        updateOn: 'blur'
      }],
      newPassword: ['', [
        Validators.required,
        hasCapitalLetterValidator,
        hasNumberValidator,
        hasLowercaseLetterValidator,
        Validators.minLength(8)
      ]],
      newPasswordConfirm: ['', [
        Validators.required,
        confirmPasswordValidator('newPassword')
      ]],
    });
  }
  get customerForm() {
    return this.customerEditForm.controls;
  }
  get passwordForm() {
    return this.passwordEditForm.controls;
  }
  get userForm() {
    return this.userEditForm.controls;
  }
  getCustomer() {
    this.customerService.getCustomer().subscribe((customer: Customer) => {
      this.customerEditForm.patchValue({
        ...customer
      });
    });
  }
  getUser() {
    this.accountService.getUser().subscribe((user: UserForEdit) => {
      this.userEditForm.patchValue({
        ...user
      });
      this.userEditForm.controls.userName.setAsyncValidators(TakenUserNameValidator(this.accountService, user.userName));
      this.userEditForm.controls.email.setAsyncValidators(TakenEmailValidator(this.accountService, user.email));
    });
  }
  saveCustomer() {
    if (this.customerEditForm.dirty && this.customerEditForm.valid) {
      const customerToSave: Customer = {
        ...this.customerEditForm.value
      };
      this.customerService.editCustomer(customerToSave).subscribe(result => {
        let message: string;
        if (result) {
          message = 'Изменения успешно сохранены';
        }
        else {
          message = 'Изменения не сохранены, попробуйте позже';
        }
        this.snackBar.open(message, 'Закрыть', {
          duration: 5000
        });
      });
    }
  }
  resetCustomer() {
    this.customerEditForm.reset();
    this.getCustomer();
  }
  saveUser() {
    if (this.userEditForm.dirty && this.userEditForm.valid) {
      const userToSave: UserForEdit = {
        ...this.userEditForm.value
      };
      this.accountService.editUser(userToSave).subscribe(result => {
        let message: string;
        if (result) {
          message = 'Изменения успешно сохранены';
        }
        else {
          message = 'Изменения не сохранены, попробуйте позже';
        }
        this.snackBar.open(message, 'Закрыть', {
          duration: 5000
        });
      });
    }
  }
  resetUser() {
    this.userEditForm.reset();
    this.userForm.userName.clearAsyncValidators();
    this.userForm.email.clearAsyncValidators();
    this.getUser();
  }
  savePassword() {
    if (this.passwordEditForm.dirty && this.passwordEditForm.valid) {
      const passwordToSave: PasswordForEdit = {
        ...this.passwordEditForm.value
      };
      this.accountService.editPassword(passwordToSave).subscribe(result => {
        let message: string;
        if (result) {
          message = 'Изменения успешно сохранены';
        }
        else {
          message = 'Изменения не сохранены, попробуйте позже';
        }
        this.snackBar.open(message, 'Закрыть', {
          duration: 5000
        });
      });
    }
  }
  resetPassword() {
    this.passwordEditForm.reset();
  }
  openDialogForCustomerConfirm() {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      data: { title: 'Подтверждение', message: 'Вы уверенны в своих изменениях?' }
    });
    dialogRef.disableClose = true;
    dialogRef.afterClosed().subscribe(result => {
      if (result === dialogRef.componentInstance.ACTION_CONFIRM) {
        this.saveCustomer();
      }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result === dialogRef.componentInstance.ACTION_CANCEL) {
        this.resetCustomer();
      }
    });
  }
  openDialogForUserConfirm() {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      data: { title: 'Подтверждение', message: 'Вы уверенны в своих изменениях?' }
    });
    dialogRef.disableClose = true;
    dialogRef.afterClosed().subscribe(result => {
      if (result === dialogRef.componentInstance.ACTION_CONFIRM) {
        this.saveUser();
      }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result === dialogRef.componentInstance.ACTION_CANCEL) {
        this.resetUser();
      }
    });
  }
  openDialogForPasswordConfirm() {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      data: { title: 'Подтверждение', message: 'Вы уверенны в своих изменениях?' }
    });
    dialogRef.disableClose = true;
    dialogRef.afterClosed().subscribe(result => {
      if (result === dialogRef.componentInstance.ACTION_CONFIRM) {
        this.savePassword();
      }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result === dialogRef.componentInstance.ACTION_CANCEL) {
        this.resetPassword();
      }
    });
  }
}
