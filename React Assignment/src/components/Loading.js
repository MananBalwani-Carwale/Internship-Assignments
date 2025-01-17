import React from 'react';
import LoadingIcon from './assets/Loading.gif';
import './../styles/loading.css';
const Loading = (props)=>
{
    return (
        props.show &&
        <div data-testid = "loadingComponent" className = "loadingDiv">
            <img className = "loadingIcon" src = {LoadingIcon} />
        </div>
    );
}
export default Loading;