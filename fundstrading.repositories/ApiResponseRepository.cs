using fundstrading.domain.Context;
using fundstrading.domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fundstrading.repositories
{
    public class ApiResponseRepository : BaseRepository, IApiResponseRepository
    {
        public ApiResponseRepository(FundstradingContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Apiresponse>> SearchOrderAsync(List<long> commandId)
        {
            return await _context.Apiresponse
                .Where(m => commandId.Contains(m.Commandid))
                .OrderBy(m => m.Datetime)
                .ToListAsync();
        }
    }
}
