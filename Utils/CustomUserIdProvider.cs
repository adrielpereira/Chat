using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace WebChatQJW.Core.Utils
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        public virtual string GetUserId(HubConnectionContext connection)
        {
            string userId = connection.User?.FindFirst(ClaimTypes.Name)?.Value;
            string companyId = connection.User?.FindFirst(ClaimTypes.GroupSid)?.Value;

            return userId + companyId;
        }

    }
}
