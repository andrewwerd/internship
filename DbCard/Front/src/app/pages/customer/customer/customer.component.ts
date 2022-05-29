import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/_services/account.service';
import { User } from 'src/app/_models/account/user';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css'],
})
export class CustomerComponent implements OnInit {
  user: User | undefined;
  constructor(private accountService: AccountService) {
  }
  ngOnInit() {
    this.accountService.currentUser.subscribe(user => this.user = user)
  }
  logout() {
    this.accountService.logout();
  }
}
