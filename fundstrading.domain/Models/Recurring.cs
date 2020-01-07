using System;

namespace fundstrading.domain.Models
{
    public partial class Recurring
    {
        public long Id { get; set; }
        public DateTime? Datetime { get; set; }
        public int Channelid { get; set; }
        public string Recurringtype { get; set; }
        public string Graphitecode { get; set; }
        public long Cancelid { get; set; }
        public DateTime? Enddate { get; set; }
        public DateTime? Reported { get; set; }
    }
}
