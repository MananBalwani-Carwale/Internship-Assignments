using DataAccessLayer.Repository;
using DataAccessLayer.Entity;

namespace BusinessAccessLayer.Service;

/*
This class implements Interface IStockService
and implements the service methods for performing CRUD operation
*/
public class StockService : IStockService
{
    private readonly IStockRepository _stockRepository;

    public StockService(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }

    /*
    This method is the service method to make call for GetAllAsync
    of repository
    */
    public async Task<IEnumerable<StockEntity>> GetAllService(FilterEntity filterEntity)
    {
        IEnumerable<StockEntity> stockEntities;
        stockEntities = await _stockRepository.GetAllAsync(filterEntity);
        return stockEntities;
    }

    /*
    This method is the Service method for GetByIdAsync in the
    repository
    */
    public async Task<StockEntity> GetByIdService(int id)
    {
        StockEntity stockEntity;
        stockEntity = await _stockRepository.GetByIdAsync(id);
        return stockEntity;
    }

    /*
    This method is the service method for Add method of the
    repository
    */
    public async Task AddService(StockEntity stockEntity)
    {
        await _stockRepository.AddAsync(stockEntity);
    }

    /*
    This method checks whether stock exist if exist 
    them update it else throw not found exception
    */
    public async Task UpdateService(StockEntity stockEntity)
    {
        await _stockRepository.UpdateAsync(stockEntity);
    }

    /*
    This method checks whether stock exist if exist deletes it
    else throws not found exception
    */
    public async Task DeleteService(int id)
    {
        await _stockRepository.DeleteAsync(id);
    }

    /*
    This is service method to get attribute for getting
    IsValueForMoney Attribute
    */
    public bool GetIsValueForMoney(int kms, int price)
    {
        if(kms < 10000 && price < 200000)
        {
            return true;
        }
        return false;
    }
}

