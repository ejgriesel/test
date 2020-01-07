using fundstrading.domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fundstrading.services
{
    public interface ISearchApiResponseService
    {
        Task<IEnumerable<Apiresponse>> SearchOrderAsync(List<long> commandId);
    }
}
