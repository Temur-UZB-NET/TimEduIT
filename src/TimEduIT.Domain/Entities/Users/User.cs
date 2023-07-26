using System.ComponentModel.DataAnnotations;

namespace TimEduIT.Domain.Entities.Users;

public class User : Auditable
{
    [MaxLength(50)]
    public string FirstName { get; set; } = String.Empty;

    [MaxLength(50)]
    public string LastName { get; set; } = String.Empty;

    [MaxLength(13)]
    public string PhoneNumber { get; set; } = String.Empty;

    public bool PhoneNumberConfirmed { get; set; }

    [MaxLength(9)]
    public string PassportSeriaNumber { get; set; } = String.Empty;

    public string IdentityRole { get ; set; } = String.Empty;

    public string PasswordHash { get; set; } = String.Empty;

    public string Salt { get; set; } = String.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public DateTime LastActivity { get; set; }
}
