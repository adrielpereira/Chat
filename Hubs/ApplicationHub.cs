using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebChatQJW.Core.Business;

namespace WebChatQJW.Core.Hubs
{
    [Authorize]
    public class ApplicationHub : Hub
    {
        private UserBusiness _user;
        private MessageBusiness _message;

        public ApplicationHub()
        {
            _user = new UserBusiness();
            _message = new MessageBusiness();
        }

        #region overrides

        public override Task OnConnectedAsync()
        {
            if (_user.NewUserConnection(Context) != null)
                UserConnected();
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            if (_user.UserDisconnect(Context.ConnectionId))
                UserDesconnected();
            return base.OnDisconnectedAsync(exception);
        }

        #endregion

        public void UserCredentials(long UserId, long CompanyId, string UserName)
        {
            var usuer = _user.NewUserConnection(Context);
        }

        public void SendTo(long to, string message)
        {
            var user = new Utils.GetUser().UserContext(Context);
            var connections = _user.GetUserConnections(Context, to);

            if (connections != null && connections.Count() > 0)
            {
                foreach (var c in connections)
                    Send(c.ConnectionId, user.UserId.ToString(), message);
            }
            _message.NewMessage(Context, to, message);
        }

        public Task Send(string userConnection, string from, string message)
        {
            return Clients.Client(userConnection).SendAsync("ReceiveMessage", message, from);
        }

        public Task UserConnected()
        {
            var user = new Utils.GetUser().UserContext(Context);
            return Clients.All.SendAsync("Online", user.UserId);
        }

        public Task UserDesconnected()
        {
            var user = new Utils.GetUser().UserContext(Context);
            return Clients.All.SendAsync("Offline", user.UserId);
        }

    }
}
