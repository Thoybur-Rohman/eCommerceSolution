using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceApp.Application.DTOs;
using eCommerceApp.Application.DTOs.Product;

namespace eCommerceApp.Application.Service.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<GetProduct>> GetAllAsync();

        Task<GetProduct> GetByIdAsync(Guid id);

        Task<ServiceResponce> AddAsync(CreateProduct product);

        Task<ServiceResponce> UpdateAsync(UpdateProduct product);

        Task<ServiceResponce> DeleteAsync(Guid id);
    }
}
