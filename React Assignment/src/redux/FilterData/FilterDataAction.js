export const CHANGE_FUEL_TYPE = "CHANGE_FUEL_TYPE";
function changeFuelType(payload)
{
    return {
        type : CHANGE_FUEL_TYPE,
        payload : payload
    };
}
export const CHANGE_BUDGET = "CHANGE_BUDGET"
function changeBudget(payload)
{
    return {
        type : CHANGE_BUDGET,
        payload : payload
    };
}
export const CLEAR_FILTER = "CLEAR_FILTER";
function clearFilter()
{
    return {
        type : CLEAR_FILTER
    };
}
export const CHANGE_SORT_BY = "CHANGE_SORT_BY";
function changeSortBy(payload)
{
    return {
        type : CHANGE_SORT_BY,
        payload : payload
    };
}
export { changeFuelType, changeBudget, clearFilter, changeSortBy };