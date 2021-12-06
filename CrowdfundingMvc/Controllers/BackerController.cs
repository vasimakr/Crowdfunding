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

namespace CrowdfundingMvc.Controllers
{
    public class BackerController : Controller
    {
        private readonly IBackerService _backerService;

        private readonly FundRaiserContext _context;

        public BackerController( IBackerService backerService)
        {
            _backerService = backerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignInB()
        {
            return View();
        }

        [ActivatorUtilitiesConstructor] //Den eimai ka8olou sigouros an auto mas swzei apto na ftiaksoume ksexwristo controller entelws gia Users
                                        //mia periergh me8odos prokeimenou na valw ton 2o constructor xwris na crasharei
        public BackerController(FundRaiserContext context)
        {
            _context = context;
        }
        // Onomasthke BackerCreate logw ths xalia katastashs me to SignUp pou eixa thn faeinh idea na valw 2 formes mesa se ena view
        public IActionResult BackerCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> BackerCreate([Bind("Id,FirstName,LastName,Email")] Backer backer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(backer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // mporei na 8elei diaforetiko index (DLD KAINOURGIO IActionResult Index2 px)  edw h ftiaxnoume kainourgio controller User
            }
            return View(backer);
        }

    }
}
