using Data.Contexts;
using Data.Entitites;
using Domain.Models;

namespace Data.Repositories;

public interface IClientRepository : IBaseRepository<ClientEntity, ClientRepository>
{
}

public class ClientRepository(AppDbContext context) : BaseRepository<ClientEntity, ClientRepository>(context), IClientRepository
{
}
