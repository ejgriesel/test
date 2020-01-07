using System.Collections.Generic;

namespace fundstrading.domain.Models
{
    public partial class Channel
    {
        public Channel()
        {
            Productmapping = new HashSet<Productmapping>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string Appid { get; set; }
        public string Apikey { get; set; }
        public string Userid { get; set; }
        public string Baseurl { get; set; }

        public virtual ICollection<Productmapping> Productmapping { get; set; }
    }
}
