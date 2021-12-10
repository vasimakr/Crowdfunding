using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Crowdfunding.Model;
using Crowdfunding.Service;
using CrowdfundingMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace CrowdfundingMvc.Controllers
{

    public class CreatorController : Controller
    {
        private readonly IProjectService projectService;
        private readonly ICreatorService creatorService;
        private readonly IHostEnvironment hostEnvironment;
        private readonly IFundingPackageService fundingPackageService;

        public CreatorController(IProjectService projectService, ICreatorService creatorService, IHostEnvironment hostEnvironment, IFundingPackageService fundingPackageService)
        {
            this.projectService = projectService;
            this.hostEnvironment = hostEnvironment;
            this.creatorService = creatorService;
            this.fundingPackageService = fundingPackageService;
        }
        public IActionResult Index()
        {
            List<Project> projects = projectService.ReadProject(1, 20, Startup.UserId);
            return View(projects);
        }
        public IActionResult SignInC()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignInC([Bind("Username")] Creator creator)
        {
            var userCreator = creatorService.ReadCreator(creator.Username);
            
            if (userCreator == null) return RedirectToAction(nameof(SignInC));
            Startup.UserId = userCreator.Id;
            return RedirectToAction(nameof(Index));
        }
        [ActivatorUtilitiesConstructor]
        public IActionResult CreatorCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatorCreate([Bind("Id,Username,FirstName,LastName,Email")] Creator creator)
        {
            if (ModelState.IsValid)
            {
                creatorService.CreateCreator(creator);
                Startup.UserId = creator.Id;
                return RedirectToAction(nameof(Index)); 
            }
            return View(creator);
        }


        [HttpGet]
        public IActionResult ProjectEdit(int id)
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
