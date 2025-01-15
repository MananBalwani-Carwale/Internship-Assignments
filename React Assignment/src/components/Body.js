import React, { useEffect, useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { fetchData } from './../redux/CarData/CarDataActions';
import Card from './Card';
import './../styles/body.css';
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
    var data = cars.data.stocks;
    if(loading === false && sort === "Price - Low to High" && error === "")
    {
        data = data.sort((a,b)=>
        {
            return a['priceNumeric'] - b['priceNumeric'];
        });
    }
    if(loading === false && sort === "Price - High to Low" && error === "")
    {
        data = data.sort((a,b)=>
        {
            return b['priceNumeric'] - a['priceNumeric'];
        });
    }
    if(loading === false && sort === "km - Low to High" && error === "")
    {
        data = data.sort((a,b)=>
        {
            return a['kmNumeric'] - b['kmNumeric'];
        });
    }
    if(loading === false && sort === "km - High to Low" && error === "")
    {
        data = data.sort((a,b)=>
        {
            return b['kmNumeric'] - a['kmNumeric'];
        });
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