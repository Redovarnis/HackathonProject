using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using Application.Features.Corporates.Models;
using Application.Services.Repositories;
using Domain.Entities;

namespace Application.Features.Corporates.Queries.GetListCorporate
{
    public class GetListCorporateQuery : IRequest<CorporateListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListCorporateQueryHandler : IRequestHandler<GetListCorporateQuery, CorporateListModel>
        {
            private readonly ICorporateRepository _corporateRepository;
            private readonly IMapper _mapper;

            public GetListCorporateQueryHandler(ICorporateRepository corporateRepository, IMapper mapper)
            {
                _corporateRepository = corporateRepository;
                _mapper = mapper;
            }

            public async Task<CorporateListModel> Handle(GetListCorporateQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Corporate> corporates = await _corporateRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                CorporateListModel mappedCorporateListModel = _mapper.Map<CorporateListModel>(corporates);

                return mappedCorporateListModel;
            }
        }
    }
}
