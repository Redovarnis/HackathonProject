namespace Application.Features.Products.Dtos
{
    public class CreatedProductDto
    {
        public int Id { get; set; }
        public string CorporateName { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public double UnitPrice { get; set; }
    }
}
