using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebChatQJW.Core.Models
{
    public class Message
    {
        [Key]
        public long Id { get; set; }

        public long From { get; set; }

        public long To { get; set; }

        public long CompanyId { get; set; }

        public string MessageText { get; set; }

        public int Status { get; set; }

        public DateTime Create_at { get; set; }

        public DateTime? Read_at { get; set; }

    }
}
