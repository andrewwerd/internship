import { AccountService } from 'src/app/_services/account.service';
import { Observable } from 'rxjs';
import { ValidationErrors, AbstractControl, AsyncValidatorFn } from '@angular/forms';
import { debounceTime, take, map } from 'rxjs/operators';

export function TakenUserNameValidator(accountservice: AccountService): AsyncValidatorFn {
  return (control: AbstractControl): Observable<ValidationErrors | null> => {
    return accountservice.validateName(control.value).pipe(
      map(result => {
        return result.error ? { isTaken: true } : null;
      })
    );
  };
}
