using System;
using System.ComponentModel.DataAnnotations;

namespace fundstrading.web.Models
{
    public class FixmessageViewModel
    {
        public long Id { get; set; }
        public DateTime? Datetime { get; set; }
        public int Sessionid { get; set; }
        public long Commandid { get; set; }
        public string Direction { get; set; }

        [Display(Name = "Type")]
        public string Messagetype { get; set; }

        public string Raw { get; set; }

        public string TruncatedRaw
        {
            get
            {
                if (string.IsNullOrEmpty(Raw)) return Raw;
                return Raw.Length <= 10 ? Raw : Raw.Substring(0, 10) + "...";
            }
        }

        //FIX fields
        [Display(Name = "OnBehalfOf")]
        public string OnBehalfOfCompID { get; set; }

        public string Account { get; internal set; }
        public string OrderId { get; internal set; }
    }
}
