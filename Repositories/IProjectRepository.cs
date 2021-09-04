using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectsApi.Models;

namespace ProjectsApi.Repositories
{
    public interface IProjectRepository
    {
         Task<Project> GetProject(int id);
         Task<IEnumerable<Project>> GetAll();
         Task Create(Project project);
         Task Update(Project project);
         Task Delete(int id);
    }
}