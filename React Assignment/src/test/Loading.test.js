import Loading from './../components/Loading';
import React from 'react';
import { render, screen } from '@testing-library/react';
import { jest } from '@jest/globals';
describe("Loading Component", ()=>
{
    test("Testing loading component for false",()=>
    {
        render(<Loading show = {false} />);
        var loading  = screen.queryByTestId("loadingComponent");
        expect(loading).not.toBeInTheDocument();
    });
    test("Testing loading component for true",()=>
    {
        render(<Loading show = {true} />);
        var loading  = screen.queryByTestId("loadingComponent");
        expect(loading).toBeInTheDocument();
    });
});