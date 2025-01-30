using Dapper;
using System.Data;
using DataAccessLayer.Entity;
using MySql.Data.MySqlClient;

namespace DataAccessLayer.Repository;

/*
This class implements the interface IStockRepository
and implements its methods by connecting to database and then 
performing CRUD operation on the data 
*/
public class StockRepository : IStockRepository
{
    private readonly string _connectionString;
    
    public StockRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    /*
    This method connects to database and get all
    the stocks based on the filter budget and fueltype
    */
    public async Task<IEnumerable<StockEntity>> GetAllAsync(FilterEntity filterEntity)
    {
        IEnumerable<StockEntity> stocks;
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
        return stocks;
    }

    /*
    This method connects to database and get stock by its Id
    and returns null if id is not found
    */
    public async Task<StockEntity> GetByIdAsync(int id)
    {
        StockEntity stockEntity;
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
    
        return stockEntity;
    }

    /*
    This method adds the stock to the database
    */
    public async Task AddAsync(StockEntity stockEntity)
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

    /*
    This method connects to the database and updates the existing
    stock
    */
    public async Task UpdateAsync(StockEntity stockEntity)
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

    /*
    This method connects to database and deletes an exisiting
    stock
    */
    public async Task DeleteAsync(int id)
    {
        using (IDbConnection connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            string query = @"DELETE FROM STOCKS
            WHERE id = @id";
            await connection.ExecuteAsync(query,new { id = id});
        }
    }
}
