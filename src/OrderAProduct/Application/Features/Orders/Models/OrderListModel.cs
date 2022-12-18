using Application.Features.Orders.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Orders.Models
{
    public class OrderListModel : BasePageableModel
    {
        public IList<OrderListDto> Items { get; set; }
    }
}
