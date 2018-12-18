using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebChatQJW.Core.Models;

namespace WebChatQJW.Core.Repository.Interfaces
{
    public interface IRepositoryMessage : IRepositoryBase<Message>
    {
        IEnumerable<Message> FindMessagesByUser(long userId,long userTo, long companyId);

        IEnumerable<Message> FindMessagesByUser(long userId, long userTo, long companyId, int skip, int take);

        IEnumerable<Message> UnreadMessages(long userId, long to, long companyId);

        IEnumerable<Message> UnreadMessagesByUser(long userId, long companyId);

        IEnumerable<Message> UsersMessagesInBox(long userId, long companyId);

    }
}
