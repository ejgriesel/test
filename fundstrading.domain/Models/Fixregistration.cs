using System;

namespace fundstrading.domain.Models
{
    public partial class Fixregistration
    {
        public long Id { get; set; }
        public DateTime? Datetime { get; set; }
        public long Commandid { get; set; }
        public string Registid { get; set; }
        public string Registrefid { get; set; }
        public bool Pending { get; set; }
        public string Instructionid { get; set; }
        public DateTime? Reported { get; set; }
        public string Investorcode { get; set; }
        public bool? Tryreport { get; set; }
        public bool? Error { get; set; }
        public bool? Haserror { get; set; }
    }
}
