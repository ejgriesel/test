using System;

namespace fundstrading.domain.Models
{
    public partial class Registration
    {
        public long Id { get; set; }
        public DateTime? Datetime { get; set; }
        public int Channelid { get; set; }
        public string Iosaccount { get; set; }
        public bool Acknowledged { get; set; }
        public bool Pending { get; set; }
        public string Instructionid { get; set; }
        public DateTime? Reported { get; set; }
        public string Investorcode { get; set; }
        public string Xml { get; set; }
        public bool? Tryreport { get; set; }
        public bool Haserror { get; set; }
        public int Status { get; set; }
    }
}
