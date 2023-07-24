namespace TimEduIT.Domain.Exceptions.Order;

public class OrderNotFoundException : NotFoundException
{
    public OrderNotFoundException()
    {
        this.TitleMessage = "Order Not Found!";
    }
}
