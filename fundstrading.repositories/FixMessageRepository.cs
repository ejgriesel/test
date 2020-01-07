using fundstrading.common;
using fundstrading.domain.Context;
using fundstrading.domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fundstrading.repositories
{
    public class FixMessageRepository : BaseRepository, IFixMessageRepository
    {
        public FixMessageRepository(FundstradingContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Fixmessage>> SearchAsync(int resultCount)
        {
            if (resultCount == 0)
            {
                return await _context.Fixmessage.ToListAsync();
            }
            else
            {
                return _context.Fixmessage
                    .OrderByDescending(f => f.Datetime)
                    .Take(resultCount);
            }
        }

        public async Task<IEnumerable<Fixmessage>> SearchOrderAsync(DateTime dateTime, string orderId, int channelId)
        {
            List<Fixmessage> result = await _context.Fixmessage.Include(x => x.Session)
                    .Where(m => m.Datetime >= dateTime && !string.IsNullOrEmpty(orderId) && m.Raw.Contains(Constants.SOH + Constants.TAG11 + orderId + Constants.SOH))
                    .OrderBy(m => m.Datetime)
                    .ToListAsync();

            if (channelId != 0)
            {
                result = result.Where(m => m.Session.Channelid == channelId).ToList();
            }

            return result;
        }

        public async Task<IEnumerable<Channel>> GetChannels()
        {
            return await _context.Channel
                .OrderBy(c => c.Description)
                .ToListAsync();
        }

        private const string TAG513 = "513=";

        public async Task<IEnumerable<Fixmessage>> SearchOrderAndRegistIdAsync(DateTime dateTime, string orderId, string registId, int channelId)
        {
            List<Fixmessage> result = await _context.Fixmessage.Include(x => x.Session)
                .Where(m => m.Datetime >= dateTime && !string.IsNullOrEmpty(orderId) && (m.Raw.Contains(Constants.SOH + Constants.TAG11 + orderId + Constants.SOH) || m.Raw.Contains(Constants.SOH + TAG513 + registId + Constants.SOH)))
                .OrderBy(m => m.Datetime)
                .ToListAsync();

            if (channelId != 0)
            {
                result = result.Where(m => m.Session.Channelid == channelId).ToList();
            }

            return result;
        }
    }
}
