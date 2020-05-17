import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AccountService } from '../_services/account.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
    constructor(private accountService: AccountService, private router: Router) {}

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
      const currentUser = this.accountService.currentUserValue;
      if (currentUser) {
            if (route.data.roles && route.data.roles.indexOf(currentUser.role) === -1) {
                this.router.navigate(['/']);
                return false;
            }
            return true;
          }
      this.router.navigate(['login'], { queryParams: { returnUrl: state.url }});
      return false;
    }
}
