import React, { useEffect, useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { fetchData } from './../redux/CarData/CarDataActions';
import Card from './Card';
import './../styles/body.css';
import sortData from './utils/Sort';
const Body = ()=>
{
    const dispatch = useDispatch();
    const filterStore = useSelector(store => store.filterData);
    useEffect(()=>
    {
        dispatch(fetchData(filterStore));
    },[filterStore.fuel,filterStore.budget]);
    var cars = useSelector(store => store.carData);
    var loading = cars.loading;
    var error = cars.error;
    var sort = filterStore.sort;
    var data = [];
    if(loading  === false && error === "")
    {
        data = cars.data.stocks;
        data = sortData(data,sort);
    }
    
    return (
        <div className = "cardContent">
        {
            loading  == false && error == "" && data.map((car,index)=>
            {
                return (
                    <Card key = {index} car = {car} />
                )
            })
        }    
        </div>
    );
}
export default Body;