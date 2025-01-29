using Dapper;
using System.Data;
using DataAccessLayer.Entity;
using MySql.Data.MySqlClient;
namespace DataAccessLayer.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly string _connectionString;
        public StockRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<IEnumerable<StockEntity>> GetAllAsync(FilterEntity filterEntity)
        {
            IEnumerable<StockEntity> stocks;
            try
            {
                using (IDbConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"SELECT id, profile_id as profileId,
                    price, fuel_type as fuelType, kms, name,
                    make_model as makeModel, make_year as makeYear,
                    make_name as makeName from stocks
                    WHERE price between @MinBudget AND @MaxBudget 
                    AND fuel_type IN @FuelTypes";
                    stocks = await connection.QueryAsync<StockEntity>(query, filterEntity);
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return stocks;
        }
        public async Task<StockEntity> GetByIdAsync(int id)
        {
            StockEntity stockEntity;
            try
            {
                using (IDbConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"SELECT id, profile_id as profileId,
                    price, fuel_type as fuelType, kms, name,
                    make_model as makeModel, make_year as makeYear,
                    make_name as makeName from stocks
                    WHERE id = @id";
                    stockEntity = await connection.QueryFirstOrDefaultAsync<StockEntity>(query, new 
                    {
                        id = id
                    });
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            return stockEntity;
        }
        public async Task AddAsync(StockEntity stockEntity)
        {
            try
            {
                using (IDbConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO STOCKS 
                    (profile_id, price, fuel_type, kms, name, make_year, make_model, make_name)
                    VALUES 
                    (@ProfileId, @Price, @FuelType, @Kms, @Name, @MakeYear, @MakeModel, @MakeName)";
                    await connection.ExecuteAsync(query,stockEntity);
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
        public async Task UpdateAsync(StockEntity stockEntity)
        {
            try
            {
                using (IDbConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"UPDATE stocks SET
                    profile_id = @ProfileId,
                    price = @Price,
                    fuel_type = @FuelType,
                    kms = @Kms,
                    name = @Name,
                    make_year = @MakeYear,
                    make_model = @MakeModel,
                    make_name = @MakeName
                    WHERE id = @Id";
                    await connection.ExecuteAsync(query,stockEntity);
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
        public async Task DeleteAsync(int id)
        {
            try
            {
                using (IDbConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"DELETE FROM STOCKS
                    WHERE id = @id";
                    await connection.ExecuteAsync(query,new { id = id});
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}