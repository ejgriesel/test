using System;

namespace fundstrading.domain.Models
{
    public partial class Chain
    {
        public long Id { get; set; }
        public DateTime? Datetime { get; set; }
        public long Commandid { get; set; }
        public string Fqcnstring { get; set; }
    }
}
