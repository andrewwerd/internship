import { Component, OnInit, AfterViewInit } from '@angular/core';
import { PartnerService } from 'src/app/_services/partner.service';
import { Partner } from 'src/app/_models/partners/partner';
import { ActivatedRoute } from '@angular/router';
import { Filial } from 'src/app/_models/filial/filial';
import { News } from 'src/app/_models/news/news';
import { catchError, map, Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { MapGeocoder } from '@angular/google-maps';

@Component({
  selector: 'app-partner-page',
  templateUrl: './partnerPage.component.html',
  styleUrls: ['./partnerPage.component.css']
})
export class PartnerPageComponent implements OnInit {
  partner: Partner | undefined;
  filials: Filial[] = [];
  markerPositions: google.maps.LatLng[] = [];
  news: News[] | undefined;
  apiLoaded: Observable<boolean>;
  displayedColumns: string[] = ['region', 'city', 'street', 'houseNumber', 'phoneNumber'];

  center: google.maps.LatLngLiteral = { lat: 47.003670, lng: 28.857089 };
  zoom = 12;

  constructor(
    private route: ActivatedRoute,
    private partnerService: PartnerService,
    httpClient: HttpClient,
    private geocoder: MapGeocoder
  ) {
    this.apiLoaded = httpClient.jsonp('https://maps.googleapis.com/maps/api/js?key=AIzaSyBzdVtTBwZ3iZk4SWNK_ktfzxHCejyjntQ', 'callback')
      .pipe(
        map(() => true),
        catchError(() => of(false)),
      );
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      const partnerId = +params.id;
      this.loadPartner(partnerId);
      this.loadNews(partnerId);
    });
  }
  loadPartner(id: number) {
    this.partnerService.getPartnerInfo(id).subscribe((partner: Partner) => {
      this.partner = partner;
      this.loadFilials(partner.id);
    });
  }
  loadFilials(id: number) {
    this.partnerService.loadFilials(id).subscribe((filials: Filial[]) => {
      this.filials = filials;
      filials.forEach(filial => {
        const address = `${filial.street} ${filial.houseNumber}, ${filial.city}, Moldova`; 
        this.geocoder.geocode({
          address: address
        }).subscribe(({ results }) => { 
          this.markerPositions.push(results[0].geometry.location)
        });
      })

    });
  }
  loadNews(id: number) {
    this.partnerService.loadNews(id).subscribe((news: News[]) => {
      this.news = news;
    });
  }
}
