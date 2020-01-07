using fundstrading.domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fundstrading.repositories
{
    public interface IApiRequestRepository
    {
        Task<IEnumerable<Command>> SearchAsync(int resultCount);
        Task<IEnumerable<Apirequest>> SearchOrderAsync(List<long> commandId);
    }
}
