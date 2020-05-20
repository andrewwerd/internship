import { AccountService } from 'src/app/_services/account.service';
import { Observable } from 'rxjs';
import { ValidationErrors, AbstractControl, AsyncValidatorFn } from '@angular/forms';
import { map } from 'rxjs/operators';

export function TakenUserNameValidator(accountservice: AccountService): AsyncValidatorFn {
  return (control: AbstractControl): Observable<ValidationErrors | null> => {
    return accountservice.validateName(control.value).pipe(
      map(result => {
        return result.error ? { isTaken: true } : null;
      })
    );
  };
}
export function TakenEmailValidator(accountservice: AccountService): AsyncValidatorFn {
  return (control: AbstractControl): Observable<ValidationErrors | null> => {
    return accountservice.validateEmail(control.value).pipe(
      map(result => {
        return result.error ? { isTaken: true } : null;
      })
    );
  };
}
