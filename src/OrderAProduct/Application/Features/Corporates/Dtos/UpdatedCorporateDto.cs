namespace Application.Features.Corporates.Dtos
{
    public class UpdatedCorporateDto
    {
        public int Id { get; set; }
        public string CorporateName { get; set; }
        public bool OrderState { get; set; }
        public DateTime StartOrderTime { get; set; }
        public DateTime EndOrderTime { get; set; }
    }
}
