using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Corporates.Dtos
{
    public class CorporateGetByIdDto
    {
        public int Id { get; set; }
        public string CorporateName { get; set; }
        public bool OrderState { get; set; }
        public DateTime StartOrderTime { get; set; }
        public DateTime EndOrderTime { get; set; }
    }
}
