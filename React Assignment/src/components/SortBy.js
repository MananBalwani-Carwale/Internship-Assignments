import React from 'react';
import { changeSortBy } from './../redux/FilterData/FilterDataAction';
import { useDispatch, useDispatcher, useSelector } from 'react-redux';
import './../styles/selectComponent.css';
const SortBy = ()=>
{
    const dispatch = useDispatch();
    const sort = useSelector(store => store.filterData.sort);
    function changeSort(event)
    {
        console.log(sort);
        dispatch(changeSortBy(event.target.value));
    }
    return (
        <select className = "selectComponent" value = {sort} onChange = {changeSort}>
            <option key = "selectOption" value = "Select Option" disabled>Select Option</option>
            <option key = "Price - Low to High" value = "Price - Low to High">Price - Low to High</option>
            <option key = "Price - Hight to Low" value = "Price - High to Low">Price - High to Low</option>
            <option key = "km - Low to High" value = "km - Low to High">km - Low to High</option>
            <option key = "km - High to Low" value = "km - High to Low">km - High to Low</option>
        </select>
    );
}
export default SortBy;