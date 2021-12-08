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
    public class CreatorApiController : ControllerBase
    {
        private readonly ICreatorService creatorService;

        public CreatorApiController(ICreatorService creatorService)
        {
            this.creatorService = creatorService;
        }

        [HttpGet("/ping")]
        public string Ping()
        {
            return "it works";
        }


        // GET: api/<CreatorController>
        [HttpGet]
        public IEnumerable<Creator> Get()
        {
            return creatorService.ReadCreator();
        }

        // GET api/<CreatorController>/
        [HttpGet("{id}")]
        public Creator Get(int id)
        {
            return creatorService.ReadCreator(id);
        }

        // POST api/<CreatorController>
        [HttpPost]
        public Creator Post([FromBody] Creator creator)
        {
            creatorService.CreateCreator(creator);
            return creator;
        }
    }
}
