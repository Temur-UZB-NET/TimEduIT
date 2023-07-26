using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimEduIT.DataAccess.Utils;

namespace TimEduIT.Service.Interfaces.Common;

public interface IPoginator
{
    public void Paginate(long itemsCount, PaginationParams @params);

}
