using Crowdfunding.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Service
{
    
        public class BackerService : IBackerService
        {
            private readonly FundRaiserContext dbContext;

            public BackerService (FundRaiserContext adbContext)
            {
                dbContext = adbContext;
            }

            public void CreateBacker(Backer backer)
            {

                dbContext.Backers.Add(backer);
                try { dbContext.SaveChanges(); }
                catch { }

            }
            public Backer ReadBacker(int id)
            {

                Backer backer = dbContext.Backers.Find(id);
                return backer;
            }

            public List<Backer> ReadBacker()
            {
                return dbContext.Backers.ToList();
            }
        }
    }

