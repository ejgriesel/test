using fundstrading.domain.Models;
using fundstrading.repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fundstrading.services
{
    public class SearchApiResponseService : ISearchApiResponseService
    {
        private readonly IApiResponseRepository _apiResponseRepository;

        public SearchApiResponseService(IApiResponseRepository apiResponseRepository)
        {
            this._apiResponseRepository = apiResponseRepository;
        }

        async public Task<IEnumerable<Apiresponse>> SearchOrderAsync(List<long> commandId)
        {
            return await _apiResponseRepository.SearchOrderAsync(commandId);
        }
    }
}
