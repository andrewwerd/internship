import { Component, OnInit } from '@angular/core';
import { Partner } from '../../../_models/partners/partner'; 
import { AccountService } from 'src/app/_services/account.service'; 
import { PartnerService } from 'src/app/_services/partner.service';

@Component({
  selector: 'app-partner',
  templateUrl: './partner.component.html',
  styleUrls: ['./partner.component.css'],
})
export class PartnerComponent implements  OnInit {
  partner: Partner | undefined;
  constructor(private accountService: AccountService,
    private partnerService: PartnerService) {
  }
  ngOnInit(){
    this.loadPartner();
  }
  logout() {
    this.accountService.logout();
  }
  
  loadPartner() {
    this.partnerService.getPartner().subscribe((partner: Partner) => {
      this.partner = partner; 
    });
  }
}
