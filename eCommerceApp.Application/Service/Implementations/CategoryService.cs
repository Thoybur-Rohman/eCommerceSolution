using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceApp.Application.DTOs;
using eCommerceApp.Application.DTOs.Category;
using eCommerceApp.Application.Service.Interfaces;

namespace eCommerceApp.Application.Service.Implementations
{
    internal class CategoryService : ICategoryService
    {
        public Task<ServiceResponce> AddAsync(CreateCategory category)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponce> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetCategory>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetCategory> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponce> UpdateAsync(UpdateCategory category)
        {
            throw new NotImplementedException();
        }
    }
}
