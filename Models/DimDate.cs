using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class DimDate
    {
        public DimDate()
        {
            BeginningInventories = new HashSet<BeginningInventory>();
            CommittedSos = new HashSet<CommittedSo>();
            ItemSoldByComponents = new HashSet<ItemSoldByComponent>();
        }

        public int DateKey { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateTime { get; set; }
        public string FullDateUsa { get; set; }
        public string DayOfMonth { get; set; }
        public string DaySuffix { get; set; }
        public string DayName { get; set; }
        public string DayOfWeekUsa { get; set; }
        public string DayOfWeekInMonth { get; set; }
        public string DayOfWeekInYear { get; set; }
        public string DayOfQuarter { get; set; }
        public string DayOfYear { get; set; }
        public string WeekOfMonth { get; set; }
        public string WeekOfQuarter { get; set; }
        public string WeekOfYear { get; set; }
        public string Month { get; set; }
        public string MonthName { get; set; }
        public string MonthOfQuarter { get; set; }
        public string Quarter { get; set; }
        public string QuarterName { get; set; }
        public string Year { get; set; }
        public string YearName { get; set; }
        public string MonthYear { get; set; }
        public string Mmyyyy { get; set; }
        public DateTime FirstDayOfMonth { get; set; }
        public DateTime LastDayOfMonth { get; set; }
        public DateTime FirstDayOfQuarter { get; set; }
        public DateTime LastDayOfQuarter { get; set; }
        public DateTime FirstDayOfYear { get; set; }
        public DateTime LastDayOfYear { get; set; }
        public bool IsHolidayUsa { get; set; }
        public bool IsWeekday { get; set; }
        public DateTime MondayOfWeek { get; set; }
        public string HolidayUsa { get; set; }
        public bool IsHolidayWeek { get; set; }
        public bool IsBpmholiday { get; set; }
        public int FcstWkMonth { get; set; }
        public int FcstWkYear { get; set; }
        public int FcstWkWeekNo { get; set; }

        public virtual ICollection<BeginningInventory> BeginningInventories { get; set; }
        public virtual ICollection<CommittedSo> CommittedSos { get; set; }
        public virtual ICollection<ItemSoldByComponent> ItemSoldByComponents { get; set; }
    }
}
