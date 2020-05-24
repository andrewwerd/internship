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
  pageSize = 6;
  searchInput = new FormControl('');
  requestFilters: RequestFilters;
  constructor(private balanceService: BalanceService) { }

  ngOnInit(): void {
    this.loadBalances();
  }

  getAll() {
    this.requestFilters = { filters: [], logicalOperator: FilterLogicalOperators.And };
    this.loadBalances();
  }

  getPremium() {
    const filter: Filter = { path: 'type', value: 'premium' };
    this.applyFilterFromButton(filter);
    this.loadBalances();
  }

  getStandart() {
    const filter: Filter = { path: 'type', value: 'standart' };
    this.applyFilterFromButton(filter);
    this.loadBalances();
  }

  loadBalances() {
    const scrollRequest = new ScrollRequest(this.pageIndex, this.pageSize, this.requestFilters);
    this.balanceService.getBalancesPaged(scrollRequest).subscribe((pagedBalances: Balance[]) => {
      if (pagedBalances) {
        this.addItems(pagedBalances);
      }
    });
  }

  addItems(discounts: Balance[]) {
    discounts.forEach(element => {
      this.balances.push(element);
    });
  }

  onScroll() {
    this.pageIndex++;
    this.loadBalances();
  }

  applySearch() {
    this.createFiltersFromSearchInput();
    this.loadBalances();
  }

  private createFiltersFromSearchInput() {
    const filterValue = this.searchInput.value.trim();
    if (filterValue) {
      const filters: Filter[] = [];
      const filter: Filter = { path: 'partner.name', value: filterValue };
      filters.push(filter);
      this.requestFilters = {
        logicalOperator: FilterLogicalOperators.Or,
        filters
      };
    } else {
      this.getAll();
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
