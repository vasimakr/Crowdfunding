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

        public CreatorController(IProjectService projectService, ICreatorService creatorService, IHostEnvironment hostEnvironment)
        {
            this.projectService = projectService;
            this.hostEnvironment = hostEnvironment;
            this.creatorService = creatorService;
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
                return RedirectToAction(nameof(Index)); // mporei na 8elei diaforetiko index (DLD KAINOURGIO IActionResult Index2 px)  edw h ftiaxnoume kainourgio controller User
            }
            return View(creator);
        }

        public IActionResult ProjectEdit()
        {
            return View();
        }


    }
}
