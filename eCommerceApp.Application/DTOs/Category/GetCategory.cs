using System.ComponentModel.DataAnnotations;
using eCommerceApp.Application.DTOs.Product;

namespace eCommerceApp.Application.DTOs.Category
{
    public class GetCategory : CategoryBase
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public ICollection<GetProduct>? Products { get; set; }
    }
}
