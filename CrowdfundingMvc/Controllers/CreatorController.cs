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
        private readonly FundRaiserContext context;
        private readonly ICreatorService creatorService;
        private readonly IHostEnvironment hostEnvironment;

        [ActivatorUtilitiesConstructor]//Den eimai ka8olou sigouros an auto mas swzei apto na ftiaksoume ksexwristo controller entelws gia Users
                                       //mia periergh me8odos prokeimenou na valw ton 2o constructor xwris na crasharei
        public CreatorController(IProjectService projectService, FundRaiserContext context, ICreatorService creatorService, IHostEnvironment hostEnvironment)
        {
            this.projectService = projectService;
            this.context = context;
            this.hostEnvironment = hostEnvironment;
            this.creatorService = creatorService;
        }
        public IActionResult Index()
        {
            var id = Convert.ToInt32(TempData["activeUser"]);
            
            List<Project> projects = projectService.ReadProject(1, 20, id);
  
            return View(projects);

        }

        public IActionResult SignInC()
        {
            return View();
        }

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
                TempData["activeUser"] = creator.Id;
                TempData["activeUser2"] = creator.Id;
                return RedirectToAction(nameof(Index)); // mporei na 8elei diaforetiko index (DLD KAINOURGIO IActionResult Index2 px)  edw h ftiaxnoume kainourgio controller User
            }
            return View(creator);
        }
        

    }
}
