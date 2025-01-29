using DataAccessLayer.Entity;
namespace DataAccessLayer.Repository
{
    public interface IStockRepository
    {
        Task<IEnumerable<StockEntity>> GetAllAsync(FilterEntity filterEntity);
        Task<StockEntity> GetByIdAsync(int id);
        Task AddAsync(StockEntity stockEntity);
        Task UpdateAsync(StockEntity stockEntity);
        Task DeleteAsync(int id);
    }
}