using Data.Contexts;
using Data.Entitites;
using Domain.Models;

namespace Data.Repositories;

public interface IStatusRepository : IBaseRepository<StatusEntity, StatusRepository>
{
}

public class StatusRepository(AppDbContext context) : BaseRepository<StatusEntity, StatusRepository>(context), IStatusRepository
{
}
