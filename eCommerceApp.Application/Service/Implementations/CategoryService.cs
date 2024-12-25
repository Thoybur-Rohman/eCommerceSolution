using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using eCommerceApp.Application.DTOs;
using eCommerceApp.Application.DTOs.Category;
using eCommerceApp.Application.DTOs.Product;
using eCommerceApp.Application.Service.Interfaces;
using eCommerceApp.Domain.Entities;
using eCommerceApp.Domain.Interfaces;

namespace eCommerceApp.Application.Service.Implementations
{
    internal class CategoryService(IGeneric<Category> categoryInterface , IMapper mapper) : ICategoryService
    {
        public async Task<ServiceResponce> AddAsync(CreateCategory category)
        {
            var mappedData = mapper.Map<Category>(category);
            int result = await categoryInterface.AddAsync(mappedData);

            if (result > 0)
            {
                return new ServiceResponce(true, $"Category added ");
            }
            return new ServiceResponce(false, "Category not added");
        }

        public async Task<ServiceResponce> DeleteAsync(Guid id)
        {
            int result = await categoryInterface.DeleteAsync(id);

            if (result > 0)
            {
                return new ServiceResponce(true, $"Category deleted with id : {id}");
            }
            return new ServiceResponce(false, "Category Id not found");
        }

        public async Task<IEnumerable<GetCategory>> GetAllAsync()
        {
            var rawData = await categoryInterface.GetAllAsync();
            if (rawData != null) return [];

            return mapper.Map<IEnumerable<GetCategory>>(rawData);
        }

        public async Task<GetCategory> GetByIdAsync(Guid id)
        {
            var rawData = await categoryInterface.GetByIdAsync(id);
            if (rawData != null) return null;

            return mapper.Map<GetCategory>(rawData);
        }

        public async Task<ServiceResponce> UpdateAsync(UpdateCategory category)
        {
            var mappedData = mapper.Map<Category>(category);
            int result = await categoryInterface.UpdateAsync(mappedData);

            if (result > 0)
            {
                return new ServiceResponce(true, $"Category updated ");
            }
            return new ServiceResponce(false, "Category not updated");
        }
    }
}
