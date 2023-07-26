using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimEduIT.Service.Dtos.Notification;
using TimEduIT.Service.Interfaces.Notification;

namespace TimEduIT.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly ISmsSender _smsSender;

        public SmsController(ISmsSender smsSender)
        {
            this._smsSender = smsSender;
        }

        [HttpPost]
        public async Task<IActionResult> SendAsync([FromBody] SmsMessage smsMessage)
        {
            return Ok(await _smsSender.SendsmsAsync(smsMessage));
        }
    }
}
