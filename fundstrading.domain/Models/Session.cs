namespace fundstrading.domain.Models
{
    public partial class Session
    {
        public int Id { get; set; }
        public int Channelid { get; set; }
        public string Beginstring { get; set; }
        public string Sendercompid { get; set; }
        public string Targetcompid { get; set; }
        public string Onbehalfofcompid { get; set; }
        public string Roe { get; set; }
    }
}
