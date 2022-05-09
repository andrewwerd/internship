import { Component, OnInit } from '@angular/core';
import { PartnerService } from 'src/app/_services/partner.service';
import { PartnerGridRow } from 'src/app/_models/partners/partnerGridRow';
import { ScrollRequest } from 'src/app/_models/scrollPaginate/scroll';
import { RequestFilters } from 'src/app/_models/filter/requestFilters'; 

@Component({
  selector: 'app-partner-list',
  templateUrl: './partnerList.component.html',
  styleUrls: ['./partnerList.component.css']
})
export class PartnerListComponent implements OnInit {

  partners: PartnerGridRow[] = [];
  pageIndex = 0;
  pageSize = 10;
  requestFilters: RequestFilters | undefined;

  constructor(private partnerService: PartnerService) { }

  ngOnInit() {
    this.loadPartners();
  }

  loadPartners() {
    const scrollRequest = new ScrollRequest(this.pageIndex, this.pageSize, this.requestFilters);
    this.partnerService.getPartnersPaged(scrollRequest).subscribe((partners: PartnerGridRow[]) => {
      this.partners = partners;
    });
  }

  loadPartnersOnScroll() {
    const scrollRequest = new ScrollRequest(this.pageIndex + 1, this.pageSize, this.requestFilters);
    this.partnerService.getPartnersPaged(scrollRequest).subscribe((partners: PartnerGridRow[]) => {
      this.addItems(partners);
    });
  }

  private addItems(partners: PartnerGridRow[]) {
    if (partners) {
      this.pageIndex++;
      partners.forEach(item => {
        this.partners.push(item);
      });
    }
  }

  onScroll() {
    this.loadPartnersOnScroll();
  }
}
