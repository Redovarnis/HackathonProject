using Application.Features.Corporates.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Corporates.Models
{
    public class CorporateListModel : BasePageableModel
    {
        public IList<CorporateListDto> Items { get; set; }
    }
}
