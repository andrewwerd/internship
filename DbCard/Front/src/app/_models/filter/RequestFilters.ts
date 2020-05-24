import { FilterLogicalOperators } from './filterLogicalOperators';
import { Filter } from './filter';

export interface RequestFilters {
    logicalOperator: FilterLogicalOperators;
    filters: Filter[];
}
