using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectsApi.Data;
using ProjectsApi.Models;
namespace ProjectsApi.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IDataContext _context;

        public ProjectRepository(IDataContext context)
        {
            this._context = context;
        }
        public async Task<Project> GetProject(int id)
        {
            return await _context.Projects.FindAsync(id);
        }
        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _context.Projects.ToListAsync();
        }
        public async Task Create(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Project project)
        {
            var itemToUpdate = await _context.Projects.FindAsync(project.Id);
            if (itemToUpdate == null) return;
            itemToUpdate.Name = project.Name;
            itemToUpdate.isFinished = project.isFinished;
            itemToUpdate.startDate = project.startDate;
            itemToUpdate.finishDate = project.finishDate;
            itemToUpdate.DevID = project.DevID;

            await _context.SaveChangesAsync();
        
        }
        public async Task Delete(int id)
        {
            var itemToRemove = await _context.Projects.FindAsync(id);
            if (itemToRemove == null) return;
             _context.Projects.Remove(itemToRemove);
             await _context.SaveChangesAsync();
        }

    }
}