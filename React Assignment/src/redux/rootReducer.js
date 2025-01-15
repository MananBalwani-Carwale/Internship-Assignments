import {combineReducers} from 'redux';
import carReducer from './CarData/CarDataReducers';
import filterReducer from './FilterData/FilterDataReducers';
const rootReducer = combineReducers({
    "carData" : carReducer,
    "filterData" : filterReducer
});
export default rootReducer;