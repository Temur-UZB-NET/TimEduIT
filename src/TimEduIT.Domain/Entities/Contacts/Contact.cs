namespace TimEduIT.Domain.Entities.Contacts;

public class Contact : Auditable
{
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Subject { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;

    public long UsersId { get; set; }

}
