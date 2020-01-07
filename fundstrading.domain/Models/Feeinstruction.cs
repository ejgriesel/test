using System;

namespace fundstrading.domain.Models
{
    public partial class Feeinstruction
    {
        public long Id { get; set; }
        public DateTime? Datetime { get; set; }
        public int Channelid { get; set; }
        public string Correlationid { get; set; }
        public string Feecode { get; set; }
        public string Postinstructionid { get; set; }
        public string Investmentcode { get; set; }
        public DateTime? Applied { get; set; }
        public bool Failed { get; set; }
        public string Feeinstructionid { get; set; }
    }
}
