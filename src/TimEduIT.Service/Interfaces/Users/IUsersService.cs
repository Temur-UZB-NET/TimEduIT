using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimEduIT.DataAccess.Utils;
using TimEduIT.Domain.Entities.Users;
using TimEduIT.Service.Dtos.Users;

namespace TimEduIT.Service.Interfaces.Users;

public interface IUsersService
{
    public Task<bool> CreateAsync(UsersCreateDto dto);

    public Task<bool> DeleteAsync(long userId);

    public Task<long> CountAsync();

    public Task<IList<User>> GetAllAsync(PaginationParams @params);

    public Task<User> GetByIdAsync(long userId);

    public Task<bool> UpdateAsync(long userId, UsersCreateDto dto);
}
