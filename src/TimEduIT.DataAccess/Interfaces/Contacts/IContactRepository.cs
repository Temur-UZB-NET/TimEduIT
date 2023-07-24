using TimEduIT.DataAccess.Common.Interfaces;
using TimEduIT.DataAccess.Interfaces;
using TimEduIT.DataAccess.ViewModels.Contact;
using TimEduIT.Domain.Entities.Contacts;

namespace TimEduIT.DataAccess.Interfaces.Contacts;

public interface IContactRepository : IRepository<Contact, Contact>, IGetAll<ContactViewModel>, ISearchable<ContactViewModel>
{
}
