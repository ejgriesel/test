using System;
using System.Collections.Generic;

namespace fundstrading.domain.Models
{
    public partial class Productmapping
    {
        public long Id { get; set; }
        public string Incoming { get; set; }
        public string Outgoing { get; set; }
        public int Channelid { get; set; }

        public virtual Channel Channel { get; set; }
    }
}
