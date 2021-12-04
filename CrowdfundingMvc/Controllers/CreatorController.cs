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

namespace CrowdfundingMvc.Controllers
{

    public class CreatorController : Controller
    {
        private readonly FundRaiserContext _context;
        private readonly ICreatorService _creatorService;
        public IActionResult Index()
        {
            return View();
        }
        public CreatorController(ICreatorService creatorService)
        {
            _creatorService = creatorService;
        }

        [ActivatorUtilitiesConstructor] //Den eimai ka8olou sigouros an auto mas swzei apto na ftiaksoume ksexwristo controller entelws gia Users
                                        //mia periergh me8odos prokeimenou na valw ton 2o constructor xwris na crasharei
        public CreatorController(FundRaiserContext context) 
        {
            _context = context;
        }
        
        public IActionResult CreatorCreate()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CreatorCreate([Bind("Id,FirstName,LastName,Email")] Creator creator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(creator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // mporei na 8elei diaforetiko index (DLD KAINOURGIO IActionResult Index2 px)  edw h ftiaxnoume kainourgio controller User
            }
            return View(creator);
        }
        

    }
}
