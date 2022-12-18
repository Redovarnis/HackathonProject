namespace Application.Features.Orders.Dtos
{
    public class CreatedOrderDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CorporateId { get; set; }
        public string ClientName { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
