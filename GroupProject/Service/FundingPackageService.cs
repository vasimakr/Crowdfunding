using Crowdfunding.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Service
{
	public class FundingPackageService : IFundingPackageService
    {
        private readonly FundRaiserContext dbContext;

        public FundingPackageService(FundRaiserContext adbContext)
        {
            dbContext = adbContext;
        }

        public FundingPackage CreateFundingPackage(int projectId, FundingPackage aFundingPackage)
        {
            var project = dbContext.Projects.Find(projectId);

            if (project == null)
            {
                return null;
            }

            var fundingPackage = new FundingPackage()
            {
                Project = project,
                Tier = AfundingPackage.Tier,
                Name = AfundingPackage.Name,
                Price = AfundingPackage.Price,
                Description = AfundingPackage.Description
=            };

            dbContext.FundingPackage.Add(fundingPackage);
            dbContext.SaveChanges();
            return fundingPackage;
        }

        public FundingPackage UpdateFundingPackage(int fundingPackageId, FundingPackage fundingPackage)
        {
            var dbFundingPackage = dbContext.FundingPackage.Find(fundingPackageId);

            if (dbFundingPackage == null)
            {
                return null;
            }

            var fundingPackage = new FundingPackage()
            {
                dbFundingPackage.Project = project,
                dbFundingPackage.Tier = fundingPackage.Tier,
                dbFundingPackage.Name = fundingPackage.Name,
                dbFundingPackage.Price = fundingPackage.Price,
                dbFundingPackage.Description = fundingPackage.Description
=            };

            dbContext.SaveChanges();
            return dbFundingPackage;
        }

        public BackerPackage BuyFundingPackage(int backerId, int fundingPackageId)
        {
            var dbBacker = dbContext.Backers.Find(backerId);
            var dbFundingPackage = dbContext.FundingPackage.Find(fundingPackageId);

            if (dbBacker == null || dbFundingPackage == null) return null;
            var backerPackage = new BackerPackage()
            {
                backer = dbBacker;
                fundingPackage = dbFundingPackage;
            }

            dbContext.BackerPackage.Add(backerPackage);
            dbContext.SaveChanges();
            return backerPackage;
        }

        public bool DeleteFundingPackage(int fundingPackageId)
        {
            var dbFundingPackage = dbContext.FundingPackage.Find(fundingPackageId);
            if (dbFundingPackage == null) return false;
            dbContext.Remove(dbFundingPackage);
            return dbContext.SaveChanges() == 1;
        }

        public FundingPackage GetFundingPackage(int fundingPackageId)
        {
            return dbContext.FundingPackage.Find(fundingPackageId);
        }

        public List<FundingPackage> GetFundingPackage()
        {
             return dbContext.FundingPackage.ToList();
        }
    }
}
