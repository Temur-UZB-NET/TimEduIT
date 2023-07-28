using DocumentFormat.OpenXml.Drawing.Charts;
using TimEduIT.DataAccess.Utils;
using TimEduIT.Service.Dtos.Orders;

namespace TimEduIT.Service.Interfaces.Orders;

public interface IOrderService
{
    public Task<bool> CreateAsync(OrderCreateDto dto);

    public Task<IList<Order>> GetAllAsync(PaginationParams @params);
}
