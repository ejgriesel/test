using System;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations.Schema;

namespace fundstrading.domain.Models
{
    public partial class Fixmessage
    {
        private string _fixTagRegex = @"\b({0})=[ -~]*";

        //FIX Constants
        private static int FIXTAG_ACCOUNT = 1;
        private static int FIXTAG_ORDER_ID = 37;
        private static int FIXTAG_SENDER_COMP_ID = 49;
        private static int FIXTAG_TARGET_COMP_ID = 56;
        private static int FIXTAG_ON_BEHALF_OF_COMP_ID = 115;
        private static int FIXTAG_REGIST_ID = 513;
        private static int FIXTAG_REGIST_TRANS_TYPE = 514;
        private static int FIXTAG_NO_REGIST_DTLS = 473;
        private static int FIXTAG_REGIST_DTLS = 509;
        private static int FIXTAG_OWNER_TYPE = 522;
        private static int FIXTAG_DELIVER_TO_COMP_ID = 128;

        //DB Columns
        public long Id { get; set; }
        public DateTime? Datetime { get; set; }
        public long Commandid { get; set; }
        public bool Incoming { get; set; }
        public string Messagetype { get; set; }
        public string Raw { get; set; }
        
        public int Sessionid { get; set; }
        [ForeignKey("Sessionid")]
        public virtual Session Session { get; set; }

        //Calculated fieldes/Parse data
        public string Account => ParseFixTag(FIXTAG_ACCOUNT);
        public string OrderId => ParseFixTag(FIXTAG_ORDER_ID);
        public string SenderCompID => ParseFixTag(FIXTAG_SENDER_COMP_ID);
        public string TargetCompID => ParseFixTag(FIXTAG_TARGET_COMP_ID);
        public string OnBehalfOfCompID => ParseFixTag(FIXTAG_ON_BEHALF_OF_COMP_ID);
        public string RegistID => ParseFixTag(FIXTAG_REGIST_ID);
        public string RegistTransType => ParseFixTag(FIXTAG_REGIST_TRANS_TYPE);
        public string NoRegistDtls => ParseFixTag(FIXTAG_NO_REGIST_DTLS);
        public string RegistDtls => ParseFixTag(FIXTAG_REGIST_DTLS);
        public string OwnerType => ParseFixTag(FIXTAG_OWNER_TYPE);
        public string DeliverToCompID => ParseFixTag(FIXTAG_DELIVER_TO_COMP_ID);

        public string ParseFixTag(int tag)
        {
            string tagValue = null;
            var tagString = Regex.Match(Raw, String.Format(_fixTagRegex, tag), RegexOptions.IgnoreCase).Value;
            if (!String.IsNullOrEmpty(tagString))
            {
                string[] splitTag = tagString.Split('=');
                if (splitTag.Length > 0)
                {
                    tagValue = splitTag[1];
                }
            }
            return tagValue;
        }
    }
}
