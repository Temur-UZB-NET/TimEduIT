namespace TimEduIT.Domain.Exceptions.Contacts;

public class ContactsNotFoundException : NotFoundException
{
    public ContactsNotFoundException()
    {
        this.TitleMessage = "Contacts Not Found";
    }
}
