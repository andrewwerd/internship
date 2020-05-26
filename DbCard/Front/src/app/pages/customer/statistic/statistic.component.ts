import { Component, OnInit, ViewChild } from '@angular/core';
import { Transaction } from 'src/app/_models/transaction/transactions';
import { MatPaginator } from '@angular/material/paginator';
import { TableColumn } from 'src/app/_models/tablePaginate/tableColumn';
import { MatSort } from '@angular/material/sort';
import { FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { TransactionService } from 'src/app/_services/transaction.service';
import { merge } from 'rxjs';
import { PaginatedRequest } from 'src/app/_models/tablePaginate/paginatedRequest';
import { RequestFilters } from 'src/app/_models/filter/requestFilters';
import { PagedResult } from 'src/app/_models/tablePaginate/pagedResult';
import { FilterLogicalOperators } from 'src/app/_models/filter/filterLogicalOperators';
import { Filter } from 'src/app/_models/filter/filter';
import { Period } from 'src/app/_models/transaction/period';
import { CategoryService } from 'src/app/_services/category.service';
import { Category } from 'src/app/_models/category';

@Component({
  selector: 'app-statistic',
  templateUrl: './statistic.component.html',
  styleUrls: ['./statistic.component.css'],
  providers: [ CategoryService]
})
export class StatisticComponent implements OnInit {
  categories: Category[];
  subcategories: Category[];
  period = Period;
  tableColumns: TableColumn[] = [
    { name: 'partnerName', index: 'partnerName', displayName: 'Партнёр', useInSearch: true },
    { name: 'address', index: 'address', displayName: 'Адресс филиала', useInSearch: true },
    { name: 'category', index: 'category.name', displayName: 'Категория', useInSearch: true },
    { name: 'subcategory', index: 'subcategory.name', displayName: 'Подкатегория', useInSearch: true },
    { name: 'dateTime', index: 'dateTime', displayName: 'Дата и время' },
    { name: 'allAmount', index: 'allAmount', displayName: 'Полная сумма' },
    { name: 'amountForPay', index: 'amountForPay', displayName: 'Сумма к оплате' },
    { name: 'discountAmount', index: 'discountAmount', displayName: 'Сумма скидки' },
    { name: 'accumulationAmount', index: 'accumulationAmount', displayName: 'Сумма накопленая' },
    { name: 'id', index: 'id', displayName: 'id' }
  ];
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  displayedColumns: string[];

  searchInput = new FormControl('');
  filterForm: FormGroup;

  pagedTransactions: PagedResult<Transaction>;
  requestFilters: RequestFilters;
  constructor(
    private transactionService: TransactionService,
    private formBuilder: FormBuilder,
    private categoryService: CategoryService
  ) {
    this.displayedColumns = this.tableColumns.map(column => column.name);
    this.filterForm = this.formBuilder.group({
      category: [''],
      subcategory: [''],
      period: ['']
    });
    this.loadCategories();
  }
 get filter(){
   return this.filterForm.controls;
 }
  ngOnInit() {
    this.loadTransactions();
    this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);

    merge(this.sort.sortChange, this.paginator.page).subscribe(() => {
      this.loadTransactions();
    });
  }
  loadTransactions() {
    const paginatedRequest = new PaginatedRequest(this.paginator, this.sort, this.requestFilters);
    this.transactionService.getTransactionsPaged(paginatedRequest)
      .subscribe((pagedTransactions: PagedResult<Transaction>) => {
        this.pagedTransactions = pagedTransactions;
      });
  }
  resetGrid() {
    this.filterForm.reset();
    this.requestFilters = { filters: [], logicalOperator: FilterLogicalOperators.And };
    this.loadTransactions();
  }
  deleteTransaction(id: number) {
    this.transactionService.deleteTransaction(id).subscribe(
      () => {
        this.loadTransactions();
      });
  }

  applyFilters() {
    this.createFiltersFromForm();
    this.loadTransactions();
  }
  applySearch() {
    this.createFiltersFromSearchInput();
    this.loadTransactions();
  }
  private createFiltersFromForm() {
    if (this.filterForm.value) {
      const filters: Filter[] = [];

      Object.keys(this.filterForm.controls).forEach(key => {

        const controlValue = this.filterForm.controls[key].value;
        if (controlValue) {
          if (key !== 'period') {
            const foundTableColumn = this.tableColumns.find(tableColumn => tableColumn.name === key);
            const filter: Filter = { path: foundTableColumn.index, value: controlValue };
            filters.push(filter);
          }
          else{
            const filter: Filter = { path: 'period', value: controlValue };
            filters.push(filter);
          }
        }
      });

      this.requestFilters = {
        logicalOperator: FilterLogicalOperators.And,
        filters
      };
    }
  }
  private createFiltersFromSearchInput() {
    const filterValue = this.searchInput.value.trim();
    if (filterValue) {
      const filters: Filter[] = [];
      this.tableColumns.forEach(column => {
        if (column.useInSearch) {
          const filter: Filter = { path: column.index, value: filterValue };
          filters.push(filter);
        }
      });
      this.requestFilters = {
        logicalOperator: FilterLogicalOperators.Or,
        filters
      };
    } else {
      this.resetGrid();
    }
  }
  onCategorySelected(id: number) {
    if (id) {
      this.categoryService.getSubcategories(id)
        .subscribe((arg: Category[]) => this.subcategories = arg);
    }
  }

  loadCategories() {
    this.categoryService.getCategories()
      .subscribe((categories: Category[]) => this.categories = categories);
  }
}
