using System.Collections.Generic;
using WebChatQJW.Core.Models;

namespace WebChatQJW.Core.Repository.Interfaces
{
    public interface IRepositoryUser : IRepositoryBase<User>
    {
        List<User> FindUser(long userId, long companyId);

        IEnumerable<User> OnlineUsers(long companyId);

        User FindUser(long userId, long companyId, string connectionId);

        User FindUserByConnection(string connectionId);
    }
}
