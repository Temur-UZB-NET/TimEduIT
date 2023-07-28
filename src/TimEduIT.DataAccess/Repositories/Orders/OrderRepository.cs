using Dapper;
using TimEduIT.DataAccess.Common.Interfaces;
using TimEduIT.DataAccess.Interfaces;
using TimEduIT.DataAccess.Interfaces.Orders;
using TimEduIT.DataAccess.Utils;
using TimEduIT.DataAccess.ViewModels.Orders;
using TimEduIT.Domain.Entities.Orders;

namespace TimEduIT.DataAccess.Repositories.Orders;

public class OrderRepository : BaseRepository, IOrderRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select count(*) from orders";
            var result = await _connection.QuerySingleAsync<long>(query);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<long> CreateAsync(Order entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO orders(user_id, courses_id, card_number, cardholder_name, expiration_date, created_at) " +
                "VALUES (@UserId, @CoursesId, @CardNumber, @CardholderName, @ExpirationDate, @CreatedAt); RETURNING id;";
            return await _connection.ExecuteScalarAsync<long>(query, entity);
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<int> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<Order>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM orders order by id desc offset {@params.GetSkipCount()} limit {@params.PageSize} ;";
            return (await _connection.QueryAsync<Order>(query)).ToList();
        }
        catch
        {
            return new List<Order>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<OrderViewModel?> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<(int ItemsCount, IList<OrderViewModel>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, Order entity)
    {
        throw new NotImplementedException();
    }

    Task<int> IRepository<Order, OrderViewModel>.CreateAsync(Order entity)
    {
        throw new NotImplementedException();
    }

    Task<IList<OrderViewModel>> IGetAll<OrderViewModel>.GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }
}
