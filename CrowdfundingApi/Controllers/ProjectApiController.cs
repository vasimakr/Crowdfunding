using Crowdfunding.Service;
using Crowdfunding.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectApiController : ControllerBase
    {
        private readonly IProjectService projectService;

        public ProjectApiController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpGet("/ping")]
        public string Ping()
        {
            return "Pinged";
        }

        [HttpGet]
        public IEnumerable<Project> Get(int PageCount, int PageSize)
        {
            return projectService.ReadProject(PageCount,PageSize);
        }

        [HttpGet("{id}")]
        public Project ReadProject(int id)
        {
            return projectService.ReadProject(id);
        }
        [HttpPost]
        public Project Post([FromBody] Project project)
        {
            projectService.CreateProject(project);
            return project;
        }
    }
}
