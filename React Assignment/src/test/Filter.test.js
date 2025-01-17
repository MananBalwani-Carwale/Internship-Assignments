import React from 'react';
import { CHANGE_FUEL_TYPE,CHANGE_BUDGET, CHANGE_SORT_BY } from '../redux/FilterData/FilterDataAction';
import { render, screen } from '@testing-library/react';
import { fireEvent } from '@testing-library/react';
import { jest } from '@jest/globals';
import { useSelector, useDispatch, Provider } from 'react-redux';
import Filter from './../components/Filter';
jest.mock('react-redux');
var store = {};
describe("Testing Fuel filters",()=>
{
    beforeEach(()=>
    {
        function filterReducer(action)
        {
            switch(action.type)
            {
                case CHANGE_FUEL_TYPE : 
                    store = {
                        ...store.carData,
                        filterData : {
                            ...store.filterData,
                            fuel : action.payload
                        }
                    };
                    break;
                case CHANGE_BUDGET : 
                    return {
                        ...store.carData,
                        filterData : {
                            ...store.filterData,
                            budget : action.payload
                        }
                    };
                case CLEAR_FILTER : 
                    return store;
                case CHANGE_SORT_BY : 
                    return {
                        ...store.carData,
                        filterData : {
                            ...store.filterData,
                            fuel : action.payload
                        }
                    };
                default : 
                    return store;
            }
        }
        store = {
            carData : {
                loading : false,
                data : {
                    stocks : []
                },
                error : ""
            },
            filterData : {
                fuel : "",
                budget : "",
                sort : ""
            }
        };
        useSelector.mockImplementation((func)=>
        {
            return func(store);
        });
        useDispatch.mockReturnValue(filterReducer);  
    });
    test("Testing store values based on fuel petrol selected",()=>
    {
        
        render(<Filter />);
        const petrol = screen.queryByTestId("petrol");
        fireEvent.click(petrol);
        expect(store.filterData.fuel).toBe("1");
    });
    test("Testing store values based on multiple fuel types selected",()=>
    {
        render(<Filter />);
        const deisel = screen.queryByTestId("diesel");
        const petrol = screen.queryByTestId("petrol");
        fireEvent.click(petrol);
        fireEvent.click(deisel);
        expect(store.filterData.fuel).toBe("1+2");
    });
    test("Testing store values based on fuel types deselected",()=>
    {
        render(<Filter />);
        const deisel = screen.queryByTestId("diesel");
        const petrol = screen.queryByTestId("petrol");
        fireEvent.click(petrol);
        fireEvent.click(deisel);
        fireEvent.click(petrol);
        expect(store.filterData.fuel).toBe("2");
    }); 
    test("Testing store values based on multiple fuel types deselected",()=>
    {
        render(<Filter />);
        const deisel = screen.queryByTestId("diesel");
        const petrol = screen.queryByTestId("petrol");
        fireEvent.click(petrol);
        fireEvent.click(deisel);
        fireEvent.click(petrol);
        fireEvent.click(diesel);
        expect(store.filterData.fuel).toBe("");
    });
});