using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EBayNotification
    {
        public int NotifyId { get; set; }
        public string Topic { get; set; }
        public string SchemaVerison { get; set; }
        public bool? Deprecated { get; set; }
        public string NotificationId { get; set; }
        public DateTime? EventDate { get; set; }
        public DateTime? PublishDate { get; set; }
        public int? PublishAttemtCount { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string EiasToken { get; set; }
    }
}
