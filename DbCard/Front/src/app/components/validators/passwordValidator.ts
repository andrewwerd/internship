import { AbstractControl, ValidatorFn, ValidationErrors } from '@angular/forms';

export function confirmPasswordValidator(controlToCompare: string): ValidatorFn {
    return (control: AbstractControl): ValidationErrors => {
      let compare: boolean;
      if (control.parent) {
      compare  = control.parent.get(controlToCompare)?.value !== control.value;
      }
      return compare ? {passwordNotConfirmed: {value: compare}} : null;
    };
}
export function hasNumberValidator(control: AbstractControl): ValidationErrors{
    const  hasNumber = !(/[0-9]/.test(control.value));
    return hasNumber ? {number: {value: hasNumber}} : null;
}
export function hasCapitalLetterValidator(control: AbstractControl): ValidationErrors {
   const hasCapitalLetter = !/[A-Z]/.test(control.value);
   return hasCapitalLetter ? {capital : 'Пароль должен содержать заглавные буквы}'} : null;
}
export function hasLowercaseLetterValidator(control: AbstractControl): ValidationErrors{
   const hasLowercaseLetter = !/[a-z]/.test(control.value);
   return hasLowercaseLetter ? {lower : 'Пароль должен содержать прописные буквы}'} : null;
}


