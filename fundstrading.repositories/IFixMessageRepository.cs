using fundstrading.domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fundstrading.repositories
{
    public interface IFixMessageRepository
    {
        Task<IEnumerable<Fixmessage>> SearchAsync(int resultCount);
        Task<IEnumerable<Fixmessage>> SearchOrderAsync(DateTime dateTime, string orderId, int channelId);
        Task<IEnumerable<Fixmessage>> SearchOrderAndRegistIdAsync(DateTime dateTime, string orderId, string registId, int channelId);
        Task<IEnumerable<Channel>> GetChannels();
    }
}
