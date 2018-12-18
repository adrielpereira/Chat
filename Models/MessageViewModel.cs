using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using WebChatQJW.Core.Utils;

namespace WebChatQJW.Core.Models
{
    public class MessageViewModel
    {
        public long Id { get; set; }

        public long From { get; set; }

        public long To { get; set; }

        public long CompanyId { get; set; }

        [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = false)]
        [IgnoreDataMember]
        public string MessageText { get; set; }

        public int Status { get; set; }

        public DateTime Create_at { get; set; }

        public DateTime? Read_at { get; set; }

        public string Message
        {
            get
            {
                return new Decrypt().DecryptData(MessageText, From, To, CompanyId);
            }
        }
    }

    public class MessageCountViewModel
    {
        public long UserId { get; set; }
        public long Count { get; set; }
    }
}
