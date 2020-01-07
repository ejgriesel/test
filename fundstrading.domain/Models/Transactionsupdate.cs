using System;

namespace fundstrading.domain.Models
{
    public partial class Transactionsupdate
    {
        public long Id { get; set; }
        public DateTime Datetime { get; set; }
        public long Commandid { get; set; }
        public int Sessionid { get; set; }
        public long Originalcommandid { get; set; }
        public long? Newcommandid { get; set; }
        public string Raw { get; set; }
    }
}
