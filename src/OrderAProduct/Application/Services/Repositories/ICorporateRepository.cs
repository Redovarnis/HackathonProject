using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface ICorporateRepository : IAsyncRepository<Corporate>, IRepository<Corporate>
    {

    }
}