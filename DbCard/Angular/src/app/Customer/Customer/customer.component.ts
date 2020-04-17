import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-customer',
    templateUrl: './customer.component.html',
    styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

    constructor(private router: Router){ }

    ngOnInit(): void {
    }

    logout(): void {
        localStorage.removeItem('accessToken');
        this.router.navigate(['login']);
    }
}
