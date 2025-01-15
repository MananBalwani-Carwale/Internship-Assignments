import { CHANGE_BUDGET, CHANGE_FUEL_TYPE, CLEAR_FILTER, CHANGE_SORT_BY } from "./FilterDataAction";
export const initialState = 
{
    fuel : "",
    budget : "",
    sort : "Price - Low to High"
};
function reducer(state = initialState,action)
{
    switch(action.type)
    {
        case CHANGE_FUEL_TYPE : 
            return {
                ...state,
                fuel : action.payload
            };
        case CHANGE_BUDGET : 
            return {
                ...state,
                budget : action.payload
            };
        case CLEAR_FILTER : 
            return initialState;
        case CHANGE_SORT_BY : 
            return {
                ...state,
                sort : action.payload
            };
        default : 
            return state;
    }
}
export default reducer;