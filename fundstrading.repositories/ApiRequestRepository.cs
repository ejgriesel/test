using fundstrading.domain.Context;
using fundstrading.domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fundstrading.repositories
{
    public class ApiRequestRepository : BaseRepository, IApiRequestRepository
    {
        public ApiRequestRepository(FundstradingContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Command>> SearchAsync(int resultCount)
        {
            //Last *resultCount* requests to Graphite. Returns the commands associated
            var result = from arq in _context.Apirequest
                         join c in _context.Command on arq.Commandid equals c.Id
                         join ar in _context.Apiresponse on c.Id equals ar.Commandid
                         join i in _context.Instruction on c.Id equals i.Commandid
                         join ch in _context.Channel on i.Channelid equals ch.Id

                         orderby arq.Datetime descending

                         select new Command
                         {
                             Id = c.Id,
                             Datetime = c.Datetime,

                             Apirequest = arq,
                             Apiresponse = ar,
                             Instruction = new Instruction
                             {
                                 Id = i.Id,
                                 Datetime = i.Datetime,
                                 Commandid = i.Commandid,
                                 Channelid = i.Channelid,
                                 Instructiontype = i.Instructiontype,
                                 Instructionid = i.Instructionid,
                                 Recurring = i.Recurring,
                                 Reported = i.Reported,
                                 Instancestatus = i.Instancestatus,
                                 Command = i.Command,
                                 Channel = ch
                             },
                         };
            if (resultCount == 0)
            {
                return await result.ToListAsync<Command>();
            }
            else
            {
                return result.Take<Command>(resultCount);
            }
        }

        public async Task<IEnumerable<Apirequest>> SearchOrderAsync(List<long> commandId)
        {
            return await _context.Apirequest
                .Where(m => commandId.Contains(m.Commandid))
                .OrderBy(m => m.Datetime)
                .ToListAsync();
        }
    }
}
