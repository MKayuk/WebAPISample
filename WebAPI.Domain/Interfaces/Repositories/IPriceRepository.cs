using WebAPI.Domain.Entities;
using System.Collections.Generic;

namespace WebAPI.Domain.Interfaces.Repositories
{
    public interface IPriceRepository : IBaseRepository<PriceList>
    {
        List<PriceList> GetCustomPriceList();
    }
}
