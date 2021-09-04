using Microsoft.EntityFrameworkCore;
using ProjectsApi.Models;

namespace ProjectsApi.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; init; }
    }
}