export interface Pagination {
    currentPage: number;
    itemsPerPage: number;
    totalItems: number;
    totalPages: number;
  }

  // tslint:disable-next-line: align
  export class PaginatedResult<T> {
    result: T;
    pagination: Pagination;
  }
