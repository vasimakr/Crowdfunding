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

namespace CrowdfundingMvc.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;
        private readonly IFundingPackageService fundingPackageService;
        private readonly IHostEnvironment hostEnvironment;

        public ProjectController(IProjectService projectService, IHostEnvironment hostEnvironment, IFundingPackageService fundingPackageService)
        {
            this.projectService = projectService;
            this.hostEnvironment = hostEnvironment;
            this.fundingPackageService = fundingPackageService;
        }



        public IActionResult Index()
        {
            List<Project> projects = projectService.ReadProject(1, 10);
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
        [HttpPost]
        public IActionResult Create(ProjectImage projectImage)
        {
            Project project = projectImage.Project;
            var img = projectImage.ProjectImageFile;
            if (img!= null)
            {
                var uniqueFileName = GetUniqueFileName(img.FileName);
                var Uploads = Path.Combine(hostEnvironment.ContentRootPath + "\\wwwroot", "images");
                var filePath = Path.Combine(Uploads, uniqueFileName);
                img.CopyTo(new FileStream(filePath, FileMode.Create));

                project.Description = uniqueFileName;


            }

            projectService.CreateProject(project);

            return RedirectToAction(nameof(CreateFundingPackage));




        }
        [HttpPost]
        public IActionResult CreateFundingPackage(ProjectImage projectImage)
        {
            FundingPackage fP = projectImage.FundingPackage;
            Project project = projectImage.Project;

            fundingPackageService.CreateFundingPackage(project.Id,fP);
            return RedirectToAction(nameof(Index));
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                + "_"
                + Guid.NewGuid().ToString().Substring(0, 4)
                + Path.GetExtension(fileName);


        }



    }
}

