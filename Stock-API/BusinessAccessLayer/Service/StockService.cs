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
            IEnumerable<StockEntity> stockEntities;
            try
            {
                stockEntities = await _stockRepository.GetAllAsync(filterEntity);
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return stockEntities;
        }
        public async Task<StockEntity> GetByIdService(int id)
        {
            StockEntity stockEntity;
            try
            {
                stockEntity = await _stockRepository.GetByIdAsync(id);
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return stockEntity;
        }
        public async Task AddService(StockEntity stockEntity)
        {
            try
            {
                await _stockRepository.AddAsync(stockEntity);
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
        public async Task UpdateService(StockEntity stockEntity)
        {
            try
            {
                StockEntity stock = await _stockRepository.GetByIdAsync(stockEntity.Id);
                if(stock == null)
                {
                    throw new Exception("Cannot find stock");
                }
                await _stockRepository.UpdateAsync(stockEntity);
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
        public async Task DeleteService(int id)
        {
            try
            {
                StockEntity stock = await _stockRepository.GetByIdAsync(id);
                if(stock == null)
                {
                    throw new Exception("Cannot find stock");
                }
                await _stockRepository.DeleteAsync(id);
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
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
