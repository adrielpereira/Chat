using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebChatQJW.Core.Models;

namespace WebChatQJW.Core.Utils
{
    public class GetUser
    {
        private long UserId;
        private long CompanyId;

        public LoginViewModel UserContext(HubCallerContext context)
        {
            Int64.TryParse(context.User?.FindFirst(ClaimTypes.Name)?.Value, out UserId);
            Int64.TryParse(context.User?.FindFirst(ClaimTypes.GroupSid)?.Value, out CompanyId);

            var m = new LoginViewModel();
            m.UserId = UserId;
            m.CompanyId = CompanyId;

            return m;
        }
    }
}
