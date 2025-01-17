//import axios from 'axios';
export const FETCH_DATA = "FETCH_DATA";
function fetchDataRequest()
{
    return {
        type : FETCH_DATA,
    }
}
function fetchData(payload = {})
{
    return (dispatch)=>
    {
        var url = "https://stg.carwale.com/api/stocks";
        if(JSON.stringify(payload) != JSON.stringify({}))
        {
            var index = 0;
            for(var key in payload)
            {
                if(payload[key] != "")
                {
                    if(index === 0)
                    {
                        url = url+"?";
                    }
                    else
                    {
                        url = url+"&";
                    }
                    url = url+`${key}=${payload[key]}`;
                    index++;
                }
            }
        }
        fetch(url).then((response)=>
        {
            return response.json();
        }).then((jsonData)=>
        {
            dispatch(fetchDataSuccess(jsonData));
        }).catch((error)=>
        {
            dispatch(fetchDataFailure(error.message));
        });
    }
}
export const FETCH_DATA_SUCCESS = "FETCH_DATA_SUCCESS";
function fetchDataSuccess(payload)
{
    return {
        type : FETCH_DATA_SUCCESS,
        payload : payload
    };
}
export const FETCH_DATA_FAILURE = "FETCH_DATA_FAILURE";
function fetchDataFailure(payload)
{
    return {
        type : FETCH_DATA_FAILURE,
        payload : payload
    };
}
export { fetchData, fetchDataSuccess, fetchDataFailure, fetchDataRequest };