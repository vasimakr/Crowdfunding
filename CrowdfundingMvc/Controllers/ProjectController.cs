using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Crowdfunding.Model;
using Crowdfunding.Service;
using CrowdfundingMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace CrowdfundingMvc.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;
        private readonly IFundingPackageService fundingPackageService;
        private readonly IHostEnvironment hostEnvironment;
        private readonly FundRaiserContext context;

        public ProjectController(IProjectService projectService, IHostEnvironment hostEnvironment, IFundingPackageService fundingPackageService, FundRaiserContext context)
        {
            this.projectService = projectService;
            this.hostEnvironment = hostEnvironment;
            this.fundingPackageService = fundingPackageService;
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Project> projects = projectService.ReadProject(1, 20);
            return View(projects);
        }

        public IActionResult Get(int Id)
        {
            Project project = projectService.ReadProject(Id);
            if (project == null) return NotFound();
            return View(project);
        }

        public IActionResult Create()
        {
            return View();

        }
        public IActionResult CreateFundingPackage()
        {
            return View();
        }

        public IActionResult TrendingProjects()
        {
            List<Project> projects = projectService.ReadTrendingProject();
            return View(projects);
        }

        public IActionResult Applications()
        {
            List<Project> projects = projectService.ReadProjectCat(Category.APPLICATIONS);
            return View(projects);
        }

        public IActionResult Boardgames()
        {
            List<Project> projects = projectService.ReadProjectCat(Category.BOARDGAMES);
            return View(projects);
        }

        public IActionResult Games()
        {
            List<Project> projects = projectService.ReadProjectCat(Category.GAMES);
            return View(projects);
        }

        public IActionResult Movies()
        {
            List<Project> projects = projectService.ReadProjectCat(Category.MOVIES);
            return View(projects);
        }

        public IActionResult Nutrition()
        {
            List<Project> projects = projectService.ReadProjectCat(Category.NUTRITION);
            return View(projects);
        }

        public IActionResult Other()
        {
            List<Project> projects = projectService.ReadProjectCat(Category.OTHER);
            return View(projects);
        }

        public IActionResult TechnologyandElectronics()
        {
            List<Project> projects = projectService.ReadProjectCat(Category.TECHNOLOGY);
            return View(projects);
        }

        [HttpPost]
        public IActionResult Create(ProjectImage projectImage)
        {
            Project project = projectImage.Project;
            var creator = context.Creators.Find(Startup.UserId);

            var img = projectImage.ProjectImageFile;
            if (img != null)
            {
                var uniqueFileName = GetUniqueFileName(img.FileName);
                var Uploads = Path.Combine(hostEnvironment.ContentRootPath + "\\wwwroot", "images");
                var filePath = Path.Combine(Uploads, uniqueFileName);
                img.CopyTo(new FileStream(filePath, FileMode.Create));

                project.Description = uniqueFileName;
            }

            projectService.CreateProject(project, creator);

            Startup.ProjectId = project.Id;
            return RedirectToAction(nameof(CreateFundingPackage));
        }
        [HttpPost]
        public IActionResult CreateFundingPackage(ProjectImage projectImage)
        {
            FundingPackage fP = projectImage.FundingPackage;
            fundingPackageService.CreateFundingPackage(Startup.ProjectId, fP);
            return RedirectToAction("ProjectEdit", "Creator");
        }
        
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                + "_"
                + Guid.NewGuid().ToString().Substring(0, 4)
                + Path.GetExtension(fileName);
        }
        [HttpPost]
        public IActionResult Search(string search)
        {
            var list= projectService.SearchProjects(search);
            return View(list);
        }
        [HttpPost]
        public IActionResult StatusUpdate([Bind("Id, StatusUpdate")] Project project)
        {
            projectService.UpdateStatus(project.Id, project.StatusUpdate);
            return RedirectToAction("ProjectEdit", "Creator", project);
        }
        [HttpGet]
        public IActionResult ProjectView(int id)
        {
            var project = projectService.ReadProject(id);
            var fundingpackage = fundingPackageService.GetFundingPackageList(id);
            var projectFunding = new ProjectFunding();
            projectFunding.Project = project;
            projectFunding.FundingPackages = fundingpackage;
            return View(projectFunding);
        }

    }
}

