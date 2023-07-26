using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimEduIT.Service.Dtos.Users;

public class UsersCreateDto
{
    public string FirstName { get; set; } = String.Empty;

    public string LastName { get; set; } = String.Empty;

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = String.Empty;

    public string PassportSeriaNumber { get; set; } = string.Empty;

    public string IdentityRole { get; set; } = string.Empty;




}
