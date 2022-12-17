using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class CorporateRepository : EfRepositoryBase<Corporate, BaseDbContext>, ICorporateRepository
    {
        public CorporateRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
