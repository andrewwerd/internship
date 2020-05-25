import { Component, OnInit } from '@angular/core';
import { PartnerService } from 'src/app/_services/partner.service';
import { PartnerGridRow } from 'src/app/_models/partners/partnerGridRow';
import { ScrollRequest } from 'src/app/_models/scrollPaginate/scroll';
import { RequestFilters } from 'src/app/_models/filter/requestFilters';
import { StarRatingComponent } from 'ng-starrating';

@Component({
  selector: 'app-partner-list',
  templateUrl: './partnerList.component.html',
  styleUrls: ['./partnerList.component.css']
})
export class PartnerListComponent implements OnInit {

  partners: PartnerGridRow[] = [];
  pageIndex = 0;
  pageSize = 6;
  requestFilters: RequestFilters;

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
    const scrollRequest = new ScrollRequest(this.pageIndex, this.pageSize, this.requestFilters);
    this.partnerService.getPartnersPaged(scrollRequest).subscribe((partners: PartnerGridRow[]) => {
      this.addItems(partners);
    });
  }

  private addItems(partners: PartnerGridRow[]) {
    if (partners) {
      partners.forEach(item => {
        this.partners.push(item);
      });
    }
  }

  onScroll() {
    this.pageIndex++;
    this.loadPartnersOnScroll();
  }
  onRate($event: {oldValue: number, newValue: number, starRating: StarRatingComponent}) {
    alert(`Old Value:${$event.oldValue},
      New Value: ${$event.newValue},
      Checked Color: ${$event.starRating.checkedcolor},
      Unchecked Color: ${$event.starRating.uncheckedcolor}`);
  }
}
