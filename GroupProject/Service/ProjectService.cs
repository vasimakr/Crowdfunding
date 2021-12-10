using Crowdfunding.dto;
using Crowdfunding.Model;
using Microsoft.EntityFrameworkCore;
using MoreLinq;
using System.Collections.Generic;
using System.Linq;

namespace Crowdfunding.Service
{
    public class ProjectService : IProjectService
    {
        private readonly FundRaiserContext dbContext;
        public ProjectService(FundRaiserContext db)
        {
            dbContext = db;
        }
        public ApiResponse<Project> CreateProject(Project project)
        {

            dbContext.Add(project);
            if (dbContext.SaveChanges() == 1)
            {
                return new ApiResponse<Project>() { Data = project, Description = "OK", StatusCode = 1 };
            }
            return new ApiResponse<Project>() { Data = null, Description = "No data saved.", StatusCode = 50 };
        }
        public bool CreateProject(Project project, Creator creator)
        {
            project.Creator = creator;
            dbContext.Add(project);
            return dbContext.SaveChanges() == 1;
        }

        public bool DeleteProject(int id)
        {
            var dbProject = dbContext.Projects.Find(id);
            if (dbProject == null) return false;

            dbContext.Projects.Remove(dbProject);
            return dbContext.SaveChanges() == 1;
        }

        public Project ReadProject(int id)
        {
            return dbContext.Projects.Find(id);
        }

        public List<Project> ReadProject(int pageCount, int pageSize) //Reads list of projects
        {

            return dbContext.Projects.ToList();
        }
        public List<Project> ReadProject(int pageCount, int pageSize, int creatorId) //Reads projects by specific creator
        {
            if (pageCount <= 0) pageCount = 1;
            if (pageSize <= 0 || pageSize > 20) pageSize = 20;
            return dbContext.Projects
                .Where(project => project.Creator.Id.Equals(creatorId))
                .ToList();
        }
        public List<Project> BReadProject(int pageCount, int pageSize, int backerId) //Reads projects by specific creator
        {
            if (pageCount <= 0) pageCount = 1;
            if (pageSize <= 0 || pageSize > 20) pageSize = 20;
            var existance = dbContext.BackerPackages
                                     .Where(backerpackage => backerpackage.Backer.Id == backerId)
                                     .ToList();
            if (existance.Count() == 0) return null;

            List<BackerPackage> backerpackages = dbContext.BackerPackages
                                          .Where(backerpackage => backerpackage.Backer.Id == backerId)
                                          .Include(item => item.FundingPackage)
                                          .ToList();


            List<Project> finalList = new List<Project>();
            var packageList = new List<FundingPackage>();

            backerpackages.ForEach(element => packageList.Add(dbContext.FundingPackages.Where(fp => fp.Id == element.FundingPackage.Id).Include(item => item.Project).First()));
            packageList.ForEach(pack => finalList.Add(dbContext.Projects.Find(pack.Project.Id)));

            return finalList.DistinctBy(x => x.Id).ToList();
        }
        public List<Project> ReadTrendingProject()
        {
            return dbContext.Projects
               .Where(project => project.IsTrending)
               .ToList();
        }
        public Project UpdateStatus(int projectId, string update)
        {
            var project = ReadProject(projectId);
            project.StatusUpdate = update;
            dbContext.SaveChanges();
            return project;
        }
        public List<Project> ReadProjectCat(Category category)
        {

            return dbContext.Projects
                .Where(project => project.Category.Equals(category))
                .ToList();
        }
        public List<Project> SearchProjects(string searchString)
        {
            return dbContext.Projects.Where(item => item.Title.Equals(searchString)).ToList();
        }
        public Project UpdateProject(int projectId, Project project) //Edits project (not implemented)
        {
            var dbProject = dbContext.Projects.Find(projectId);
            dbProject.Title = project.Title;
            dbProject.Description = project.Description;
            dbProject.Goal = project.Goal;
            dbProject.Category = project.Category;
            dbContext.SaveChanges();
            return dbProject;
        }
    }
}
