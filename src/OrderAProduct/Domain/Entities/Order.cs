using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Order : Entity
    {
        public int CorporateId { get; set; }
        public int ProductId { get; set; }
        public string ClientName { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual Corporate? Corporate { get; set; }

        public Order()
        {
            
        }

        public Order(int id, int corporateId, int productId, string clientName, DateTime orderDate)
        {
            Id = id;
            CorporateId = corporateId;
            ProductId = productId;
            ClientName = clientName;
            OrderDate = orderDate;
        }
    }
}
