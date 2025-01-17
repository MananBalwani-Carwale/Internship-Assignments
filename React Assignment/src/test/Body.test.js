import React from 'react';
import { render, screen } from '@testing-library/react';
import { jest } from '@jest/globals';
import { useSelector, useDispatch } from 'react-redux';
import Body from './../components/Body';
jest.mock('react-redux');
describe("Body Component",()=>
{
    test("Testing the body when loading",()=>
    {
        useDispatch.mockReturnValue((action)=>{});
        useSelector.mockReturnValue({
            fuel : "",
            budget : "",
            sort : "Price - Low to High"
        });
        useSelector.mockReturnValue({
            loading : true,
            data : {},
            error : ""
        });
        var {debug} = render(<Body />);
        var card = screen.queryAllByTestId("cardComponent");
        expect(card.length).toBe(0);
    });
    test("Testing the body when error occurs",()=>
    {
        useDispatch.mockReturnValue((func)=>{});
        useSelector.mockReturnValue({
            fuel : "",
            budget : "",
            sort : "Price - Low to High"
        });
        useSelector.mockReturnValue({
            loading : false,
            data : {},
            error : "Their is some error"
        });
        var {debug} = render(<Body />);
        var card = screen.queryAllByTestId("cardComponent");
        expect(card.length).toBe(0);
    });
    test("Testing The Card Component Based on the store states when data is their",()=>
    {
        useDispatch.mockReturnValue((func)=>{});
        useSelector.mockReturnValue({
            fuel : "",
            budget : "",
            sort : "Price - Low to High"
        });
        useSelector.mockReturnValue({
            loading : false,
            data : {
                "stocks": [
                  {
                    "carName": "Hyundai Creta EX 1.5 Petrol",
                    "price": "10.77 Lakh",
                    "priceNumeric": "1076757",
                    "km": "12,121",
                    "kmNumeric": "12121",
                    "fuel": "Petrol",
                    "stockImages": []
                  },
                  {
                    "carName": "Hyundai Creta EX 1.5 Petrol",
                    "price": "10.77 Lakh",
                    "priceNumeric": "1076757",
                    "km": "12,121",
                    "kmNumeric": "12121",
                    "fuel": "Petrol",
                    "cityName": "Mumbai",
                    "stockImages": [],
                  }
                ]
              },
            error : ""
        });
        var {debug} = render(<Body />);
        var card = screen.queryAllByTestId("cardComponent");
        expect(card.length).toBeGreaterThan(0);
    });
});
describe("Testing Sorting Function",()=>
{
    beforeEach(()=>
    {
        
    });
    test("Testing sorting for price low to high",()=>
    {

    })
});