using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemPrice
    {
        public DateTime? Date { get; set; }
        public int Sort { get; set; }
        public string Ca { get; set; }
        public string Code { get; set; }
        public string ItemSku { get; set; }
        public string Item { get; set; }
        public string CategoryZinus { get; set; }
        public decimal _2020AveFob { get; set; }
        public decimal _2019AveFob { get; set; }
        public decimal CurrentFobIfMultiPriceMax { get; set; }
        public int Duty { get; set; }
        public int Tariff { get; set; }
        public double Cbm { get; set; }
        public double Cft { get; set; }
        public int _40HqQty { get; set; }
        public decimal OceanFreight { get; set; }
        public decimal DutyTariff { get; set; }
        public decimal DdpWarehouse { get; set; }
        public decimal WhseExpense { get; set; }
        public decimal Storage3month { get; set; }
        public decimal InterestRate { get; set; }
        public decimal Elc { get; set; }
        public string Status { get; set; }
        public string SalesTier { get; set; }
        public string FobPriceFromPriceRecapFile05202020 { get; set; }
        public decimal _2019OldFob { get; set; }
        public string Ratio { get; set; }
    }
}
