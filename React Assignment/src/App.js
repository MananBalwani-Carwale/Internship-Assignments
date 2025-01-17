import './styles/style.css';
import SortBy from './components/SortBy';
import Body from './components/Body';
import { useSelector } from 'react-redux';
import Loading from './components/Loading';
import Filter from './components/Filter';
function App() {
    const loading = useSelector(store => store.carData.loading);
    return (
        <div className = "mainDiv">
            <Loading show = {loading} />
            <div className = "filterDiv">
                <Filter />
            </div>
            <div className = "rightDiv">
                <div className = "sortByDiv">
                    Sort By : <SortBy />
                </div>
                <div className = "bodyDiv">
                    <Body />
                </div>
            </div>
        </div>
    );
}

export default App;
