using Crowdfunding.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingMvc.Controllers
{
    public class BackerController : Controller
    {
        private readonly IBackerService _backerService;

        public BackerController( IBackerService backerService)
        {
            _backerService = backerService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
