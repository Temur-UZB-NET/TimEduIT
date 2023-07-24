using TimEduIT.DataAccess.Common.Interfaces;
using TimEduIT.Domain.Entities.Categories;

namespace TimEduIT.DataAccess.Interfaces.Categories;

public interface ICategoryRepository : IRepository<Category, Category>, IGetAll<Category>
{

}
