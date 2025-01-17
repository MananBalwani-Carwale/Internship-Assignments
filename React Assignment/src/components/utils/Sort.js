function sortData(data,sort)
{
    if(sort === "Price - Low to High")
    {
        data = data.sort((a,b)=>
        {
            return a['priceNumeric'] - b['priceNumeric'];
        });
    }
    if(sort === "Price - High to Low")
    {
        data = data.sort((a,b)=>
        {
            return b['priceNumeric'] - a['priceNumeric'];
        });
    }
    if(sort === "km - Low to High")
    {
        data = data.sort((a,b)=>
        {
            return a['kmNumeric'] - b['kmNumeric'];
        });
    }
    if(sort === "km - High to Low")
    {
        data = data.sort((a,b)=>
        {
            return b['kmNumeric'] - a['kmNumeric'];
        });
    }
    return data;
}
export default sortData;