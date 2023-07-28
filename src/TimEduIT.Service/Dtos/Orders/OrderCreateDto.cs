using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimEduIT.Service.Dtos.Orders;

public class OrderCreateDto
{
    public long UserId { get; set; }

    public long CourseId { get; set; }
}
