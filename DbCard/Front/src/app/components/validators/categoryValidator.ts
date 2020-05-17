import { AbstractControl, ValidatorFn, ValidationErrors } from '@angular/forms';

export function categoryValidator(array: string[]): ValidatorFn {
  return (control: AbstractControl): ValidationErrors => {
    let compare: boolean;
    if (array) {
      compare = array.indexOf(control.value) < 0;
    }
    return compare ? { passwordNotConfirmed: { value: compare } } : null;
  };
}
