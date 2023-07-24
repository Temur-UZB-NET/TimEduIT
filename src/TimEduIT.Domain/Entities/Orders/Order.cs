namespace TimEduIT.Domain.Entities.Orders;

public class Order : Auditable
{
    public long UserId { get; set; }

    public long CoursesId { get; set; }

    public string CardNumber { get; set; }

    public string CardholderName { get; set; }

    public string ExpirationDate { get; set; }
}
