using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectsApi.Repositories;
using ProjectsApi.Models;

namespace ProjectsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectController(IProjectRepository projectRepository)
        {
            this._projectRepository = projectRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            var projects = await _projectRepository.GetAll();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var project = await _projectRepository.GetProject(id);
            if (project == null)
                return NotFound();

            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProject(CreateProjectDto createProjectDto)
        {
            Project project = new()
            {
                Name = createProjectDto.Name,
                isFinished = createProjectDto.isFinished,
                startDate = DateTime.Now
            };

            await _projectRepository.Create(project);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            await _projectRepository.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProject(int id, UpdateProjectDto updateProjectDto)
        {
            Project project = new()
            {
                Id = id,
                Name = updateProjectDto.Name,
                isFinished = updateProjectDto.isFinished,
            };

            await _projectRepository.Update(project);
            return Ok();
        }
    }

    public class UpdateProjectDto
    {
        public string Name { get; set; }
        public bool isFinished { get; set; }
    }
    public class CreateProjectDto
    {
        public string Name { get; set; }
        public bool isFinished { get; set; }
    }
}