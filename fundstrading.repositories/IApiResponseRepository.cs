using fundstrading.domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fundstrading.repositories
{
    public interface IApiResponseRepository
    {
        Task<IEnumerable<Apiresponse>> SearchOrderAsync(List<long> commandId);
    }
}
