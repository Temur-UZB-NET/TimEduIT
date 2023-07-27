using TimEduIT.DataAccess.Utils;

namespace TimEduIT.Service.Interfaces.Common;

public interface IPoginator
{
    public void Paginate(long itemsCount, PaginationParams @params);

}
