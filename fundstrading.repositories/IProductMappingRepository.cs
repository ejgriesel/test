using fundstrading.domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fundstrading.repositories
{
    public interface IProductMappingRepository
    {
        IEnumerable<Channel> ChannelList();
        Task<IEnumerable<Productmapping>> ProductMappingList();
        Task<Productmapping> FindProductMapping(long id);
        void CreateProductMapping(Productmapping productMapping);
        void DeleteProductMapping(Productmapping productMapping);
        void UpdateProductMapping(Productmapping productMapping);
    }
}
