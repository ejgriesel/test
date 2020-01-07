using System;

namespace fundstrading.domain.Models
{
    public partial class Apirequest
    {
        public long Id { get; set; }
        public DateTime? Datetime { get; set; }
        public long Commandid { get; set; }
        public string Raw { get; set; }

        public Command Command { get; set; }
    }
}
