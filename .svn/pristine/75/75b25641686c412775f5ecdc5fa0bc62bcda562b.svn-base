using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebChatQJW.Core.Business;
using WebChatQJW.Core.Repository.UnityOfWork;

namespace WebChatQJW.Core.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly MessageBusiness _messages;

        public MessageController()
        {
            _messages = new MessageBusiness();
        }

        [HttpGet("{id}/{page?}")]
        public  IActionResult Get(long id, int page = 0)
        {
            var skip = page * 10;
            Int64.TryParse(User?.FindFirst(ClaimTypes.Name)?.Value, out long userId);
            Int64.TryParse(User?.FindFirst(ClaimTypes.GroupSid)?.Value, out long companyId);

            var mensagens = _messages.UserMessages(userId, id, companyId, skip, 10).OrderBy(x => x.Create_at);
            
            return Ok(mensagens);
        }

        public IActionResult Get()
        {
            Int64.TryParse(User?.FindFirst(ClaimTypes.Name)?.Value, out long id) ;
            Int64.TryParse(User?.FindFirst(ClaimTypes.GroupSid)?.Value, out long companyId);

            var mensagens = _messages.UserMessagesUnread(id,companyId);

            return Ok(mensagens);
        }

        [HttpPost("{id}")]
        public IActionResult Post(long id)
        {
            Int64.TryParse(User?.FindFirst(ClaimTypes.Name)?.Value, out long userId);
            Int64.TryParse(User?.FindFirst(ClaimTypes.GroupSid)?.Value, out long companyId);

            _messages.ReadMessages(userId, companyId, id);

            return Ok();
        }
    }
}