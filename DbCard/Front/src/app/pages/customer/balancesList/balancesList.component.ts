import { Component, OnInit } from '@angular/core';
import { Balance } from '../../../_models/discounts/balance';
import { FormControl } from '@angular/forms';
import { BalanceService } from 'src/app/_services/balance.service';
import { Filter } from 'src/app/_models/filter/filter';
import { FilterLogicalOperators } from 'src/app/_models/filter/filterLogicalOperators';
import { RequestFilters } from 'src/app/_models/filter/requestFilters';
import { ScrollRequest } from 'src/app/_models/scrollPaginate/scroll';

@Component({
  selector: 'app-balances-list',
  templateUrl: './balancesList.component.html',
  styleUrls: ['./balancesList.component.css']
})
export class BalancesListComponent implements OnInit {
  balances: Balance[] = [];
  pageIndex = 0;
  pageSize = 4;
  searchInput = new FormControl('');
  requestFilters: RequestFilters;
  constructor(private balanceService: BalanceService) { }

  ngOnInit(): void {
    this.getPremium();
  }


  getPremium() {
    this.pageIndex = 0;
    const filter: Filter = { path: 'type', value: 'Premium' };
    this.applyFilterFromButton(filter);
    this.searchInput.reset();
    this.loadBalances();
  }

  getStandart() {
    this.pageIndex = 0;
    const filter: Filter = { path: 'type', value: 'Standart' };
    this.applyFilterFromButton(filter);
    this.searchInput.reset();
    this.loadBalances();
  }

  loadBalances() {
    const scrollRequest = new ScrollRequest(this.pageIndex, this.pageSize, this.requestFilters);
    this.balanceService.getBalancesPaged(scrollRequest).subscribe((pagedBalances: Balance[]) => {
        this.balances = pagedBalances;
    });
  }
  loadBalancesScrolled() {
    const scrollRequest = new ScrollRequest(this.pageIndex  + 1, this.pageSize, this.requestFilters);
    this.balanceService.getBalancesPaged(scrollRequest).subscribe((pagedBalances: Balance[]) => {
      if (pagedBalances) {
        this.addItems(pagedBalances);
        this.pageIndex++;
      }
    });
  }

  addItems(discounts: Balance[]) {
    discounts.forEach(element => {
      this.balances.push(element);
    });
  }

  onScroll() {
    this.loadBalancesScrolled();
  }

  applySearch() {
    this.createFiltersFromSearchInput();
    this.loadBalances();
  }

  private createFiltersFromSearchInput() {
    const filterValue = this.searchInput.value.trim();
    if (filterValue) {
      const filter: Filter = { path: 'partner.name', value: filterValue };
      const searchFilter = this.requestFilters.filters.find(x => x.path === filter.path);
      if (searchFilter){
        searchFilter.value = filter.value;
      }
      else{
        this.requestFilters.filters.push(filter);
      }
    }
    else {
      this.loadBalances();
    }
  }

  private applyFilterFromButton(filter: Filter) {
    if (filter) {
      const filters: Filter[] = [];
      filters.push(filter);
      this.requestFilters = {
        logicalOperator: FilterLogicalOperators.And,
        filters
      };
    }
  }
}
