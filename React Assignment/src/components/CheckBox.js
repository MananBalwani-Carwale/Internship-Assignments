import React from 'react';
import './../styles/filter.css';
const CheckBox = ({id,text,value,clickHandler,checked})=>
{
    return (
        <div className = "filterCheckBox">
            <input className = "checkBox" data-testid = {id} id = {id} type = "checkbox" value = {value} onClick = {()=>clickHandler({value})} defaultChecked = {checked} />
            <label className = "labelText" htmlFor = {id}>  {text}</label><br />
        </div>
    );
}
export default CheckBox;