using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectsApi.Models;

namespace ProjectsApi.Data
{
    public interface IDataContext
    {
        DbSet<Project> Projects { get; init; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}