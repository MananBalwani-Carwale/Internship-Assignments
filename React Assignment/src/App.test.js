import { render, screen } from '@testing-library/react';
import App from './App';
import { useSelector, useDispatch } from 'react-redux';
jest.mock('react-redux');
test('Testing Loading functionality', () => {
  useSelector.mockReturnValue(true);
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
  useDispatch.mockReturnValue((func)=>{});
  render(<App />);
  var loading = screen.getByTestId("loadingComponent");
  expect(loading).toBeInTheDocument();
});
