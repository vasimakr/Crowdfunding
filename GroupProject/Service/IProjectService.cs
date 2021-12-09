using Crowdfunding.dto;
using Crowdfunding.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Service
{
    public interface IProjectService
    {
        public ApiResponse<Project> CreateProject(Project project);
        public Project ReadProject(int id);
        public List<Project> ReadProject(int pageCount, int pageSize); //Reads list of projects
        public Project UpdateProject(int projectId, Project project);
        public bool DeleteProject(int id);
        public List<Project> ReadProject(int pageCount, int pageSize, int creatorId); //Reads projects by specific creator
        public List<Project> BReadProject(int pageCount, int pageSize, int backerId); //Reads projects by specific creator
        public bool CreateProject(Project project, Creator creator);
        public Project UpdateStatus(int projectId, string update);
        public List<Project> ReadProjectCat(Category category);
        public List<Project> ReadTrendingProject();
        public List<Project> SearchProjects(string searchString);
    }
}
