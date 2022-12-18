using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Dtos
{
    public class OrderListDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CorporateId { get; set; }
        public string ClientName { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
