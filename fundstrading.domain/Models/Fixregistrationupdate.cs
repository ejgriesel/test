using System;

namespace fundstrading.domain.Models
{
    public partial class Fixregistrationupdate
    {
        public long Id { get; set; }
        public DateTime? Datetime { get; set; }
        public int Commandid { get; set; }
        public int Channelid { get; set; }
        public int Sessionid { get; set; }
        public string Registid { get; set; }
        public string Registrefid { get; set; }
        public string Instructionid { get; set; }
        public DateTime? Reported { get; set; }
        public bool? Tryreport { get; set; }
        public bool Haserror { get; set; }
    }
}
