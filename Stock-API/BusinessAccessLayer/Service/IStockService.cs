using DataAccessLayer.Entity;
namespace BusinessAccessLayer.Service
{
    public interface IStockService
    {
        Task<IEnumerable<StockEntity>>GetAllService(FilterEntity filterEntity);
        Task<StockEntity> GetByIdService(int id);
        Task AddService(StockEntity stockEntity);
        Task UpdateService(StockEntity stockEntity);
        Task DeleteService(int id);
        bool GetIsValueForMoney(int kms, int price);
    }
}