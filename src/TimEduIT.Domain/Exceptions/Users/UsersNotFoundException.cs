namespace TimEduIT.Domain.Exceptions.Users;

public class UsersNotFoundException : NotFoundException
{
    public UsersNotFoundException()
    {
        this.TitleMessage = "Users not found";
    }
}
