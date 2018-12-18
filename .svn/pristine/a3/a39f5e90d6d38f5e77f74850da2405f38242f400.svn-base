using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WebChatQJW.Core.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, IExceptionHandlerFeature message)
        {
            response.Headers.Add("Application-Error", message.Error.Message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");

            LogManager.LogException(message);
        }
    }
}
