using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebChatQJW.Core.Models;
using WebChatQJW.Core.Repository.UnityOfWork;
using WebChatQJW.Core.Utils;

namespace WebChatQJW.Core.Business
{
    public class MessageBusiness
    {
        private UnityOfWork db;

        public MessageBusiness()
        {
            db = new UnityOfWork();
        }

        public bool NewMessage(HubCallerContext context, long to, string message)
        {
            long companyId = 0;
            long userId = 0;

            Int64.TryParse(context.User?.FindFirst(ClaimTypes.Name)?.Value, out userId);
            Int64.TryParse(context.User?.FindFirst(ClaimTypes.GroupSid)?.Value, out companyId);

            var msg = new Message();
            msg.CompanyId = companyId;
            msg.From = userId;
            msg.To = to;
            msg.Create_at = DateTime.Now;
            msg.MessageText = new Encrypt().EncryptData(message, userId, to, companyId);
            msg.Status = 2; // 1 LIDO 2 NÃO LIDO
            db.RepositoryMessage.Add(msg);

            return db.Commit();
        }

        public IEnumerable<MessageViewModel> UserMessages(long userId, long to, long companyId, int skip, int take)
        {           
            var msgs = db.RepositoryMessage.FindMessagesByUser(userId, to, companyId, skip, take)
                .Select( x => new MessageViewModel
                {
                    Id = x.Id,
                    From = x.From,
                    To = x.To,
                    CompanyId = x.CompanyId,
                    MessageText = x.MessageText,
                    Status = x.Status,
                    Create_at = x.Create_at,
                    Read_at = x.Read_at
                });

            return msgs;
        }

        public IEnumerable<MessageCountViewModel> UserMessagesUnread(long userId, long companyId)
        {
            var msgs = db.RepositoryMessage.UnreadMessagesByUser(userId, companyId)
                .GroupBy(x => x.From)
                .Select(group => new MessageCountViewModel
                {
                    UserId = group.Key,
                    Count = group.Count()
                });

            return msgs;
        }

        public bool ReadMessages(long userId, long companyId, long to)
        {
            var msgs = db.RepositoryMessage.UnreadMessages(userId, to, companyId);

            if(msgs != null)
            {
                foreach(var m in msgs)
                {
                    m.Read_at = DateTime.Now;
                    m.Status = 1;
                    db.RepositoryMessage.Update(m);
                }
            }

            return db.Commit();
        }
    }
}
