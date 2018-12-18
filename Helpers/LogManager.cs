using Microsoft.AspNetCore.Diagnostics;
using System;
using WebChatQJW.Core.Models;
using WebChatQJW.Core.Repository.UnityOfWork;

namespace WebChatQJW.Core.Helpers
{
    public static class LogManager
    {

        public static void LogException(IExceptionHandlerFeature error)
        {
            UnityOfWork _u = new UnityOfWork();

            Log log = new Log();

            log.Create_at = DateTime.Now;
            log.ExceptionMessage = error.Error.ToString();
            log.Type = "Exception";

            _u.RepositoryLog.Add(log);

            _u.Commit();
        }
    } 
}
