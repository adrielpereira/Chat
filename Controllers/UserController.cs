using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using WebChatQJW.Core.Business;
using WebChatQJW.Core.Repository.UnityOfWork;

namespace WebChatQJW.Core.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UnityOfWork unityOfWork;
        private readonly UserBusiness userBusiness;


        public UserController()
        {
            unityOfWork = new UnityOfWork();
            userBusiness = new UserBusiness();
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var model = unityOfWork.RepositoryUser.OnlineUsers(id).ToList();
            return Ok(model);
        }

        [HttpGet]
        public IActionResult GetUserInbox()
        {
            Int64.TryParse(User?.FindFirst(ClaimTypes.Name)?.Value, out long id);
            Int64.TryParse(User?.FindFirst(ClaimTypes.GroupSid)?.Value, out long companyId);

            var model = userBusiness.GetUsersInbox(id, companyId);
            return Ok(model);
        }
    }
}