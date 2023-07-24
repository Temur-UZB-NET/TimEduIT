using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TimEduIT.DataAccess.Interfaces.Users;
using TimEduIT.DataAccess.Utils;
using TimEduIT.DataAccess.ViewModels.Users;
using TimEduIT.Domain.Entities.Users;

namespace TimEduIT.DataAccess.Repositories.Users;

public class UsersRepository : BaseRepository, IUserRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select count(*) from users";
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

    public async Task<int> CreateAsync(User entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO users(\r\n\tid, first_name, last_name, email, phone_number, phone_number_confirmed, passport_seria_number, password_hash, salt, image_path, last_activity, created_at, updated_at) " +
                "VALUES (@First_name, @Last_name, @Email, @Phone_number, @Phone_number_confirmed, @Passport_seria_number, @Password_hash, @Salt, @Image_path, @Last_activity, @Created_at, @Updated_at); ";
            return await _connection.ExecuteAsync(query, entity);
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

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"delete from users where id = @Id";
            var result = await _connection.ExecuteAsync(query, new { Id = id });
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

    public async Task<IList<UsersViewModel>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select * from companies " +
                $"order by id desc " +
                $"offset {@params.GetSkipCount()} limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<UsersViewModel>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<UsersViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<UsersViewModel?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select * from users where id = {id}";
            var result = await _connection.QuerySingleAsync<UsersViewModel>(query);
            return result;
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<UsersViewModel?> GetByPhoneAsync(string phone)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM users where phone_number = @PhoneNumber";
            var data = await _connection.QuerySingleAsync<UsersViewModel>(query, new { PhoneNumber = phone });
            return data;
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<(int ItemsCount, IList<UsersViewModel>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    

    public Task<int> UpdateAsync(long id, User entity)
    {
        throw new NotImplementedException();
    }

    Task<User?> IUserRepository.GetByPhoneAsync(string phoneNumber)
    {
        throw new NotImplementedException();
    }
}
