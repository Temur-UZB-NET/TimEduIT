using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimEduIT.Domain.Entities.Users;

namespace TimEduIT.Service.Interfaces.Auth;

public interface ITokenService
{
    public string GenerateToken(User user);
}
