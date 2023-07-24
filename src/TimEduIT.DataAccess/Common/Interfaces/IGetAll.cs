using TimEduIT.DataAccess.Utils;

namespace TimEduIT.DataAccess.Common.Interfaces;

public interface IGetAll<TModel>
{
    public Task<IList<TModel>> GetAllAsync(PaginationParams @params);
}
