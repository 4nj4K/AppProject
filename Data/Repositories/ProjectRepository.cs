using Data.Contexts;
using Data.Entitites;
using Domain.Models;

namespace Data.Repositories;

public interface IProjectRepository : IBaseRepository<ProjectEntity, ProjectRepository>
{
}

public class ProjectRepository(AppDbContext context) : BaseRepository<ProjectEntity, ProjectRepository>(context), IProjectRepository
{
}
