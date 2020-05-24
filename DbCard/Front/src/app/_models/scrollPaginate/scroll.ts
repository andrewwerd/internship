import { RequestFilters } from '../filter/requestFilters';

export class ScrollRequest {
    pageIndex: number;
    pageSize: number;
    requestFilters: RequestFilters;

    constructor(pageIndex: number, pageSize: number, requestFilters?: RequestFilters) {
      this.pageIndex = pageIndex;
      this.pageSize = pageSize;
      this.requestFilters = requestFilters;
  }
}

