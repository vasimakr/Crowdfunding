﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingMvc.Controllers
{
    public class BackerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
