using Crowdfunding.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Crowdfunding.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CrowdfundingMvc.Controllers
{
    public class BackerController : Controller
    {
        private readonly IBackerService backerService;
        private readonly IProjectService projectService;
        private readonly FundRaiserContext context;
        private readonly IHostEnvironment hostEnvironment;

        [ActivatorUtilitiesConstructor]
        public BackerController( IBackerService backerService, IProjectService projectService, FundRaiserContext context, IHostEnvironment hostEnvironment)
        {
            this.backerService = backerService;
            this.projectService = projectService;
            this.context = context;
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var id = Convert.ToInt32(TempData["activeBacker"]);

            List<Project> projects = projectService.BReadProject(1, 20, id);
            return View(projects);
        }

        public IActionResult SignInB([Bind("Username")] Backer backer)
        {
            var userBacker = backerService.ReadBacker(backer.Username);
            TempData["activeBacker"] = backer.Id;
            if(backer.Id != 0) return RedirectToAction(nameof(Index));

            return View();
        }

        // Onomasthke BackerCreate logw ths xalia katastashs me to SignUp pou eixa thn faeinh idea na valw 2 formes mesa se ena view
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
                TempData["activeBacker"] = backer.Id;
                return RedirectToAction(nameof(Index)); // mporei na 8elei diaforetiko index (DLD KAINOURGIO IActionResult Index2 px)  edw h ftiaxnoume kainourgio controller User
            }
            return View(backer);
        }

    }
}
