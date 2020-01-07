using fundstrading.domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace fundstrading.web.Models.Adapters
{
    public static class GraphiteMessageAdapter
    {
        public static IEnumerable<GraphiteMessageViewModel> ToViewModel(this IEnumerable<Command> commands)
        {
            return commands.Select(c => new GraphiteMessageViewModel
            {
                CommandId = c.Id,
                ApiRequesID = c.Apirequest.Id,
                Datetime = c.Datetime,
                Channel = c.Instruction.Channel.Description,
                InstructionType = c.Instruction.Instructiontype,
                Status = c.Apiresponse.ResponseCode.ToString(),
                RawRequest = c.Apirequest.Raw,
                RawResponse = c.Apiresponse.Raw
            });
        }
    }
}

