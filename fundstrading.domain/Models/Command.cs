using System;

namespace fundstrading.domain.Models
{
    public partial class Command
    {
        public long Id { get; set; }
        public DateTime? Datetime { get; set; }

        public Apirequest Apirequest { get; set; }
        public Apiresponse Apiresponse { get; set; }
        public Instruction Instruction { get; set; }
    }
}
