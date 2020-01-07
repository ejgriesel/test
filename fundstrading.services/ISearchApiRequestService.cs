using fundstrading.domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fundstrading.services
{
    public interface ISearchApiRequestService
    {
        Task<IEnumerable<Command>> SearchAsync(int resultCount);
        Task<IEnumerable<Apirequest>> SearchOrderAsync(List<long> commandId);
    }
}
