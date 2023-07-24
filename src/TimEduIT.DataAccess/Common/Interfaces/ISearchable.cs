using TimEduIT.DataAccess.Utils;

namespace TimEduIT.DataAccess.Common.Interfaces;

public interface ISearchable<TModel>
{
    public Task<(int ItemsCount, IList<TModel>)> SearchAsync(string search,
        PaginationParams @params);
}
