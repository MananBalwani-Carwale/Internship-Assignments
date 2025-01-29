using System.Collections;
using DataAccessLayer.Repository;
using DataAccessLayer.Entity;
namespace BusinessAccessLayer.Service
{
    //Using Automapper to map some objects.
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
        public async Task<IEnumerable<StockEntity>> GetAllService(FilterEntity filterEntity)
        {
            IEnumerable<StockEntity> stockEntities = await _stockRepository.GetAllAsync(filterEntity);
            return stockEntities;
        }
        public async Task<StockEntity> GetByIdService(int id)
        {
            StockEntity stockEntity = await _stockRepository.GetByIdAsync(id);
            return stockEntity;
        }
        public async Task AddService(StockEntity stockEntity)
        {
            await _stockRepository.AddAsync(stockEntity);
        }
        public async Task UpdateService(StockEntity stockEntity)
        {
            
            await _stockRepository.UpdateAsync(stockEntity);
        }
        public async Task DeleteService(int id)
        {
            await _stockRepository.DeleteAsync(id);
        }
        public bool GetIsValueForMoney(int kms, int price)
        {
            if(kms < 10000 && price < 200000)
            {
                return true;
            }
            return false;
        }
    }
}
