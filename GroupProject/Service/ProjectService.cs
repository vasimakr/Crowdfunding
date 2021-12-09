using Crowdfunding.dto;
using Crowdfunding.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public bool CreateProject(Project project, Creator creator)
        {
            project.Creator = creator;
            dbContext.Add(project);
            return dbContext.SaveChanges() == 1;
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

        public List<Project> ReadProject(int pageCount, int pageSize) //Reads list of projects
        {
       //     if (pageCount <= 0) pageCount = 1;
       //     if (pageSize <= 0 || pageSize > 20) pageSize = 20;
            return dbContext.Projects.ToList();
        }
        public List<Project> ReadProject(int pageCount, int pageSize, int creatorId) //Reads projects by specific creator
        {
            if (pageCount <= 0) pageCount = 1;
            if (pageSize <= 0 || pageSize > 20) pageSize = 20;
            return dbContext.Projects
                .Where(project => project.Creator.Id.Equals(creatorId))
               // .Skip((pageCount - 1) * pageSize)
              //  .Take(pageSize)
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

            var backerpackages = dbContext.BackerPackages
                                          .Where(backerpackage => backerpackage.Backer.Id==backerId)
                                          //.GroupBy(q => q.FundingPackage.Id)
                                          //.Select(g => g.First())
                                   //       .Skip((pageCount - 1) * pageSize)
                                  //        .Take(pageSize)
                                          .ToList();

            List<Project> finalList = new List<Project>();
          //  var packageList = new List<FundingPackage>();
            
            backerpackages.ForEach(pack => finalList.Add(dbContext.Projects.Find(pack.Id)));

          //  packageList.ForEach(pack => finalList.Add(dbContext.Projects.Find(pack.Id)));
           
            //return dbContext.Projects
            //    .Where(backerpackage => backerpackage.Backer.Id.Equals(backerId))
            //    .Inculde(item)
            //    .Skip((pageCount - 1) * pageSize)
            //    .Take(pageSize)
            //    .ToList();
            return finalList;
        }

        public Project UpdateProject(int projectId, Project project) // εδω γιατι προτζεκτ;
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
