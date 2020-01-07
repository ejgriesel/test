using fundstrading.domain.Context;
using fundstrading.domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fundstrading.repositories
{
    public class ProductMappingRepository : BaseRepository, IProductMappingRepository
    {
        public ProductMappingRepository(FundstradingContext context) : base(context)
        {
        }

        public IEnumerable<Channel> ChannelList()
        {
            return _context.Channel
                .OrderBy(c => c.Description)
                .AsNoTracking()
                .ToList();
        }

        public async Task<IEnumerable<Productmapping>> ProductMappingList()
        {
            return await _context.Productmapping
                .OrderBy(c => c.Incoming)
                .Include(c => c.Channel)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Productmapping> FindProductMapping(long id)
        {
            return await _context.Productmapping
                .Include(c => c.Channel)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public void CreateProductMapping(Productmapping productMapping)
        {
            _context.Productmapping.Add(productMapping);
            _context.SaveChanges();
        }

        public void DeleteProductMapping(Productmapping productMapping)
        {
            _context.Productmapping.Remove(productMapping);
            _context.SaveChanges();
        }

        public void UpdateProductMapping(Productmapping productMapping)
        {
            _context.Productmapping.Update(productMapping);
            _context.SaveChanges();
        }
    }
}
