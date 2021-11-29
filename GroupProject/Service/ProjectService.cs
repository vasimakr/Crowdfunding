using Crowdfunding.dto;
using Crowdfunding.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Service
{
    class ProjectService : IProjectService
    {
        private readonly FundRaiserContext dbContext;
        public ProjectService(FundRaiserContext db)
        {
            dbContext = db;
        }
        public ApiResponse<Project> CreateProject(Project project)
        {
            //  if (project == null)
            //  {
            //      return new ApiResponse<Project>()
            //      {
            //          Data = null,
            //          Description = "No data saved: inserted project was NULL.",
            //          StatusCode = 51
            //      };
            //  }
            dbContext.Add(project);
            if (dbContext.SaveChanges() == 1)
            {
                return new ApiResponse<Project>() { Data = project, Description = "OK", StatusCode = 1 };
            }
            return new ApiResponse<Project>() { Data = null, Description = "No data saved.", StatusCode = 50 };
        }

        public bool DeleteProject(int id)
        {
            var dbProject = dbContext.Projects.Find(id);
            if (dbProject==null) return false;

            dbContext.Projects.Remove(dbProject);
            return dbContext.SaveChanges() == 1;
        }

        public Project ReadProject(int id)
        {
            return dbContext.Projects.Find(id);
        }

        public List<Project> ReadProject(int pageCount, int pageSize)
        {
            if (pageCount <= 0) pageCount = 1;
            if (pageSize <= 0 || pageSize > 20) pageSize = 20;
            return dbContext.Projects
                .Skip((pageCount - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public bool UpdateFunding(int projectId, int tierPrice)
        {
            var dbProject = dbContext.Projects.Find(projectId);
            dbProject.Fundings += tierPrice;
            return dbContext.SaveChanges() == 1;
        }

        public Project UpdateProject(int projectId, Project project)
        {
            var dbProject = dbContext.Projects.Find(projectId);
            dbProject.Title = project.Title;
            dbProject.Description = project.Description;
            dbProject.Goal = project.Goal;
            dbProject.Category= project.Category;
            // εδω ίσως θέλει περισσότερα
            dbContext.SaveChanges();
            return dbProject;
        }
    }
}
