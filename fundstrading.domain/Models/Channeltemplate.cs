namespace fundstrading.domain.Models
{
    public partial class Channeltemplate
    {
        public long Id { get; set; }
        public int Channelid { get; set; }
        public int Investortypeid { get; set; }
        public string Template { get; set; }
    }
}
