import React from 'react';
import './../styles/card.css';
const Card = (props)=>
{
    return (
        <div data-testid = "cardComponent" className = "cardDiv">
            <img className = "cardImage" src = {props.car.stockImages[0]} />
            <div className = "carName">
                {props.car.carName}
            </div>
            <span className = "carDetails">
                {props.car.kmNumeric} km | {props.car.fuel} | {props.car.cityName}
            </span><br />
            <div className = "carPrice">
                <h4>Rs. {props.car.price}</h4>
            </div>
            <button className = "cardButton">Get Seller Details</button>
        </div>
    );
}
export default Card;