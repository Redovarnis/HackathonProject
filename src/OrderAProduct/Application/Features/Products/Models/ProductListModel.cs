using Application.Features.Products.Dtos;

namespace Application.Features.Products.Models
{
    public class ProductListModel
    {
        public IList<ProductListDto> Items { get; set; }
    }
}
