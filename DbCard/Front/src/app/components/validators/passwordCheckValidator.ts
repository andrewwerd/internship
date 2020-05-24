import { AccountService } from 'src/app/_services/account.service';
import { Observable } from 'rxjs';
import { ValidationErrors, AbstractControl, AsyncValidatorFn } from '@angular/forms';
import { map } from 'rxjs/operators';

export function checkPassword(accountservice: AccountService): AsyncValidatorFn {
  return (control: AbstractControl): Observable<ValidationErrors | null> => {
    return accountservice.checkPassword(control.value).pipe(
      map(result => {
        return result.error ? { isWrong: true } : null;
      })
    );
  };
}
