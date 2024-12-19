using eCommerceApp.Application.DTOs;
using eCommerceApp.Application.DTOs.Category;

namespace eCommerceApp.Application.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<GetCategory>> GetAllAsync();

        Task<GetCategory> GetByIdAsync(Guid id);

        Task<ServiceResponce> AddAsync(CreateCategory category);

        Task<ServiceResponce> UpdateAsync(UpdateCategory category);

        Task<ServiceResponce> DeleteAsync(Guid id);
    }
}
