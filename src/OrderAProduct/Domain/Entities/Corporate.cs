using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Corporate : Entity
    {
        public string CorporateName { get; set; }
        public bool OrderState { get; set; }
        public DateTime StartOrderTime { get; set; }
        public DateTime EndOrderTime { get; set;}

        public Corporate()
        {

        }

        public Corporate(int id, string corporateName, bool orderState, DateTime startOrderTime, DateTime endOrderTime)
        {
            Id = id;
            CorporateName = corporateName;
            OrderState = orderState;
            StartOrderTime = startOrderTime;
            EndOrderTime = endOrderTime;
        }
    }
}
