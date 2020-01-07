using fundstrading.domain.Models;
using fundstrading.repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fundstrading.services
{
    public class SearchApiRequestService : ISearchApiRequestService
    {
        private readonly IApiRequestRepository _apiRequestRepository;

        public SearchApiRequestService(IApiRequestRepository apiRequestRepository)
        {
            this._apiRequestRepository = apiRequestRepository;
        }

        public async Task<IEnumerable<Command>> SearchAsync(int resultCount)
        {
            return await _apiRequestRepository.SearchAsync(resultCount);
        }

        public async Task<IEnumerable<Apirequest>> SearchOrderAsync(List<long> commandId)
        {
            return await _apiRequestRepository.SearchOrderAsync(commandId);
        }
    }
}
