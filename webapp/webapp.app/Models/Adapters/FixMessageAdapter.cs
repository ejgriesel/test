using fundstrading.domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace fundstrading.web.Models.Adapters
{
    public static class FixMessageAdapter
    {
        public static IEnumerable<FixmessageViewModel> ToViewModel(this IEnumerable<Fixmessage> fixMessages)
        {
            return fixMessages.Select(p => new FixmessageViewModel
            {
                Id = p.Id,
                Sessionid = p.Sessionid,
                Commandid = p.Commandid,
                Datetime = p.Datetime,
                Direction = p.Incoming ? "Incoming" : "Outgoing",
                Messagetype = GetMessageTypeDescription(p.Messagetype),
                Raw = p.Raw,
                Account = p.Account,
                OrderId = p.OrderId,
                OnBehalfOfCompID = p.OnBehalfOfCompID
            });
        }

        public static string GetMessageTypeDescription(string tag)
        {
            switch (tag)
            {
                case "p": return "Registration Instructions Response (p)";
                case "o": return "Registration Instruction(o)";
                case "8": return "Execution Report (8)";
                case "D": return "New Order Single (D)";
            }
            return "";
        }
    }
}
