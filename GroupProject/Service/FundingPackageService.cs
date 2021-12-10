using Crowdfunding.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
            dbContext.FundingPackages.Add(aFundingPackage);
            aFundingPackage.Project = project;
            dbContext.SaveChanges();
            return aFundingPackage;
        }

        public FundingPackage UpdateFundingPackage(int fundingPackageId, FundingPackage fundingPackage) //Editing funding packages (not implemented)
        {
            var dbFundingPackage = dbContext.FundingPackages.Find(fundingPackageId);

            if (dbFundingPackage == null)
            {
                return null;
            }


            dbFundingPackage.Project = fundingPackage.Project;
            dbFundingPackage.Tier = fundingPackage.Tier;
            dbFundingPackage.Name = fundingPackage.Name;
            dbFundingPackage.Price = fundingPackage.Price;
            dbFundingPackage.Description = fundingPackage.Description;


            dbContext.SaveChanges();
            return dbFundingPackage;
        }

        public BackerPackage BuyFundingPackage(int backerId, int fundingPackageId)
        {
            Backer dbBacker = dbContext.Backers.Find(backerId);
            var dbFundingPackage = dbContext.FundingPackages
                .Where(item => item.Id == fundingPackageId).Include(item => item.Project).First();


            var backerPackage = new BackerPackage
            {
                Backer = dbBacker,
                FundingPackage = dbFundingPackage
            };
            var project = dbContext.Projects.Find(dbFundingPackage.Project.Id);
            project.Fundings += dbFundingPackage.Price;
            if (project.Fundings > 0.4 * project.Goal) project.IsTrending = true;   //Sets project as trending if it reaches 40% of its goal.
            dbContext.BackerPackages.Add(backerPackage);
            dbContext.SaveChanges();
            return backerPackage;
        }

        public bool DeleteFundingPackage(int fundingPackageId)
        {
            var dbFundingPackage = dbContext.FundingPackages.Find(fundingPackageId);
            if (dbFundingPackage == null) return false;
            dbContext.Remove(dbFundingPackage);
            return dbContext.SaveChanges() == 1;
        }

        public FundingPackage GetFundingPackage(int fundingPackageId)
        {
            return dbContext.FundingPackages.Find(fundingPackageId);
        }

        public List<FundingPackage> GetFundingPackageList(int id)
        {
            return dbContext.FundingPackages.Where(fp => fp.Project.Id.Equals(id)).ToList();
        }
    }
}
