using System.Collections.Generic;
using System.Threading.Tasks;
using fundstrading.domain.Models;

namespace fundstrading.services
{
    public interface IProductMappingService
    {
        IEnumerable<Channel> ChannelList();
        Task<IEnumerable<Productmapping>> ProductMappingList();
        Task<Productmapping> FindProductMapping(long id);
        void CreateProductMapping(Productmapping productMapping);
        void DeleteProductMapping(Productmapping productMapping);
        void UpdateProductMapping(Productmapping productMapping);
    }
}