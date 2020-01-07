using System;

namespace fundstrading.domain.Models
{
    public partial class Instruction
    {
        public long Id { get; set; }
        public DateTime? Datetime { get; set; }
        public long Commandid { get; set; }
        public int Channelid { get; set; }
        public string Instructiontype { get; set; }
        public string Instructionid { get; set; }
        public bool Recurring { get; set; }
        public DateTime? Reported { get; set; }
        public int? Instancestatus { get; set; }

        public Command Command { get; set; }
        public Channel Channel { get; set; }
    }
}
