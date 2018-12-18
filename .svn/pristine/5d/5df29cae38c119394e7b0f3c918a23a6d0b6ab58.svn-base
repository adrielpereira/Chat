using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebChatQJW.Core.Data;
using WebChatQJW.Core.Models;
using WebChatQJW.Core.Repository.Interfaces;
using WebChatQJW.Core.Utils;

namespace WebChatQJW.Core.Repository.Entities
{
    public class RepositoryUser : RepositoryBase<User>, IRepositoryUser
    {
        public RepositoryUser(DataContext context) : base(context)
        {
        }

        public List<User> FindUser(long userId, long companyId)
        {
            return DbContexto.User.Where(x => x.UserId == userId && x.CompanyId == companyId).ToList();
        }

        public User FindUser(long userId, long companyId, string connectionId)
        {
            return DbContexto.User.FirstOrDefault(x => x.UserId == userId && x.CompanyId == companyId && x.ConnectionId == connectionId);
        }

        public User FindUserByConnection(string connectionId)
        {
            return DbContexto.User.FirstOrDefault(x => x.ConnectionId == connectionId);
        }

        public IEnumerable<User> OnlineUsers(long companyId)
        {
            return DbContexto.User.Where(x => x.CompanyId == companyId).ToList().Distinct(new UserConnectComparer());
        }

        
    }
}
