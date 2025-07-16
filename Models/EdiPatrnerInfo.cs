using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiPatrnerInfo
    {
        public EdiPatrnerInfo()
        {
            EdiConns = new HashSet<EdiConn>();
            MyAs2Certs = new HashSet<MyAs2Cert>();
            PtAs2Certs = new HashSet<PtAs2Cert>();
            Tpl944s = new HashSet<Tpl944>();
            Tpl945s = new HashSet<Tpl945>();
            TplB2pIcs = new HashSet<TplB2pIc>();
            TplP2bIcs = new HashSet<TplP2bIc>();
        }

        public int EdiPartnerId { get; set; }
        public string PartnerName { get; set; }
        public string BpmIdQual { get; set; }
        public string BpmId { get; set; }
        public string PartnerIdQual { get; set; }
        public string PartnerId { get; set; }
        public string Usage { get; set; }
        public string EncProvider { get; set; }
        public string EncAlgorithm { get; set; }
        public string EncHash { get; set; }
        public string CertFileBpm { get; set; }
        public string CertFilePartner { get; set; }
        public string PartnerUrl { get; set; }
        public string As2PartnerId { get; set; }
        public string As2BpmId { get; set; }
        public DateTime? ExpDatePartner { get; set; }
        public bool IsInactive { get; set; }
        public string FullName { get; set; }
        public string Protocol { get; set; }
        public string FtpId { get; set; }
        public string FtpPw { get; set; }
        public bool? IsSign { get; set; }
        public bool? IsEncrypt { get; set; }
        public bool IsOnPause { get; set; }

        public virtual ICollection<EdiConn> EdiConns { get; set; }
        public virtual ICollection<MyAs2Cert> MyAs2Certs { get; set; }
        public virtual ICollection<PtAs2Cert> PtAs2Certs { get; set; }
        public virtual ICollection<Tpl944> Tpl944s { get; set; }
        public virtual ICollection<Tpl945> Tpl945s { get; set; }
        public virtual ICollection<TplB2pIc> TplB2pIcs { get; set; }
        public virtual ICollection<TplP2bIc> TplP2bIcs { get; set; }
    }
}
