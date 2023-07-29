using TimEduIT.DataAccess.Common.Interfaces;
using TimEduIT.DataAccess.Interfaces;
using TimEduIT.DataAccess.ViewModels.Users;
using TimEduIT.Domain.Entities.Users;

namespace TimEduIT.DataAccess.Interfaces.Users;

public interface IUserRepository : IRepository<User, UsersViewModel>, IGetAll<UsersViewModel>, ISearchable<UsersViewModel>
{
    public Task<User?> GetByPhoneAsync(string phone);
}
