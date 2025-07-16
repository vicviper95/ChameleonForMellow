using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Edipartner
    {
        public Edipartner()
        {
            BpmLocations = new HashSet<BpmLocation>();
            Customers = new HashSet<Customer>();
            EdiAutoMks = new HashSet<EdiAutoMk>();
            EdiAutoTpls = new HashSet<EdiAutoTpl>();
            EdiCarriers = new HashSet<EdiCarrier>();
            EdiIcM2ps = new HashSet<EdiIcM2p>();
            EdiIcP2ms = new HashSet<EdiIcP2m>();
            Edicertificates = new HashSet<Edicertificate>();
        }

        public int PartnerId { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public bool Is3Pl { get; set; }
        public byte Protocol { get; set; }
        public string MyAs2id { get; set; }
        public string PartnerAs2id { get; set; }
        public string Url { get; set; }
        public string MyIsa { get; set; }
        public string MyQual { get; set; }
        public string PartnerIsa { get; set; }
        public string PartnerQual { get; set; }
        public string Usage { get; set; }
        public string LoginId { get; set; }
        public string LoginPw { get; set; }
        public bool IsSignature { get; set; }
        public bool IsEncrypt { get; set; }
        public bool IsSandbox { get; set; }
        public bool IsActive { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime LastModTime { get; set; }
        public bool IsOnPause { get; set; }
        public string SftpRxDir { get; set; }
        public string SftpTxDir { get; set; }
        public int PartnerSignAlgorithm { get; set; }
        public int? MarketId { get; set; }
        public int? MyCertificateId { get; set; }
        public int EdiVersion { get; set; }

        public virtual Market Market { get; set; }
        public virtual Edicertificate MyCertificate { get; set; }
        public virtual ICollection<BpmLocation> BpmLocations { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<EdiAutoMk> EdiAutoMks { get; set; }
        public virtual ICollection<EdiAutoTpl> EdiAutoTpls { get; set; }
        public virtual ICollection<EdiCarrier> EdiCarriers { get; set; }
        public virtual ICollection<EdiIcM2p> EdiIcM2ps { get; set; }
        public virtual ICollection<EdiIcP2m> EdiIcP2ms { get; set; }
        public virtual ICollection<Edicertificate> Edicertificates { get; set; }
    }
}
