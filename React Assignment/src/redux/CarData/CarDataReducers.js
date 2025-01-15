import { FETCH_DATA, FETCH_DATA_FAILURE, FETCH_DATA_SUCCESS } from './CarDataActions';
const initialState = 
{
    loading : true,
    data : [],
    error : ''
};
function reducer(state = initialState, action)
{
    switch(action.type)
    {
        case FETCH_DATA : 
            return {
                ...state,
                loading : true
            };
        case FETCH_DATA_SUCCESS :
            return {
                ...state,
                loading : false,
                data : action.payload,
                error :''
            };
        case FETCH_DATA_FAILURE : 
            return {
                ...state,
                loading : false,
                error : action.payload,
                data : []
            };
        default :
            return state;
    }
}
export default reducer;