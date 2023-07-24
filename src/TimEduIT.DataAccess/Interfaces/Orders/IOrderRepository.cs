using TimEduIT.DataAccess.Common.Interfaces;
using TimEduIT.DataAccess.Interfaces;
using TimEduIT.DataAccess.ViewModels.Orders;
using TimEduIT.Domain.Entities.Orders;

namespace TimEduIT.DataAccess.Interfaces.Orders;

public interface IOrderRepository : IRepository<Order,OrderViewModel>, IGetAll<OrderViewModel>,ISearchable<OrderViewModel>
{
}
