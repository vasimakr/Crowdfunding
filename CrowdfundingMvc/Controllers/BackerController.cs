using Crowdfunding.Model;
using Crowdfunding.Service;
using CrowdfundingMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace CrowdfundingMvc.Controllers
{
    public class BackerController : Controller
    {
        private readonly IBackerService backerService;
        private readonly IProjectService projectService;
        private readonly IHostEnvironment hostEnvironment;
        private readonly IFundingPackageService fundingPackageService;

        [ActivatorUtilitiesConstructor]
        public BackerController(IBackerService backerService, IProjectService projectService, IHostEnvironment hostEnvironment, IFundingPackageService fundingPackageService)
        {
            this.backerService = backerService;
            this.projectService = projectService;
            this.hostEnvironment = hostEnvironment;
            this.fundingPackageService = fundingPackageService;
        }

        public IActionResult Index()
        {
            List<Project> projects = projectService.BReadProject(1, 20, Startup.UserId);
            return View(projects);
        }
        public IActionResult SignInB()
        {
            return View();
        }

        public IActionResult ProjectEdit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignInB([Bind("Username")] Backer backer)
        {
            var userBacker = backerService.ReadBacker(backer.Username);
            if (userBacker == null) return RedirectToAction(nameof(SignInB));
            Startup.UserId = userBacker.Id;
            return RedirectToAction(nameof(Index));
        }

        [ActivatorUtilitiesConstructor]
        public IActionResult BackerCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult BackerCreate([Bind("Id,Username,FirstName,LastName,Email")] Backer backer)
        {
            if (ModelState.IsValid)
            {
                backerService.CreateBacker(backer);
                Startup.UserId = backer.Id;
                return RedirectToAction(nameof(Index));
            }
            return View(backer);
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
        [HttpGet]
        public IActionResult BuyPackage(int id)
        {
            fundingPackageService.BuyFundingPackage(Startup.UserId, id);
            return RedirectToAction(nameof(Index));
        }
    }
}
