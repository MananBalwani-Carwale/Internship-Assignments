import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { changeBudget, changeFuelType, clearFilter } from '../redux/FilterData/FilterDataAction';
import './../styles/filter.css';
import CheckBox from './CheckBox';
import FilterIcon from './assets/filter.svg';
import Slider from '@mui/material/Slider';
import Box from '@mui/material/Box';
const Filter = ()=>
{
    var [fuelsChecked,setFuelsChecked] = useState([]);
    var [min,setMin] = useState(0);
    var [max,setMax] = useState(21);
    var [error, setError] = useState("errorHide");
    const dispatch = useDispatch();
    var fuel = useSelector(store => store.filterData.fuel);
    const changeFuel = (value)=>
    {   
        if(fuelsChecked.indexOf(value.value) === -1)
        {
            fuelsChecked.push(value.value);
            if(fuel === "")
            {
                fuel = fuel+`${value.value}`;
            }
            else
            {
                fuel = fuel+`+${value.value}`;
            }
            dispatch(changeFuelType(fuel));
        }
        else
        {
            fuelsChecked = fuelsChecked.filter((fuel)=>
            {
                if(fuel === value.value)
                    return false;
                return true;
            });
            var fuelString = "";
            for(var i = 0; i < fuelsChecked.length; i++)
            {
                if(fuelString == "")
                {
                    fuelString = fuelString+`${fuelsChecked[i]}`;        
                }
                else
                {
                    fuelString = fuelString+`+${fuelsChecked[i]}`;
                } 
            }
            dispatch(changeFuelType(fuelString));    
        }  
        setFuelsChecked([...fuelsChecked]); 
    }
    const clearAllFilters = ()=>
    {
        setMin(0);
        setMax(21);
        setFuelsChecked([]);
        dispatch(clearFilter());
        
    }
    function changeMinBudget(event)
    {
        setMin(event.target.value);
        if(event.target.value < 0 || event.target.value > max)
        {
            setError("errorShow");
            return;
        }
        else
        {
            setError("errorHide");
        }
        if(event.target.value != '' && max != '')
        {
            var budget = `${event.target.value}-${max}`;
            dispatch(changeBudget(budget));
        }
    }
    function changeMaxBudget(event)
    {
        setMax(event.target.value);
        if(event.target.value > 21 || event.target.value < min)
        {
            setError("errorShow");
            return;
        }
        else
        {
            setError("errorHide");
        }
        if(event.target.value != '' && min != '')
        {
            var budget = `${min}-${event.target.value}`;
            dispatch(changeBudget(budget));
        }
    }
    function changeSliderValue(event, value)
    {
        setMin(value[0]);
        setMax(value[1]);
        dispatch(changeBudget(`${value[0]}-${value[1]}`));
    }
    const fuelTypes = [
        {id : "petrol",text : "Petrol",value : "1"},
        {id : "diesel",text : "Diesel",value : "2"},
        {id : "cng",text : "CNG",value : "3"},
        {id : "lpg",text : "LPG",value : "4"},
        {id : "electric",text : "Electric",value : "5"},
        {id : "hybrid",text : "Hybrid",value : "6"}
    ];
    const basicFilters = [
        {id : 1,text : "CarWale abSure",value : ""},
        {id : 2,text : "Certified Cars",value : ""},
        {id : 3,text : "Quality Report Available",value : ""},
        {id : 4,text : "Luxury Cars",value : ""},
    ];
    return (
        <div>
            <img className = "filterIcon" src = {FilterIcon} />
            &nbsp;&nbsp;
            <span className = "filterText">
                Filters
            </span>
            <span className = "filterClearAll">
                <a className = "clearAllLink" href = "#" onClick = {clearAllFilters}>Clear All</a>
            </span>
            <br /><br />
            <div className = "basicFilters">
            {
                basicFilters.map((filter)=>
                {
                    return (
                        <CheckBox key = {filter.id} id = {filter.id} value = {filter.value} text = {filter.text} clickHandler = {()=>{}} />
                    )
                })
            }    
            </div>
            <br />
            Budget Filters
            <br /><br />
            <div className = "budgetFilters">
                <Box sx={{width : 180}}>
                    <Slider value = {[min,max]} onChange = {changeSliderValue} min = {0} max = {21} disableSwap />
                </Box>
                <input type = "number" className = "filterInput" onChange = {changeMinBudget} value = {min} min = {0} />
                &nbsp;&nbsp;-&nbsp;&nbsp;
                <input type = "number" className = "filterInput" onChange = {changeMaxBudget} value = {max} max = {21} />
                <span className = {error} id  = "error"> Enter Correct Value in between 0 - 21</span>
            </div>
            <br />
            Fuel Type
            <br /><br />
            <div className = "basicFilters">
            {
                fuelTypes.map((fuel)=>
                {
                    return (
                        <CheckBox key = {fuel.id} id = {fuel.id} value = {fuel.value} text = {fuel.text} clickHandler = {changeFuel} checked = {fuelsChecked.indexOf(fuel.value) != -1} />
                    )
                })
            }
            </div>
        </div>
    );
}
export default Filter;