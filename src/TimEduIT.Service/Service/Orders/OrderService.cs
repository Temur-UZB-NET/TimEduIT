using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimEduIT.DataAccess.Interfaces.Courses;
using TimEduIT.DataAccess.Interfaces.Orders;
using TimEduIT.DataAccess.Utils;
using TimEduIT.Service.Dtos.Orders;
using TimEduIT.Service.Interfaces.Orders;

namespace TimEduIT.Service.Service.Orders;

public class OrderService : IOrderService
{
 

    public Task<bool> CreateAsync(OrderCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Order>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }
}
