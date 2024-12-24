using eCommerceApp.Application.DTOs;
using eCommerceApp.Application.DTOs.Product;
using eCommerceApp.Application.Service.Interfaces;
using eCommerceApp.Domain.Entities;
using eCommerceApp.Domain.Interfaces;

namespace eCommerceApp.Application.Service.Implementations
{
    public class ProductService(IGeneric<Product> productInterface) : IProductService
    {
        public async Task<ServiceResponce> AddAsync(CreateProduct product)
        {
           int result = await productInterface.AddAsync(product);
        }

        public Task<ServiceResponce> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetProduct>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetProduct> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponce> UpdateAsync(UpdateProduct product)
        {
            throw new NotImplementedException();
        }
    }
}
