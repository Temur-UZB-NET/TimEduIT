using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimEduIT.Service.Dtos.Notification;

namespace TimEduIT.Service.Interfaces.Notification;

public interface ISmsSender
{
    public Task<bool> SendsmsAsync(SmsMessage smsMessage);

}
