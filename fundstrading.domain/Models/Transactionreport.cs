using System;

namespace fundstrading.domain.Models
{
    public partial class Transactionreport
    {
        public long Id { get; set; }
        public int Channelid { get; set; }
        public string Transactionid { get; set; }
        public DateTime Processed { get; set; }
        public DateTime Reported { get; set; }
    }
}
