import { FormControl, AbstractControl, ValidatorFn, ValidationErrors } from '@angular/forms';

export function confirmPasswordValidator(controlToCompare: AbstractControl): ValidatorFn {
    return (control: AbstractControl): {[key: string]: any} | null => {
      const compare  = controlToCompare.value !== control.value;
      return compare ? {passwordNotConfirmed: {value: compare}} : null;
    };
}
export function hasNumberValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors => {
    const  hasNumber = /[0-9]/.test(control.value);
    return hasNumber ? {passwordInvalid: 'Пароль должен содержать цифры'} : null;
  };
}
export function hasCapitalLetterValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors => {
   const hasCapitalLetter = /[A-Z]/.test(control.value);
   return hasCapitalLetter ? {passwordInvalid : 'Пароль должен содержать заглавные буквы}'} : null;
  };
}
export function hasLowercaseLetterValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors => {
   const hasLowercaseLetter =  /[a-z]/.test(control.value);
   return hasLowercaseLetter ? {passwordInvalid : 'Пароль должен содержать прописные буквы}'} : null;
  };
}


