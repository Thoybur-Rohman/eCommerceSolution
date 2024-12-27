using AutoMapper;
using eCommerceApp.Application.DTOs;
using eCommerceApp.Application.DTOs.Product;
using eCommerceApp.Application.Service.Interfaces;
using eCommerceApp.Domain.Entities;
using eCommerceApp.Domain.Interfaces;

namespace eCommerceApp.Application.Service.Implementations
{
    public class ProductService(IGeneric<Product> productInterface , IMapper mapper) : IProductService
    {
        public async Task<ServiceResponce> AddAsync(CreateProduct product)
        {
           var mappedData = mapper.Map<Product>(product);
           int result = await productInterface.AddAsync(mappedData);

            if (result > 0)
            {
                return new ServiceResponce(true, $"Product with id added ");
            }
            return new ServiceResponce(false, "Id not added");
        }

        public async Task<ServiceResponce> DeleteAsync(Guid id)
        {
            int result = await productInterface.DeleteAsync(id);

            if (result > 0)
            {
                return new ServiceResponce(true, $"Product deleted with id : {id}");
            }
            return new ServiceResponce(false ,"Id not found");
        }
             
        public async Task<IEnumerable<GetProduct>> GetAllAsync()
        {
            var rawData = await productInterface.GetAllAsync();
            if (!rawData.Any()) return [];

            return mapper.Map<IEnumerable<GetProduct>>(rawData);
        }

        public async Task<GetProduct> GetByIdAsync(Guid id)
        {
            var rawData = await productInterface.GetByIdAsync(id);
            if (rawData == null) return new GetProduct();

            return mapper.Map<GetProduct>(rawData);
        }

        public async Task<ServiceResponce> UpdateAsync(UpdateProduct product)
        {
            var mappedData = mapper.Map<Product>(product);
            int result = await productInterface.UpdateAsync(mappedData);

            if (result > 0)
            {
                return new ServiceResponce(true, $"Product updated ");
            }
            return new ServiceResponce(false, "Id not updated");
        }
    }
}
