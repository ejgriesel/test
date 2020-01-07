using fundstrading.domain.Models;
using fundstrading.repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fundstrading.services
{
    public class ProductMappingService : IProductMappingService
    {
        private readonly IProductMappingRepository _productMappingRepository;

        public ProductMappingService(IProductMappingRepository productMappingRepository)
        {
            this._productMappingRepository = productMappingRepository;
        }

        public IEnumerable<Channel> ChannelList()
        {
            return _productMappingRepository.ChannelList();
        }

        public async Task<IEnumerable<Productmapping>> ProductMappingList()
        {
            return await _productMappingRepository.ProductMappingList();
        }

        public async Task<Productmapping> FindProductMapping(long id)
        {
            return await _productMappingRepository.FindProductMapping(id);
        }

        public void CreateProductMapping(Productmapping productMapping)
        {
            _productMappingRepository.CreateProductMapping(productMapping);
        }

        public void DeleteProductMapping(Productmapping productMapping)
        {
            _productMappingRepository.DeleteProductMapping(productMapping);
        }

        public void UpdateProductMapping(Productmapping productMapping)
        {
            _productMappingRepository.UpdateProductMapping(productMapping);
        }
    }
}
