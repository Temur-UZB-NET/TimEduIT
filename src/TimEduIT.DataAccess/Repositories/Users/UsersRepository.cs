using Dapper;
using System.Collections.Generic;
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
            string query = "INSERT INTO users(\r\n\tfirst_name, last_name, email, phone_number, phone_number_confirmed, passport_seria_number, identity_role, password_hash, salt, image_path, last_activity, created_at, updated_at) " +
                "VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @PhoneNumberConfirmed, @PassportSeriaNumber, @IdentityRole, @PasswordHash, @Salt, @ImagePath, @LastActivity, @CreatedAt, UpdatedAt); ";
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

    public async Task<User?> GetByPhoneAsync(string phone)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM users where phone_number = @PhoneNumber";
            var data = await _connection.QuerySingleAsync<User>(query, new { PhoneNumber = phone });
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



    public async Task<int> UpdateAsync(long id, User entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE users SET first_name = @FirstName, last_name = @LastName, " +
                "email = @Email, phone_number = @PhoneNumber, phone_number_confirmed = @PhoneNumberConfirmed, " +
                "passport_seria_number = @PassportSeriaNumber, identity_role = @IdentityRole," +
                " password_hash = @PasswordHash, salt = @Salt, image_path = @ImagePath, " +
                "last_activity = @LastActivity, created_at = @CreatedAt, updated_at = @UpdatedAt" +
                $"WHERE id = {id};";
            var result = await _connection.ExecuteAsync(query, entity);
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
}
