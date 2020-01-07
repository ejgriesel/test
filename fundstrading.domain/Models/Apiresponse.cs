using System;

namespace fundstrading.domain.Models
{
    public partial class Apiresponse
    {
        public long Id { get; set; }
        public DateTime? Datetime { get; set; }
        public long Commandid { get; set; }
        public int ResponseCode { get; set; }
        public bool? Accepted { get; set; }
        public string Instructionid { get; set; }
        public string Raw { get; set; }

        public Command Command { get; set; }
    }
}
