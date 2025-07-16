using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BpmEdiInterchange
    {
        public int InterchangeKey { get; set; }
        public string Isa01AuthorizationInformationQualifier { get; set; }
        public string Isa02AuthorizationInformation { get; set; }
        public string Isa03SecurityInformationQualifier { get; set; }
        public string Isa04SecurityInformation { get; set; }
        public string Isa05InterchangeSenderIdQualifier { get; set; }
        public string Isa06InterchangeSenderId { get; set; }
        public string Isa07InterchangeReceiverIdQualifier { get; set; }
        public string Isa08InterchangeReceiverId { get; set; }
        public string Isa09InterchangeDate { get; set; }
        public string Isa10InterchangeTime { get; set; }
        public string Isa11InterchangeControlStandardsIdentifier { get; set; }
        public string Isa12InterchangeControlVersionNumber { get; set; }
        public string Isa13InterchangeControlNumber { get; set; }
        public string Isa14AcknowledgmentRequested { get; set; }
        public string Isa15UsageIndicator { get; set; }
        public string Isa16ComponentElementSeparator { get; set; }
    }
}
