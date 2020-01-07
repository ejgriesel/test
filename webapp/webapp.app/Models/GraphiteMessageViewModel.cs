using System;

namespace fundstrading.web.Models
{
    public class GraphiteMessageViewModel
    {
        public long CommandId { get; set; }
        public long ApiRequesID { get; set; }
        public DateTime? Datetime { get; set; }
        public string Channel { get; set; }
        public string InstructionType { get; set; }
        public string Status { get; set; }
        public string RawRequest { get; set; }
        public string RawResponse { get; set; }

        public string TruncatedRawRequest
        {
            get
            {
                if (string.IsNullOrEmpty(RawRequest)) return RawRequest;
                return RawRequest.Length <= 20 ? RawRequest : RawRequest.Substring(0, 20) + "...";
            }
        }

        public string TruncatedRawResponse
        {
            get
            {
                if (string.IsNullOrEmpty(RawResponse)) return RawResponse;
                return RawResponse.Length <= 20 ? RawResponse : RawResponse.Substring(0, 20) + "...";
            }
        }
    }
}
