using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebChatQJW.Core.Models;
using WebChatQJW.Core.Repository.UnityOfWork;

namespace WebChatQJW.Core.Business
{
    public class UserBusiness
    {
        private UnityOfWork db;

        public UserBusiness()
        {
            db = new UnityOfWork();
        }

        public User NewUserConnection(HubCallerContext context)
        {
            long companyId = 0;
            long userId = 0;

            Int64.TryParse(context.User?.FindFirst(ClaimTypes.Name)?.Value, out userId);
            Int64.TryParse(context.User?.FindFirst(ClaimTypes.GroupSid)?.Value, out companyId);

            var user = new User();
            user.CompanyId = companyId;
            user.ConnectionId = context.ConnectionId;
            user.Connected_at = DateTime.Now;
            user.UserId = userId;
            db.RepositoryUser.Add(user);
            db.Commit();

            return user;
        }

        public bool UserDisconnect(string connectionId)
        {
            var user = db.RepositoryUser.FindUserByConnection(connectionId);

            if (user != null)
                db.RepositoryUser.Remove(user);

            return db.Commit();
        }

        public List<User> GetUserConnections(HubCallerContext context, long to)
        {
            Int64.TryParse(context.User?.FindFirst(ClaimTypes.GroupSid)?.Value, out long companyId);
            return db.RepositoryUser.FindUser(to, companyId);
        }

        public List<UserInboxViewModel> GetUsersInbox(long UserId, long CompanyId)
        {
            var users = db.RepositoryMessage.UsersMessagesInBox(UserId, CompanyId)
                .ToList()
                .Select(x => new
                {
                    Id = x.To == UserId ? x.From : x.To
                });

            var list = users.GroupBy(x => x.Id)
                .Select(b => new UserInboxViewModel
                {
                    UserId = b.Key
                }).ToList();

            return list;
        }
    }
}
