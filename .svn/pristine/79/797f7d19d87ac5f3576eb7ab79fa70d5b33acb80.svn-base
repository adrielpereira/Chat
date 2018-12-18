using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebChatQJW.Core.Models;

namespace WebChatQJW.Core.Utils
{
    public class UserConnectComparer : IEqualityComparer<User>
    {
        public bool Equals(User x, User y)
        {
            if (Object.ReferenceEquals(x, y)) return true;

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;


            return x.UserId == y.UserId && x.CompanyId == y.CompanyId;
        }

        public int GetHashCode(User obj)
        {
            if (Object.ReferenceEquals(obj, null)) return 0;
            int hashUserUserId = obj.UserId.GetHashCode();
            int hasUserCompanyId = obj.CompanyId.GetHashCode();
            return hashUserUserId ^ hasUserCompanyId;
        }
    }
}
