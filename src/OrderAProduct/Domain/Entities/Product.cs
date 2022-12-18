using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Product : Entity
    {
        public string CorporateName { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public double UnitPrice { get; set; }
        public virtual Corporate? Corporate { get; set; }

        public Product()
        {
            
        }
        public Product(int id, string corporateName, string productName, int stock, double unitPrice) : this()
        {
            Id = id;
            CorporateName = corporateName;
            ProductName = productName;
            Stock = stock;
            UnitPrice = unitPrice;
        }
    }
}
