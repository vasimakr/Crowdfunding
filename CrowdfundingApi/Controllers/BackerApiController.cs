using Crowdfunding.Model;
using Crowdfunding.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackerApiController : ControllerBase
    {
        private readonly IBackerService backerService;

        public BackerApiController(IBackerService backerService)
        {
            this.backerService = backerService;
        }

        [HttpGet("/ping")]
        public string Ping()
        {
            return "it works";
        }


        // GET: api/<BackerController>
        [HttpGet]
        public IEnumerable<Backer> Get()
        {
            return backerService.ReadBacker();
        }

        // GET api/<BackerController>/5
        [HttpGet("{id}")]
        public Backer Get(int id)
        {
            return backerService.ReadBacker(id);
        }

        // POST api/<BackerController>
        [HttpPost]
        public Backer Post([FromBody] Backer backer)
        {
            backerService.CreateBacker(backer);
            return backer;
        }


    }
}

