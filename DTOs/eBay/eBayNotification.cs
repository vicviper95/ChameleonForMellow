using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.DTOs.eBay
{
    public class Rootobject
    {
        public Metadata metadata { get; set; }
        public Notification notification { get; set; }
    }

    public class Metadata
    {
        public string topic { get; set; }
        public string schemaVersion { get; set; }
        public bool deprecated { get; set; }
    }

    public class Notification
    {
        public string notificationId { get; set; }
        public string eventDate { get; set; }
        public string publishDate { get; set; }
        public int publishAttemptCount { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string username { get; set; }
        public string userId { get; set; }
        public string eiasToken { get; set; }
    }
}
