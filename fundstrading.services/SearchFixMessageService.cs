using fundstrading.domain.Models;
using fundstrading.repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace fundstrading.domain.Services
{
    public class SearchFixMessageService : ISearchFixMessageService
    {
        private readonly IFixMessageRepository _fixMessageRepository;

        public SearchFixMessageService(IFixMessageRepository fixMessageRepository)
        {
            this._fixMessageRepository = fixMessageRepository;
        }

        public async Task<IEnumerable<Fixmessage>> SearchAsync(int resultCount)
        {
            return await _fixMessageRepository.SearchAsync(resultCount);
        }

        public async Task<IEnumerable<Fixmessage>> SearchOrderAsync(DateTime dateTime, string orderId, int channelId)
        {
            return await _fixMessageRepository.SearchOrderAsync(dateTime, orderId, channelId);
        }

        public async Task<IEnumerable<Channel>> GetChannels()
        {
            return await _fixMessageRepository.GetChannels();
        }

        public async Task<IEnumerable<Fixmessage>> SearchOrderAndRegistIdAsync(DateTime dateTime, string orderId, string registId, int channelId)
        {
            return await _fixMessageRepository.SearchOrderAndRegistIdAsync(dateTime, orderId, registId, channelId);
        }
    }
}