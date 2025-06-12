using Data.Contexts;
using Data.Entitites;
using Domain.Models;

namespace Data.Repositories;

public interface IUserRepository : IBaseRepository<UserEntity, UserRepository>
{
}

public class UserRepository(AppDbContext context) : BaseRepository<UserEntity, UserRepository>(context), IUserRepository
{
}
