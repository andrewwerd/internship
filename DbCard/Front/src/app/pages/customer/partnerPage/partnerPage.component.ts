import { Component, OnInit, AfterViewInit } from '@angular/core';
import { PartnerService } from 'src/app/_services/partner.service';
import { Partner } from 'src/app/_models/partners/partner';
import { ActivatedRoute } from '@angular/router';
import { Filial } from 'src/app/_models/filial/filial';
import { News } from 'src/app/_models/news/news';

@Component({
  selector: 'app-partner-page',
  templateUrl: './partnerPage.component.html',
  styleUrls: ['./partnerPage.component.css']
})
export class PartnerPageComponent implements OnInit {
  partner: Partner;
  filials: Filial[];
  news: News[];
  displayedColumns: string[] = ['region', 'city', 'street', 'houseNumber', 'phoneNumber'];
  constructor(
    private route: ActivatedRoute,
    private partnerService: PartnerService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      const partnerId = +params.id;
      this.loadPartner(partnerId);
      this.loadNews(partnerId);
    });
  }
  loadPartner(id: number) {
    this.partnerService.getPartner(id).subscribe((partner: Partner) => {
      this.partner = partner;
      this.loadFilials(partner.id);
    });
  }
  loadFilials(id: number) {
    this.partnerService.loadFilials(id).subscribe((filials: Filial[]) => {
      this.filials = filials;
    });
  }
  loadNews(id: number) {
    this.partnerService.loadNews(id).subscribe((news: News[]) => {
      this.news = news;
    });
  }
}
