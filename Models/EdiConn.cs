using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiConn
    {
        public int EdiConnId { get; set; }
        public int EpId { get; set; }
        public string MyAs2TestUrl { get; set; }
        public string MyAs2TestId { get; set; }
        public string MyAs2ProdUrl { get; set; }
        public string MyAs2ProdId { get; set; }
        public string EpAs2TestUrl { get; set; }
        public string EpAs2TestId { get; set; }
        public string EpAs2ProdUrl { get; set; }
        public string EpAs2ProdId { get; set; }
        public string EndProvider { get; set; }
        public string EncAlgorithm { get; set; }
        public string EncHash { get; set; }
        public string FtpUrl { get; set; }
        public int? FtpId { get; set; }
        public string FtpPw { get; set; }
        public bool? IsSign { get; set; }
        public bool? IsEncrypt { get; set; }

        public virtual EdiPatrnerInfo Ep { get; set; }
    }
}
