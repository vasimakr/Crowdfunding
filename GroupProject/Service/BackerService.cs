using Crowdfunding.dto;
using Crowdfunding.Model;
using Microsoft.EntityFrameworkCore;
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

            public ApiResponse<Backer> CreateBacker(Backer backer)
            {
                if (backer == null)
                {
                    return new ApiResponse<Backer>()
                    {
                        Data = null,
                        Description = "Backer inserted was null. Nothing saved",
                        StatusCode  = 301
                    };
            }

                if (backer.Email == null)
                {
                    return new ApiResponse<Backer>()
                    {
                        Data = null,
                        Description = "Backer inserted had null Email. Nothing saved",
                        StatusCode  = 302
                    };
                }

                dbContext.Backers.Add(backer);
                if (dbContext.SaveChanges() == 1)
                {
                    return new ApiResponse<Backer>() { Data = backer, Description = "ok", StatusCode = 0 };
                }

                return new ApiResponse<Backer>() { Data = null, Description = "Nothing saved", StatusCode = 399 };

            }
            public Backer ReadBacker(int id)
            {
                return dbContext.Backers.Find(id);
            }

            public List<Backer> ReadBacker()
            {
                return dbContext.Backers.ToList();
            }

            public Backer UpdateBacker( int backerId, Backer backer)
            {
                var dbBacker = dbContext.Backers.Find(backerId);
                if (dbBacker == null) throw new KeyNotFoundException();
                dbBacker.Email = backer.Email;
                dbBacker.FirstName = backer.FirstName;
                dbBacker.LastName = backer.LastName;
                dbContext.SaveChanges();
                return dbBacker;
            }

            public bool DeleteBacker( int backerId)
            {
                var dbBacker = dbContext.Backers.Find(backerId);
                if (dbBacker == null) return false;
                dbContext.Remove(dbBacker);
                return dbContext.SaveChanges() == 1;
            }

            public List<BackerPackage> GetBackerFundingPackages(int backerId)
            {
                return dbContext
                       .BackerPackages
                       .Where(item => item.Backer.Id == backerId)
                       .Include(item => item.FundingPackage)
                       .ToList();
            }
        }
    }

