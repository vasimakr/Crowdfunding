using Crowdfunding.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Crowdfunding.Service
{
    public class CreatorService : ICreatorService
    {
        private readonly FundRaiserContext dbContext;

        public CreatorService(FundRaiserContext adbContext)
        {
            dbContext = adbContext;
        }

        public void CreateCreator(Creator creator)
        {

            dbContext.Creators.Add(creator);
            try { dbContext.SaveChanges(); }
            catch { }

        }
        public Creator ReadCreator(int id)
        {
            Creator creator = dbContext.Creators.Find(id);

            return creator;
        }
        public Creator ReadCreator(string username)
        {
            var test = dbContext.Creators.Where(aCreator => aCreator.Username.Equals(username));
            try
            {
                return test.First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Creator> ReadCreator()
        {
            return dbContext.Creators.ToList();
        }
    }
}

